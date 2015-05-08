using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Samples
{
    /// <summary>
    /// Represents a customer model
    /// </summary>
    public class CustomerModel
    {
        public String ID { get; set; }
        public String FullName { get; set; }
        public int CustomerType { get; set; }
    }
}
