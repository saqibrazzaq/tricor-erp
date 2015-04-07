﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class SaleOrderItemModel
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ProductName { get; set; }

        // for checking the data of warehouse 
        public int WareHouseID { get; set; }

        public string WareHouseName { get; set; }            

    }
}
