using Microsoft.EntityFrameworkCore;
using Kozariz.Edelveis.Models.Configuration;
using Kozariz.Edelveis.Models.UsersTable;

namespace Kozariz.Edelveis.EF.Database
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> UsersTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:edelveis-server.database.windows.net,1433;Initial Catalog=edelveis-db;Persist Security Info=False;User ID=odvova;Password=9v9uja1Ziv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", options => options.MigrationsAssembly("Kozariz.Edelveis.Core"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

        

       

       
  

   

