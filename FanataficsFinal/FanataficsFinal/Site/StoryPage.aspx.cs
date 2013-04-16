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
            ChapterList cl = new ChapterList();
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            cl = cl.GetByStoryID(storyID);

            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataBind();
           

            
           
        }
    }
}