using Kozariz.Edelveis.Core;
using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Kozariz.Edelveis.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddApplicationInsightsTelemetry();
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                var config = builder.Configuration["AppConfig:ConnectionString"];
                options.UseSqlServer(config);
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                dbContext.Database.Migrate();
            }

            app.Run();
        }
    }
}
