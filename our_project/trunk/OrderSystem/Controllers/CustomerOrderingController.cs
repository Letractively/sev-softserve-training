using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{

    public class CustomerOrderingController : Controller
    {
        OrderSystemEntities database = new OrderSystemEntities();
        //
        // GET: /CustomerOrdering/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /CustomerOrdering/Create.cshtml
        public ActionResult Create()
        {
            OrderSystem.Models.Orders newOrder = new OrderSystem.Models.Orders();
            List<string> assignies = new List<string>();
            foreach(Users user in database.Users.Where(user => user.Role == "Merchandiser"))
            {
                assignies.Add(user.Login);
            }
            
            newOrder.Merchandisers = new List<string>(assignies);
            newOrder.OrderingDate = DateTime.Today;
            newOrder.Status = "Created";
            List<string> orderNumbers = database.Orders.Select<Orders, string>(order => order.OrderNumber).ToList<string>();
            newOrder.OrderNumber = getNewOrderNumber(orderNumbers);
            return View(newOrder);
        }

        /// <summary>
        /// Searches for next free order number
        /// </summary>
        /// <param name="orderNumbers">Already exists order numbers in db</param>
        /// <returns>Free order number</returns>
        private string getNewOrderNumber(List<string> orderNumbers)
        {
            string orderNumber = "000001";
            
            while (orderNumbers.Contains(orderNumber))
            {
                int curNumber;
                if (Int32.TryParse(orderNumber, out curNumber))
                {
                    curNumber++;
                    int curOrderNumberLength = orderNumber.Length;
                    orderNumber = curNumber.ToString();
                    while (orderNumber.Length < curOrderNumberLength)
                    {
                        orderNumber = "0" + orderNumber;
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return orderNumber;
        }


    }
}
