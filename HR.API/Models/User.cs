using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HR.API
{
    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "{2} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{2} Should be minimum 3 characters and a maximum of 30 characters")]
        public string Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{3} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{3} Should be minimum 3 characters and a maximum of 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{4} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{5} is required")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "{5} Should be minimum 6 characters and a maximum of 12 characters")]
        public string Password { get; set; }
    }
}