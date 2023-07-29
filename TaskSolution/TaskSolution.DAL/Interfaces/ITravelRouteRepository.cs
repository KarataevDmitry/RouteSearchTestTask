using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Interfaces
{
    public interface ITravelRouteRepository
    {
        Task AddTravelRouteAsync(TravelRoute route);
        Task<TravelRoute?> GetTravelRouteAsync(Guid id);
        IEnumerable<TravelRoute> GetAllTravelRoutes();
        void DeleteTravelRoute(Guid id);
    }
}
