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
        String check = null;
        String id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            check = Request.QueryString["update"];
             id = Request.QueryString["ProductID"];
            if (check == "1")
                {
                ProductModel product = new ProductModel();
                product = Database.SCM.ProductDB.getProductInFo(id);
                ProductNameText.Text = product.ProductName;
                ProductPriceText.Text = product.ProductPrice.ToString();
                ProductCodeText.Text = product.ProductCode;
                ProductDescriptionText.Text = product.ProductDescription;
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
            product.ProductName = ProductNameText.Text;
            product.ProductCode = ProductCodeText.Text;
            product.ProductThresholdValue = int.Parse(ThresholdValueText.Text);
            product.ProductReOderValue = int.Parse(ReOrderValueText.Text);
            product.ProductPrice = float.Parse(ProductPriceText.Text);
            product.ProductDescription = ProductDescriptionText.Text;
            int updated = 0;
             ProductModel newProduct = null;
            if(check != null)
            {
                product.ProductID = int.Parse(id);
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