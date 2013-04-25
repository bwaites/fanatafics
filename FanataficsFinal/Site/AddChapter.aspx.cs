using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using CKEditor;
namespace Site
{
    public partial class AddChapter : System.Web.UI.Page
    {
        protected HiddenField hidnEdit;

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
            if (ddlStory.SelectedValue != null)
            {
                //if story has been selected from ddlStory
                //make new chapter and fill in values using input values
                Chapter chap = new Chapter();
                chap.Title = this.txtChapTitle.Text;
                //gets storyID guid based on ddlStory selected value
                chap.StoryID = new Guid(this.ddlStory.SelectedValue);
                chap.ChapterContent = hidnEdit.Value;
                //TO DO: better logic for chapter order
                chap.ChapterOrder += 1;
                //if chapter is savable, save it to the db
                if (chap.IsSavable())
                {
                    chap = chap.Save();
                }
            }
            
        }

    }
}