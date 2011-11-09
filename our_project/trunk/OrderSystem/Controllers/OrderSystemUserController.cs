using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OrderSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace OrderSystem.Controllers
{
    public class OrderSystemUserController : Controller
    {
        //
        // GET: /OrderSystemUser/
        //TODO Implement OrderSystemUserController
        OrderSystemEntities database=new OrderSystemEntities();
        public ActionResult Index()
        {
            ViewData["CountOfUsers"] = database.Users.Count();
            return View(database.Users.ToList());
        }
        [HttpPost]
        public ActionResult Index(string userInfo,string filtrationOption,string filtrationText)
        {
            List<Users> filterList = database.Users.ToList();
            #region FilterUsers
            if (userInfo=="UserName")
            {
                switch (filtrationOption)
                {
                    case "End's with":
                        filterList = filterList.Where(u => u.Login.EndsWith(filtrationText)).ToList();
                        break;
                    case "Start's with":
                        filterList = filterList.Where(u => u.Login.StartsWith(filtrationText)).ToList();
                        break;
                    default:
                        filterList = filterList.Where(u => u.Login.Contains(filtrationText)).ToList();
                        break;
                }
            }
            else
            {
                if(userInfo=="FirstName")
                {
                    switch (filtrationOption)
                    {
                        case "End's with":
                            filterList = filterList.Where(u => u.UserFName.EndsWith(filtrationText)).ToList();
                            break;
                        case "Start's with":
                            filterList = filterList.Where(u => u.UserFName.StartsWith(filtrationText)).ToList();
                            break;
                        default:
                            filterList = filterList.Where(u => u.UserFName.Contains(filtrationText)).ToList();
                            break;
                    }
                }
                else
                {
                    if(userInfo=="LastName")
                    {
                        switch (filtrationOption)
                        {
                            case "End's with":
                                filterList = filterList.Where(u => u.UserLName.EndsWith(filtrationText)).ToList();
                                break;
                            case "Start's with":
                                filterList = filterList.Where(u => u.UserLName.StartsWith(filtrationText)).ToList();
                                break;
                            default:
                                filterList = filterList.Where(u => u.UserLName.Contains(filtrationText)).ToList();
                                break;
                        }
                    }
                    else
                    {
                        if(userInfo=="Mail")
                        {
                            switch (filtrationOption)
                            {
                                case "End's with":
                                    filterList = filterList.Where(u => u.Mail.EndsWith(filtrationText)).ToList();
                                    break;
                                case "Start's with":
                                    filterList = filterList.Where(u => u.Mail.StartsWith(filtrationText)).ToList();
                                    break;
                                default:
                                    filterList = filterList.Where(u => u.Mail.Contains(filtrationText)).ToList();
                                    break;
                            }
                        }
                        else
                        {
                            if(userInfo=="Role")
                            {
                                switch (filtrationOption)
                                {
                                    case "End's with":
                                        filterList = filterList.Where(u => u.Role.EndsWith(filtrationText)).ToList();
                                        break;
                                    case "Start's with":
                                        filterList = filterList.Where(u => u.Role.StartsWith(filtrationText)).ToList();
                                        break;
                                    default:
                                        filterList = filterList.Where(u => u.Role.Contains(filtrationText)).ToList();
                                        break;
                                }
                            }
                            else
                            {
                                if(userInfo=="Region")
                                {
                                    switch (filtrationOption)
                                    {
                                        case "End's with":
                                            filterList = filterList.Where(u => u.Region.EndsWith(filtrationText)).ToList();
                                            break;
                                        case "Start's with":
                                            filterList = filterList.Where(u => u.Region.StartsWith(filtrationText)).ToList();
                                            break;
                                        default:
                                            filterList = filterList.Where(u => u.Region.Contains(filtrationText)).ToList();
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //TODO Filter Database and return model to view
            ViewData["CountOfUsers"] = filterList.Count;
            return View(filterList);
        }


        // GET: /OrderSystemUser/Login.cshtml
        public ActionResult Login()
        {
            if (Session["LoginCounter"] == null)
            {
                Session.Add("LoginCounter", 0);
                Session.Timeout = 5;
            }
            return this.View();
        }

        // POST: /OrderSystemUser/Login.cshtml
        [HttpPost]
        public ActionResult Login(OrderSystemUser user)
        {
            foreach (Users currentUser in database.Users)
            {
                MD5 md5Hasher = MD5.Create();
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(user.Password));
                StringBuilder crypt = new StringBuilder();
                foreach (byte value in data)
                    crypt.Append(value.ToString("x2"));
                if (currentUser.Login.Equals(user.LoginName) &&
                    currentUser.Password.Equals(crypt.ToString()))
                switch (currentUser.Role)
                {
                    case "Administrator": /* Add link */ break;
                    case "Merchandiser": /* Add link */ break;
                    case "Supervisor": /* Add link */ break;
                    case "Costumer": /* Add link */ break;
                }
                return this.RedirectToAction("Index");
            }
            // Increment counter
            Session["LoginCounter"] = (int)Session["LoginCounter"] + 1;
            Response.Write(Session["LoginCounter"]);
            return this.View();
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

        public ActionResult Delete(int id)
        {
            Users user = database.Users.Single(u => u.UserID == id);
            return View(user);
        }

        //
        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO
            Users user = database.Users.Single(u => u.UserID == id);
            database.Users.DeleteObject(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
