using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchStockItem : System.Web.UI.Page
    {
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
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
              
            }
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
            SearchStockItems(WareHouseDropDown.SelectedValue,SearchStockItemText.Text);
        }
    }
}