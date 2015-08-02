using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class PurchaseOrderModel
    {
        public String ID { set; get; }
        public String WHID { set; get; }
        public String SID { set; get; }
        public String OrderDate { set; get; }
        public String OrderType { set; get; }
        public String CreatedBy { get; set; }
        public String LastUpdatedBy { get; set; }

        public String OrderStatus { get; set; }

        public String OrderStatusName { get; set; }
        public String WHName { get; set; }

        public string DeliveryDate { get; set; }
    }
}
