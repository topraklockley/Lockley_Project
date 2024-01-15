using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Order
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name ="Order Number")]

        public string OrderNumber { get; set; }

        [Display(Name ="Payment Option")]

        public EPaymentOption PaymentOption { get; set; }

		[Display(Name = "Order Status")]

		public EOrderStatus OrderStatus { get; set; }
        public DateTime RecDate { get; set; }

		[Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Full Name")]

		public string FullName { get; set; }
		
		[Column(TypeName ="Varchar(100)"), StringLength(100), Display(Name = "Address Information")]

		public string Address { get; set; }

		[Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Country")]

		public string Country { get; set; }

		[Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "City")]

		public string City { get; set; }

		[Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "District")]

		public string District { get; set; }

		[Column(TypeName = "Varchar(10)"), StringLength(10), Display(Name = "Postal Code")]

		public string PostalCode { get; set; }

		[Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Phone Number")]

		public string Phone { get; set; }

		[Column(TypeName = "Varchar(80)"), StringLength(80), Display(Name = "E-Mail Address")]

		public string EMailAddress { get; set; }

		[Column(TypeName = "decimal(18, 2)"), Display(Name = "Shipping Fee")]

		public decimal ShippingFee { get; set; }

		// Table Connection Properties \\

		public ICollection<OrderDetail> OrderDetails { get; set; }

		// NotMapped Attributed Properties \\

		[NotMapped]

		public string CardNumber { get; set; }

		[NotMapped]

		public string CardExpirationM { get; set; }

		[NotMapped]

		public string CardExpirationY { get; set; }

		[NotMapped]

		public string CardCVV { get; set; }
	}
}
