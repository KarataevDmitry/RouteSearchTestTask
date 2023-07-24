using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;

namespace TaskSolution.DAL.Repositories
{
    public class TravelPointRepository:ITravelPointRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelPointRepository(ApplicationDbContext context)
        {
                _context = context;
        }
    }
}
