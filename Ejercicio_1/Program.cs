using Ejercicio_1.BAL.Interfaces;
using Ejercicio_1.BAL.Repositories;
using Ejercicio_1.BAL.Services;
using Ejercicio_1.DAL;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Guia3Periodo3Context>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IContactoRepository, ContactoRepository>();
            builder.Services.AddScoped<IContactoService, ContactoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Shared/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contacto}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
