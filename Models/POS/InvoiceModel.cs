using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS
{
    public class InvoiceModel
    {
        public String ID { set; get; }
        public float Price { set; get; }
        public String Date { set; get; }
        public String OrderID { set; get; }
        public String CustomerID { get; set; }
    }
}
