using Database.SCM;
using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String UpdateCheck = null;
        String Productid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCheck = Request.QueryString["update"];
             Productid = Request.QueryString["ProductID"];
            if (UpdateCheck == "1" && IsPostBack == false)
                {
                ProductModel product = new ProductModel();
                product = Database.SCM.ProductDB.getProductInFo(Productid);
                ProductNameText.Text = product.ProductName;
                SalePriceText.Text = product.SalesPrice.ToString();
                PurchasePriceText.Text = product.PurchasePrice.ToString();
                ProductTypeID.Text = product.ProductTypeID.ToString();
                UnitTypeID.Text = product.UnitTypeID.ToString();
                PurchasePriceText.Text = product.PurchasePrice.ToString();
                ProductCodeText.Text = product.ProductCode;
                ProductDescriptionText.Text = product.ProductDescription;
                ThresholdValueText.Text = product.ProductThresholdValue.ToString();
                ReOrderValueText.Text = product.ProductReOderValue.ToString();
                ManufactureTimeText.Text = product.ManufactureTime.ToString();
              
                }
            else
            {
                //ProductNameText.Text = "";
                //ProductPriceText.Text = "";
                //ProductCodeText.Text = "";
                //ProductDescriptionText.Text = "";
                //ErrorMessageLable.Text = "";
            }
        }
        public int updateProduct(ProductModel pModel)
        {
            return Database.SCM.ProductDB.updateProduct(pModel);
        }
        
        protected ProductModel addNewProduct(ProductModel pModel)
        {
            return Database.SCM.ProductDB.addProduct(pModel);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            ProductModel product = new ProductModel();
            product.ProductTypeID = int.Parse(ProductTypeID.SelectedValue);
            product.UnitTypeID = int.Parse(UnitTypeID.SelectedValue);
            product.ProductName = ProductNameText.Text;
            product.ProductCode = ProductCodeText.Text;
            product.ProductThresholdValue = int.Parse(ThresholdValueText.Text);
            product.ProductReOderValue = int.Parse(ReOrderValueText.Text);
            product.SalesPrice = float.Parse(SalePriceText.Text);
            product.PurchasePrice = float.Parse(PurchasePriceText.Text);
            product.ProductDescription = ProductDescriptionText.Text;
            product.CreatedBy = int.Parse(Session["RoleID"].ToString());
            product.LastUpdatedBy = int.Parse(Session["RoleID"].ToString());
            product.ManufactureTime = int.Parse(ManufactureTimeText.Text);
            
            int updated = 0;
             ProductModel newProduct = null;
            if(UpdateCheck != null)
            {
                product.ProductID = int.Parse(Productid);
                product.LastUpdatedBy = int.Parse(Session["RoleID"].ToString());
                updated = updateProduct(product);
            }
            else
            {
               newProduct = addNewProduct(product);
            }

            if (newProduct != null)
            {
                ErrorMessageLable.Text = "Data of new Product is saved...";
            }
            else if(updated == 1)
            {
                ErrorMessageLable.Text = "Data is Updated Successfully...";
            }
        }
    }
}