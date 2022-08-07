namespace Shopping_Cart.Models
{
	public class User 
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		User(){}
		public User(AppUser appUser)
		{
			Username = appUser.UserName;
			Email = appUser.Email;
			Password = appUser.PasswordHash;
		}
	}
}
