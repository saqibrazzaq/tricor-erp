using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class PurchaseOrderItemsModel
    {
        public String ID { set; get; }
        public String PurchaseOrderID { set; get; }
        public String ProductID { set; get; }
        public int Quantity { set; get; }
        public float PurchasePrice { set; get; }
        public String CreatedBy { get; set; }
        public String LastUpdatedBy { get; set; }
        public String ProductName { get; set; }
    }
}
