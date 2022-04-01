using Ceiba.ParkingLotADN.Domain.Entities;
using Ceiba.ParkingLotADN.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ceiba.ParkingLotADN.Infrastructure.Context
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
            modelBuilder.Entity<ParkingLot>();


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(DomainEntity).IsAssignableFrom(t))
                {
                    modelBuilder.Entity(entityType.Name).Property<Guid>("Id").HasDefaultValueSql("NEWID()");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
