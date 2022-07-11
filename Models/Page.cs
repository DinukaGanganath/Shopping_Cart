using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
    public class Page
    {
        public int Id { get; set; }
        [Required, MinLength(2,ErrorMessage ="Need at least 2 characters.")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Need at least 4 characters.")]
        public string Content { get; set; }
        public int Sorting { get; set; }
    }

    
}
