
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Model;

namespace SignalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddSignalR();
            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
               }));
            builder.Services.AddDbContext<Context>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
         );
           
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting(); 
            app.UseCors("CorsPolicy");
            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<VisitorHub>("/VisitorHub");

            app.Run();
        }
    }
}
