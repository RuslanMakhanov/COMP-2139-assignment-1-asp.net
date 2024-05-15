using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class ProductModel
    {
        [DisplayName("Product Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength =5)]
        [DisplayName("Product Code")]
        public string Code { get; set; }


        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }


        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Product Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
}
