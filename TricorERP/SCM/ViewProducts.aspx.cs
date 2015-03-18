﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewProducts : System.Web.UI.Page
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
            SearchProduct("");
        }
        private void SearchProduct(String SearchProduct)
        {
            // Declare list
            List<Models.SCM.ProductModel> product = null;
            if (SearchProduct == null)
            {
                product = GetFromDatabase(null);
            }
            else if (SearchProduct != null)
            {
                product = GetFromDatabase(SearchProduct);
            }
            CustomerListview.DataSource = product;
            CustomerListview.DataBind();
        }

        private List<Models.SCM.ProductModel> GetFromDatabase(String SearchProduct)
        {
            return Database.SCM.ProductDB.getProductList(SearchProduct);
        }
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                String ProductID = e.CommandArgument.ToString();
                Response.Redirect("EditProduct.aspx?ID=" + ProductID);
                Session["ProductID"] = ProductID;
            }
        }

        protected void SearchProduct(object sender, EventArgs e)
        {
            SearchProduct(SearchProductText.Text);
        }

    }
}