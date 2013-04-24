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
            //make a chapter list
            ChapterList cl = new ChapterList();
            //make a storyID guid, passing the value in a query string 
            //(value of query string is stored in repeater)
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //get all chapters by storyID
            cl = cl.GetByStoryID(storyID);
            //bind the list to the ddlChapter
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataBind();
           

            
           
        }
    }
}