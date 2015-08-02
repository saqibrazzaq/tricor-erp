using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class StockModel
    {
        public int ProductID { get; set; }
        public int WareHouseID { get; set; }
        public int ID { get; set; }
        public List<ProductModel> Puroducts { set; get; }
        public int Quantity { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
        public int check { get; set; }
        public string ProductName { get; set; }
    }
}
