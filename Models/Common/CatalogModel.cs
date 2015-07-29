using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class CatalogModel
    {
        
        public String ID { set; get; }
        public String PName { set; get; }
        public String ImagePath { set; get; }
        public String PDescription { set; get; }
        public int SalePrice { get; set; }

    }
}
