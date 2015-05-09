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
        String CustomerID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerID = Request.QueryString["CustomerID"].ToString();
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            ErroMessage.Text = "";
            txtPrice.Text = "";

            InitializeInvoiceModel();
            LoadPaymentMethodDropDownListInDropdown();
            GetCustomerInFo(CustomerID);
            DateTextBox.Text = DateTime.Today.ToShortDateString();
            CustomerNameTextBox.Text = customerinfo.Name;

            AddInvoiceListview.DataSource = invoicemodel;
            AddInvoiceListview.DataBind();

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
            invoicemodel = Database.POS.InvoiceDB.getInvoiceModel(OrderID, CustomerID); 
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

            // set dropdown for pop up 
            PaymentMethordDropDownListPop.DataSource = paymentmethord;
            PaymentMethordDropDownListPop.DataTextField = "PaymentMathordName";
            PaymentMethordDropDownListPop.DataValueField = "ID";
            PaymentMethordDropDownListPop.DataBind();
        }

        private List<Models.POS.PaymentMethordModel> GetPaymentMathordList()
        {
            return Database.POS.InvoiceDB.getPaymentMathordList();
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            
            Models.POS.InvoiceModel addInvice = new Models.POS.InvoiceModel();
            addInvice.CustomerID = CustomerID;
            addInvice.Date = DateTextBox.Text;
            addInvice.OrderID = Request.QueryString["ID"].ToString().Trim();
            addInvice.Price = int.Parse(Price.Text);
            addInvice.CreatedBy = Session["UserID"].ToString().Trim();
            addInvice.LastUpdatedBy = Session["UserID"].ToString().Trim();
            addInvice.PaymentMathordName = PaymentMethodDropDownList.SelectedValue;
            addInvice = Database.POS.InvoiceDB.addInviceData(addInvice);
            InitializePageContents();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/AddOrder.aspx?ID=" + Request.QueryString["ID"].ToString());
        }

        protected void DeleteInvoice_Click(object sender, EventArgs e)
        {
            String InvoiceID = txtInvoiceID.Text.Trim();
            int check = Database.POS.InvoiceDB.deleteInvoice(InvoiceID);
            if (check > 0)
            {
                InitializePageContents();
            }
            else
            {
                ErroMessage.Text = "Due to some problem data is not deleted";
            }
        }

        protected void UpdateInvoicePrice_Click(object sender, EventArgs e)
        {
            Models.POS.InvoiceModel updateinvoice = new Models.POS.InvoiceModel();
            updateinvoice.Price = int.Parse(txtPrice.Text);
            updateinvoice.ID = txtInvoiceID.Text.Trim();
            updateinvoice.PaymentMathordID = PaymentMethordDropDownListPop.SelectedValue;
            updateinvoice.LastUpdatedBy = Session["UserID"].ToString().Trim();
            int check = Database.POS.InvoiceDB.updateInvoice(updateinvoice);
            
            if (check > 0) {
                InitializePageContents();
            }

            ErroMessage.Text = "Data is Updated...";

        }

    }
}