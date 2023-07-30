using HotChocolate.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;
using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Repositories
{
    public class TravelRouteRepository : ITravelRouteRepository
    {
        private readonly InMemoryDbContext db;
        private readonly IMemoryCache _cache;
        MemoryCacheOptions cacheOptions = new MemoryCacheOptions() { SizeLimit = 10 };

        public TravelRouteRepository(InMemoryDbContext context, IMemoryCache cache)
        {
            db = context;
            _cache = cache;
        }

        public async Task AddTravelRouteAsync(TravelRoute route)
        {
          
            db.TravelRoutes.Add(route);
            var n = await db.SaveChangesAsync();
            if (n > 0)
            {

                TravelRoute travelRoute = _cache.Set(route.Id, route, TimeSpan.FromSeconds(60));
            }
        }


        public async Task<IEnumerable<TravelRoute>> GetAllTravelRoutes() => await db.TravelRoutes.ToListAsync();

        public async Task<TravelRoute?> GetTravelRouteAsync(Guid id)
        {

            if (_cache.TryGetValue(id, out TravelRoute route))
            {
                return route;
            }

            route = await db.TravelRoutes.FirstOrDefaultAsync(p => p.Id == id);
            if (route == null)
            {
                return null;
            }
            _cache.Set(route.Id, route, TimeSpan.FromSeconds(60));
            return route;
        }

        public async Task<IEnumerable<TravelRoute>> GetGetTravelRoutesAsync()
        {
            return await db.TravelRoutes.ToListAsync();
        }
    }
}
