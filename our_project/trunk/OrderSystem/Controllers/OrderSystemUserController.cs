using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OrderSystem.Models;

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

        // GET: /OrderSystemUser/Register.cshtml
        public ActionResult Register()
        {
            return this.View();
        }

        // POST: /OrderSystemUser/Register.cshtml
        [HttpPost]
        public ActionResult Register(OrderSystemUser user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add server-side validation
                // TODO: Add user to DB
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Edit.aspx
        public ActionResult Edit()
        {
            // TODO: Parameter - user to Edit
            return this.View(new OrderSystemUser());
        }

        // POST: /OrderSystemUser/Edit.cshtml
        [HttpPost]
        public ActionResult Edit(OrderSystemUser user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add server-side validation
                // TODO: Edit user in DB
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Duplicate.aspx
        public ActionResult Duplicate()
        {
            // TODO: Parameter - user to Duplicate
            return this.View(new OrderSystemUser());
        }

        // POST: /OrderSystemUser/Duplicate.cshtml
        [HttpPost]
        public ActionResult Duplicate(OrderSystemUser user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add server-side validation
                // TODO: Duplicate user in DB
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

    }
}
