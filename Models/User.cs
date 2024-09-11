using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITI_Final_Project.Models
{
    public class User
    {
        public int Id {  get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 12 Charcter.")]
        public string FName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 12 Charcter.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }
}
