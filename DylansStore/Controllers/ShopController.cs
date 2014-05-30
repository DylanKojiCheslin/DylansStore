using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DylansStore.Controllers
{
    public class ShopController : BaseController
    {
        //
        // GET: /Shop/



        public ActionResult Index()
        {

            return View();

        }

        public ActionResult byCategory( int id)
        {

            var category = db.Categorys.Find(id);

            category.Allproducts = db.GetProductsByCategoryID(id).ToList();
            return View(category);
        }


        public ActionResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult Product(int id)
        {
            //get product from db
            var product = db.Products.Find(id);
            //returns view
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductDetail(int id, FormCollection values)
        {

            int qty = int.Parse(values["qty"]);
            int orderID = GetOrderID();

            //get our order
            
            var orderline = new Models.OrderLine();
            var p = db.Products.Find(id).Price;
            orderline.ProductID = id;
            orderline.Quantity = qty;
            orderline.UnitPrice = decimal.Parse(values["price"]);
            orderline.OrderID = orderID;


            //add the oruderline to the db
            db.OrderLines.Add(orderline);
            db.SaveChanges();

            //update the order total

            //1get the order
            var order = db.Orders.Find(orderID);
            //2update the total for the order(sum of order line
            order.SubTotal = order.OrderLines.Sum(x =>x.SubTotal.GetValueOrDefault());
            //3save save the updated order total
            db.SaveChanges();


            var product = db.Products.Find(id);

            


            return View(product);
        }

    }
}
