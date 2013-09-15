using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class EditChapters : System.Web.UI.Page
    {
        protected HiddenField hidnExisting = new HiddenField();
        protected ChapterList chapList = new ChapterList();
        protected StoryList storyList = new StoryList();
        protected Chapter chap = new Chapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            //check for postback
            if (!Page.IsPostBack)
            {
                //make a number called myNumb and give it a value from session LoggedIn
                var myNumb = Convert.ToInt32(Session["LoggedIn"]);
                if (myNumb <= 0)
                {
                    //if myNumb is less than or equal to zero, assume there is no one logged in
                }
                else
                {
                    //if myNumb is equal to anything else, assume user is logged in and populate the following
                    ddlStory_Populate();
                    ddlChapters_Populate();
                }
            }
             
        }

        void ddlStory_Populate()
        {
            //enable ddlStory and make it visible
            ddlStory.Enabled = true;
            ddlStory.Visible = true;

            //Get stories based on UserID (stored in a sesson from Login.Aspx)
            storyList = storyList.GetByUserID(new Guid(Session["UserID"].ToString()));
            //bind the title of list to ddlStory
            ddlStory.DataSource = storyList.List;
            ddlStory.DataTextField = "Title";
            ddlStory.DataValueField = "ID";
            ddlStory.DataBind();

        }
        protected void ddlStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call ddlChapters_Populate
            ddlChapters_Populate();
            
        }
        protected void ddlStory_DataBound(object sender, EventArgs e)
        {
            //after ddlStory has been bound, populate ddlChapters
        }
        
        protected void ddlChapters_DataBound(object sender, EventArgs e)
        {
            ////try to get chapter by ID taken from ddlChapters.SelectedValue
            //chap = chap.GetById(new Guid(ddlChapters.SelectedValue));
            ////call loadChapterContent
            //loadChapterContent(chap.Title, chap.ChapterContent);
        }
        void ddlChapters_Populate()
        {
            //enable ddlChapters
            ddlChapters.Enabled = true;
            //get the chapters by the story ID (taken from ddlStory)
            chapList = chapList.GetByStoryID(new Guid(this.ddlStory.SelectedValue));
            //bind chapList to ddlChapters
            ddlChapters.DataSource = chapList.List;
            ddlChapters.DataTextField = "Title";
            ddlChapters.DataValueField = "ID";
            ddlChapters.DataBind();

            ddlChapters.SelectedIndex = ddlChapters.Items.IndexOf(ddlChapters.Items.FindByValue(chap.Id.ToString()));
            
        }
        protected void ddlChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a selection is changed, do loadChapterContent
            if (ddlChapters.SelectedIndex >= 0)
            {
                //get chapter from Id taken from ddlChapters
                chap = chap.GetById(new Guid(this.ddlChapters.SelectedValue));
                //call loadChapterContent
                loadChapterContent(chap.Title, chap.ChapterContent);
            }
        }

        void getChapterContent()
        {
            
        }
        void loadChapterContent(string title, string content)
        {
            //sets the text of txtChapTitle to title passed in
            txtChapTitle.Text = title;
            //sets the hidnExisting field to content passed in
            hidnExisting.Value = content;
            //calls javascript function to setText();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction", "setText();", true);

        }
        void editExistingChapter()
        {
            Guid chapID = new Guid(this.ddlChapters.SelectedValue);
            //get the proper chapter based on chapterID
            chap = chap.GetById(chapID);
            //put title of chapter into txtChapter
            txtChapTitle.Text = chap.Title;
            ddlChapters.Enabled = true;
            ddlChapters.Visible = true;
            hidnExisting.Value = chap.ChapterContent;
            chap.ChapterOrder = chap.ChapterOrder;
            chap.IsNew = false;
            //change chap.isDirty to true
            chap.IsDirty = true;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {

            //call editExistingChapter()
            editExistingChapter();
            //checks to see if chap is savable
            if (chap.IsSavable() == true)
            {
                //if it's savable, save it
                chap = chap.Save();
                //call loadChapterContent
                loadChapterContent(chap.Title, chap.ChapterContent);
            }
        }


    }
}