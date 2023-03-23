using Kozariz.Edelveis.Core.Services;
using Kozariz.Edelveis.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kozariz.Edelveis.Core
{
    public static class DIConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Server=tcp:edelveis-server.database.windows.net,1433;Initial Catalog=edelveis-db;Persist Security Info=False;User ID=odvova;Password=9v9uja1Ziv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"),
                    b => b.MigrationsAssembly(typeof(DbContext).Assembly.FullName));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
