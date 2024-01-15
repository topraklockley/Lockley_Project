using Lockley.BL;
using Lockley.BL.Tools;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lockley.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Policy = "AdminPolicy")]
    
    public class HomeController : Controller
    {
        IRepository<Admin> repoAdmin;

        public HomeController(IRepository<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous, Route("/login")]

        public IActionResult Login()
        {          
            return View();
        }

        [AllowAnonymous, HttpPost, Route("/login"), ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(string username, string password)
        {          
            string MD5Password = GeneralTools.GetMD5(password);
            
            Admin admin = repoAdmin.GetBy(x => x.Username == username && x.Password == MD5Password);
            
            if(admin != null)
            {
                bool isAdmin = admin.ID != 6;
                
                if (isAdmin)
                {
					List<Claim> claims = new List<Claim>()
					{
						new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
						new Claim(ClaimTypes.Name, admin.FullName)
					};

					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AdminAuthorization");

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });

					return Redirect("/admin");
				}
                else
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
                        new Claim(ClaimTypes.Name, admin.FullName)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "RegularAuthorization");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });

                    return Redirect("/");
                }
            }
            else
            {
                TempData["Information"] = "Either Username or Password is wrong.";

                return RedirectToAction("login");
            }
        }

        [AllowAnonymous, Route("/logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            Response.Cookies.Delete("ShoppingCart");

            return RedirectToAction("login");
        }
    }
}
