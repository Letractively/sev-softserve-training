using System;
using System.Linq;
using System.Web.Mvc;
using OrderSystem.Models;
using System.Collections.Generic;

namespace OrderSystem.Controllers
{
    public class DisplayOrderController : Controller
    {
        private OrderSystemEntities database = new OrderSystemEntities();
        private ViewModel MyViewModel = new ViewModel();
  
        private void InitializeViewModel(int id)
        {
            var query1 = (  from item in database.Items
                            join order in database.ItemsOrder
                            on item.ItemID equals order.ItemID
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

            var query2 = (  from user in database.Users
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
                                Assignee = order.Assignee,
                                DateOfOrdering = order.OrderingDate,
                                PreferableDeliveryDate = order.PreferableDeliveryDate
                            }
                         );

            if (query2.Count() != 0)
            MyViewModel.OrderInfo = query2.ToArray()[0];
            MyViewModel.OrderedItems = query1.ToList();
        }

        public ActionResult AnalyzeOrders(int orderNumber = 1)
        {
            InitializeViewModel(orderNumber);
            return View(MyViewModel);
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Cancel")]
        public ActionResult Cancel()
        {
            return RedirectToAction("AnalyzeOrders", "DisplayOrder");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Order")]
        public ActionResult Order(string DeliveryDate, bool? Gift, bool? Ordered, bool? Delivered)
        {
            Orders ord = database.Orders.FirstOrDefault(order => order.OrderID == 1);
            ord.DeliveryDate = Convert.ToDateTime(DeliveryDate);
            database.SaveChanges();
            return RedirectToAction("AnalyzeOrders", "DisplayOrder");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Save")]
        public ActionResult Save(string DeliveryDate)
        {

            return RedirectToAction("AnalyzeOrders", "DisplayOrder");
        }
    }

    public class ViewModel
    {
        public TotalOrderInfo OrderInfo { get; set; }
        public List<OrderedItemsInfo> OrderedItems { get; set; }
    }
}
