using System.Data;
using FooBar.Domain.Ports;
using FooBar.Infrastructure.Adapters;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FooBar.Infrastructure.Extensions {

    public static class PersistenceExtensions {
        public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config) {
            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            svc.AddTransient<IDbConnection>((sp) => new SqlConnection(config.GetConnectionString("database")));
            return svc;
        }
    }
}