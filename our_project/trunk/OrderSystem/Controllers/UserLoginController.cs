using System;
using System.Collections;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Forms;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class UserLoginController : Controller
    {
        OrderSystemEntities database = new OrderSystemEntities();

        public ActionResult Login()
        {
            GetOnlineUsers().Remove(Session.SessionID);
            if (Session["LoginCounter"] == null)
            {
                Session.Add("LoginCounter", 0);
                Session.Timeout = 5;
            }
            ViewBag.Error = 0;
            return this.View();
        }

        // POST: /OrderSystemUser/Login.cshtml
        [HttpPost]
        public ActionResult Login(Logon user)
        {
            ViewBag.Error = 0;
            if (ModelState.IsValid)
            {
                foreach (Users currentUser in database.Users)
                {
                    if (currentUser.Login.Equals(user.UserLogin) &&
                        currentUser.Password.Equals(user.UserPassword))
                    {
                        Session["User"] = currentUser.Login;
                        if (! GetOnlineUsers().Contains(Session.SessionID))
                        {
                            // юзверь уже залогинен
                            if (GetOnlineUsers().ContainsValue(user.UserLogin))
                            {
                                ViewBag.Error = 2;
                                return this.View();
                            }
                            // Только 50 юзверей могут войти
                            if (GetOnlineUsers().Count >= 50)
                            {
                                ViewBag.Error = 1;
                                return this.View();
                            }
                            //Добавляем Юзера в список онлайн
                            GetOnlineUsers().Add(Session.SessionID, currentUser.Login);
                        }
                        switch (currentUser.Role)
                        {
                            case "Administrator": return RedirectToAction("Index", "OrderSystemUser");
                            case "Merchandiser": return RedirectToAction("AnalyzeOrders", "DisplayOrder");
                            case "Supervisor": /* Add link */ break;
                            case "Costumer": /* Add link */ break;
                        }
                    }
                    ModelState.AddModelError("Login", @"Such user does not exist in the system - please try again");
                    ModelState.AddModelError("Password", @"Password is incorrect - please try again");

                }
            }
            // Increment counter
            Session["LoginCounter"] = (int) Session["LoginCounter"] + 1;
            Response.Write(Session["LoginCounter"]);
            return this.View();
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
        /// Получаем количество юзеров, работающих с сайтом
        /// </summary>
        /// <returns>Юзверы</returns>
        public Hashtable GetOnlineUsers()
        {
            return (Hashtable) HttpContext.Application["OnlineUsers"];
        }
    }
}
