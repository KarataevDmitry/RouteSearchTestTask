using Asp.Versioning;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;

using TaskSolution.API.Providers.AggregateSearch;
using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;
using TaskSolution.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opt => {
    opt.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    opt.ApiVersionReader = new QueryStringApiVersionReader("v");
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ITravelRouteRepository, TravelRouteRepository>();
builder.Services.AddScoped<ITravelPointRepository, TravelPointRepository>();
var cacheOptions = new MemoryCacheOptions()
{
    ExpirationScanFrequency = TimeSpan.FromSeconds(60),
    SizeLimit = 200
};
var memCache = new MemoryCache(cacheOptions);
builder.Services.AddDbContext<InMemoryDbContext>(
    options =>
    options.UseMemoryCache(memCache));
builder.Services.AddGraphQLServer()
    .AddQueryType<QueryCached>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .UseDocumentCache()
    .UseOperationCache();
builder.WebHost.UseUrls("http://localhost:7777");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL("/graphql");
app.Run();

/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{

}