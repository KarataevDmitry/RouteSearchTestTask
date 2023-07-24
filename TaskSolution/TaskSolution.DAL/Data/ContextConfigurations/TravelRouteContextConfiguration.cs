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
    internal class TravelRouteContextConfiguration : IEntityTypeConfiguration<TravelRoute>
    {
        private Guid[] _travelPointIds;
        public TravelRouteContextConfiguration(Guid[] travelPointIds) { _travelPointIds = travelPointIds; }
        public void Configure(EntityTypeBuilder<TravelRoute> builder)
        {
            builder.Property(e => e.TimeToLive)
                .HasConversion<long>();
            builder.HasData(
                new TravelRoute
                {
                    Id = Guid.NewGuid(),
                    StartPointId = _travelPointIds[0],
                    EndPointId = _travelPointIds[1],
                    StartDateTimeUTC = new DateTime(2023, 2, 15, 7, 0, 0).ToUniversalTime(),
                    ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 5, 0, 0).ToUniversalTime(),
                    Cost = 25,
                    TimeToLive = new(3, 0, 0)

                },
                new TravelRoute
                {
                    Id = Guid.NewGuid(),
                    StartPointId = _travelPointIds[0],
                    EndPointId = _travelPointIds[1],
                    StartDateTimeUTC = new DateTime(2023, 2, 15, 7, 0, 0).ToUniversalTime(),
                    ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 5, 0, 0).ToUniversalTime(),
                    Cost = 29,
                    TimeToLive = new(2, 0, 0)

                },
                 new TravelRoute
                 {
                     Id = Guid.NewGuid(),
                     StartPointId = _travelPointIds[0],
                     EndPointId = _travelPointIds[1],
                     StartDateTimeUTC = new DateTime(2023, 2, 15, 7, 0, 0).ToUniversalTime(),
                     ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 5, 0, 0).ToUniversalTime(),
                     Cost = 70,
                     TimeToLive = new(0, 30, 0)

                 }
                ); ;
        }
    }
}
