using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HR.API
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} Should be minimum 3 characters and a maximum of 30 characters long")]
        public string Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{1} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{1} Should be minimum 3 characters and a maximum of 30 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{2} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{3} is required")]
        [StringLength(300, MinimumLength = 6, ErrorMessage = "{3} Should be minimum 6 characters and a maximum of 12 characters long")]
        public string Password { get; set; }
    }
}