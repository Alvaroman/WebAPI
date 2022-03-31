using System.Reflection;
using FooBar.Api.Filters;
using Elastic.Apm.NetCoreAll;
using Elastic.Apm.SerilogEnricher;
using FooBar.Infrastructure.Context;
using FooBar.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var originsAllowedName = "ParkingPoliciy";

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(AppExceptionFilterAttribute));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.Load("FooBar.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("FooBar.Application"));

builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("database"), sqlopts =>
    {
        sqlopts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName"));
    });
});

builder.Services.AddHealthChecks().AddSqlServer(config["ConnectionStrings:database"]);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

builder.Services.AddPersistence(config).AddDomainServices().AddRabbitSupport(config);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ADN- Álvaro Morales", Version = "v1" });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: originsAllowedName,
                      builder =>
                      {
                          builder.WithOrigins(config.GetSection("AllowedOrigins").Get<string[]>()).AllowAnyHeader().AllowAnyMethod();
                      });
});

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();
app.UseCors(originsAllowedName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Block Api"));
}

app.UseRouting().UseHttpMetrics().UseEndpoints(endpoints =>
{
    endpoints.MapGet("/ceiba/adn", () => new { version = 1.0, by = "Álvaro Morales" });
    endpoints.MapMetrics();
    endpoints.MapHealthChecks("/health");
});
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
