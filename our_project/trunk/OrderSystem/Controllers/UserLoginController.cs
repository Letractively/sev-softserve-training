using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class UserLoginController : Controller
    {
        private OrderSystemEntities _db = new OrderSystemEntities();

        public ActionResult Login()
        {
            string ip = HttpContext.Request.UserHostAddress;
            if (BanCheck(ip))
            {
                ViewBag.Error = 3;
                return View();
            }
            var httpCookie = Request.Cookies["Login"];
            if (httpCookie != null) ViewBag.Name = httpCookie.Value;
            GetOnlineUsers().Remove(Session.SessionID);
            ViewBag.Error = 0;
            return View();
        }

        // POST: /OrderSystemUser/Login.cshtml
        [HttpPost]
        public ActionResult Login(Logon user)
        {
            ViewBag.Error = 0;
            if (ModelState.IsValid)
            {
                string ip = HttpContext.Request.UserHostAddress;
                if (BanCheck(ip))
                {
                    ViewBag.Error = 3;
                    return View();
                }
                if (UserValidation (user.UserLogin, user.UserPassword))
                {
                    Session["User"] = user.UserLogin;

                    if (user.RememberMe)
                    {
                        var cookie = new HttpCookie("Login", user.UserLogin);
                        DateTime dateTime = DateTime.Now;
                        TimeSpan span = new TimeSpan(24, 0, 0);
                        cookie.Expires = dateTime.Add(span);
                        Response.AppendCookie(cookie);
                    }

                    if (!GetOnlineUsers().Contains(Session.SessionID))
                    {
                        // юзверь уже залогинен
                        if (GetOnlineUsers().ContainsValue(user.UserLogin))
                        {
                            ViewBag.Error = 2;
                            return View();
                        }
                        // Только 50 юзверей могут войти
                        if (GetOnlineUsers().Count >= 50)
                        {
                            ViewBag.Error = 1;
                            return View();
                        }
                        //Добавляем Юзера в список онлайн
                        GetOnlineUsers().Add(Session.SessionID, user.UserLogin);
                    }
                    switch (_db.Users.Single(m => m.Login == user.UserLogin).Role)
                    {
                        case "Administrator": return RedirectToAction("Index", "OrderSystemUser");
                        case "Merchandiser": return RedirectToAction("AnalyzeOrders", "DisplayOrder", new {orderNumber = 1});
                        case "Supervisor": return RedirectToAction("Index", "Items");
                        case "Customer": return RedirectToAction("OrderList", "CustomerOrdering");
                    }
                }
                ModelState.AddModelError("Login", @"Such user does not exist in the system - please try again");
                ModelState.AddModelError("Password", @"Password is incorrect - please try again");
            }
            return View();
        }

        /// <summary>
        /// Получаем количество юзеров, работающих с сайтом
        /// </summary>
        /// <returns>Юзверы</returns>
        public Hashtable GetOnlineUsers()
        {
            return (Hashtable) HttpContext.Application["OnlineUsers"];
        }

        public bool UserValidation (string login, string password)
        {
            string ipAddress = HttpContext.Request.UserHostAddress;
            foreach (Users currentUser in _db.Users)
            {
                if (currentUser.Login.Equals(login) &&
                    currentUser.Password.Equals(password))
                    return true;
            }
            /*var ban = _db.Ban.SingleOrDefault(u => u.ip == ipAddress);
            if (ban == null)
            {
                var b = new Ban { ip = ipAddress, attempt = 1, bantime = null };
                _db.Ban.AddObject(b);
            }
            else
            {
                if (ban.bantime != null && DateTime.Compare((DateTime)ban.bantime, DateTime.Now) < 0)
                {
                    ban.attempt = 1;
                    ban.bantime = null;
                }
                else // Баним на 10 минут.
                    if (ban.attempt == 4)
                    { 
                        ban.bantime = DateTime.Now.AddMinutes(10);
                        ViewBag.Error = 3;
                    }
                    else ban.attempt = ban.attempt + 1;
            }*/
            _db.SaveChanges();
            return false;
        }

        /// <summary>
        /// Шифруем пароль алгоритмом MD5.
        /// Функцию необходимо юзать при записи пороля в БД.
        /// Также ее юзают при логине.
        /// </summary>
        /// <param name="text"> не зашифрованный пороль </param>
        /// <returns> зашифрованный пороль (32 символа) </returns>
        public string PasswordCrypter(string text)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(text));
            var crypt = new StringBuilder();
            foreach (byte value in data)
                crypt.Append(value.ToString("x2"));
            return crypt.ToString();
        }

        /// <summary>
        /// Проверка на баню
        /// </summary>
        /// <param name="ip"> IP юзверя </param>
        /// <returns> Результат проверки </returns>
        public bool BanCheck(string ip)
        {
            /*foreach (Ban b in _db.Ban)
            {
                if (b.bantime != null && b.ip == ip)
                {
                    if (DateTime.Compare((DateTime)b.bantime, DateTime.Now) > 0)
                        return true;
                    _db.Ban.DeleteObject(b);
                    break;
                }
            }
            _db.SaveChanges();*/
            return false;
        }
    }
}
