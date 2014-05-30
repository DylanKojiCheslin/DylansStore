using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DylansStore.Controllers
{
  
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Models.DylansStoreEntities db = new Models.DylansStoreEntities();

        public ActionResult Breadcrumbs(int id)
        {
            var category = db.Categorys.Find(id);
            var breadcrumbList = new List<Models.Category>();

            //loop to add all to list
            while (category.ParentID != null)
            {
                breadcrumbList.Add(category);
                category = category.ParentCategory;
            }
            breadcrumbList.Add(category);

            breadcrumbList.Reverse();

            return PartialView(breadcrumbList);
        }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Navigation()
        {
            var categories = db.Categorys.Where(x=> x.ParentID == null);
            return PartialView(categories);
            
        }



    }
}
