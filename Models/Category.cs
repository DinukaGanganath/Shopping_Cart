using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Need at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Only letters are allowed")]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public int Sorting { get; set; }
    }
}
