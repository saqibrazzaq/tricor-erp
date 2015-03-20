﻿using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class AddNewStockItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDropDownLists();
        }
        private void loadDropDownLists()
        {
            //WareHouseDropDown.DataSource = ;
        }
        protected StockModel addNewStockItem(StockModel sModel)
        {
            return Database.SCM.StockDB.addNewStockItem(sModel);
        }
        // getting products list..
        private List<Models.SCM.ProductModel> GetProductsFromDatabase()
        {
            return Database.SCM.ProductDB.getProductList("");
        }
        // getting WareHouses list..
        private List<Models.SCM.WareHouseModel> GetWareHouseFromDatabase()
        {
            return Database.SCM.WareHouseDB.getWareHouseList("");
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            StockModel sModel = new StockModel();
            sModel.WareHouseID = int.Parse(WareHouseDropDown.SelectedValue);
            sModel.ProductID = int.Parse(ProductDropDown.SelectedValue);
            sModel.Quantity = float.Parse(QuantityText.Text);
            StockModel SModel = addNewStockItem(sModel);
            if (SModel != null)
                ErrorMessageLable.Text = "Data of new Stock is saved...!!!";
        }
    }
    }

