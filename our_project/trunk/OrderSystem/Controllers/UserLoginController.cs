using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class UserLoginController : Controller
    {
        OrderSystemEntities database = new OrderSystemEntities();

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
        public ActionResult Login(Logon user)
        {
            if (ModelState.IsValid)
            {
                foreach (Users currentUser in database.Users)
                {
                    MD5 md5Hasher = MD5.Create();
                    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(user.UserPassword));
                    StringBuilder crypt = new StringBuilder();
                    foreach (byte value in data)
                        crypt.Append(value.ToString("x2"));
                    if (currentUser.Login.Equals(user.UserLogin) &&
                        currentUser.Password.Equals(user.UserPassword))
                        switch (currentUser.Role)
                        {
                            case "Administrator":
                                {
                                    Session["User"] = currentUser.Login;
                                    //Добавляем юзера в список онлайн
                                    if (!((Hashtable)HttpContext.Application["OnlineUsers"]).Contains(Session.SessionID))
                                    ((Hashtable) HttpContext.Application["OnlineUsers"]).Add(Session.SessionID,currentUser.Login);
                                }
                                return RedirectToAction("Index", "OrderSystemUser");
                            case "Merchandiser": 
                                { 
                                    Session["User"] = currentUser.Login;
                                    if (!((Hashtable)HttpContext.Application["OnlineUsers"]).Contains(Session.SessionID))
                                    ((Hashtable)HttpContext.Application["OnlineUsers"]).Add(Session.SessionID, currentUser.Login); 
                                }
                                return RedirectToAction("AnalyzeOrders", "DisplayOrder");
                            case "Supervisor": /* Add link */ break;
                            case "Costumer": /* Add link */ break;
                        }
                }
            }
            // Increment counter
            Session["LoginCounter"] = (int)Session["LoginCounter"] + 1;
            Response.Write(Session["LoginCounter"]);
            return this.View();
        }

    }
}
