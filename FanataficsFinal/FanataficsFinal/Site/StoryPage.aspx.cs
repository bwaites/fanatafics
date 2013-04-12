using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class StoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Story story = new Story();
            Guid storyID = new Guid(Request.QueryString["StoryID"]);

            story = story.GetById(storyID);


            
           
        }
    }
}