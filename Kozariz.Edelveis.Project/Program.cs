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
                var config = builder.Configuration.GetSection("AppConfig").Get<AppConfig>();
                options.UseSqlServer("Server=tcp:edelveis-server.database.windows.net,1433;Initial Catalog=edelveis-db;Persist Security Info=False;User ID=odvova;Password=9v9uja1Ziv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

            // Apply database migrations
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                dbContext.Database.Migrate();
            }

            app.Run();
        }
    }
}
