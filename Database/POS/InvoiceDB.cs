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

        public static List<Models.POS.InvoiceModel> getInvoiceModel(String OrderID, String CustomerID)
        {
            List<Models.POS.InvoiceModel> invoicelist = new List<Models.POS.InvoiceModel>();

//            String sql = @"SELECT [ID]
//                          ,[CustomerID]
//                          ,[OrderID]
//                          ,[Price]
//                          ,[PaymentMethordID]
//                          ,[PaymentDate]
//                          ,[CreatedBy]
//                          ,[LastUpdatedBy]
//                      FROM [dbo].[Invoice]
//                      WHERE [CustomerID] = '"+CustomerID+"' AND [OrderID] = '"+OrderID+"'";
            String sql = @"SELECT [Invoice].[ID] ,[Invoice].[CustomerID] ,[Invoice].[OrderID]
                       ,[Invoice].[Price] ,[Invoice].[PaymentMethordID]
	                   ,[Invoice].[PaymentDate] ,[Invoice].[CreatedBy]
	                   ,[Invoice].[LastUpdatedBy], [PaymentMethord].PaymentMathordName
	                   FROM [dbo].[Invoice]                      
	                   JOIN PaymentMethord ON [PaymentMethord].ID = [Invoice].PaymentMethordID
	                   WHERE [Invoice].[CustomerID] = '"+CustomerID
                       +"'AND [Invoice].[OrderID] = '"+OrderID+"'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.InvoiceModel invoicevalues = new Models.POS.InvoiceModel();
                invoicevalues.ID = reader["ID"].ToString();
                invoicevalues.CustomerID = reader["CustomerID"].ToString();
                invoicevalues.OrderID = reader["OrderID"].ToString();
                invoicevalues.Price = int.Parse(reader["Price"].ToString());
                invoicevalues.PaymentMathordName = reader["PaymentMethordID"].ToString();
                invoicevalues.Date = reader["PaymentDate"].ToString();
                invoicevalues.PaymentMathordName = reader["PaymentMathordName"].ToString();
                // to be continue on that point.....
                invoicelist.Add(invoicevalues);
            }
            return invoicelist;
        }

        public static Models.POS.InvoiceModel addInviceData(Models.POS.InvoiceModel addInvice)
        {
            String sql = @"INSERT INTO [dbo].[Invoice]
                       ([CustomerID] ,[OrderID] ,[Price]
                       ,[PaymentMethordID] ,[PaymentDate]
                       ,[CreatedBy] ,[LastUpdatedBy])
                       OUTPUT inserted.ID
                       VALUES('"+addInvice.CustomerID+"','"+addInvice.OrderID+"','"+addInvice.Price+"','"+addInvice.PaymentMathordName
                                +"','"+addInvice.Date+"','"+addInvice.CreatedBy+"','"+addInvice.LastUpdatedBy+"')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            addInvice.ID = id.ToString();
            return addInvice;
        }


        public static int deleteInvoice(string InvoiceID)
        {
            String sql = @"DELETE FROM [dbo].[Invoice] WHERE [ID] = '"+InvoiceID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        public static int updateInvoice(Models.POS.InvoiceModel updateinvoice)
        {
            String sql = @"UPDATE [dbo].[Invoice]
                         SET [Price] = '"+updateinvoice.Price+"' ,[PaymentMethordID] = '"+updateinvoice.PaymentMathordID
                         +"' ,[LastUpdatedBy] = '"+updateinvoice.LastUpdatedBy+"' WHERE [Invoice].ID = '"+updateinvoice.ID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
