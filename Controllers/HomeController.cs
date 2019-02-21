using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SEFApplicationDashboard.app;

//controller for all dashboard applications
namespace SEFApplicationDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<EmptyResult> RunClearingAsync()
        {
           
            var response = await ImportWIPClearing.RunWIPClearing(1,false);
            return null;
           
        }

        //Customer Order Block
        public ActionResult CustomerOrderBlock()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CustomerOrderBlock(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            return View(file.FileName);
        }
    }
}