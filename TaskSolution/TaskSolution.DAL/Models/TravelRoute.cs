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
        public TravelPoint StartPoint { get; set; }
        [ForeignKey("StartPointId")]
        public Guid StartPointId { get; set; }
        public TravelPoint EndPoint { get; set; }
        [ForeignKey("EndPointId")]
        public Guid EndPointId { get; set; }
        //public ICollection<TravelPoint> RoutePoints { get; set; }
        public DateTime StartDateTimeUTC { get; set; }
        public DateTime ArrivalDateTimeUTC { get; set; }
        public TimeSpan TimeToLive { get; set; }
        public decimal Cost { get; set; }
    }
}
