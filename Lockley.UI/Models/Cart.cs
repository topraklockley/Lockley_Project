namespace Lockley.UI.Models
{
    public class Cart
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
