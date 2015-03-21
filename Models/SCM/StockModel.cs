using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class StockModel
    {
        public int ProductID { get; set; }
        public int WareHouseID { get; set; }
        public int ID { get; set; }
        public int ProductReOderValue { get; set; }
        public int ProductThresholdValue { get; set; }
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public float ProductPrice { get; set; }
        public String ProductDescription { get; set; }
        public float Quantity { get; set; }
    }
}
