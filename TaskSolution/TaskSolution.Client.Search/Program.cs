using Asp.Versioning;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

using ProviderOneReader;

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
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
//builder.Services.AddScoped<ITravelRouteRepository, TravelRouteRepository>();
MemoryCacheOptions mo = new MemoryCacheOptions() { SizeLimit = 10 };
MemoryCache memCache = new MemoryCache(mo);
//builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseMemoryCache(memCache));
builder.Services.AddHttpClient<ProviderOneClient>();
builder.Services.AddGraphQLServer()
    .AddQueryType<QueryRest>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
    //.UseDocumentCache()
    //.AddDiagnosticEventListener<MyCacheEventListener>();
builder.WebHost.UseUrls("http://localhost:7777");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL("/graphql");
app.Run();

/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{

}