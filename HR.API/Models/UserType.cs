using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.API
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }

        [Required(ErrorMessage = "{1} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{2} is required")]
        public string Description { get; set; }
    }
}