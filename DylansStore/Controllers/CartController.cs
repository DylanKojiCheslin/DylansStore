using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DylansStore.Controllers
{
    public class CartController : BaseController
    {

        //
        // GET: /Cart/

        public ActionResult Index()
        {
            var orderID = GetOrderID();
            var order = db.Orders.Find(orderID);
            List<DylansStore.Models.OrderLine> orderLines = new List<DylansStore.Models.OrderLine>();

            foreach (var item in order.OrderLines)
            {
                orderLines.Add(item);
            }

            return View(order);
        }



        

    }

}
