using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class BatmanFandom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StoryList sl = new StoryList();
            Guid fandomID = new Guid(Request.QueryString["FandomID"]);
            sl = sl.GetByFandomID(fandomID);

            rptStories.DataSource = sl.List;
            rptStories.DataBind();
        }
    }
}