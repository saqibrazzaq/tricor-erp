using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS
{
    public class ProductModel
    {
        public int ProductReOderValue { get; set; }
        public int ProductThresholdValue { get; set; }
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String Description { get; set; }
        public int ProductTypeID { get; set; }
        public int UnitTypeID { get; set; }
        public String ProductCode { get; set; }
        public float SalesPrice { get; set; }
        public String ProductDescription { get; set; }
        public float PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
