using Lockley.BL;
using Lockley.BL.Tools;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace Lockley.API.Controllers
{
	[Route("api/[controller]"), Authorize, AllowAnonymous] // AllowAnonymous Attributed for now
	[ApiController]
	public class HomeController : ControllerBase
	{
		IRepository<Admin> repoAdmin;
		IRepository<Brand> repoBrand;

        public HomeController(IRepository<Admin> _repoAdmin, IRepository<Brand> _repoBrand)
        {
            repoAdmin = _repoAdmin;
            repoBrand = _repoBrand;        
        }

		[HttpGet]

		public IEnumerable<Brand> GetBrands()
		{
			return repoBrand.GetAll();
		}

		[HttpGet("{id}")]

		public Brand GetBrands(int id)
		{
			return repoBrand.GetBy(x => x.ID == id);
		}

		[HttpPost("Add")]

		public string Add(Brand model)
		{
			try
			{
				repoBrand.Add(model);
				
				return model.Name + " brand has been successfully added.";
			}
			catch (Exception ex)
			{
                return "An error occured during the addition process.\nHere are the details: " + ex.Message;
            }
		}

		[HttpPut]

		public string Update(Brand model)
		{
			try
			{
				repoBrand.Update(model);

                return "The brand with " + model.ID + " ID has been successfully updated.";
            }
			catch (Exception ex)
            {
                return "An error occured during the updation process.\nHere are the details: " + ex.Message;
            }
		}

		[HttpDelete("{id}")]

		public string Delete(int id)
		{
			try
			{
				Brand brand = repoBrand.GetBy(x => x.ID == id);
				
			    repoBrand.Delete(brand);
				
				return brand.Name + " brand has been successfully deleted.";
            }
            catch (Exception ex)
            {
                return "An error occured during the deletion process.\nHere are the details: " + ex.Message;
            }
        }

		[AllowAnonymous, HttpGet, Route("/api/login")]

		public string Login(string username, string password)
		{
			string MD5Password = GeneralTools.GetMD5(password);

			Admin admin = repoAdmin.GetBy(x => x.Username == username && x.Password == MD5Password);

			string secrettext = repoAdmin.GetBy(x => x.ID == 1).Username;

			if (admin != null)
			{
				List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.GroupSid, admin.ID.ToString()),
					new Claim(ClaimTypes.Name, admin.FullName)
				};

				string SignInKey = "AuthorizationKey";

				SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(SignInKey));

				SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

				JwtSecurityToken jwtSecurityToken = new(
					issuer: "http://localhost:5218",
					audience: "moderators",
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					notBefore: DateTime.Now,
					signingCredentials: signingCredentials
					);

				string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

				return jwtToken;
			}
			else
			{
				return "Sign In Failed.";
			}
		}
	}
}
