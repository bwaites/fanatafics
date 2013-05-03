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
            //check to make sure page isn't postback
            if (!Page.IsPostBack)
            {
                //populate the ddlStory
                ddlStory_Populate();
                //check and make sure ddlStory has items in it
                if (ddlStory.Items.Count > 0)
                {
                    //if ddlStory has items, populate ddlChapters and addChapterContent
                    ddlChapters_Populate();
                    addChapterContent();
                }
                else
                {
                    //if the page /has/ posted back, then populate the chapters
                    ddlChapters_Populate();
                }
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

        void ddlChapters_Populate()
        {
            //enable ddlChapters and make it visible
            ddlChapters.Enabled = true;
            ddlChapters.Visible = true;
            //make a new chapterlist
            ChapterList chapList = new ChapterList();
            //get the chapters by the story ID (taken from ddlStory)
            chapList = chapList.GetByStoryID(new Guid(this.ddlStory.SelectedValue));
            //bind chapList to ddlChapters
            ddlChapters.DataSource = chapList.List;
            ddlChapters.DataTextField = "Title";
            ddlChapters.DataValueField = "ID";
            ddlChapters.DataBind();
        }

        void addChapterContent()
        {
            //checks if ddlChapters has been loaded
            if (ddlChapters.Items.Count > 0)
            {
                //checks if something in ddlChapters has been selected
                if (ddlChapters.SelectedIndex >= 0)
                {
                    //make a new chapterID (using the value from ddlChapters)
                    Guid chapID = new Guid(ddlChapters.SelectedValue);
                    //make a new chapter
                    Chapter chap = new Chapter();
                    //get the proper chapter based on chapterID
                    chap = chap.GetById(chapID);
                    //put title of chapter into txtChapter
                    txtChapTitle.Text = chap.Title;
                    //store chap.ChapterContent into hidnEdit.Value
                    hidnEdit.Value = chap.ChapterContent;
                    //Execute javascript that sets the text of the Editor
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction", "setText();", true);
                    btnSaveChanges.Enabled = true;
                    btnSaveChanges .Visible = true;
                }
            }
        }

        protected void ddlChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a selection is changed, do addChapterContent
            addChapterContent();
        }

        protected void btnAddChapter_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //check and make sure the selectedindex is greater or equal to zero
            if (ddlStory.SelectedIndex >= 0)
            {
                if (ddlChapters.SelectedIndex >= 0)
                {
                    ChapterList chapList = new ChapterList();
                    chapList = chapList.GetByStoryID(new Guid(ddlStory.SelectedValue));
                    //Make a new chapter
                    Chapter chap = new Chapter();
                    //get the chapter by the chapterId (taken from ddlChapters)
                    chap = chap.GetById(new Guid(ddlChapters.SelectedValue));
                    //set the storyID of chapter to ddlStory's selected value
                    chap.StoryID = new Guid(ddlStory.SelectedValue);
                    //set the title based on txtChapTitle
                    chap.Title = txtChapTitle.Text;
                    //set chapterContent of Chap to the hidnEdit.value
                    chap.ChapterContent = hidnEdit.Value;
                    //chapter order is the same
                    
                    chap.ChapterOrder = chapList.List.Count + 1;
                    //change the chap.IsNew to false
                    chap.IsNew = false;
                    //change chap.isDirty to true
                    chap.IsDirty = true;
                    //check if chap is savable
                    if (chap.IsSavable())
                    {//if it's savable, save it
                        chap = chap.Save();
                        addChapterContent();
                    }
                }
            }           
        }
    }
}

