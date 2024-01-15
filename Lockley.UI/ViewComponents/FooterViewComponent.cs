using Lockley.BL;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lockley.UI.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public FooterViewComponent()
		{
			
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
