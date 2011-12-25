using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderSystem.Models;
using System.Collections;
namespace OrderSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerOrderingController : Controller
    {
        OrderSystemEntities database = new OrderSystemEntities();

        // GET: /CustomerOrdering/OrderList.cshtml
        public ActionResult OrderList()
        {
            foreach (Users user in database.Users)
            {
                if (user.Login == HttpContext.User.Identity.Name)
                {
                    return View(user.Orders.ToList());
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult OrderList(string filterType, string statusOptions, string roleOptions, string searchType, string searchText)
        {
            List<Orders> filterList = null;
            foreach (Users user in database.Users)
            {
                if (user.Login == HttpContext.User.Identity.Name)
                {
                    filterList = user.Orders.ToList();
                }
            }
            if (filterList == null)
                return this.View();

            #region FilterOrders
            if (filterType == "Status")
            {
                if( statusOptions != "None" )
                {
                        filterList = filterList.Where(u => u.Status.Equals(statusOptions)).ToList();
                }
            }
            else
            {
                if(filterType == "Role") 
                {
                    if( roleOptions != "None" )
                        {
                           filterList = filterList.Where(u => u.Status.Equals(roleOptions)).ToList();
                        }
                }
            }

            if (searchType == "Order Name")
            {
                filterList = filterList.Where(u => u.OrderNumber.Equals(searchText)).ToList();
            }
            else
            {
                if(searchType == "Status")
                {
                    filterList = filterList.Where(u => u.Status.Equals(searchText)).ToList();
                }
                else
                {
                    if(searchType == "Assignee")
                    {
                        filterList = filterList.Where(u => u.Assignee.Equals(searchText)).ToList();
                    }
                }
            }
            #endregion
            return View(filterList);
        }

        public ActionResult Delete(int id)
        {
            Orders order = database.Orders.Single(o => o.OrderID == id);
            return View(order);
        }

        //
        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = database.Orders.Single(o => o.OrderID == id);
            database.Orders.DeleteObject(order);
            database.SaveChanges();
            return RedirectToAction("OrderList");
        }

        // GET: /CustomerOrdering/Create.cshtml
        public ActionResult Create()
        {
            CustomerOrderInfo newOrder = new CustomerOrderInfo();
            List<string> assignies = new List<string>();
            foreach (Users user in database.Users.Where(user => user.Role == "Merchandiser"))
            {
                assignies.Add(user.Login);
            }

            newOrder.Merchandisers = new List<string>(assignies);
            newOrder.OrderingDate = DateTime.Today;
            newOrder.PreferableDeliveryDate = null;
            newOrder.DeliveryDate = null;
            newOrder.ExpiredDate = (DateTime)DateTime.Today;
            newOrder.MakeDate = (DateTime)DateTime.Today;
            newOrder.Status = "Created";
            newOrder.ItemsOrder = new List<CustomerItemsInfo>();
            List<string> orderNumbers = database.Orders.Select<Orders, string>(order => order.OrderNumber).ToList<string>();
            newOrder.OrderNumber = getNewOrderNumber(orderNumbers);
            return View(newOrder);
        }

        // POST: /CustomerOrdering/Create.cshtml
        [HttpPost]
        public ActionResult Create(CustomerOrderInfo order)
        {
            if (order.Command == "Add Item")
            {
                Orders dbOrder = new Orders();
                string curUserLogin = HttpContext.User.Identity.Name;

                dbOrder.UserID = database.Users.Single(user => user.Login.ToLower() == curUserLogin.ToLower()).UserID;
                dbOrder.CardID = null;
                dbOrder.OrderNumber = order.OrderNumber;
                dbOrder.Status = "Created";
                dbOrder.OrderingDate = DateTime.Today;
                dbOrder.PreferableDeliveryDate = order.PreferableDeliveryDate;
                dbOrder.Assignee = order.Assignee;
                dbOrder.TotalPrice = order.TotalPrice;
                dbOrder.Discount = 0;
                dbOrder.IsGift = false;
                database.Orders.AddObject(dbOrder);
                database.SaveChanges();
                int addedOrderID = database.Orders.FirstOrDefault(ord => ord.OrderNumber == order.OrderNumber).OrderID;
                return RedirectToAction("AddItem", new { orderID = addedOrderID });
            }
            // TODO: When items search will be ready add validation for items
            List<string> orderNumbers = database.Orders.Select<Orders, string>(order1 => order1.OrderNumber).ToList<string>();
            if (orderNumbers.Contains(order.OrderNumber))
            {
                ModelState.AddModelError("OrderNumber", "Order Number already exists in the system./nPlease re-type it or just leave it blank");
            }
            if (order.PreferableDeliveryDate != null &&
                       order.PreferableDeliveryDate < order.OrderingDate)
            {
                ModelState.AddModelError("PreferableDeliveryDate", "Preferable delivery date goes before Date of ordering./nPlease re-choose it or just leave it blank");
            }
            // Because PreferableDeliveryDate by default = "  /  /"
            if (order.PreferableDeliveryDate == null)
            {
                ModelState["PreferableDeliveryDate"].Errors.Clear();
            }
            order.DeliveryDate = null;

            // If customer just saves order, skiping Credit Card Validation
            for (int i = 4; i < ModelState.Count; i++)
            {
                ModelState.Values.ElementAt(i).Errors.Clear();
            }
            if (ModelState.IsValid)
            {
                Orders dbOrder = new Orders();
                string curUserLogin = HttpContext.User.Identity.Name;

                dbOrder.UserID = database.Users.Single(user => user.Login.ToLower() == curUserLogin.ToLower()).UserID;
                dbOrder.CardID = null;
                dbOrder.OrderNumber = order.OrderNumber;
                dbOrder.Status = "Created";
                dbOrder.OrderingDate = DateTime.Today;
                dbOrder.PreferableDeliveryDate = order.PreferableDeliveryDate;
                dbOrder.Assignee = order.Assignee;
                dbOrder.TotalPrice = order.TotalPrice;
                dbOrder.Discount = 0;
                dbOrder.IsGift = false;
                database.Orders.AddObject(dbOrder);
                database.SaveChanges();
                int addedOrderID = database.Orders.FirstOrDefault(ord => ord.OrderNumber == order.OrderNumber).OrderID;
                return RedirectToAction("Edit", new { orderID = addedOrderID });
            }
            else
            {
                List<string> assignies = new List<string>();
                foreach (Users user in database.Users.Where(user => user.Role == "Merchandiser"))
                {
                    assignies.Add(user.Login);
                }
                order.Merchandisers = new List<string>(assignies);
                order.ItemsOrder = new List<CustomerItemsInfo>();
                return View(order);
            }
        }


        // GET: /CustomerOrdering/Edit.cshtml
        public ActionResult Edit(int orderID)
        {
            Orders dbOrder = database.Orders.FirstOrDefault(ord => ord.OrderID == orderID);

            // Checks is order is not exists
            if (dbOrder == null)
            {
                return RedirectToActionPermanent("Index");
            }

            // Checks is order belongs to user
            string curUserLogin = HttpContext.User.Identity.Name;
            
            int curUserId = database.Users.Single(user => user.Login.ToLower() == curUserLogin.ToLower()).UserID;
            if (dbOrder.UserID != curUserId)
            {
                return RedirectToActionPermanent("Index");
            }

            Card dbCard = database.Card.FirstOrDefault(card => card.CardID == dbOrder.CardID);

            CustomerOrderInfo order = new CustomerOrderInfo();
            order.Assignee = dbOrder.Assignee;
            order.DeliveryDate = dbOrder.DeliveryDate;
            order.ItemsCount = dbOrder.ItemsOrder.Count;

            order.OrderNumber = dbOrder.OrderNumber;
            List<string> assignies = new List<string>();
            foreach (Users user in database.Users.Where(user => user.Role == "Merchandiser"))
            {
                assignies.Add(user.Login);
            }
            order.OrderID = dbOrder.OrderID;
            // TODO: Delete when items search will be done
            order.ItemsOrder = new List<CustomerItemsInfo>();
            initItems(order);
            order.Merchandisers = assignies;
            order.OrderingDate = dbOrder.OrderingDate;
            order.PreferableDeliveryDate = dbOrder.PreferableDeliveryDate;
            order.Status = dbOrder.Status;
            order.TotalPrice = dbOrder.TotalPrice;

            if (dbCard != null)
            {
                order.CardNumber = dbCard.CardNumber;
                order.CardType = dbCard.CardType;
                order.CVV2Code = dbCard.CVV2Code;
                order.ExpiredDate = dbCard.ExpiredDate;
                order.IssueNumber = dbCard.IssueNumber;
                order.MakeDate = dbCard.MakeDate;
            }

            return View(order);
        }

        private void initItems(CustomerOrderInfo order)
        {
            foreach (ItemsOrder item in database.ItemsOrder.Where(it => it.OrderID == order.OrderID))
            {
                CustomerItemsInfo ordItem = new CustomerItemsInfo();
                ordItem.Dimension = item.Dimension;
                ordItem.ItemNumber = database.Items.SingleOrDefault(it1 => it1.ItemID == item.ItemInfoID).ItemID.ToString();
                ordItem.Price = database.Items.SingleOrDefault(it1 => it1.ItemID == item.ItemInfoID).Price;
                ordItem.Quantity = item.Quantity;
                ordItem.ItemName = database.Items.SingleOrDefault(it1 => it1.ItemID == item.ItemInfoID).ItemName;
                ordItem.ItemDescription = database.Items.SingleOrDefault(it1 => it1.ItemID == item.ItemInfoID).ItemDescriprion;
                switch (ordItem.Dimension)
                {
                    case "Box":
                        ordItem.PricePerLine = ordItem.Price * ordItem.Quantity * 5;
                        break;
                    case "Item":
                        ordItem.PricePerLine = ordItem.Price * ordItem.Quantity;
                        break;

                    case "Package":
                        ordItem.PricePerLine = ordItem.Price * ordItem.Quantity * 10;
                        break;
                    default:
                        ordItem.PricePerLine = ordItem.Price * ordItem.Quantity;
                        break;
                }
                order.ItemsOrder.Add(ordItem);
            }

        }


        // POST: /CustomerOrdering/Create.cshtml
        [HttpPost]
        public ActionResult Edit(CustomerOrderInfo order)
        {
            if (order.Command == "Add Item")
            {
                return RedirectToAction("AddItem", new { orderID = order.OrderID });
            }

            List<string> assignies = new List<string>();
            foreach (Users user in database.Users.Where(user => user.Role == "Merchandiser"))
            {
                assignies.Add(user.Login);
            }
            order.Merchandisers = assignies;
            List<string> orderNumbers = database.Orders.Select<Orders, string>(order1 => order1.OrderNumber).ToList<string>();
            if (orderNumbers.Contains(order.OrderNumber) && 
                order.OrderNumber != database.Orders.FirstOrDefault(ord => ord.OrderID == order.OrderID).OrderNumber)
            {
                ModelState.AddModelError("OrderNumber", "Order Number already exists in the system./nPlease re-type it or just leave it blank");
            }
            if (order.PreferableDeliveryDate != null &&
                       order.PreferableDeliveryDate < order.OrderingDate)
            {
                ModelState.AddModelError("PreferableDeliveryDate", "Preferable delivery date goes before Date of ordering./nPlease re-choose it or just leave it blank");
            }
            // Because PreferableDeliveryDate by default = "  /  /"
            if (order.PreferableDeliveryDate == null)
            {
                ModelState["PreferableDeliveryDate"].Errors.Clear();
            }
            order.DeliveryDate = null;
            if (order.Command == "Save")
            {
                // If customer just saves order, skiping Credit Card Validation
                for (int i = 4; i < ModelState.Count; i++)
                {
                    ModelState.Values.ElementAt(i).Errors.Clear();
                }
                if (ModelState.IsValid)
                {
                    Orders dbOrder = new Orders();
                    string curUserLogin = HttpContext.User.Identity.Name;
                    dbOrder.UserID = database.Users.Single(user => user.Login.ToLower() == curUserLogin.ToLower()).UserID;
                    dbOrder.CardID = null;
                    dbOrder.OrderNumber = order.OrderNumber;
                    dbOrder.OrderID = order.OrderID;
                    dbOrder.Status = "Created";
                    dbOrder.OrderingDate = order.OrderingDate;
                    dbOrder.PreferableDeliveryDate = order.PreferableDeliveryDate;
                    dbOrder.Assignee = order.Assignee;
                    dbOrder.TotalPrice = order.TotalPrice;
                    dbOrder.Discount = 0;
                    dbOrder.IsGift = false;
                    database.Orders.Attach(database.Orders.Single(ord => ord.OrderID == dbOrder.OrderID));
                    database.ApplyCurrentValues("Orders", dbOrder);
                    database.SaveChanges();
                    int editedOrderID = dbOrder.OrderID;
                    return View(order);
                }
                else
                {
                    return View(order);
                }
            }
            else if (order.Command == "Order")
            {
                // TODO: Delete, whent items search will be done
                ModelState.Values.ElementAt(16).Errors.Clear();

                if (order.ExpiredDate < DateTime.Today.AddDays(3))
                {
                    ModelState.AddModelError("ExpiredDate", "Order Number already exists in the system./nPlease re-type it or just leave it blank");
                }
                if (order.PreferableDeliveryDate != null &&
                         order.PreferableDeliveryDate < order.OrderingDate)
                {
                    ModelState.AddModelError("ServerValidationError", "Preferable delivery date goes before Date of ordering./nPlease re-choose it or just leave it blank");
                }
                if (ModelState.IsValid)
                {
                    Card dbCard;
                    Orders dbOrder = new Orders();
                    string curUserLogin = HttpContext.User.Identity.Name;
                    dbOrder.UserID = database.Users.Single(user => user.Login.ToLower() == curUserLogin.ToLower()).UserID;
                    dbCard = database.Card.SingleOrDefault(card => card.CardNumber == order.CardNumber);
                    if (dbCard == null)
                    {
                        dbCard = new Card();
                        dbCard.CardNumber = order.CardNumber;
                        dbCard.CardType = order.CardType;
                        dbCard.CVV2Code = order.CVV2Code;
                        dbCard.ExpiredDate = (DateTime)order.ExpiredDate;
                        dbCard.IssueNumber = order.IssueNumber;
                        dbCard.MakeDate = order.MakeDate;
                        database.Card.AddObject(dbCard);
                        database.SaveChanges();
                    }
                    dbOrder.CardID = database.Card.FirstOrDefault(card => card.CardNumber == dbCard.CardNumber).CardID;
                    dbOrder.OrderID = order.OrderID;
                    dbOrder.OrderNumber = order.OrderNumber;
                    dbOrder.Status = "Ordered";
                    dbOrder.OrderingDate = DateTime.Today;
                    dbOrder.PreferableDeliveryDate = order.PreferableDeliveryDate;
                    dbOrder.Assignee = order.Assignee;
                    dbOrder.TotalPrice = order.TotalPrice;
                    dbOrder.Discount = 0;
                    dbOrder.IsGift = false;
                    database.Orders.Attach(database.Orders.Single(ord => ord.OrderID == dbOrder.OrderID));
                    database.ApplyCurrentValues("Orders", dbOrder);
                    database.SaveChanges();
                    int editedOrderID = dbOrder.OrderID;
                    return View(order);

                }
                else
                {
                    return View(order);
                }
            }
            return View(order);
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

        // GET: /CustomerOrdering/AddItem.cshtml
        public ActionResult AddItem(int orderID)
        {
            ViewData["OrderID"] = orderID;
            return View();
        }
    }
}
