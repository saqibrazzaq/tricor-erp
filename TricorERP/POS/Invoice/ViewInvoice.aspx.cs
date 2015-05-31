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
            String x = customerinfo.Name;

            labcidship.Text = customerinfo.Name.ToString();
            labcustomernamebil.Text = customerinfo.Name.ToString();
            
            labcnicbil.Text = customerinfo.CNIC;
            labcnicship.Text = customerinfo.CNIC;
            labtotalprice.Text = soModel.TotalPrice.ToString().Trim();
            laborderid.Text = soModel.ID;

            AddressModel address = Database.Common.AddressDB.getSingleAddress(soModel.CustomerID);
            labaddressbil.Text = address.Location1 + ", " + address.Location2;
            labecustomermail.Text = address.Email;

            labaddressship.Text = address.Location1 + ", " + address.Location2;

            SalesOrderItemInvoiceView.DataSource = soModel.items;
            SalesOrderItemInvoiceView.DataBind();
        }



        
        
        protected void SalesOrderItemInvoiceView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}