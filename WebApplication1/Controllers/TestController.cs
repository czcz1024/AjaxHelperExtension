using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    using System.Threading;

    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(string str)
        {
            return Content(str);
        }

        public ActionResult AjaxLoad()
        {
            Thread.Sleep(3000);
            return View();
            //return Content("ajax load " + DateTime.Now);
        }

        public ActionResult AjaxLoad2()
        {
            return Content("ajax load " + DateTime.Now);
        }
    }
}