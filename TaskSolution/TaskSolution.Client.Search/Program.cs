using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

using TaskSolution.API.Providers.AggregateSearch;
using TaskSolution.API.Providers.AggregateSearch.HealthChecks;
using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;
using TaskSolution.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddOutputCache(options => options.SizeLimit = 500);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    opt.ApiVersionReader = new QueryStringApiVersionReader("v");
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
MemoryCacheOptions mo = new MemoryCacheOptions() { SizeLimit = 10 };
MemoryCache memCache = new MemoryCache(mo);
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
    });
builder.Services.AddHealthChecks()
    .AddCheck<ProviderOneHealthCheck>(nameof(ProviderOneHealthCheck));
//builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseMemoryCache(memCache));
builder.Services.AddHttpClient();
builder.WebHost.UseUrls("http://localhost:7777");
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.Run();
/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{

}