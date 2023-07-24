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
    public class TravelPointContextConfiguration : IEntityTypeConfiguration<TravelPoint>
    {
        private Guid[] _travelPointsIds;
        public TravelPointContextConfiguration(Guid[] routesIds) { _travelPointsIds = routesIds; }
        public void Configure(EntityTypeBuilder<TravelPoint> builder)
        {
            builder.HasData(
                new TravelPoint
                {
                    Id = _travelPointsIds[0],
                    Name = "Alabama",
                    TravelRouteId = _travelPointsIds[0]
                },
                new TravelPoint
                {
                    Id = _travelPointsIds[1],
                    Name = "San-Francisco",
                    TravelRouteId = _travelPointsIds[0]
                },
                new TravelPoint
                {
                    Id = _travelPointsIds[2],
                    Name = "Washington",
                    TravelRouteId = _travelPointsIds[1]
                },
                new TravelPoint
                {
                    Id = _travelPointsIds[3] ,
                    Name = "Ohaio",
                    TravelRouteId= _travelPointsIds[0]
                }

                ) ;
        }
    }
}
