using Imani.Solutions.Core.API.Util;
using steeltoe.data.showcase.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace steeltoe.data.showcase.Repository
{
    public class SampleContext : DbContext
    {
        private ISettings settings = new ConfigSettings();
        private const string defaultSchemaName = "Sample";

        public SampleContext(DbContextOptions options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.
        // }


        protected override void OnModelCreating(ModelBuilder builder){

            builder.HasDefaultSchema(settings.GetProperty("SCHEMA_NAME",defaultSchemaName));    //To all the tables.

            builder.Entity<TestData>()
            .HasKey(b => b.Id).HasName("data_id");

            builder.Entity<TestData>().Property(b => b.Id)
            .UseIdentityColumn();


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TestData> TestData { get; set; }
    }

}
