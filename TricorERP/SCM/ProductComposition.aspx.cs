using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ProductComposition : System.Web.UI.Page
    {
        String ProductID = "-1";
        String ProductName = "-1";
        //ProductComposition PCModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Request.QueryString["PID"];
            ProductName = Request.QueryString["PName"];
            if (IsPostBack == false)
            {
                PNameText.Text = ProductID;
                LoadProductList();
                LoadProductSpecificationList(ProductID);
            }
        }

        private void LoadProductSpecificationList(string ProductID)
        {
            List<Models.SCM.ProductCompositionModel> PCList = null;
            PCList = getProductCompositionListFromDateBase(ProductID);

            RawMaterialListview.DataSource = PCList;
            RawMaterialListview.DataBind();
        }

        private List<ProductCompositionModel> getProductCompositionListFromDateBase(string ProductID)
        {
            return Database.SCM.ProductDB.getProductCompositionList(ProductID);
        }
        private void LoadProductList()
        {
            List<ProductModel> products = GetRawMaterialsFromDatabase();
            ProductDropDown.DataTextField = "ProductName";
            ProductDropDown.DataValueField = "ProductID";
            ProductDropDown.DataSource = products;
            ProductDropDown.DataBind();
        }
        private List<Models.SCM.ProductModel> GetRawMaterialsFromDatabase()
        {
            // 3 = rawMaterial
            return Database.SCM.ProductDB.getProductListOfType("3");
        }
        
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            ProductCompositionModel PCModel = new ProductCompositionModel();
            PCModel.RawMaterialID = int.Parse(ProductDropDown.SelectedValue);
            PCModel.ProductID = int.Parse(ProductID);
            PCModel.Quantity = int.Parse(QuantityText.Text);

            PCModel.CreatedBy = int.Parse(Session["RoleID"].ToString());
            PCModel.LastUpdatedBy = int.Parse(Session["RoleID"].ToString());
            AddRawMaterialInProductComposition(PCModel);
            Response.Redirect("~/SCM/ProductComposition.aspx?PID=" + ProductID + "&PName=0");
        }

        private ProductCompositionModel AddRawMaterialInProductComposition(ProductCompositionModel PCModel)
        {
            return Database.SCM.ProductDB.addProductCompositionItem(PCModel);
        }

        protected void UpdateProductCompositionItem_onClick(object sender, EventArgs e)
        {
            ProductCompositionModel PCModel = new ProductCompositionModel();
            PCModel.RawMaterialID = int.Parse(ProductDropDown.SelectedValue);
            PCModel.ProductID = int.Parse(ProductID);
            PCModel.Quantity = int.Parse(txtProductCompositionItemID.Text);
            PCModel.LastUpdatedBy = int.Parse(Session["RoleID"].ToString());
            UpdateProductComposition(PCModel);
            Response.Redirect("~/SCM/ProductComposition.aspx?PID=" + ProductID + "&PName=0");
        }

        private int UpdateProductComposition(ProductCompositionModel PCModel)
        {
            return Database.SCM.ProductDB.updateProductCompositionItem(PCModel);
        }
        protected void deleteProductCompositionItem_onClick(object sender, EventArgs e)
        {
            deleteProductComposition(txtProductCompositionItemID.Text);
            Response.Redirect("~/SCM/ProductComposition.aspx?PID=" + ProductID + "&PName=0");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SCM/ViewProducts.aspx");
        }

        private void deleteProductComposition(string id)
        {
            Database.SCM.ProductDB.DeleteProductCompositionItem(id);
        }
        protected void RawMaterialListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String ID = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
            }
            else if (e.CommandName == "Delete")
            {
            }
        }
    }
}