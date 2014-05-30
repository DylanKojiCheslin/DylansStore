using AuthorizeNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DylansStore.Controllers
{
    public class CheckoutController : BaseController
    {
        //
        // GET: /Checkout/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CredidtCardTest()
        {
            //what sends our transaction request
            Gateway target = new Gateway("8V6W3XnqP", "4x2uREmfJH393D7G", true);

            //creating a authorization request
            IGatewayRequest request = new AuthorizationRequest("5424000000000015", "0224", (decimal)20.10, "AuthCap transaction approved testing", true);
            request.Address = "123 main st. apt. 2 denver co 80211";
            string description = "AuthCap transaction approved testing";
            //sends the request
            IGatewayResponse response = target.Send(request, description);

            return Content("C");
        }

    }
}
