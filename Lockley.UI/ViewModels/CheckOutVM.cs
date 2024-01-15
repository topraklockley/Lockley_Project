using Lockley.DAL.Entities;
using Lockley.UI.Models;

namespace Lockley.UI.ViewModels
{
	public class CheckOutVM
	{
		public Order Order { get; set; }
		public IEnumerable<Cart> Carts { get; set; }
	}
}
