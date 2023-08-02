using HotChocolate;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSolution.DAL.Data;
using TaskSolution.DAL.Models;

using TaskSolution.API.Providers.AggregateSearch.ZeroQLClient;

namespace TaskSolution.API.Providers.AggregateSearch
{
    public class QueryRest
    {
        [
             UseProjection,
             UseFiltering,
             UseSorting
        ]
        public async Task<ICollection<ZeroQLClient.TravelRoute>> GetTravelRoutes()
        {
            using var httpClient = new HttpClient() {BaseAddress = new Uri("http://localhost:4883")};
            var provOne = new ProviderClient(httpClient);
            var r = await provOne.Query(q => q.TravelRoutes(null, null,p => p.Id));
            return r.Data.Cast<ZeroQLClient.TravelRoute>().ToList();
        }
    }
}
