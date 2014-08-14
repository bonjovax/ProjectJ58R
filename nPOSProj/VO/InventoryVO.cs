using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class InventoryVO
    {
        private String _supplier_name;
        private String _cat_description;
        private String _warehouse_name;
        private DAO.InventoryDAO idao;

        public InventoryVO()
        {

        }

        public String supplier_name
        {
            get { return _supplier_name; }
            set { _supplier_name = value; }
        }
        public String cat_description
        {
            get { return _cat_description; }
            set { _cat_description = value; }
        }
        public String warehouse_name
        {
            get { return _warehouse_name; }
            set { _warehouse_name = value; }
        }

        public String patchSupplierCode()
        {
            String SupplierCode;
            idao = new DAO.InventoryDAO();
            idao.grabSupplierCode(supplier_name);
            SupplierCode = idao.grabSupplierCode(supplier_name);
            SupplierCode = idao.sendSupplierCode();
            return SupplierCode;
        }

        public String patchCategoryCode()
        {
            String CategoryCode;
            idao = new DAO.InventoryDAO();
            idao.grabCategoryCode(cat_description);
            CategoryCode = idao.grabCategoryCode(cat_description);
            CategoryCode = idao.sendCategoryCode();
            return CategoryCode;
        }

        public String patchWarehouseCode()
        {
            String WarehouseCode;
            idao = new DAO.InventoryDAO();
            idao.grabWarehouseCode(warehouse_name);
            WarehouseCode = idao.grabWarehouseCode(warehouse_name);
            WarehouseCode = idao.sendWarehouseCode();
            return WarehouseCode;
        }
    }
}