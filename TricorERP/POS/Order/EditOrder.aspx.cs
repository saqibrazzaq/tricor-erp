using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Order;

// for get the products
using Models.POS;



namespace TricorERP.POS.Order
{
    public partial class EditOrder : System.Web.UI.Page
    {
        String SaleOrderID = "0";
        String CustoemrID = "0";
        List<CustomerModel> customerlist = null;
        DateTime dt = DateTime.Now;
        SaleOrderModel newsaleorder = null;
        SaleOrderItemModel saleorderitem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateText.Text = dt.ToShortDateString().ToString();
            SaleOrderID = Request.QueryString["SaleOrderID"];
            CustoemrID = Request.QueryString["CustomerID"];

            if (SaleOrderID == "0" && CustoemrID == "0") {
                AddProductsButten.Enabled = false;
            }
            
            if (CustoemrID != "0") {
                CustomerDropDown.Enabled = false;            
            }

            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            //if (CustoemrID == "0")
                LoadCustomerListInDropdown();
            //else { }
                //CustomerDropDown.Items.FindByValue(CustoemrID).Selected = true;
            if(SaleOrderID!="0")
                LoadSalesOrderItemData();
        }

        // that function load the data of items that are buy by a customer
        private void LoadSalesOrderItemData()
        {
            List<ProductModel> selecteditem = null;
            selecteditem = GetSaleOrderItemList();
            OrderListview.DataSource = selecteditem;
            OrderListview.DataBind();
        }

        /* that function return a list of items from database that list is 
           related to the a customer purchases*/
        private List<ProductModel> GetSaleOrderItemList()
        {
            return Database.POS.Order.OrderDB.getSaleOrderItemList(SaleOrderID);
        }

        // load all the customer these are singe an proper agreement of create customer. 
        private void LoadCustomerListInDropdown()
        {
            //customer list is an list type object that can bind all the customer list
            customerlist = GetCustomerList();
            CustomerDropDown.DataSource = customerlist;
            CustomerDropDown.DataTextField = "Name";
            CustomerDropDown.DataValueField = "ID";
            CustomerDropDown.DataBind();
            if(CustoemrID != "0")
                CustomerDropDown.Items.FindByValue(CustoemrID).Selected = true;
        }

        // that function get the data of customer and bind that data with a drop-down list.
        private List<CustomerModel> GetCustomerList()
        {
            return Database.POS.Customer.CustomerDB.getCustomersList("");
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String ProductID = e.CommandArgument.ToString();

            // these function can get the data of newsaleorer and sales order item 
            newsaleorder = Database.POS.Order.OrderDB.SaleOrderInFo(SaleOrderID);
            saleorderitem = Database.POS.Order.OrderDB.getSaleOrderItem(newsaleorder.ID, ProductID);

            // Edit customer command
            if (e.CommandName == "DeleteOrderItem")
            {
                // if data is deleted in the data base then also increment the quantity of that product
                int check = Database.POS.Order.OrderDB.deleteSaleOrderItem(saleorderitem.ID);
                if(check > 0)
                        Response.Redirect("EditOrder.aspx?SaleOrderID=" + newsaleorder.ID 
                                         + "&CustomerID=" + CustomerDropDown.SelectedValue);
            }
            else if (e.CommandName == "EditOrderItem")
            {
                //when new sale-order is added in the database then also decreases the product quantity 
                Response.Redirect("EditOrderItem.aspx?SaleOrderID="+newsaleorder.ID+"&CustomerID="+CustomerDropDown.SelectedValue
                    +"&SaleOrderItemID="+saleorderitem.ID+"&ProductID="+ProductID);
            }
        }

        protected void CustomerListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddProductsButten_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/EditOrderItem.aspx?SaleOrderID=" + SaleOrderID + "&CustomerID=" 
                + CustomerDropDown.SelectedValue + "&SaleOrderItemID=0");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaleOrderID == "0")
                newSaleOrder();
            
        }

        // function for save the new sale order into database.
        private void newSaleOrder()
        {
            newsaleorder = new SaleOrderModel();
            newsaleorder.OrderDate = dt.ToShortDateString();
            newsaleorder.CustomerID = int.Parse(CustomerDropDown.SelectedValue);
            newsaleorder = Database.POS.Order.OrderDB.assNewSaleOrder(newsaleorder);
            // if (newsaleorder.ID != 0)
                Response.Redirect("~/POS/Order/EditOrderItem.aspx?SaleOrderID=" + newsaleorder.ID + "&CustomerID=" + newsaleorder.CustomerID + "&SaleOrderItemID=0");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}