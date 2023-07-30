using HotChocolate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Models;

using ZeroQL;
using ZeroQL.Client;

namespace TaskSolution.API.Providers.AggregateSearch
{
    public class QueryCached
    {
        [
             UseProjection,
             UseFiltering,
             UseSorting
        ]
        public async Task< IQueryable<DAL.Models.TravelRoute>> GetTravelRoutes([Service] ApplicationDbContext context)
        {
            if (context.TravelRoutes.Any())
            {
                return context.TravelRoutes;
            }
            using var httpClientProviderTwo = new HttpClient() { BaseAddress = new Uri("http://localhost:2292/graphql") };
            using var httpClientProviderOne = new HttpClient() { BaseAddress = new Uri("http://localhost:4883") };
            using var providerOneClient = new ProviderClient(httpClientProviderOne);
            using var providerTwoClient = new ProviderClient(httpClientProviderTwo);
           var provider1qres = await providerOneClient.Query(o => o.TravelRoutes(selector: s => new DAL.Models.TravelRoute()
            {
                Id = s.Id,
                StartDateTimeUTC = s.StartDateTimeUTC.UtcDateTime,
                ArrivalDateTimeUTC = s.ArrivalDateTimeUTC.UtcDateTime,
                Cost = s.Cost,
                EndPoint = s.EndPoint,
                StartPoint = s.StartPoint,
                TimeToLive = s.TimeToLive
            }));
            context.AddRange(provider1qres.Data);
            return null;

            
        }
    }
}
