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
            //make a storylist
            StoryList sl = new StoryList();
            //make a fandomID guid, passing the value in a query string 
            //(value of query string is stored in repeater)
            Guid fandomID = new Guid(Request.QueryString["FandomID"]);
            //get all stories by the appropriate fandom
            sl = sl.GetByFandomID(fandomID);
            //bind list of stories to repeater
            rptStories.DataSource = sl.List;
            rptStories.DataBind();
        }
    }
}