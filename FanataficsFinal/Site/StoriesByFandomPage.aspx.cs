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
            
            
            getAuthor();
            
        }

        void getAuthor()
        {
            //make a new userstory
            UserStory usrStry = new UserStory();
            //make a StoryId and fill it with a query string
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //make a new user
            User usr = new User();
            //get the user by the story's id
            usr = usr.GetUserByStoryID(storyID);
            //set lblAuthor.Text to username of story

            Label lblAuthor = (Label)Page.FindControl("lblAuthor");

            lblAuthor.Text = usr.UserName;
        }
    }
}