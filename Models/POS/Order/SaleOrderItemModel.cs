using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class SaleOrderItemModel
    {
        public int ID { set; get; }
        public int SaleOrderID { set; get; }
        public int ProductID { set; get; }
        public int Quantity { set; get; }
        public float UnitPrice { set; get; }

    }
}
