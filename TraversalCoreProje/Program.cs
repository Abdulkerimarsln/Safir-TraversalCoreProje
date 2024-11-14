using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog.Events;
using Serilog;
using TraversalCoreProje.Models;
using BusinessLayer.Container;
using FluentValidation.AspNetCore;
using TraversalCoreProje.Mapping.AutoMapperProfile;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Microsoft ile ilgili loglarý sýnýrlamak
             .Enrich.FromLogContext()
             .WriteTo.File("Logs/Log1.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

            builder.Services.AddHttpClient();

            builder.Host.UseSerilog();

            // Logging konfigürasyonu
            builder.Services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomerIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();          
            builder.Services.ContainerDependencies();

            builder.Services.AddTransient<GetAllDestinationQueryHandler>();
            builder.Services.AddTransient<GetDestinationByIDQueryHandler>();
            builder.Services.AddTransient<CreateDestinationCommandHandler>();
            builder.Services.AddTransient<RemoveDestinationCommandHandler>();
            builder.Services.AddTransient<UpdateDestinationCommandHandler>();

            builder.Services.AddMediatR(typeof(Program));


            builder.Services.AddAutoMapper(typeof(MapProfile));

            builder.Services.ContainerDependencies();
           

            builder.Services.AddControllersWithViews().AddFluentValidation();



            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });
            builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            builder.Services.ConfigureApplicationCookie(opt => opt.LoginPath = "/Login/SignIn");
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
            var localizationOptions = new RequestLocalizationOptions()
                    .SetDefaultCulture(suppertedCultures[4])  
                    .AddSupportedCultures(suppertedCultures)
                    .AddSupportedUICultures(suppertedCultures);
            app.UseRequestLocalization(localizationOptions);

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

           
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
           
          


            app.Run();
        }
    }
}