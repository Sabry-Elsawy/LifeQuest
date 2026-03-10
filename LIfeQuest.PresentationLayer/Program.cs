using LifeQuest.DAL.Data;
using LifeQuest.DAL.Data.Seed;
using LifeQuest.DAL.Models;
using LifeQuest.DAL.UOW.Implementation;
using LifeQuest.DAL.UOW.Interface;
using LifeQuest.BLL.Services.Implementation;
using LifeQuest.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Builder;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using LIfeQuest.BLL.Services.Implementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using LifeQuest;

namespace LIfeQuest.PresentationLayer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Db Connection String Di
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // UOW Di 
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IApplicationUserRegisterService, ApplicationUseRegisterService>();

            // ApplicationDb Context Di
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;

                //confirm email
                options.SignIn.RequireConfirmedEmail = true; // cant login before confirm
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var Scope = app.Services.CreateScope())
            {
                var ServiceProvider = Scope.ServiceProvider;

                var roleManager = ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                await RoleSeeder.SeedRolesAsync(roleManager);
            }

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
