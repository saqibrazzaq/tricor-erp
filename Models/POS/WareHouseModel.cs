using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS
{
    public class WareHouseModel
    {
        public String ID { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public String CreatedBy { get; set; }
        public String LastUpdatedBy { get; set; }
    }
}
