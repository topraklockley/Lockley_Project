using Microsoft.AspNetCore.Mvc;
using Lockley.DAL.Entities;
using Lockley.BL;

namespace Lockley.UI.Areas.admin.ViewComponents
{
	[Area("admin")]

	public class AdminFooterViewComponent : ViewComponent
	{
		IRepository<Category> repoCategory;

		public AdminFooterViewComponent(IRepository<Category> _repoCategory)
		{
			repoCategory = _repoCategory;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
