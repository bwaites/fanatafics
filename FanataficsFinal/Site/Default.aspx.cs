using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using BusinessObjects;
namespace Site
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the rpCategory_Populate to populate categories
            rpCategory_Populate();            
        }

        void rpCategory_Populate()
        {
            //make category list
            CategoryList catList = new CategoryList();
            //get all categories
            catList = catList.GetAll();
            //bind the list to the repeater
            rptCategories.DataSource = catList.List;
            rptCategories.DataBind();
        }
    }
}