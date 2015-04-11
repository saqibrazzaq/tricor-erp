using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SCM
{
    public class RawMaterial
    {
        public int ReOderValue { get; set; }
        public int ThresholdValue { get; set; }
        public int ID  { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
