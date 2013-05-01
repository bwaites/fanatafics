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
            if (!Page.IsPostBack)
            {
                ddlStory_Populate();
                if (ddlStory.Items.Count > 0)
                {
                    ddlChapters_Populate();
                    addChapterContent();
                }

                else
                {
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
                    //store chap.ChapterContent into hidnEdit.Value
                    hidnEdit.Value = chap.ChapterContent;
                    //Execute javascript that sets the text of the Editor
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction", "setText();", true);
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
            if (ddlStory.SelectedIndex >= 0)
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

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {

        }
    }
}

