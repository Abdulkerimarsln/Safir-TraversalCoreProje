using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfDestinationalDal : GenericRepository<Destination>, IDestinationalDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x=>x.DestinationID==id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var context= new Context())
            {
                var values= context.Destinations.Take(4).OrderByDescending(x=>x.DestinationID).ToList(); 
                return values;
            }
        }
    }
}
