using Models.POS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Invoice
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        List<Models.POS.InvoiceModel> invoicemodel = null;
        Models.POS.Customer.CustomerModel customerinfo = null;
        SaleOrderModel soModel = new SaleOrderModel() { ID = Common.NULL_ID };
        String OrderID = null;
        String CustomerID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Price.Text = "";

            CustomerID = Request.QueryString["CustomerID"].ToString();
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            ErroMessage.Text = "";
            Pricetxt.Text = "";
            InitializeInvoiceModel();
            totalpaymettxt.Text = soModel.TotalPrice.ToString();

            LoadPaymentMethodDropDownListInDropdown();
            GetCustomerInFo(CustomerID);
            DateTextBox.Text = DateTime.Today.ToShortDateString();
            CustomerNameTextBox.Text = customerinfo.Name;

            AddInvoiceListview.DataSource = invoicemodel;
            AddInvoiceListview.DataBind();

            if (int.Parse(totalpaymettxt.Text) == int.Parse(TotalAmount.Text))
            {
                btnAddInvoice.Enabled = false;
                Pricetxt.Enabled = false;
                
            }
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

            var total = 0;

            //foreach (var count in invoicemodel.Count.ToString())
            //{
            //    total = total + invoicemodel[count].Price;
            //}

            for (int i = 0; i < invoicemodel.Count; i++)
            {
                total = total + invoicemodel[i].Price;
            }

            TotalAmount.Text = total.ToString();

            soModel.ID = OrderID;
            soModel = Database.POS.Order.OrderDB.loadOrderModel(soModel);
        }

        private void GetCustomerInFo(String CustomerID)
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
           
            if (int.Parse(totalpaymettxt.Text) < int.Parse(TotalAmount.Text) + int.Parse(Pricetxt.Text))
            {
                
                    ErroMessage.Text = "The Amount Entered is incorrect...";
            }
            else
            {
                Models.POS.InvoiceModel addInvice = new Models.POS.InvoiceModel();
                addInvice.CustomerID = CustomerID;
                addInvice.Date = DateTextBox.Text;
                addInvice.OrderID = Request.QueryString["ID"].ToString().Trim();
                addInvice.Price = int.Parse(Pricetxt.Text);
                addInvice.CreatedBy = Session["UserID"].ToString().Trim();
                addInvice.LastUpdatedBy = Session["UserID"].ToString().Trim();
                addInvice.PaymentMathordName = PaymentMethodDropDownList.SelectedValue;
                addInvice = Database.POS.InvoiceDB.addInviceData(addInvice);
                InitializePageContents();
            }
            Pricetxt.Text = "";
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

            if (check > 0)
            {
                InitializePageContents();
            }

            ErroMessage.Text = "Data is Updated...";

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/AddOrder.aspx?ID=" + Request.QueryString["ID"].ToString());
        }

        protected void AddInvoiceListview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (int.Parse(totalpaymettxt.Text) == int.Parse(TotalAmount.Text))
            {
                btnAddInvoice.Enabled = false;
                Control myControl1 = e.Item.FindControl("ItemCommandtd");
                if (myControl1 != null)
                    myControl1.Visible = false;
               
            }
        }

    }
}