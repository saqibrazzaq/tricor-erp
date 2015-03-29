using Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Order;

namespace TricorERP.POS.Order
{
    public partial class EditOrderItem : System.Web.UI.Page
    {
        String SaleOrderID = "0";
        String CustomerID  = "0";
        String SaleOrderItemID = "0";
        List<ProductModel> productlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SaleOrderID = Request.QueryString["SaleOrderID"];
            CustomerID = Request.QueryString["CustomerID"];
            SaleOrderItemID = Request.QueryString["SaleOrderItemID"];

            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            LoadProductDropdown();
            loadCustomerInFo(CustomerID);
            loadOrderInFo(SaleOrderID);
        }

        // that function can get the information of order and show on text field.
        private void loadOrderInFo(string SaleOrderID)
        {
            SaleOrderModel saleinfo = GetSaleOrderInFo();
            //set the order date of an saleorder
            OrderDate.Text = saleinfo.OrderDate;

        }
        private SaleOrderModel GetSaleOrderInFo()
        {
            return Database.POS.Order.OrderDB.SaleOrderInFo(SaleOrderID);
        }
        // get the customer information for show that information on the page.
        private void loadCustomerInFo(String id)
        {
            CustomerModel customerinfo = GetCustomerInFo(id);
            CustomerNameText.Text = customerinfo.Name;
            CNIC.Text = customerinfo.CNIC;
        }

        private CustomerModel GetCustomerInFo(String id)
        {
            return Database.POS.Customer.CustomerDB.getCustomerInFo(id);
        }

        // load data of products in drop-down list and bind with it. 
        private void LoadProductDropdown()
        {
            productlist = GetProductList();
            ProductDropDown.DataSource = productlist;
            ProductDropDown.DataTextField = "ProductName";
            ProductDropDown.DataValueField = "ProductID";
            ProductDropDown.DataBind();

            if (SaleOrderItemID != "0")
            {
                ProductDropDown.Items.FindByValue(SaleOrderItemID).Selected = true;
                productlist.ToString();
            }
        }

        protected void ProductDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////
            ProductDropDown.SelectedValue.ToString();
        }

        private List<ProductModel> GetProductList()
        {
            return Database.POS.ProductDB.getProductList("");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/EditOrder.aspx?SaleOrderID="+SaleOrderID);
        }

        
    }
}