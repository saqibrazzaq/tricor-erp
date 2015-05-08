using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class SaleOrderModel
    {
        public String ID { set; get; }
        public String CustomerID { set; get; }
        public String OrderDate { set; get; }
        public String DeliveryDate { set; get; }
        public String CustomerName { set; get; }
        public String OrderStatus { set; get; }
        public String OrderStatusName { set; get; }
        public List<SaleOrderItemModel> items = new List<SaleOrderItemModel>();
        //that mathord is used for geting the total price of different items....
        public float TotalPrice { get; set; }
    }
}
