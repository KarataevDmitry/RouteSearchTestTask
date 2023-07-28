using HotChocolate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data
{
    public class Query
    {
        [
             UseProjection,
             UseFiltering,
             UseSorting
        ]
        public IQueryable<TravelRoute> GetTravelRoutes([Service] ApplicationDbContext context) => context.TravelRoutes;
        
    }
}
