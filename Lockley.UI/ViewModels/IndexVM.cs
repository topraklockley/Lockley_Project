using Lockley.DAL.Entities;

namespace Lockley.UI.ViewModels
{
	public class IndexVM
	{
		public IEnumerable<Slide> Slides { get; set; }
		public IEnumerable<Product> LatestProducts { get; set; }
        public IEnumerable<Product> TopSellingProducts { get; set; }
    }
}
