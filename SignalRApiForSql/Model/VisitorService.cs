using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Hubs;

namespace SignalRApiForSql.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;
        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
            SELECT tarih, [1], [2], [3], [4], [5]
            FROM (
                SELECT [City], CityVisitCount, CAST([VisitDate] AS date) AS tarih
                FROM Visitors
            ) AS visitTable
            PIVOT (
                SUM(CityVisitCount)
                FOR City IN ([1], [2], [3], [4], [5])
            ) AS pivottable
            ORDER BY tarih ASC";

                command.CommandType = System.Data.CommandType.Text;

                try
                {
                    _context.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VisitorChart visitorChart = new VisitorChart
                            {
                                VisitDate = reader.GetDateTime(0).ToShortDateString(), 
                                Counts = new List<int>() 
                            };

                            
                            for (int i = 1; i <= 5; i++)
                            {
                                
                                visitorChart.Counts.Add(reader.IsDBNull(i) ? 0 : reader.GetInt32(i));
                            }

                            visitorCharts.Add(visitorChart);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    _context.Database.CloseConnection(); 
                }
            }

            return visitorCharts;
        }
    }
}
