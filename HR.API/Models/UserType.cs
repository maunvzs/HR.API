using System.ComponentModel.DataAnnotations;

namespace HR.API
{
    public class UserType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{1} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{2} is required")]
        public string Description { get; set; }
    }
}