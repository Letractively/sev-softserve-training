using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using OrderSystem.Models;
using System.Collections.Generic;

namespace OrderSystem.Controllers
{
    public class DisplayOrderController : Controller
    {
        private OrderSystemEntities database = new OrderSystemEntities();
        private static int OrderID;

        // GET: /CustomerOrdering/OrderList.cshtml
        public ActionResult MerchandiserOrderList()
        {
            return View(database.Orders.ToList());
        }

        [HttpPost]
        public ActionResult MerchandiserOrderList(string filterType, string statusOptions, string roleOptions, string searchType, string searchText)
        {
            List<Orders> filterList = database.Orders.ToList();

            if (filterList == null)
                return this.View();

            #region FilterOrders
            if (filterType == "Status")
            {
                if (statusOptions != "None")
                {
                    filterList = filterList.Where(u => u.Status.Equals(statusOptions)).ToList();
                }
            }
            else
            {
                if (filterType == "Role")
                {
                    if (roleOptions != "None")
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
                if (searchType == "Status")
                {
                    filterList = filterList.Where(u => u.Status.Equals(searchText)).ToList();
                }
                else
                {
                    if (searchType == "Assignee")
                    {
                        filterList = filterList.Where(u => u.Assignee.Equals(searchText)).ToList();
                    }
                }
            }
            #endregion
            return View(filterList);
        }

        private void InitializeViewModel(int id, ViewModel model)
        {
            var query1 = (from item in database.Items
                          join order in database.ItemsOrder
                          on item.ItemID equals order.ItemInfoID
                          where order.OrderID == id
                          select new OrderedItemsInfo()
                          {
                              ItemNumber = item.ItemID,
                              ItemName = item.ItemName,
                              ItemDescription = item.ItemDescriprion,
                              Dimension = order.Dimension,
                              Price = item.Price,
                              Quantity = order.Quantity,
                              PricePerLine = item.Price * order.Quantity
                          }
                         );

            int itemsCounter = 0;
            var dt = new DimensionType();
            List<OrderedItemsInfo> tmp = query1.ToList();
            foreach (OrderedItemsInfo info in tmp)
            {
                itemsCounter += dt.GetDimension(info.Dimension) * info.Quantity;
                info.PricePerLine = info.PricePerLine * dt.GetDimension(info.Dimension);
            }
            model.OrderedItems = tmp;

            var query2 = (from user in database.Users
                          join order in database.Orders
                          on user.UserID equals order.UserID
                          join rank in database.Rank
                          on user.RankType equals rank.RankID
                          where order.OrderID == id
                          select new TotalOrderInfo()
                          {
                              CustomerName = user.UserFName,
                              CustomerType = rank.RankName,
                              OrderNumber = order.OrderID,
                              TotalPrice = order.TotalPrice,
                              TotalNumberOfItems = itemsCounter,
                              Assignee = order.Assignee,
                              DateOfOrdering = order.OrderingDate,
                              PreferableDeliveryDate = order.PreferableDeliveryDate,
                              DeliveryDate = order.DeliveryDate,
                              IsGift = order.IsGift,
                              IsOrdered = order.Status.Equals("Ordered") || order.Status.Equals("Delivered"),
                              IsDelivered = order.Status.Equals("Delivered")
                          }
                         );
            model.OrderInfo = query2.First();
        }

        public ActionResult AnalyzeOrders(int orderNumber)
        {
            ViewBag.OrderDisabled = true;
            OrderID = orderNumber;
            var model = new ViewModel();
            InitializeViewModel(orderNumber, model);
            return View(model);
        }

        [HttpPost]
        public ActionResult AnalyzeOrders(ViewModel model)
        {
            if (model.Action.Equals("Cancel"))
                return RedirectToAction("AnalyzeOrders", new { orderNumber = OrderID });

            if (model.Action.Equals("Save"))
            {
                if (model.OrderInfo.DeliveryDate == null)
                {
                    ModelState.AddModelError("NullDate", @"Delivery Date field is empty !!! Please select date !");
                    ViewBag.OrderDisabled = true;
                }
                else
                {
                    DateTime dt1 = database.Orders.Single(m => m.OrderID == OrderID).OrderingDate;
                    DateTime dt2 = (DateTime)model.OrderInfo.DeliveryDate;
                    if (DateTime.Compare(dt2, dt1) < 0)
                    {
                        ModelState.AddModelError("IncorrectDate", @"Delivery Date is incorrect !!! Please try again !");
                        ViewBag.OrderDisabled = true;
                    }
                    else ViewBag.OrderDisabled = false;
                }
            }
            else
                if (model.Action.Equals("Order"))
                {
                    ViewBag.OrderDisabled = false;
                    Orders order = database.Orders.FirstOrDefault(ord => ord.OrderID == OrderID);
                    order.DeliveryDate = Convert.ToDateTime(model.OrderInfo.DeliveryDate);
                    order.IsGift = model.OrderInfo.IsGift;
                    if (model.OrderInfo.IsOrdered && model.OrderInfo.IsDelivered)
                        order.Status = "Delivered";
                    else
                        if (model.OrderInfo.IsOrdered)
                            order.Status = "Ordered";
                    database.SaveChanges();
                }
            InitializeViewModel(OrderID, model);
            return View(model);
        }
    }

    public class ViewModel
    {
        public string Action { get; set; }
        public TotalOrderInfo OrderInfo { get; set; }
        public List<OrderedItemsInfo> OrderedItems { get; set; }
    }

    public class DimensionType
    {
        readonly Hashtable _dims;

        public DimensionType()
        {
            _dims = new Hashtable();
            _dims["Box"] = 5;
            _dims["Item"] = 1;
            _dims["Package"] = 10;
        }

        public int GetDimension(string key)
        {
            if (_dims[key] != null) return Convert.ToInt32(_dims[key]);
            return 0;
        }
    }
}
