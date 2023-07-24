using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSolution.DAL.Models
{
    public class TravelPoint
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please specify a name of the city")]
        public string Name { get; set; }
        [ForeignKey("TravelRouteId")]
        public Guid TravelRouteId { get; set; }
    }
}