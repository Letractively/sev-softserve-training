using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{ 
    public class ItemsController : Controller
    {
        private OrderSystemEntities db = new OrderSystemEntities();

        //
        // GET: /Items/

        public ViewResult Index()
        {
            ViewData["CountOfItems"] = db.Items.Count();
            return View(db.Items.ToList());
        }

        //Search items
        [HttpPost]
        public ViewResult Index(string itemInfo,string filtrationOption,string filtrationText,string priceFiltrationOption,string priceSearchText,
                                string quantityFiltrationOption,string quantitySearchText)
        {
            Debug.WriteLine(quantitySearchText);
            var filteredItems = SearhItems(itemInfo, filtrationOption, filtrationText, priceFiltrationOption,
                                           priceSearchText, quantityFiltrationOption, quantitySearchText);
            ViewData["CountOfItems"] = filteredItems.Count;
            return View(filteredItems);
        }
        //

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Items/Create

        [HttpPost]
        public ActionResult Create(Items item)
        {
            //TODO:Right validation of price!
            if (ModelState.IsValid)
            {
                db.Items.AddObject(item);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            return View(item);
        }
        
        //
        // GET: /Items/Edit/5
 
        public ActionResult Edit(int id)
        {
            Items items = db.Items.Single(i => i.ItemID == id);
            return View(items);
        }

        //
        // POST: /Items/Edit/5

        [HttpPost]
        public ActionResult Edit(Items items)
        {
            if (ModelState.IsValid)
            {
                db.Items.Attach(items);
                db.ObjectStateManager.ChangeObjectState(items, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        //
        // GET: /Items/Delete/5
 
        public ActionResult Delete(int id)
        {
            Items items = db.Items.Single(i => i.ItemID == id);
            return View(items);
        }

        //
        // POST: /Items/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Items items = db.Items.Single(i => i.ItemID == id);
            db.Items.DeleteObject(items);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        private List<Items> SearhItems(string itemInfo, string filtrationOption, string filtrationText, string priceFiltrationOption, string priceSearchText,
                                string quantityFiltrationOption, string quantitySearchText)
        {
            var items = db.Items.ToList();
            //Фитрация по тексту
            #region FiltrationByText
            if (itemInfo=="Item Name")
            {
                if (filtrationOption == "Contain's")
                {
                    items = items.Where(item => item.ItemName.Contains(filtrationText)).ToList();
                }
                else
                {
                    items = filtrationOption=="Start's with" ? items.Where(item => item.ItemName.StartsWith(filtrationText)).ToList() : items.Where(item => item.ItemName.EndsWith(filtrationText)).ToList();
                }
            }
            else
            {
                if (filtrationOption == "Contain's")
                {
                    items = items.Where(item => item.ItemDescriprion.Contains(filtrationText)).ToList();
                }
                else
                {
                    items = filtrationOption == "Start's with" ? items.Where(item => item.ItemDescriprion.StartsWith(filtrationText)).ToList() : items.Where(item => item.ItemDescriprion.EndsWith(filtrationText)).ToList();
                }
            }
            #endregion
            //Фильтрация по цене и количевству
            #region PriceAndQuantityFiltration);)
            if(priceFiltrationOption!="All")
            {
                switch (priceFiltrationOption)
                {
                    case ">":
                        items = items.Where(x =>x.Price > Convert.ToDecimal(priceSearchText)).ToList();
                        break;
                    case "<":
                        items = items.Where(x => x.Price < Convert.ToDecimal(priceSearchText)).ToList();
                        break;
                    case "!=":
                        items = items.Where(x => x.Price != Convert.ToDecimal(priceSearchText)).ToList();
                        break;
                    case "=":
                        items = items.Where(x => x.Price==Convert.ToDecimal(priceSearchText)).ToList();
                        break;
                }
            }
            
            if(quantityFiltrationOption!="All")
            {
                switch (quantityFiltrationOption)
                {
                    case ">":
                        items = items.Where(x => x.Quantity > int.Parse(quantitySearchText)).ToList();
                        break;
                    case "<":
                        items = items.Where(x => x.Quantity < int.Parse(quantitySearchText)).ToList();
                        break;
                    case "!=":
                        items = items.Where(x => x.Quantity != int.Parse(quantitySearchText)).ToList();
                        break;
                    case "=":
                        items = items.Where(x => x.Quantity == int.Parse(quantitySearchText)).ToList();
                        break;
                }
            }
            #endregion

            return items;
        }
    }
}