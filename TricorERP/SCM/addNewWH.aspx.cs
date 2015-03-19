using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }   
        protected WareHouseModel addNewWH(WareHouseModel warehouseModel)
        {
            return Database.SCM.WareHouseDB.addNewWareHouse(warehouseModel);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            WareHouseModel warehouse = new WareHouseModel();
            warehouse.Name = WHNameText.Text;
            warehouse.City = WHCityText.Text;
            warehouse.Email = WHEmailText.Text;
            warehouse.PhoneNumber = WHPhonenumberText.Text;
            warehouse.Location1 = WHLocation1Text.Text;
            warehouse.Location2 = WHLocation2Text.Text;
            WareHouseModel newWareHouse = addNewWareHouse(warehouse);
            if (newWareHouse != null)
                ErrorMessageLable.Text = "Data of new Product is saved.";
        }
    }
    }
}