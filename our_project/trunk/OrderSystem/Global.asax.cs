using System;
using System.Collections;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrderSystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "UserLogin", action = "Login", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            Application["OnlineUsers"] = new Hashtable();
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /*При окончании сессии проверяем есть ли с таким SessionID User в Application["OnlineUsers"],
         * и если есть удаляем его.
         */
        protected void Session_Start(object sender,EventArgs e)
        {
            
        }
        protected void Session_End(object sender,EventArgs e)
        {
            Application.Lock();
                if (((Hashtable)Application["OnlineUsers"]).ContainsKey(Session.SessionID))
                {
                    ((Hashtable)Application["OnlineUsers"]).Remove(Session.SessionID);
                }
            Application.UnLock();
        }
    }
}