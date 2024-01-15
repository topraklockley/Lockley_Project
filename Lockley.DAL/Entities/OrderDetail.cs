using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class OrderDetail
    {
        public int ID { get; set; }
		public int Quantity { get; set; }

		// Table Connection Properties \\

		public int OrderID { get; set; }
		public Order Order { get; set; }
		public int? ProductID { get; set; }
	}
}
