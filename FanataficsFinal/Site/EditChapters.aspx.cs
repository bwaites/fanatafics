using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Text.RegularExpressions;

namespace Site
{
    public partial class EditChapters : System.Web.UI.Page
    {
        protected HiddenField hidnExisting = new HiddenField();
        protected Chapter chap = new Chapter();
        protected bool bIsLoggedIn = false;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            checkIfLoggedIn(bIsLoggedIn);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //check for postback
            if (!Page.IsPostBack)
            {
                checkIfLoggedIn(bIsLoggedIn);
            }
        }
        protected void checkIfLoggedIn(bool bIsLoggedIn)
        {
            //make a variable called myNumb, and set its value to a converted number of Session "LoggedIn"
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            //if statement that will run if myNumb value is equal to 0
            if (myNumb == 0)
            {
                //set visible property of ddlChapters to 'false'
                ddlChapters.Visible = false;
                //set enabled property of ddlChapters to 'false'
                ddlChapters.Enabled = false;
                //clear items from ddlStory
                ddlStory.Items.Clear();
                //set bIsLoggedIn to 'false'
                bIsLoggedIn = false;
            }
            //else that will run if myNumb value is NOT equal to zero
            else
            {
                //set bIsLoggedIn to 'true'
                bIsLoggedIn = true;
                //call ddlStory_Populate
                ddlStory_Populate();
                //call ddlChapters_Populate
                ddlChapters_Populate();
            }
        }
        void ddlStory_Populate()
        {
            //make a new StoryList called storyList
            StoryList storyList = new StoryList();
            //Get right storyList based on UserID (stored in a sesson)
            storyList = storyList.GetByUserID(new Guid(Session["UserID"].ToString()));
            //bind the list to ddlStory
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
        protected void ddlChapters_DataBound(object sender, EventArgs e)
        {
            //get right chapter by ID taken from ddlChapters.SelectedValue
            chap = chap.GetById(new Guid(ddlChapters.SelectedValue));
            //call loadChapterContent
            loadChapterContent(chap.Title, chap.ChapterContent);
        }
        void ddlChapters_Populate()
        {
            //make a new ChapterList called chapList
            ChapterList chapList = new ChapterList();
            //enable ddlChapters
            ddlChapters.Enabled = true;
            //set ddlChapters visible property to true
            ddlChapters.Visible = true;
            //get the chapters by the story ID (taken from ddlStory's selected value)
            chapList = chapList.GetByStoryID(new Guid(this.ddlStory.SelectedValue));
            //bind chapList to ddlChapters
            ddlChapters.DataSource = chapList.List;
            ddlChapters.DataTextField = "Title";
            ddlChapters.DataValueField = "ID";
            ddlChapters.DataBind();
            //set ddlChapter's selected index to the index of chapter
            ddlChapters.SelectedIndex = ddlChapters.Items.IndexOf(ddlChapters.Items.FindByValue(chap.Id.ToString()));
        }
        protected void ddlChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if statement that will run if ddlChapters selected index is greater or equal to zero
            if (ddlChapters.SelectedIndex >= 0)
            {
                //get chapter from Id taken from ddlChapters
                chap = chap.GetById(new Guid(this.ddlChapters.SelectedValue));
                //call loadChapterContent, passing in the chap Title and ChapterContent
                loadChapterContent(chap.Title, chap.ChapterContent);
            }
        }
        void loadChapterContent(string title, string content)
        {
            //set the text of txtChapTitle to title passed in
            txtChapTitle.Text = title;
            //set the hidnExisting field to content passed in
            hidnExisting.Value = content;
            //replace all of the '&nbsp;' with actual spaces, so the text will wrap in the div
            hidnExisting.Value = Regex.Replace(hidnExisting.Value, @"(\s*)?&nbsp;(\s*)?", " ");
            //call javascript function to setText();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction", "setText();", true);
        }
        void editExistingChapter()
        {
            //make a new guid called chapID, set its value to ddlChapters selected value
            Guid chapID = new Guid(this.ddlChapters.SelectedValue);
            //get the proper chapter based on chapterID
            chap = chap.GetById(chapID);
            //set Title property of chap to text from txtChapTitle
            chap.Title = txtChapTitle.Text;
            //set ChapterContent property of chap to value of hidnExisting
            chap.ChapterContent = hidnExisting.Value;
            //set ChapterOrder property of chap to value of ChapterOrder property (it doesn't change)
            chap.ChapterOrder = chap.ChapterOrder;
            //set IsNew property of chap to false
            chap.IsNew = false;
            //set IsDirty property of chap to true
            chap.IsDirty = true;
        }
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //call editExistingChapter()
            editExistingChapter();
            //if statement will run if chapter is savable
            if (chap.IsSavable() == true)
            {
                //save the chap
                chap = chap.Save();
                //call loadChapterContent, passing in Title and ChapterContent properties of chap
                loadChapterContent(chap.Title, chap.ChapterContent);
            }
        }
    }
}