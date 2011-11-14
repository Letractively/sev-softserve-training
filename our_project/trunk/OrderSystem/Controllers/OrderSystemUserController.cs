 using System;
 using System.Collections;
 using System.Collections.Generic;
using System.Linq;
 using System.Web.Mvc;
using OrderSystem.Models;

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

        // GET: /OrderSystemUser/UserDetails.cshtml
        public ActionResult UserDetails()
        {
            return this.View();
        }


        // GET: /OrderSystemUser/Register.cshtml
        public ActionResult Register()
        {
            return this.View();
        }

        // POST: /OrderSystemUser/Register.cshtml
        [HttpPost]
        public ActionResult Register(Users user)
        {
            user.UserFName = user.UserFName.Trim();
            user.UserLName = user.UserLName.Trim();
            if (ModelState.IsValid)
            {
                if (isLoginExists(user.Login))
                {
                    ModelState.AddModelError("Login", Resources.Shared.ErrorRes.LoginExistsInDB);
                    return this.View();
                }
                else
                {
                    if (user.Role == "Customer")
                    {
                        user.Rank = 1;
                        user.RankType = 1;
                    }
                    else
                    {
                        user.Rank = 0;
                        user.RankType = 0;
                    }
                    database.Users.AddObject(user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Edit.cshtml
        public ActionResult Edit( int id )
        {
            Users user = database.Users.Single(u => u.UserID == id);
            //user.ConfirmPassword = user.Password;
            return this.View(user);
        }

        // POST: /OrderSystemUser/Edit.cshtml
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            user.UserFName = user.UserFName.Trim();
            user.UserLName = user.UserLName.Trim();
            if (ModelState.IsValid)
            {
                if (isLoginExists(user.Login) &&
                    (user.Login != database.Users.Single(u => u.UserID == user.UserID).Login))
                {
                    ModelState.AddModelError("Login", Resources.Shared.ErrorRes.LoginExistsInDB);
                    return this.View();
                }
                else
                {
                    database.Users.Attach(database.Users.Single(u => u.UserID == user.UserID));
                    database.ApplyCurrentValues("Users", user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Duplicate.cshtml
        public ActionResult Duplicate(int id)
        {
            Users user = database.Users.Single(u => u.UserID == id);
            user.Password = "";
            user.Login = "";
            return this.View(user);
        }

        // POST: /OrderSystemUser/Duplicate.cshtml
        [HttpPost]
        public ActionResult Duplicate(Users user)
        {
            user.UserFName = user.UserFName.Trim();
            user.UserLName = user.UserLName.Trim();
            if (ModelState.IsValid)
            {
                if (isLoginExists(user.Login))
                {
                    ModelState.AddModelError("Login", Resources.Shared.ErrorRes.LoginExistsInDB);
                    return this.View();
                }
                else
                {
                    if (user.Role == "Customer")
                    {
                        user.Rank = 1;
                        user.RankType = 1;
                    }
                    else
                    {
                        user.Rank = 0;
                        user.RankType = 0;
                    }
                    database.Users.AddObject(user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
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
            Users user = database.Users.Single(u => u.UserID == id);
            //Проверяем онлайн ли пользователь, если онлайн даем ошибку в представление
            if(((Hashtable)HttpContext.Application["OnlineUsers"]).ContainsValue(user.Login))
            {
                
                ModelState.AddModelError("Online",@"User is online!");
                return this.View();
            }
            database.Users.DeleteObject(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Checks is user with input login is already exists in database
        /// </summary>
        /// <param name="user">Inputed login</param>
        /// <returns>true - user with input login exists in database</returns>
        private bool isLoginExists(string login)
        {
            try
            {
                database.Users.First(u => u.Login.ToLower() == login.ToLower());
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}


