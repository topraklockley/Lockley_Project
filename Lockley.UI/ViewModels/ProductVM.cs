using Lockley.DAL.Entities;

namespace Lockley.UI.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		public IEnumerable<Product> RelatedProducts { get; set; }
	}
}
