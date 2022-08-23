using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Persistence
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));
            modelBuilder.Entity<Client>()
                .HasIndex(client => client.IdentificationNumber).IsUnique();
            modelBuilder.Entity<Brand>()
                .HasIndex(brand => brand.Name).IsUnique();
            modelBuilder.Entity<CreditRequest>();
            modelBuilder.Entity<Assigment>();
            modelBuilder.Entity<DriveWay>()
                .HasIndex(driveWay => driveWay.Name).IsUnique();
            modelBuilder.Entity<Executive>()
                .HasIndex(executive => executive.IdentificationNumber).IsUnique();



            base.OnModelCreating(modelBuilder);
        }
    }
}
