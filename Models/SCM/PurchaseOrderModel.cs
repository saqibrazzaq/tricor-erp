using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class PurchaseOrderModel
    {
        public int ID { set; get; }
        public int WareHouseID { set; get; }
        public int SupplierID { set; get; }
        public String OrderDate { set; get; }
        public List<PurchaseOrderItemsModel> PurchaseOrderItems { set; get; }
    }
}
