using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class AddChapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //find lblLogin on Master Page, store it in mpLabel
            Label mpLabel = (Label)Master.FindControl("lblLogin");
            //if mpLabel.Text is NOT equal to "Login" then populate list
            if (mpLabel.Text != "Login")
            {
                ddlStory_Populate();
            }                  
        }

        void ddlStory_Populate()
        {
            //Make a story list
            StoryList storyList = new StoryList();
            //Get stories based on UserID (stored in a sesson from Login.Aspx)
            storyList = storyList.GetByUserID(new Guid(Session["UserID"].ToString()));
            //bind the title of list to ddlStory
            ddlStory.DataSource = storyList.List;
            ddlStory.DataTextField = "Title";
            ddlStory.DataValueField = "ID";
            ddlStory.DataBind();

        }

        protected void btnAddChapter_Click(object sender, EventArgs e)
        {
            
        }

    }
}