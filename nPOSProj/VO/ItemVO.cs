using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class ItemVO
    {
        private Int32 _item_id;
        private String _stock_code;
        private String _item_ean;
        private Int32 _item_quantity;
        private Double _item_retail_price;
        private Double _item_whole_price;
        private String _item_tax_type;
        private Int32 _is_kit;
        private String _kit_name;
        private DAO.ItemsDAO items;
        private String _eantmp;
        private String _description;

        public ItemVO() { }

        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Int32 item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }
        public String stock_code
        {
            get { return _stock_code; }
            set { _stock_code = value; }
        }
        public String item_ean
        {
            get { return _item_ean; }
            set { _item_ean = value; }
        }
        public Int32 item_quantity
        {
            get { return _item_quantity; }
            set { _item_quantity = value; }
        }
        public Double item_retail_price
        {
            get { return _item_retail_price; }
            set { _item_retail_price = value; }
        }
        public Double item_whole_price
        {
            get { return _item_whole_price; }
            set { _item_whole_price = value; }
        }
        public String item_tax_type
        {
            get { return _item_tax_type; }
            set { _item_tax_type = value; }
        }
        public Int32 is_kit
        {
            get { return _is_kit; }
            set { _is_kit = value; }
        }
        public String kit_name
        {
            get { return _kit_name; }
            set { _kit_name = value; }
        }
        public String eanTmp
        {
            get { return _eantmp; }
            set { _eantmp = value; }
        }

        public void UpdateItem()
        {
            items = new DAO.ItemsDAO();
            items.Update(item_quantity, item_ean, item_retail_price, item_whole_price, item_tax_type, stock_code, eanTmp);
        }
        public void TrasferItemToStock()
        {
            items = new DAO.ItemsDAO();
            items.ReturnToStocks(item_quantity, stock_code);
        }
        public void TrasferStockToItem()
        {
            items = new DAO.ItemsDAO();
            items.SendToItem(item_quantity, stock_code);
        }
        public String askKitName()
        {
            String Kit;
            items = new DAO.ItemsDAO();
            items.pushKitName(item_ean);
            Kit = items.pushKitName(item_ean);
            return Kit;
        }
        public String askEAN()
        {
            String EAN;
            items = new DAO.ItemsDAO();
            items.pushEan(kit_name);
            EAN = items.pushEan(kit_name);
            return EAN;
        }
        public void eanPatch()
        {
            items = new DAO.ItemsDAO();
            items.patchEAN(stock_code, item_ean);
        }
        #region Item Kits Objects
        public void PushKit()
        {
            items = new DAO.ItemsDAO();
            items.InsertKit(item_quantity, item_ean, stock_code);
        }
        public void PatchKit()
        {
            items = new DAO.ItemsDAO();
            items.UpdateKit(item_quantity, item_ean, stock_code);
        }
        public void PullKit()
        {
            items = new DAO.ItemsDAO();
            items.DeleteKit(item_ean, stock_code);
        }
        #endregion
        public Int32 askQty()
        {
            Int32 qty;
            items = new DAO.ItemsDAO();
            items.askQuantity(item_ean);
            qty = items.askQuantity(item_ean);
            return qty;
        }
        public void OrderItem()
        {
            items = new DAO.ItemsDAO();
            items.OrderI(item_ean, item_quantity);
        }
        //
        public String[,] ReadKits()
        {
            items = new DAO.ItemsDAO();
            Int32 count = items.KitCount();
            String[,] xxx = new String[4, count];
            items.ReadKits();
            xxx = items.ReadKits();
            return xxx;
        }
        public String[,] ReadKitsSearch()
        {
            items = new DAO.ItemsDAO();
            Int32 count = items.KitCount();
            String[,] xxx = new String[4, count];
            items.ReadKitsSearch(description);
            xxx = items.ReadKitsSearch(description);
            return xxx;
        }
        public String[,] ReadItems()
        {
            items = new DAO.ItemsDAO();
            Int32 count = items.ItemCount();
            String[,] yyy = new String[4, count];
            items.ReadItems();
            yyy = items.ReadItems();
            return yyy;
        }
        public String[,] ReadItemsSearch()
        {
            items = new DAO.ItemsDAO();
            Int32 count = items.ItemCount();
            String[,] yyy = new String[4, count];
            items.ReadItemsSearch(description);
            yyy = items.ReadItemsSearch(description);
            return yyy;
        }
    }
}