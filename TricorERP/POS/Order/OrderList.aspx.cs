using Models.POS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Order
{
    public partial class OrderList : System.Web.UI.Page
    {
        // that list can manage all the saleorderlist thes list are get from database.
        List<SaleOrderModel> saleorderlist = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        // that function is work for initialize the page contents
        private void InitializePageContents()
        {
            SearchOrders("");
        }
        /* that function is work for searching the order from database and according to the search
           show the data of orders in the list view*/
        private void SearchOrders(string saleorder)
        {
            if (saleorder == null)
                saleorderlist = GetFromDatabase(null);
            else if (saleorder != null)
                saleorderlist = GetFromDatabase(saleorder);
            OrderListview.DataSource = saleorderlist;
            OrderListview.DataBind();
        }

        // that function get data from database and return an list of data
        private List<SaleOrderModel> GetFromDatabase(string p)
        {
            return Database.POS.Order.OrderDB.getOrderList(p);
        }

        // that function can get the data according to the  our requirement 
        protected void OrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit Sales order 
            if (e.CommandName == "EditSaleOrder")
            {
                // Customer ID is in argument
                String saleOrderID = e.CommandArgument.ToString();

                //get sale order information from database 
                //SaleOrderModel saleorderdata = GetOrderInFo(saleOrderID);

                // Open the edit customer page CustomerID=29&SaleOrderID=62
                Response.Redirect("AddOrder.aspx?ID=" + saleOrderID);
            }
        }

        // that method return an object of sale order information. 
        private SaleOrderModel GetOrderInFo(string customerID)
        {
            return Database.POS.Order.OrderDB.SaleOrderInFo(customerID);
        }

        // that method is used for checking the data from database after clicking the button of search
        protected void SearchOrderDataButton1_Click(object sender, EventArgs e)
        {
            SearchOrders(SearchOrderData.Text);
            // check if our data that i want o search is not present in database then show an  error message.
            if (saleorderlist.Count == 0)
                ErrorMessage.Text = @"Data is not found...";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}