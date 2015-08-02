using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchStockItem : System.Web.UI.Page
    
    {

        public Boolean check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            LoadWarehouseList();
            SearchStockItems(WareHouseDropDown.SelectedValue, "");
        }
        private void SearchStockItems(String WHID,String Items)
        {
            // Declare list
            List<Models.SCM.StockModel> product = null;
            if (Items == "")
            {
                product = GetFromDatabase(WHID,null);
            }
            else if (Items != null)
            {
                product = GetFromDatabase(WHID,Items);
            }
            StockProductListview.DataSource = product;
            StockProductListview.DataBind();
        }
        private void LoadWarehouseList()
        {
            List<WareHouseModel> wareHouses = GetWareHouseFromDatabase();
            WareHouseDropDown.DataTextField = "Name";
            WareHouseDropDown.DataValueField = "ID";
            WareHouseDropDown.DataSource = wareHouses;
            WareHouseDropDown.DataBind();
        }
        private List<Models.SCM.WareHouseModel> GetWareHouseFromDatabase()
        {
            return Database.SCM.WareHouseDB.getWareHouseList("", Session["UserID"].ToString());
        }

        private List<Models.SCM.StockModel> GetFromDatabase(String WHID, String SearchProduct)
        {
            return Database.SCM.StockDB.getStockItems(WHID, SearchProduct);
        }
        private int DeleteStockItemFromDatabase(String ID)
        {
            return Database.SCM.StockDB.DeleteStockItem(ID);
        }
        private int UpdateStockItemInDatabase(StockModel SMODEL)
        {
            return Database.SCM.StockDB.updateStockItem(SMODEL);
        }
      
        protected void deleteStockItem_onClick(object sender, EventArgs e)
        {
            DeleteStockItemFromDatabase(txtStockItemID.Text);
            Response.Redirect("~/SCM/SearchStockItem.aspx");
        }
        protected void UpdateStockItem_onClick(object sender, EventArgs e)
        {
            StockModel SModel = new StockModel();
            SModel.ID = int.Parse(txtStockItemID.Text);
            SModel.Quantity = int.Parse(txtQuantity.Text);
            UpdateStockItemInDatabase(SModel);
            Response.Redirect("~/SCM/SearchStockItem.aspx");
        }
        protected void SearchWareHouse(object sender, EventArgs e)
        {
            String wareHouse = WareHouseDropDown.SelectedValue;
            SearchStockItems(wareHouse,SearchStockItemText.Text);
            if(wareHouse == Models.SCM.Common.OurWareHouseID.ToString())
            {
                check = true;
            }
           
        }
        //protected void SearchWareHouse()
        //{
        //    String wareHouse = WareHouseDropDown.SelectedValue;
        //   // SearchStockItems(wareHouse, SearchStockItemText.Text);
        //    if (wareHouse == Models.SCM.Common.OurWareHouseID.ToString())
        //    {
        //        check = true;
        //    }

        //}
        private int GetStockStatusSCM()
        {
            return Database.SCM.StockDB.getStockStatus();
        }
       
        protected void StockProductListview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // check for hidding coloumns of ReOrder
            String wareHouse = WareHouseDropDown.SelectedValue;
            if (wareHouse != Models.SCM.Common.OurWareHouseID.ToString())
            {
                HideColoumnsforOtherWarehouses(e);  
            }
            Models.SCM.StockModel stock = (Models.SCM.StockModel)e.Item.DataItem;
            if (stock.Quantity < 10)
            {
                // make the data row red
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("Tr1");
                row.Attributes.Add("Class", "alert-danger");
            } 
            
        }

        private void HideColoumnsforOtherWarehouses(ListViewItemEventArgs e)
        {
            Control myControl = e.Item.FindControl("ReOrderHeading");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
            myControl = e.Item.FindControl("EditHeading");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
            myControl = e.Item.FindControl("DeleteHeading");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
            myControl = e.Item.FindControl("ReOrderCol");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
            myControl = e.Item.FindControl("EditCol");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
            myControl = e.Item.FindControl("DeleteCol");
            if (myControl != null)
            {
                myControl.Visible = false;
            }
        }

        protected void StockProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ReOrder")
            {
                SalesOrderModel SO = new SalesOrderModel();
                // tricor warehouse ID Hardcoded
                SO.CustomerID = Models.SCM.Common.OurWareHouseID;
                SO.OrderDate = DateTime.Today.Date.ToString();
                SO.OrderStatus = 2;
                SO = Database.SCM.SalesOrder.addNewSaleOrder(SO);
                SalesOrderItemModel SOI = new SalesOrderItemModel();
                SOI.ProductID = int.Parse(e.CommandArgument.ToString());
                SOI.OrderID = SO.ID;
                SOI.ProductStatus = "Pending";
                SOI = Database.SCM.SalesOrder.addSaleOrderItems(SOI);                
            }
        }
    }
}