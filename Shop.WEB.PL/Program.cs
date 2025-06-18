using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.Interface;
using Shop.BLL.Repositries;
using Shop.DAL.Context;
using Shop.DAL.Entities;

namespace Shop.WEB.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // To make Connection (Depandancy Injection) -------------------------------------------------------------------

            builder.Services.AddDbContext<AppilcationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //--------------------------------------------------------------------------------------------------------------
            // Registering the Generic Repository for Dependency Injection
            builder.Services.AddScoped<IProductRepo, ProductRepository>();
            builder.Services.AddScoped<IGenericRepository<Category>, GenericRepositry<Category>>();

            builder.Services.AddScoped<IGenericRepository<Product>, GenericRepositry<Product>>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppilcationDbContext>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers(); 
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
