using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Report
{
    public class ReportModel
    {
        public string ProductName { set; get; }
        public int Quantity { set; get; }
        public float SalePrice { set; get; }
        public float PurchasePrice { set; get; }
        public float TotalPrice { set; get; }
        public float Profit { set; get; }
        public string orderdates { set; get; }

        public string OrderStatus { get; set; }
    }
}
