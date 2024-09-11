using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_Final_Project.Models
{
    public class Category
    {
        public int Id { get; set; }


        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 Charcter.")]
        public string Name { get; set; }

        [DisplayName("Description")]
        
        public string? Description { get; set; }


        public ICollection<Product> Products{ get; set; }

    }
}
