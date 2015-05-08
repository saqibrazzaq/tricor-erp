using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Invoice
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        List <Models.POS.InvoiceModel> invoicemodel = null;
        Models.POS.Customer.CustomerModel customerinfo = null;
        String OrderID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            ErroMessage.Text = "";

            InitializeInvoiceModel();
            LoadPaymentMethodDropDownListInDropdown();

            String CustomerID = Request.QueryString["CustomerID"].ToString();
            
            GetCustomerInFo( CustomerID );
            DateTextBox.Text = DateTime.Today.ToShortDateString();
            CustomerNameTextBox.Text = customerinfo.Name;
        }

        private void InitializeInvoiceModel()
        {
            try
            {
                
                if (Common.CheckNullString(Request.QueryString["ID"]) != Common.NULL_ID)
                {
                    OrderID = Request.QueryString["ID"].ToString();
                    loadInvoiceModel();
                }
            }
            catch (Exception ex)
            {
                OrderID = Common.NULL_ID;
                throw ex;
            }
        }

        private void loadInvoiceModel()
        {
            invoicemodel = Database.POS.InvoiceDB.getInvoiceModel(OrderID); 
        }

        private void GetCustomerInFo(String CustomerID )
        {
            customerinfo = Database.POS.Customer.CustomerDB.getCustomerInFo(CustomerID);
        }

        private void LoadPaymentMethodDropDownListInDropdown()
        {
            List<Models.POS.PaymentMethordModel> paymentmethord = GetPaymentMathordList();
            // Bind list to the dropdown
            PaymentMethodDropDownList.DataSource = paymentmethord;
            PaymentMethodDropDownList.DataTextField = "PaymentMathordName";
            PaymentMethodDropDownList.DataValueField = "ID";
            PaymentMethodDropDownList.DataBind();
        }

        private List<Models.POS.PaymentMethordModel> GetPaymentMathordList()
        {
            return Database.POS.InvoiceDB.getPaymentMathordList();
        }

        protected void DeleteInvoice_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/AddOrder.aspx?ID=" + Request.QueryString["ID"].ToString());
        }

        protected void SaveInvoicePrice_Click(object sender, EventArgs e)
        {

        }
    }
}