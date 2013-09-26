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
        //make a bool called bIsLoggedIn, set it to 'false'
        protected bool bIsLoggedIn = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if statement will run if the page has NOT posted back to itself
            if (!Page.IsPostBack)
            {
                //call CheckIfLoggedIn, passing in bIsLoggedIn
                CheckIfLoggedIn(bIsLoggedIn);
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //if statement will run if Page HAS posted back to itself
            if (Page.IsPostBack)
            {
                //call CheckIfLoggedIn, passing in bIsLoggedIn
                CheckIfLoggedIn(bIsLoggedIn);
            }
        }
        protected void CheckIfLoggedIn(bool bIsLoggedIn)
        {
            //make a variable called myNumb, and set its value to a converted number of Session "LoggedIn"
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            //if statement that will run if myNumb value is equal to 0
            if (myNumb == 0)
            {               
                //set bIsLoggedIn to 'false'
                bIsLoggedIn = false;
            }
            //else that will run if myNumb value is NOT equal to zero
            else
            {
                //set bIsLoggedIn to 'true'
                bIsLoggedIn = true;
                //make a new guid called userID and give it a value from session
                ddlStory_Populate();
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

