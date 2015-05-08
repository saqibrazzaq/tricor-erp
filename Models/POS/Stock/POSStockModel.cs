using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Stock
{
    public class POSStockModel
    {
        public String ID { set; get; }
        public String ProductID { set; get; }
        public String WHID { set; get; }
        public int Quantity { set; get; }
        public string ProductName { set; get; }

        public int check { set; get; }
    }
}
