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
    public class TravelRouteContextConfiguration : IEntityTypeConfiguration<TravelRoute>
    {
        public void Configure(EntityTypeBuilder<TravelRoute> builder)
        {
           
            builder.Property(e => e.TimeToLive)
                .HasConversion<long>();
        
            
                  
        }
    }
}
