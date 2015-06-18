using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class SalesOrderItemModel
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int TotalQuantity { get; set; }
        public int ManufacturedQuantity { get; set; }        
        public float Price { get; set; }
        public string ProductName { get; set; }
        public string ProductStatus { get; set; }
        public int ManufactureTime { get; set; }
    }
}
