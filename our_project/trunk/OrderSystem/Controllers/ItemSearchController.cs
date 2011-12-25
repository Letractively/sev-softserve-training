using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using ItemSearcher.Models;
using OrderSystem.Models;
namespace ItemSearcher.Controllers
{

    public class ItemSearchController : Controller
    {
        // Резервирование памяти под состояние модели во время работы 
        ISModelState ismodel = new ISModelState();

        // Обработка стартового запроса и запросов вебгрида
        [HttpGet]
        public ActionResult ItemSearch()
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            // Если сессия начата - первый запрос - то инициализация
            if (Session.IsNewSession)
            {
                Session["err"] = "";
                ismodel.OnInit();
                ismodel.ResetSelectedItem();
                SaveState(ismodel);
            }
            else
            {
                ismodel = RestoreState();
            }
            ismodel.OnInit();
            ismodel.ResetSelectedItem();
            SaveState(ismodel);
            WriteView();
           
            List<Items> tmpview = ReadList(ismodel.sortmode, ismodel.SubstringFind);
            if (Session["err"] != "")
            {
                return RedirectToAction("Errored", "ItemSearch");
            }
            return View(tmpview);

        }

        // Обработка пост-запроса, нажатия клавиш на веб-форме и т.п. 
        [HttpPost]
        public ActionResult ItemSearch(string ddl1, string SubstringFind, string button, string selecteditem, string quantity, string ddl2)
        {
            ismodel = RestoreState();
            switch (button)
            {
                case " Search ":
                    {
                        ismodel.SetFilterOption(ddl1, SubstringFind);
                        break;
                    }
                case "   Add  ":
                    {
                        ismodel.ResetSelectedItem();
                        int i = int.Parse(selecteditem);
                        Items tmp = new Items();
                        tmp = ReadList(ismodel.sortmode, ismodel.SubstringFind).ElementAt<Items>(i);
                        if (Session["err"] != "")
                        {
                            return RedirectToAction("Errored", "ItemSearch");
                        }
                        if(i>=0)
                        {
                            ismodel.SelectedItem = tmp.ItemID;
                            ismodel.CopyItem(tmp);
                        }
                        break;
                    }
                case "  Done  ":
                    {
                        int qu;
                        ismodel.Dimension = ddl2;
                        ItemsOrder rw = new ItemsOrder();
                        if (int.TryParse(quantity, out qu))
                        {
                            ismodel.Quantity = qu;
                            ismodel.order = 123;
                            rw=ismodel.WriteToOrder();
                            OutRecord(rw);
                            if (Session["err"] != "")
                            {
                                return RedirectToAction("Errored", "ItemSearch");
                            }
                            else
                            {
                                return RedirectToAction("~/CustomerOrdering/OrderList.cshtml");
                            }
                        }
                        else
                        {
                            ismodel.Quantity = 1;
                        }
                        break;
                    }
                case "  Close ":
                    {
                        return RedirectToAction("~/CustomerOrdering/OrderList.cshtml");
                    }

            }
            WriteView();
            SaveState(ismodel);
            List<Items> tmpview = ReadList(ismodel.sortmode, ismodel.SubstringFind);
            if (Session["err"] != "")
            {
                return RedirectToAction("Errored", "ItemSearch");
            }
            return View(tmpview);
        }

        // Запись выходных данных в бд
        [NonAction]
        public void OutRecord(ItemsOrder tmp)
        {            
            try
            {

                OrderSystemEntities database = new OrderSystemEntities();
                database.ItemsOrder.AddObject(tmp);
                int t = database.SaveChanges();
                if (t <= 0)
                {
//                    ErroredSoft();
                }
                database.Dispose();
            }
            catch (Exception ex)
            {
                Session["err"] = ex.Message.ToString();

//                Errored();
            }

        }

        // Восстановление состояния модели
        [NonAction]
        public ISModelState RestoreState()
        {
            ISModelState tmp =new ISModelState();
            tmp = (ISModelState) Session["isdata"];
            return tmp;
        }

        // Сохранение состояния модели в сессии
        [NonAction]
        public void SaveState(ISModelState tmp)
        {
            Session.Add("isdata", tmp);
        }

        // Чтение из набора сущностей Items набора с фильтром по имени и описанию - будущая модель
        [NonAction]
        public List<Items> ReadList(string sortmode, string filter)
        {
            List<Items> tmp = new List<Items>();
            try
            {
                OrderSystemEntities database = new OrderSystemEntities();

                if (filter == "")
                {
                    tmp = database.Items.Where<Items>(rec => rec.Quantity>0).ToList<Items>();
                }
                else
                    switch (sortmode)
                    {
                        case "name":
                            {
                                tmp = database.Items.Where<Items>(rec => rec.ItemName.ToLower().Contains(filter.ToLower()) && rec.Quantity>0).ToList<Items>();
                                break;
                            }
                        case "description":
                            {
                                tmp = database.Items.Where<Items>(rec => rec.ItemDescriprion.ToLower().Contains(filter.ToLower()) && rec.Quantity > 0).ToList<Items>();
                                break;
                            }
                    }
                database.Dispose();
            }
            catch (Exception ex)
            {
                Session["err"] = ex.Message.ToString();
             }
            return tmp;
        }

        // Формирование полей вьюхи по сохраненному-восстановленному состоянию системы
        [NonAction]
        public void WriteView()
        {
            List<string> ddlist1 = new List<string>();
            List<string> ddlist2 = new List<string>();
            foreach (var tmp in ismodel.ddl1items)
            {
                ddlist1.Add(tmp);
            }
            foreach (var tmp in ismodel.ddl2items)
            {
                ddlist2.Add(tmp);
            }
                        ViewData["ddl1"] = new SelectList(ddlist1, ismodel.sortmode);
            ViewData["ddl2"] = new SelectList(ddlist2);
            ViewData["SubstringFind"] = ismodel.SubstringFind;
            if (ismodel.SelectedItem >= 0)
            {
                ViewData["i-name"] = ismodel.item.ItemName;
                ViewData["i-price"] = ismodel.item.Price;
            }
            ViewData["quantity"] = ismodel.Quantity;
        }

        // Обработчик ошибок и исключений Exception с редиректом на страницу выше
        public ViewResult Errored()
        {
            return View(Session["err"]);
        }

    }     
}
