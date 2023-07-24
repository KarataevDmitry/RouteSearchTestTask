using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolution.DAL.Models
{
    public class TravelRoute
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(StartPointId))]
        public TravelPoint StartPoint { get; set; }
        
        public Guid StartPointId { get; set; }
        [ForeignKey(nameof(EndPointId))]
        public TravelPoint EndPoint { get; set; }
        public Guid? EndPointId { get; set; }
        //public ICollection<TravelPoint> RoutePoints { get; set; }
        public DateTime StartDateTimeUTC { get; set; }
        public DateTime ArrivalDateTimeUTC { get; set; }
        public TimeSpan TimeToLive { get; set; }
        public int Cost { get; set; }
    }
}
