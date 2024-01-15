using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
	public enum EPaymentOption
	{
		[Display(Name ="Credit Card")]

		CreditCard = 1,

		[Display(Name = "Transfer")]

		Transfer,

		[Display(Name = "Cash On Delivery (COD)")]

		CashOnDelivery
	}
}
