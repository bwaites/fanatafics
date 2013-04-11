using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class CartoonsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StoryList sl = new StoryList();
            Guid categoryID = new Guid(Request.QueryString["CategoryID"]);
            sl = sl.GetByCategoryID(categoryID);

            rptCartoons.DataSource = sl.List;
            rptCartoons.DataBind();

        }
    }
}