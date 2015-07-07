using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class SaleOrderItemModel
    {
        public String ID { get; set; }
        public String OrderID { get; set; }
        public String ProductID { get; set; }
        
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ProductName { get; set; }
        public float PurchasePrice { get; set; }

        public string ProductStatus { get; set; }
        public int ManufacturedQuantity { get; set; }

        // for checking the data of warehouse 
        public String WareHouseID { get; set; }
        public string WareHouseName { get; set; }

        public float PerUnitTotalPrice { get; set; }


        public int QuantityCheck { get; set; }

        public String ProductDescription { get; set; }
    }
}
