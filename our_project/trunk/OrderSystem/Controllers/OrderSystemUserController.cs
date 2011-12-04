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
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            ViewData["CountOfUsers"] = database.Users.Count();
            return View(database.Users.ToList());
        }
        [HttpPost, Authorize(Roles = "Administrator")]
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
        [Authorize]
        public ActionResult UserDetails()
        {
            foreach (Users user in database.Users)
            {
                if (user.Login == (string)Session["User"])
                {
                    var maxTresholdRank = (from r in database.Rank
                                           orderby r.RankTreshold descending
                                           select r).First();
                    Decimal moneyToNextRank = Decimal.Parse(maxTresholdRank.RankTreshold.ToString()) - (Decimal)user.Balance;
                    string nextRankName = maxTresholdRank.RankName;
                    foreach (Rank rank in database.Rank)
                    {
                        decimal curTreshold = Decimal.Parse(rank.RankTreshold.ToString());
                        if (curTreshold > user.Balance && curTreshold < moneyToNextRank)
                        {
                            moneyToNextRank = curTreshold;
                            nextRankName = rank.RankName;
                        }
                    }

                    NextRankInfo rankInfo = new NextRankInfo();
                    rankInfo.MoneyToNextRank = (double)moneyToNextRank;
                    rankInfo.NextRankName = nextRankName;
                    ViewBag.NextRankInfo = rankInfo;

                    return this.View(user);
                }
            }

            return this.View();

        }

        // GET: /OrderSystemUser/Register.cshtml
        [Authorize(Roles = "Administrator")]
        public ActionResult Register()
        {
            return this.View();
        }

        // POST: /OrderSystemUser/Register.cshtml
        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Register(Users user)
        {
            if (user.UserFName != null)
            {
                user.UserFName = user.UserFName.Trim();
            }
            if (user.UserLName != null)
            {
                user.UserLName = user.UserLName.Trim();
            }
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
                        user.Rank = 0;
                        user.RankType = 0;
                        user.Balance = 0;
                    }
                    else
                    {
                        user.Rank = null;
                        user.RankType = null;
                        user.Balance = null;
                    }
                    database.Users.AddObject(user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Edit.cshtml
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit( int id )
        {
            Users user = database.Users.Single(u => u.UserID == id);
            //user.ConfirmPassword = user.Password;
            return this.View(user);
        }

        // POST: /OrderSystemUser/Edit.cshtml
        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Edit(Users user)
        {
            if (user.UserFName != null)
            {
                user.UserFName = user.UserFName.Trim();
            }
            if (user.UserLName != null)
            {
                user.UserLName = user.UserLName.Trim();
            }
            List<Orders> a = user.Orders.ToList();
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
                    if (user.Role == "Customer")
                    {
                        if (user.Rank == null)
                        {
                            user.Rank = 0;
                        }
                        if (user.RankType == null)
                        {
                            user.RankType = 0;
                        }
                        if (user.Balance == null)
                        {
                            user.Balance = 0;
                        }
                    }
                    database.Users.Attach(database.Users.Single(u => u.UserID == user.UserID));
                    database.ApplyCurrentValues("Users", user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }

        // GET: /OrderSystemUser/Duplicate.cshtml
        [Authorize(Roles = "Administrator")]
        public ActionResult Duplicate(int id)
        {
            Users user = database.Users.Single(u => u.UserID == id);
            user.Password = "";
            user.Login = "";
            return this.View(user);
        }

        // POST: /OrderSystemUser/Duplicate.cshtml
        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Duplicate(Users user)
        {
            if (user.UserFName != null)
            {
                user.UserFName = user.UserFName.Trim();
            }
            if (user.UserLName != null)
            {
                user.UserLName = user.UserLName.Trim();
            }
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
                        user.Rank = 0;
                        user.RankType = 0;
                        user.Balance = 0;
                    }
                    else
                    {
                        user.Rank = null;
                        user.RankType = null;
                        user.Balance = null;
                    }
                    database.Users.AddObject(user);
                    database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Users user = database.Users.Single(u => u.UserID == id);
            return View(user);
        }

        //
        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete"), Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Users user = database.Users.Single(u => u.UserID == id);
            //Проверяем онлайн ли пользователь, если онлайн даем ошибку в представление
            if(((Hashtable)HttpContext.Application["OnlineUsers"]).ContainsValue(user.Login))
            {
                
                ModelState.AddModelError("Online",@"User is online!");
                return this.View(user);
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


