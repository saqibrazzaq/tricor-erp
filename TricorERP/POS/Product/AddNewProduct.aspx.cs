using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Product
{
    public partial class AddNewProduct : System.Web.UI.Page
    {
        Models.POS.Product.ProductModel product = new Models.POS.Product.ProductModel();
        Database.POS.MainCatalog mainCatalogObject = new Database.POS.MainCatalog();

        SqlDataAdapter sda = null;

        int pId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pId = int.Parse(Request.QueryString["Pid"]);

            ErrorMessageLable.Text = "";
            sda = mainCatalogObject.showCatalogProducts("AllProducts");
            setListView();

            if (pId != 0 && Session["updateCheck"] != null) //update product
            {
                Savebtn.Text = "Update";
                product = Database.POS.CatalogProductDB.showProduct(pId, product);
                Session["updateCheck"] = null;
                showProduct();
            }
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            product.ProductName = ProductNameText.Text;
            product.ProductCode = ProductCodeText.Text;
            product.ProductTypeID = int.Parse(ProductTypeID.SelectedValue);
            product.UnitTypeID = int.Parse(UnitTypeID.SelectedValue);
            product.SalesPrice = float.Parse(SalePriceText.Text);
            product.PurchasePrice = float.Parse(PurchasePriceText.Text);
            product.ProductThresholdValue = int.Parse(ThresholdValueText.Text);
            product.ProductCatagory = int.Parse(Catagory.SelectedValue);
            product.ProductDescription = ProductDescriptionText.Text;
            product.CreatedBy = int.Parse(Session["RoleID"].ToString());
            product.LastUpdatedBy = int.Parse(Session["RoleID"].ToString());

            if (pId != 0)
            {
                string imgPath = uploadImage();
                int result = Database.POS.CatalogProductDB.updateProduct(pId, imgPath, product);
                if (result == 1)
                {
                    ErrorMessageLable.ForeColor = System.Drawing.Color.Green;
                    ErrorMessageLable.Text = "Data updated successfully...";
                    sda = mainCatalogObject.showCatalogProducts("AllProducts");
                    setListView();

                }
                else
                {
                    ErrorMessageLable.Text = "Data not updated, something went wrong";
                }

            }

            else
            {
                int productID = Database.POS.CatalogProductDB.AddProduct(product);
                string imgPath = uploadImage();
                Database.POS.CatalogProductDB.uploadImage(productID, imgPath);


                sda = mainCatalogObject.showCatalogProducts("AllProducts");
                setListView();

                ErrorMessageLable.ForeColor = System.Drawing.Color.Green;
                ErrorMessageLable.Text = "Data saved successfully...";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Product/AddNewProduct.aspx?pId=0");
        }

        protected void ProductList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int productId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "EditProduct")
            {
                Session["updateCheck"] = "update";
                Response.Redirect("~/POS/Product/AddNewProduct.aspx?pId=" + productId);
            }
            else if (e.CommandName == "DeleteProduct")
            {
                int temp = Database.POS.CatalogProductDB.deleteProduct(productId);
            }
            sda = mainCatalogObject.showCatalogProducts("AllProducts");
            setListView();
        }

        public void showProduct()
        {
            ProductNameText.Text = product.ProductName;
            ProductCodeText.Text = product.ProductCode;
            ProductTypeID.Text = product.ProductTypeID.ToString();
            UnitTypeID.Text = product.UnitTypeID.ToString();
            SalePriceText.Text = product.SalesPrice.ToString();
            PurchasePriceText.Text = product.PurchasePrice.ToString();
            ThresholdValueText.Text = product.ProductThresholdValue.ToString();
            Catagory.Text = product.ProductCatagory.ToString();
            ProductDescriptionText.Text = product.ProductDescription;
        }

        public void setListView()
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ProductList.DataSource = dt;
            ProductList.DataBind();
        }

        public string uploadImage()
        {
            string imgName = FileUpload1.FileName.ToString();
            string imgPath = "../../Images/Catalog/" + imgName;
            FileUpload1.SaveAs(Server.MapPath(imgPath));
            return imgPath;
        }
    }
}