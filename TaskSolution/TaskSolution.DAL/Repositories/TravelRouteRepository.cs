using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;

namespace TaskSolution.DAL.Repositories
{
    public class TravelRouteRepository:ITravelRouteRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelRouteRepository(ApplicationDbContext applicationDbContext)
        {
                _context = applicationDbContext;
        }
    }
}
