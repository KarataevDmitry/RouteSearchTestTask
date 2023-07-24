using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data.ContextConfigurations
{
    internal class TravelPointContextConfiguration : IEntityTypeConfiguration<TravelPoint>
    {
        private Guid[] _routesIds;
        public TravelPointContextConfiguration(Guid[] routesIds) { _routesIds = routesIds; }
        public void Configure(EntityTypeBuilder<TravelPoint> builder)
        {
            builder.HasData(
                new TravelPoint
                {
                    Id = Guid.NewGuid(),
                    Name = "Alabama",
                    TravelRouteId = _routesIds[0]
                },
                new TravelPoint
                {
                    Id = Guid.NewGuid(),
                    Name = "San-Francisco",
                    TravelRouteId = _routesIds[0]
                },
                new TravelPoint
                {
                    Id = Guid.NewGuid(),
                    Name = "Washington",
                    TravelRouteId = _routesIds[1]
                },
                new TravelPoint
                {
                    Id = Guid.NewGuid() ,
                    Name = "Ohaio",
                    TravelRouteId= _routesIds[0]
                }

                ) ;
        }
    }
}
