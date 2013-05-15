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
        protected HiddenField hidnEdit;
        protected ChapterList chapList = new ChapterList();
        protected StoryList storyList = new StoryList();
        protected Chapter chap = new Chapter();

        protected void Page_Load(object sender, EventArgs e)
        {

            //check to make sure page isn't postback
            if (!Page.IsPostBack)
            {
                //call ddlStory_populate
                ddlStory_Populate();
            }
        }
        protected void ddlStory_Populate()
        {
            //set the first item in the ddlStory to be 'select a story'
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

        }
        protected void loadChapterContent(string title, string content)
        {
            //set txtChapTitle.Text to the title being passed in
            txtChapTitle.Text = title;
            //set hidnEdit.value to content being passed in
            hidnEdit.Value = content;
            //javascript to call the setText(); function
            ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction", "setText();", true);

        }
        protected void addNewChapter()
        {
            //make a new chapterlist
            chapList = new ChapterList();
            //make a new chapter
            chap = new Chapter();
            chapList = chapList.GetByStoryID(new Guid(this.ddlStory.SelectedValue));

            //set chap property values to input values 
            chap.StoryID = new Guid(ddlStory.SelectedValue);
            //set chap's title to txtChapTitle.Text
            chap.Title = txtChapTitle.Text;
            //set chap's chaptercontent to the hidnEdit.value
            chap.ChapterContent = hidnEdit.Value;
            //set the chap's chapter order to the chapterlist's count + 1
            chap.ChapterOrder = chapList.List.Count + 1;
        }
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //if statement checks to see status of bool blNewChap

            //if new, call addNewChapter()
            addNewChapter();
            //check to see if savable
            if (chap.IsSavable() == true)
            {
                //if savable, save it
                chap = chap.Save();
                //redirect to editChapters
                Server.Transfer("EditChapters.aspx", true);
            }
        }
    }
}

