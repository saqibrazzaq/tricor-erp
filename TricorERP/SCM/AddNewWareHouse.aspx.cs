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
        protected WareHouseModel addNewWareHouse(WareHouseModel warehouseModel)
        {
            return Database.SCM.WareHouseDB.addNewWareHouse(warehouseModel);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            WareHouseModel warehouse = new WareHouseModel();
            warehouse.Name = WHNameText.Text;
            warehouse.Description = WHDescriptionText.Text;
            WareHouseModel newWareHouse = addNewWareHouse(warehouse);
            if (newWareHouse != null)
                ErrorMessageLable.Text = "Data of new Product is saved.";
        }
    }
    }
