

using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;
using TaskSolution.DAL.Models;
using TaskSolution.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddOutputCache(options => options.SizeLimit = 3000);
builder.Services.AddHealthChecks();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddApiVersioning(opt => {
  //  opt.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
   // opt.ApiVersionReader = new QueryStringApiVersionReader("v");
//});
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => 
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
builder.WebHost.UseUrls("http://localhost:4883");

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHealthChecks("/ping");

app.MapGet("/TravelRoutes/getAll", async (ApplicationDbContext context) => await context.TravelRoutes.ToListAsync());
app.MapGet("/search", async (ApplicationDbContext context,
                       [AsParameters] ProviderOneSearchRequest queryParameters) =>
{
    SetSearchRequestValues(queryParameters);

    IQueryable<TravelRoute> res = ApplyFiltersToContextData(context, queryParameters);
    Debug.WriteLine($"resulting query string: {res.ToQueryString()}");
    return await res.ToListAsync();

    static IQueryable<TravelRoute> ApplyStartPointContainsFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        Debug.WriteLine("Interval filters applied");
        Debug.WriteLine("Start point contains entry");
        if (string.IsNullOrEmpty(queryParameters.StartPointContains))
        {
            Debug.WriteLine("No sp contains, next: sp ew");
            return ApplyStartPointEndsWithFilter(queryParameters, res);
        }
        Debug.WriteLine("Sp cont  applied");
        return ApplyStartPointEndsWithFilter(queryParameters, res.Where(x => x.StartPoint.Contains(queryParameters.StartPointContains)));
    }

    static IQueryable<TravelRoute> ApplyEndPointContainsFilter(ProviderOneSearchRequest queryParameters, IQueryable<TravelRoute> res)
    {
        if (string.IsNullOrEmpty(queryParameters.EndPointContains))
        {
            Debug.WriteLine(" no ep cont, next: ep ew");
            return ApplyEndPointEndsWithFilter(queryParameters, res);
        }
        Debug.WriteLine(" ep cont applied, next: ep ew");
        return ApplyEndPointEndsWithFilter(queryParameters, res.Where(x => x.EndPoint.Contains(queryParameters.EndPointContains)));
    }

    static IQueryable<TravelRoute> ApplyEndPointStartsWithFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (string.IsNullOrEmpty(queryParameters.EndPointStartsWith))
        {
            Debug.WriteLine("no ep sw, return result");
            return res;
        }
        Debug.WriteLine("ep sw applied, return result");
        return res.Where(x => x.EndPoint.StartsWith(queryParameters.EndPointStartsWith));
    }

    static IQueryable<TravelRoute> ApplyStartPointStartsWithFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (string.IsNullOrEmpty(queryParameters.StartPointStartsWith))
        {
            Debug.WriteLine(" no sp sw, next: ep cont");
            return ApplyEndPointContainsFilter(queryParameters, res);
        }
        Debug.WriteLine(" sp sw applied, next: ep cont");
        return ApplyEndPointContainsFilter(queryParameters, res.Where(x => x.StartPoint.StartsWith(queryParameters.StartPointStartsWith)));
    }

    static IQueryable<TravelRoute> ApplyEndPointEndsWithFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (string.IsNullOrEmpty(queryParameters.EndPointEndsWith))
        {
            Debug.WriteLine("no ep ew, next: ep sw");
            return ApplyEndPointStartsWithFilter(queryParameters, res.Where(x => x.EndPoint.EndsWith(queryParameters.EndPointEndsWith!)));
        }
        Debug.WriteLine(" ep ew applied, next: ep sw");
        return ApplyEndPointStartsWithFilter(queryParameters, res.Where(x => x.EndPoint.EndsWith(queryParameters.EndPointEndsWith!)));
    }

    static IQueryable<TravelRoute> ApplyStartPointEndsWithFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        if (string.IsNullOrEmpty(queryParameters.StartPointEndsWith))
        {
            Debug.WriteLine("No sp ew next: sp sw");
            return ApplyStartPointStartsWithFilter(queryParameters, res);
        }
        Debug.WriteLine(" sp ew applied, next: sp sw");
        return ApplyStartPointStartsWithFilter(queryParameters, res.Where(x => x.StartPoint.EndsWith(queryParameters.StartPointEndsWith)));

    }

    static IQueryable<TravelRoute> ApplyIntervalConditionsFilter(ProviderOneSearchRequest queryParameters, IQueryable<TaskSolution.DAL.Models.TravelRoute> res)
    {
        Debug.WriteLine("Interval filters entry");
        var resWithCostFilter = res.Where(x =>
        x.Cost >= queryParameters.MinCost
        && x.Cost <= queryParameters.MaxCost);
        var resWithCostStartDateFilter = resWithCostFilter.Where(x =>
        x.StartDateTimeUTC >= queryParameters.MinStartDateTimeUTC
        && x.StartDateTimeUTC <= queryParameters.MaxStartDateTimeUTC);
        var resWithADTFilter = resWithCostStartDateFilter.Where(x =>
           x.ArrivalDateTimeUTC >= queryParameters.MinArrivalDateTimeUTC
        && x.ArrivalDateTimeUTC <= queryParameters.MaxStartDateTimeUTC);
        return ApplyStartPointContainsFilter(queryParameters, resWithADTFilter);

    }

    static IQueryable<TaskSolution.DAL.Models.TravelRoute> ApplyFiltersToContextData(ApplicationDbContext context, ProviderOneSearchRequest queryParameters)
    {
        var res = context.TravelRoutes;

        return ApplyIntervalConditionsFilter(queryParameters, res);
    }

    static void SetSearchRequestValues(ProviderOneSearchRequest searchRequest)
    {
        searchRequest.MinStartDateTimeUTC = searchRequest.MinStartDateTimeUTC.HasValue ? searchRequest.MinStartDateTimeUTC : new DateTime(1, 1, 1).ToUniversalTime();
        searchRequest.MaxStartDateTimeUTC = searchRequest.MaxStartDateTimeUTC.HasValue ? searchRequest.MaxStartDateTimeUTC : new DateTime(9999, 12, 31).ToUniversalTime();
        searchRequest.MinArrivalDateTimeUTC = searchRequest.MinArrivalDateTimeUTC.HasValue ? searchRequest.MinArrivalDateTimeUTC : new DateTime(1, 1, 1).ToUniversalTime();
        searchRequest.MaxArrivalDateTimeUTC = searchRequest.MaxArrivalDateTimeUTC.HasValue ? searchRequest.MaxArrivalDateTimeUTC : new DateTime(9999, 12, 31).ToUniversalTime();

        searchRequest.MaxCost = searchRequest.MaxCost.HasValue ? searchRequest.MaxCost : decimal.MaxValue;
        searchRequest.MinCost = searchRequest.MinCost.HasValue ? searchRequest.MinCost : decimal.MinValue;

        searchRequest.EndPointStartsWith = searchRequest.EndPointStartsWith is null ? string.Empty : searchRequest.EndPointStartsWith;
        searchRequest.StartPointStartsWith = searchRequest.StartPointStartsWith is null ? string.Empty : searchRequest.StartPointStartsWith;

        searchRequest.EndPointEndsWith = searchRequest.EndPointEndsWith is null ? string.Empty : searchRequest.EndPointEndsWith;
        searchRequest.StartPointEndsWith = searchRequest.StartPointEndsWith is null ? string.Empty : searchRequest.StartPointEndsWith;

        searchRequest.EndPointContains = searchRequest.EndPointContains is null ? string.Empty : searchRequest.EndPointContains;
        searchRequest.StartPointContains = searchRequest.StartPointContains is null ? string.Empty : searchRequest.StartPointContains;
    }
}).CacheOutput();
app.Run();

/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{
    
};