using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String User = Session["Username"].ToString();
            //if (User == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
                if (IsPostBack == false)
                {
                    InitializePageContents();
                }
            //}
        }

        private void InitializePageContents()
        {
            UpdateDatabasePanels();
        }
        /*For checking the pending sales order and view the count of pending and
          view in-progress sales order*/
        private void UpdateDatabasePanels()
        {
            if (Session["RoleID"].ToString() == "1" || Session["RoleID"].ToString() == "2")
            {
                UpdatePOSPanels();
            }
        }
        /*That function load the data of Panels related to the POS*/
        private void UpdatePOSPanels()
        {
            GetPendingSalesOrder();
            GetInProgressSalesOrder();
            POSStockStatus();
        }
        /*Function get the count of pending sale order and set that count on the lable*/
        private void GetPendingSalesOrder()
        {
            int pendngsalesorder = GetPendingSalesOrderDB();
            PandingSaleOrderLabel.Text = pendngsalesorder.ToString();
        }
        private int GetPendingSalesOrderDB()
        {
            return Database.POS.Order.OrderDB.getPendingSalesOrderCount();
        }
        /*function set the count of inprogress salesorder on the label*/
        private void GetInProgressSalesOrder()
        {
            int inprogresssalesorder = GetInProgressSalesOrderDB();
            InProgressOrderLabel.Text = inprogresssalesorder.ToString();
        }
        private int GetInProgressSalesOrderDB()
        {
            return Database.POS.Order.OrderDB.getProgressSalesOrderCount();
        }
        /*function set the count of low stock status*/
        private void POSStockStatus()
        {
            int stockstatus = GetStockStatus();
            StockStatusLab.Text = stockstatus.ToString();
        }
        private int GetStockStatus()
        {
            return Database.POS.StockDB.getStockStatus();
        }
    }
}