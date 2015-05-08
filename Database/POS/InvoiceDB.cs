using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class InvoiceDB
    {

        public static List<Models.POS.PaymentMethordModel> getPaymentMathordList()
        {
            List<Models.POS.PaymentMethordModel> methords = new List<Models.POS.PaymentMethordModel>();
            String sql = @"SELECT * FROM PaymentMethord";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.PaymentMethordModel methord = new Models.POS.PaymentMethordModel();
                methord.ID = reader["ID"].ToString();
                methord.PaymentMathordName = reader["PaymentMathordName"].ToString();
                methords.Add(methord);
            }
            return methords;
            
        }



        public static List<Models.POS.InvoiceModel> getInvoiceModel(string OrderID)
        {
            List<Models.POS.InvoiceModel> invoicelist = new List<Models.POS.InvoiceModel>();
            // changing
            String sql = @"";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.InvoiceModel invoicevalues = new Models.POS.InvoiceModel();
                invoicevalues.ID = reader["ID"].ToString();
                invoicevalues.Date = reader[""].ToString();
                invoicevalues.OrderID = reader[""].ToString();
                invoicevalues.Price = float.Parse(reader[""].ToString());
                invoicevalues.CustomerID = reader[""].ToString();
                
                invoicelist.Add(invoicevalues);
            }
            return invoicelist;
        }
    }
}
