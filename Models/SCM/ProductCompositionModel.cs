using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class ProductCompositionModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int RawMaterialID { get; set; }
        public int Quantity { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
        
    }
}
