using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Final_Project.Models
{
    public class Product
    {

        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Title is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 Charcter.")]
        public string Title { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is Required.")]
        [Range(0, 1_000_000)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }


        [DisplayName("Description")]
        public string? Description { get; set; }


        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is Required.")]
        [Range(0, 1_000_000)]
        public int Quantity { get; set; }


        [DisplayName("ImagePath")]
        public string? ImagePath { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
