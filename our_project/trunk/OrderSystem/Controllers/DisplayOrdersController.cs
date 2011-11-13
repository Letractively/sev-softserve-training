using System.Linq;
using System.Web.Mvc;
using OrderSystem.Models;
using System.Collections.Generic;

namespace OrderSystem.Controllers
{
    public class DisplayOrderController : Controller
    {
        OrderSystemEntities database = new OrderSystemEntities();

        public ActionResult AnalyzeOrders(int orderNumb = 1)
        {
            IEnumerable<OrderedItemsInfo> orderedItems = (
            from item in database.Items
            join order in database.ItemsOrder
            on item.ItemID equals order.ItemID
            where order.OrderID == orderNumb
            select new OrderedItemsInfo()
            {
                ItemNumber = item.ItemID,
                ItemName = item.ItemName,
                ItemDescription = item.ItemDiscription,
                Dimension = order.Dimension,
                Price = item.Price,
                Quantity = order.Quantity,
                PricePerLine = item.Price * order.Quantity
            });

            TotalOrderInfo[] orderInfo = (
            from user in database.Users
            join order in database.Orders
            on user.UserID equals order.UserID
            join rank in database.Rank
            on user.RankType equals rank.RankID
            where order.OrderID == orderNumb
            select new TotalOrderInfo()
            {
                CostumerName = user.UserFName,
                CostumerType = rank.RankName,
                OrderNumber = order.OrderID,
                TotalPrice = order.TotalPrice,
                Assignee = order.Assignee,
                DateOfOrdering = order.OrderingDate,
                PreferableDeliveryDate = order.PreferableDeliveryDate
            }).ToArray();

            ViewBag.OrderInfo = orderInfo;
            ViewBag.rowsCount = 5;
            return View(orderedItems);
        }

    }
}
