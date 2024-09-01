using Microsoft.EntityFrameworkCore;
using VSGComputers.Data;
using VSGComputers.DataAccess.Repository;
using VSGComputers.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using VSGComputers.Utility;

namespace VSGComputers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ComputersDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            ); 
            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ComputersDbContext>().AddDefaultTokenProviders();
            builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
            builder.Services.AddScoped<IEmailSender,EmailSender>();
            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}"// add views reminder 
            );
            app.Run();
        }
    }
}
