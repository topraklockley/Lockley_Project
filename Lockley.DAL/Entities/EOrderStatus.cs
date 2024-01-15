using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
	public enum EOrderStatus
	{
		[Display(Name = "Preparing")]

		Preparing = 1,

		[Display(Name = "Shipped")]

		Shipped,

		[Display(Name = "Delivered")]

		Delivered,

		[Display(Name = "Canceled")]

		Canceled
	}
}
