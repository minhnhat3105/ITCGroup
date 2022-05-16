using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"([A-Z]{1}[a-z]+(\s)?)+$")]
        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }
        
        [Required]
        [RegularExpression(@"^(\w+@\w+[.]\w+(.\w+)?)$")]
        public string Email { get; set; }
    }
}
