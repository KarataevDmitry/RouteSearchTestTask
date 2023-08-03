using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
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
        options.UseMemoryCache(memCache);
    });

//builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseMemoryCache(memCache));
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
app.MapGet("/search", async (ApplicationDbContext context,
                       [FromQuery] QueryParameters queryParameters) =>
{
    if (queryParameters.FromCache)
    {
        memCache.
        if (await context.TravelRoutes.AnyAsync())
        {
            
            IQueryable<TaskSolution.DAL.Models.TravelRoute> res = ApplyFiltersToCachedData(context, queryParameters);
            return await res.ToListAsync();
        }
        
    }

    static void ApplyStartPointContainsFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (!string.IsNullOrEmpty(queryParameters.StartPointContains))
        {
            res.Where(x => x.StartPoint.Contains(queryParameters.StartPointContains));
        }
    }

    static void ApplyEndPointContainsFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (!string.IsNullOrEmpty(queryParameters.EndPointContains))
        {
            res.Where(x => x.EndPoint.Contains(queryParameters.EndPointContains));
        }
    }

    static void ApplyStartPointStartsWithFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (!string.IsNullOrEmpty(queryParameters.StartPointStartsWith))
        {
            res.Where(x => x.StartPoint.StartsWith(queryParameters.StartPointStartsWith));
        }
    }

    static void ApplyEndPointEndsWithFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (!string.IsNullOrEmpty(queryParameters.EndPointStartsWith))
        {
            res.Where(x => x.EndPoint.StartsWith(queryParameters.EndPointStartsWith));
        }
    }

    static void ApplyStartPointEndsWithFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (!string.IsNullOrEmpty(queryParameters.StartPointEndsWith))
        {
            res.Where(x => x.StartPoint.EndsWith(queryParameters.StartPointEndsWith));
        }
    }

    static void ApplyIntervalConditionsFilter(QueryParameters queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        res.Where(x =>
        x.Cost >= queryParameters.MinCost
        && x.Cost <= queryParameters.MaxCost
        && x.StartDateTimeUTC >= queryParameters.MinStartDateTimeUTC
        && x.StartDateTimeUTC <= queryParameters.MaxStartDateTimeUTC
        && x.ArrivalDateTimeUTC >= queryParameters.MinArrivalDateTimeUTC
        && x.ArrivalDateTimeUTC <= queryParameters.MaxStartDateTimeUTC);
    }

    static IQueryable<TaskSolution.DAL.Models.TravelRoute> ApplyFiltersToCachedData(ApplicationDbContext context, QueryParameters queryParameters)
    {
        var res = context.TravelRoutes.AsQueryable();
        ApplyIntervalConditionsFilter(queryParameters, res);
        ApplyStartPointContainsFilter(queryParameters, res);
        ApplyEndPointContainsFilter(queryParameters, res);
        ApplyStartPointStartsWithFilter(queryParameters, res);
        ApplyStartPointEndsWithFilter(queryParameters, res);
        ApplyEndPointEndsWithFilter(queryParameters, res);
        return res;
    }
});

app.Run();

class QueryParameters
{
    public bool FromCache { get; set; }
    public DateTime? MinStartDateTimeUTC { get; set; } = DateTime.MinValue.ToUniversalTime();
    public DateTime? MaxStartDateTimeUTC { get; set; } = DateTime.MaxValue.ToUniversalTime();
    public DateTime? MinArrivalDateTimeUTC { get; set; } = DateTime.MinValue.ToUniversalTime();
    public DateTime? MaxArrivalDateTimeUTC { get; set; } = DateTime.MaxValue.ToUniversalTime();
    public decimal? MinCost { get; set; } = decimal.MinValue;
    public decimal? MaxCost { get; set; } = decimal.MaxValue;
    public string? EndPointStartsWith { get; set; } = null;
    public string? EndPointEndsWith { get; set; } = null;
    public string? EndPointContains { get; set; }
    public string? StartPointStartsWith { get; set; }
    public string? StartPointEndsWith { get; set; }
    public string? StartPointContains { get; set; }

}
/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{

}