using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Order
{
    public class OrderModel
    {
        public int ID { set; get; }
        public String ProductName { set; get; }
        public int Quantity { set; get; }
        public float Price { set; get; }

    }
}
