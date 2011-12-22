using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemSearcher.Models
{
    [Serializable]
    public class ISModelState
    {
        public string sortmode;
        public string SubstringFind;
        public int SelectedItem;
        public string Dimension;
        public int order;
        public int Quantity;
        public Items item;
        public Decimal Price;
        public string[] ddl1items;
        public string[] ddl2items;

        public void OnInit()
        {
            this.sortmode = "name";
            this.item = new Items();
            this.SubstringFind = "";
            this.ddl1items = new string[2] { "name", "description" };
            this.ddl2items = new string [3] { "Item", "Box", "Package" };
        }

        public void ResetSelectedItem()
        {
            this.SelectedItem = -1;
            this.Quantity = 1;
            this.Price = 0.0M;
        }

        public void SetFilterOption(string mode, string find)
        {
            this.sortmode = mode;
            this.SubstringFind = find;
        }

        public void CopyItem(Items tmp)
        {
            if (tmp.Image != null)
            {
                this.item.Image = tmp.Image;
            }
            else
            {
                this.item.Image = null;
            }
            this.item.ItemDescriprion = tmp.ItemDescriprion;
            this.item.ItemID = tmp.ItemID;
            this.item.ItemName = tmp.ItemName;
            this.item.Price = tmp.Price;
            this.item.Quantity = tmp.Quantity;
        }

        public ItemsOrder WriteToOrder()
        {
            ItemsOrder tmp = new ItemsOrder();
            tmp.ItemID = this.item.ItemID;
            tmp.ItemInfoID = this.item.ItemID;
            tmp.OrderID = this.order;
            tmp.Quantity = this.Quantity;
            tmp.Dimension = this.Dimension;
            return tmp;
        }
    }

}