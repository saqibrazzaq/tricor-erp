using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.POS.Cashier;

namespace Database.POS
{
    public class CashierDB
    {
        // addition of new customer in database. 
        public static CashierModel addNewCustomer(CashierModel newcustomer)
        {
            String sql = @"";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newcustomer.ID = int.Parse(id.ToString());
            return newcustomer;
        }

    }
}
