using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
	public class User 
	{
		[Required, MinLength(2, ErrorMessage = "Minimum length is 2.")]
		[Display(Name = "Username")]
		public string Username { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4.")]
		public string Password { get; set; }

	}
}
