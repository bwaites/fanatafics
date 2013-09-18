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
        //make a protected hiddenfield 
        protected HiddenField hidnEdit;
        //make a protected Chapter called chap
        protected Chapter chap = new Chapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if statement that will run if the page is loading for the first time
            if (!Page.IsPostBack)
            {
                //make a variable called myNumb, set its value to
                //the converted number of Session["LoggedIn"]
                var myNumb = Convert.ToInt32(Session["LoggedIn"]);
                //if statement will run if myNumb is equal to zero
                if (myNumb == 0)
                {
                }
                //else, the user must be logged
                else
                {
                    //call ddlStory_populate
                    ddlStory_Populate();
                }
            }
        }
        protected void ddlStory_Populate()
        {
            //make a new StoryList called storyList
            StoryList storyList = new StoryList();
            //Get stories based on UserID (stored in a sesson)
            storyList = storyList.GetByUserID(new Guid(Session["UserID"].ToString()));
            //bind the list to ddlStory
            ddlStory.DataSource = storyList.List;
            ddlStory.DataTextField = "Title";
            ddlStory.DataValueField = "ID";
            ddlStory.DataBind();
        }
        protected void ddlStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call loadChapterContent, passing in chap.Title and chap.ChapterContent
            //loadChapterContent(chap.Title, chap.ChapterContent);
        }
        protected void addNewChapter()
        {
            //make a new chapterlist (use this to get the count)
            ChapterList chapListForCount = new ChapterList();
            //make a new chapter
            chap = new Chapter();
            //get the right chapList by the storyID taken from ddlStory's selected value
            chapListForCount = chapListForCount.GetByStoryID(new Guid(this.ddlStory.SelectedValue));

            //set chap's storyID property to selected value of ddlStory
            chap.StoryID = new Guid(ddlStory.SelectedValue);
            //set chap's title property to text from txtChapTitle
            chap.Title = txtChapTitle.Text;
            //set chap's chaptercontent property to value from hidnEdit
            chap.ChapterContent = hidnEdit.Value;
            //set the chap's chapter order to the chapterlist's count + 1
            chap.ChapterOrder = chapListForCount.List.Count + 1;
        }
        protected void btnAddChapter_Click(object sender, EventArgs e)
        {
            //call addNewChapter()
            addNewChapter();
            //check to see if chap is savable
            if (chap.IsSavable() == true)
            {
                //if savable, save it
                chap = chap.Save();
                //refresh page
                Response.Redirect("AddChapter.aspx");
            }
        }
        protected void btnGoToEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditChapters.aspx");
        }
    }
}

