using System;
using System.Collections.Generic;
using FooBar.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore;
using FooBar.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using FooBar.Domain.Ports;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FooBar.Api.Tests;

class IntegrationTestBuilder : WebApplicationFactory<Program>
{

    readonly Guid _id;

    public Guid Id => this._id;

    public IntegrationTestBuilder()
    {
        _id = Guid.NewGuid();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var rootDb = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PersistenceContext>));
            services.AddDbContext<PersistenceContext>(options =>
                    options.UseInMemoryDatabase("Testing", rootDb));

        });

        SeedDatabase(builder.Build().Services);

        return base.CreateHost(builder);


    }

    void SeedDatabase(IServiceProvider services)
    {
        var People = new List<ParkingLot>
            {
                new ParkingLot
                {
                    VehicleType=1,StartedAt=DateTime.Now,Cylinder=1800, Plate="abc-000",Status=false
                }
            };

        using (var scope = services.CreateScope())
        {
            var personRepo = scope.ServiceProvider.GetRequiredService<IGenericRepository<ParkingLot>>();
            foreach (var person in People)
            {
                personRepo.AddAsync(person).Wait();
            }
        }
    }
}