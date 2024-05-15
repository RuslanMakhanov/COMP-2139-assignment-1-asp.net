using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class TechniciansModel
    {
        [Required]  
        [DisplayName("Technicians id")]
        public int id { get; set; }
        [DisplayName("Technicians Name")]
        public string Name { get; set; }
        [DisplayName("Technicians Email")]
        public string Email { get; set; }
        [DisplayName("Technicians Phone")]
        
        public string Phone { get; set; }
    }
}
