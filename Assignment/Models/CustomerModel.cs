using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        [Required]
        
        [DisplayName("Customer's First Name")]
        public string fName { get; set; }
        [DisplayName("Customer's Last Name")]
        public string lName { get; set; }
        [DisplayName("Customer's Address")]
        public string Address { get; set; }
        [DisplayName("Customer's City")]
        public string City { get; set; }
        [DisplayName("Customer's State")]
        public string State { get; set; }
        [DisplayName("Customer's Postal Code")]
        
        public string PostalCode { get; set; }
        [DisplayName("Customer's Country")]
        public string Country { get; set; }
        [DisplayName("Customer's Email")]
        public string Email { get; set; }
        [DisplayName("Customer's Phone")]
        public string Phone { get; set; }

    }
}
