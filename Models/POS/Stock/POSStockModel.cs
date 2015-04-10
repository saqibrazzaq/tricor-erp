using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Stock
{
    public class POSStockModel
    {
        public int ID { set; get; }
        public int ProductID { set; get; }
        public int WHID { set; get; }
        public int Quantity { set; get; }
        public string ProductName { set; get; }
    }
}
