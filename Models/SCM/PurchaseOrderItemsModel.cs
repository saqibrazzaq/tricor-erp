using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class PurchaseOrderItemsModel
    {
        public int ID { set; get; }
        public int PurchaseOrderID { set; get; }
        public int ProductID { set; get; }
        public int Quantity { set; get; }
        public int RecivedQuantity { set; get; }
        public float PurchasePrice { set; get; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
