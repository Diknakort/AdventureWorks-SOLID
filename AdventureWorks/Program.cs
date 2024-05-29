using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AdventureWorks.Services;

namespace AdventureWorks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AdventureWorks2016Context>
                (options => options.UseSqlServer("'server=(localdb)\\MSSQLLocalDB;database=AdventureWorks2016;Integrated Security=True ' Microsoft.EntityFrameworkCore.SqlServer - o Models"));
            builder.Services.AddScoped<ISpecificacionFactory, FactoriaDeEspecificaciones>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
