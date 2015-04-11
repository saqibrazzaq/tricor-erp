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
        public int WHID { set; get; }
        public int SID { set; get; }
        public String OrderDate { set; get; }
        public String OrderType { set; get; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
        public List<PurchaseOrderItemsModel> PurchaseOrderItems { set; get; }
    }
}
