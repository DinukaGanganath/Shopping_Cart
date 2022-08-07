using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using System.Threading.Tasks;

namespace Shopping_Cart.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{

		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		// GET : /account/register
		[AllowAnonymous]
		public IActionResult Register() => View();

		// POST : /account/register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(User user)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser
				{
					UserName = user.Username,
					Email = user.Email
				};

				IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Login");
				}
				else
				{
					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return View(user);
		}

		// GET : /account/login
		[AllowAnonymous]
		public IActionResult Login(string returnurl) 
		{
			Login login = new Login
			{
				ReturnUrl = returnurl
			};

			return View(login);
		}

		// POST : /account/login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Login login)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = await userManager.FindByEmailAsync(login.Email);
				if(appUser != null)
				{
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);

					if (result.Succeeded)
					{
						return Redirect(login.ReturnUrl ?? "/");
					}
					ModelState.AddModelError("", "Login failed. wrong credentials.");
				}
			}

			return View(login);
		}

	}
}
