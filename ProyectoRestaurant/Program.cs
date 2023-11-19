using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProyectoRestaurant.Context;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProyectoRestaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RestaurantDatabaseContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:RestaurantDBConnection"]));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {

              });
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change  this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "usuario",
                    pattern: "Usuario/{action=Index}/{id?}",
                    defaults: new { controller = "Usuario", action = "Index" });
            });



            /*  app.MapControllerRoute(
              name: "usuarios",
              pattern: "{controller=Usuario}/{action=Index}/{id?}");*/

            app.Run();
        }
    }
}
