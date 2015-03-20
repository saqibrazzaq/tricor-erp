using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
     public class ProductModel
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public float ProductPrice { get; set; }
        public String ProductDescription { get; set; }

    }
}
