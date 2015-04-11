using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
     public class ProductModel
     {
         public int ProductReOderValue { get; set; }
         public int ProductThresholdValue { get; set; }
         public int ProductID { get; set; }
         public String ProductName { get; set; }
         public int ProductTypeID { get; set; }
         public int UnitTypeID { get; set; }
         public int CreatedBy { get; set; } 
         public int LastUpdatedBy { get; set; }
        public String ProductCode { get; set; }
        public float SalesPrice { get; set; }
        public String ProductDescription { get; set; }
        public float PurchasePrice{ get; set; }

    }
}
