using Models.POS.Customer;
using Models.POS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Invoice
{
    public partial class ViewInvoice : System.Web.UI.Page
    {
        SaleOrderModel soModel = new SaleOrderModel() { ID = Common.NULL_ID };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            InitializeOrderModel();
        }

        private void InitializeOrderModel()
        {
            try
            {
                if (Common.CheckNullString(Request.QueryString["ID"]) != Common.NULL_ID)
                {
                    soModel.ID = Request.QueryString["ID"];
                    loadOrderModel();
                }
            }
            catch (Exception ex)
            {
                soModel.ID = Common.NULL_ID;
                throw ex;
            }
        }

        private void loadOrderModel()
        {
            soModel = Database.POS.Order.OrderDB.loadOrderModel(soModel);
            laborderdate.Text = soModel.OrderDate;
            
            // for geting the data of customer
            CustomerModel customerinfo = Database.POS.Customer.CustomerDB.getCustomerInFo(soModel.CustomerID);
            labcustomernamebil.Text = customerinfo.Name;
            labcustomernameship.Text = customerinfo.Name;
            labcnicbil.Text = customerinfo.CNIC;
            labcnicship.Text = customerinfo.CNIC;



            SalesOrderItemInvoiceView.DataSource = soModel.items;
            SalesOrderItemInvoiceView.DataBind();
        }



        
        
        protected void SalesOrderItemInvoiceView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}