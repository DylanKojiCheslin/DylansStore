using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DylansStore.Controllers
{
    public class BaseController : Controller
    {

        public Models.DylansStoreEntities db = new Models.DylansStoreEntities();


        //make read only variable

        //delair a property variable
        private Models.Order _myOrder;

        //write a propery variable
        public Models.Order MyOrder
        {
            get
            {
                //is my ordeer a thing
                if (_myOrder == null)
                {
                    //don't exist get the order id
                    var orderID = GetOrderID();
                    //set the _myOder to the orderID from the the db
                    _myOrder = db.Orders.Find(orderID);
                }
                return _myOrder;
            }
        }


        public int GetOrderID()
        {
            
            
             

            if (Session["OrderID"] == null)
            {
                //create new order
                var newOrder = new Models.Order();
                newOrder.DateCreated = DateTime.Now;
                newOrder.Status = "Cart";
                newOrder.SubTotal = 0;
                newOrder.ShippingCost = 0;
                newOrder.TotalPrice = 0;
                newOrder.SalesTax = 0;
                //add to db
                db.Orders.Add(newOrder);
                db.SaveChanges();

                //set the session orderID equil to new orderID
                Session["OrderID"] = newOrder.OrderID;
                return newOrder.OrderID;
            }
            //convert object to int then to string
            return int.Parse(Session["OrderID"].ToString());
        }

    }
}
