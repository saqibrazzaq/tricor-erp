using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class SaleOrderModel
    {
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public String OrderDate { set; get; }
        public String DeliveryDate { set; get; }
        public String CName { set; get; }

        public List<SaleOrderItemModel> items = new List<SaleOrderItemModel>();
    }
}
