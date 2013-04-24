using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class FandomPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //make a fandom list
            FandomList fl = new FandomList();
            //make a categoryID guid, passing the value in a query string 
            //(value of query string is stored in repeater)
            Guid categoryID = new Guid(Request.QueryString["CategoryID"]);
            //get all fandoms by categoryID
            fl = fl.GetByCategoryID(categoryID);
            //bind the list of appropriate fandoms to repeater
            rptFandoms.DataSource = fl.List;
            rptFandoms.DataBind();
        }
    }
}