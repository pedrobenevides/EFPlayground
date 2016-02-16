using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data.Configuration;

namespace EFStudy.Infra.Data
{
    public class MyContext : DbContext
    {
        public MyContext(string connName = "PlaygroundEF") : base(connName)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ClientEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new JobEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}