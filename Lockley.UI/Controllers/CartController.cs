using Lockley.BL;
using Lockley.BL.Tools;
using Lockley.DAL.Entities;
using Lockley.UI.Models;
using Lockley.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace Lockley.UI.Controllers
{
    public class CartController : Controller
    {
        IRepository<Product> repoProduct;
        IRepository<Order> repoOrder;
		IRepository<OrderDetail> repoOrderDetail;

		public CartController(IRepository<Product> _repoProduct, IRepository<Order> _repoOrder, IRepository<OrderDetail> _repoOrderDetail)
        {
            repoProduct = _repoProduct;
			repoOrder = _repoOrder;
			repoOrderDetail = _repoOrderDetail;
		}

        public IActionResult Index()
        {
            List<Cart> carts = new List<Cart>();

			if (Request.Cookies["ShoppingCart"] != null)
            {
                carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);
            }

			return View(carts);
		}

        [HttpPost, Route("/cart/addtocart")]

        public IActionResult AddToCart(int productid, int quantity)
        {
            Product product = repoProduct.GetAll(x => x.ID == productid).Include(x => x.ProductPictures).FirstOrDefault();         

            if(product != null)
            {
				bool isDistinct = true;

				Cart cart = new Cart()
                {
                    ProductID = productid,
                    ProductName = product.Name,
                    ProductPicture = product.ProductPictures.FirstOrDefault().FilePath,
                    UnitsInStock = product.UnitsInStock,
                    Price = product.Price,
                    Quantity = quantity
                };

                List<Cart> carts = new List<Cart>();

                if (Request.Cookies["ShoppingCart"] != null)
                {
					carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

					if (carts.Where(x => x.ProductID == productid).Count() >= 1)
                    {
                        carts.First(x => x.ProductID == productid).Quantity += cart.Quantity;
                        isDistinct = false;
                    }                  
                }

                if(isDistinct)
                {
                    carts.Add(cart);
                }

				CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Append("ShoppingCart", JsonConvert.SerializeObject(carts), cookieOptions);

                return Content(product.Name);
            }
            else
            {
                return Content("Product Not Found");
            }
        }

        [Route("/cart/itemcount")]

        public int ItemCount()
        {
            int num = 0;
            
            if (Request.Cookies["ShoppingCart"] != null)
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

                num = carts.Sum(x => x.Quantity);

                foreach (Cart c in carts.Where(c => c.Quantity > c.UnitsInStock))
                {
                    int quantityDifference = c.Quantity - c.UnitsInStock;
                    num -= quantityDifference;
                }
            }

            return num;
        }

		[HttpPost, Route("/cart/updateprice")]

		public decimal UpdatePrice(int productid, bool isIncreased)
        {
            Product product = repoProduct.GetBy(x => x.ID == productid);

            decimal priceChange = 0;

            if(isIncreased)
            {
				priceChange = product.Price;

				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

                int currentQuantity = carts.FirstOrDefault(x => x.ProductID == productid).Quantity;
                currentQuantity++;
                carts.FirstOrDefault(x => x.ProductID == productid).Quantity = currentQuantity;

				CookieOptions cookieOptions = new CookieOptions();
				cookieOptions.Expires = DateTime.Now.AddHours(2);
				Response.Cookies.Append("ShoppingCart", JsonConvert.SerializeObject(carts), cookieOptions);
			}
            else
            {
				priceChange = -product.Price;

				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

				int currentQuantity = carts.FirstOrDefault(x => x.ProductID == productid).Quantity;
				currentQuantity--;
				carts.FirstOrDefault(x => x.ProductID == productid).Quantity = currentQuantity;

				CookieOptions cookieOptions = new CookieOptions();
				cookieOptions.Expires = DateTime.Now.AddHours(2);
				Response.Cookies.Append("ShoppingCart", JsonConvert.SerializeObject(carts), cookieOptions);
			}

			return priceChange;
		}

		[Route("/cart/checkout")]

		public IActionResult CheckOut()
        {
			if (Request.Cookies["ShoppingCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

                CheckOutVM checkOutVM = new CheckOutVM()
                {
                    Order = new Order() { ShippingFee = 10.75M },
                    Carts = carts
                };

                return View(checkOutVM);
			}
            else
            {
                return Redirect("/");
			}
        }

        [HttpPost, Route("/cart/placeorder"), ValidateAntiForgeryToken]

        public IActionResult PlaceOrder(CheckOutVM model)
        {
            model.Order.RecDate = DateTime.Now;
            model.Order.OrderNumber = GeneralTools.OrderNumberGenerator();
            model.Order.OrderStatus = EOrderStatus.Preparing;

            repoOrder.Add(model.Order);

            List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["ShoppingCart"]);

            foreach(Cart c in carts)
            {
                OrderDetail od = new OrderDetail()
                {
                    OrderID = model.Order.ID,
                    ProductID = c.ProductID,
                    Quantity = c.Quantity
                };

                repoOrderDetail.Add(od);
            }

            Response.Cookies.Delete("ShoppingCart");

            return Redirect("/");
        }
    }
}
