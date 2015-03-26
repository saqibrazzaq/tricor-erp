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
        public DateTime OrderDate { set; get; }
        public DateTime DeliveryDate { set; get; } 
    }
}
