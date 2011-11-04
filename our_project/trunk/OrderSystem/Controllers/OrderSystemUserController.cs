using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderSystem.Controllers
{
    public class OrderSystemUserController : Controller
    {
        //
        // GET: /OrderSystemUser/
        //TODO Implement OrderSystemUserController
        public ActionResult Index()
        {
            //TODO Get Users Count From EntityModel
            ViewData["CountOfUsers"] = 1;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userInfo,string filtrationOption,string filtrationText)
        {
            
            //TODO Filter Database and return model to view
            return View();
        }
    }
}
