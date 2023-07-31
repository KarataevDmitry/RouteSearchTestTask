using HotChocolate;

using ProviderOneReader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSolution.DAL.Data;
using TaskSolution.DAL.Models;

using ZeroQL;

namespace TaskSolution.API.Providers.AggregateSearch
{
    public class QueryRest
    {
        [
             UseProjection,
             UseFiltering,
             UseSorting
        ]
        public async Task<ICollection<ProviderOneReader.TravelRoute>> GetTravelRoutes([Service] ProviderOneClient provOne, CancellationToken cancellationToken)
        {
            var r = await provOne.GetAllAsync(cancellationToken);
            return r;
        }
    }
}
