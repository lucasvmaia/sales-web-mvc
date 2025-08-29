using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Services;

namespace SalesWebMVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SalesWebMVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SalesWebMVCContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                using var scope = app.Services.CreateScope();
                var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
                await seedingService.SeedAsync();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
