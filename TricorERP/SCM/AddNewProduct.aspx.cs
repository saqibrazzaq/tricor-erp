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
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //ProductNameText.Text = "" ;
            //ProductPriceText.Text = "";
            //ProductCodeText.Text = "";
            //ProductDescriptionText.Text = "";
            //ErrorMessageLable.Text = "";
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
            product.ProductPrice = float.Parse(ProductPriceText.Text);
            product.ProductDescription = ProductDescriptionText.Text;
            ProductModel newProduct = addNewProduct(product);
            if (newProduct != null)
                ErrorMessageLable.Text = "Data of new Product is saved.";
        }
    }
}