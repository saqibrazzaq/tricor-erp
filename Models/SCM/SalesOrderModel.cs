using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SCM;

namespace Models.SCM
{
    public class SalesOrderModel
    {
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public String OrderDate { set; get; }
        public String DeliveryDate { set; get; }
        public int OrderStatus { set; get; }
        public String OrderStatusName { set; get; }
        public List<SalesOrderItemModel> items = new List<SalesOrderItemModel>();
    }
}

