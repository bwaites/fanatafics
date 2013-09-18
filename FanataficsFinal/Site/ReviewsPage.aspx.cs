using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class ReviewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if statement that will run if page is loading for the first time
            if (!Page.IsPostBack)
            {
                //make a guid called chapterID, set the value to ChapterID taken from query string
                Guid chapterID = new Guid(Request.QueryString["ChapterID"]);
                //make a guid called storyID, set the value to StoryID taken from query string
                Guid storyID = new Guid(Request.QueryString["StoryID"]);
                //call getTitle to get the title of the story, passing in storyID
                getTitle(storyID);
                //call ddlChapterList_Populate to populate the dropdownlist of chapters, passing in storyID
                ddlChapterList_Populate(storyID);
                //populate the repeater that holds the reviews, passing in chapterID
                rptReviews_Populate(chapterID);                
            }
        }
        protected void getTitle(Guid storyID)
        {
            //make a new story object
            Story stry = new Story();
            //get the right story by the storyID passed in
            stry = stry.GetById(storyID);
            //set the text property of lblStoryTitle to the title property of stry
            lblStoryTitle.Text = stry.Title;
        }
        protected void ddlChapterList_Populate(Guid storyID)
        {
            //make a new chapterlist called cl
            ChapterList cl = new ChapterList();
            // get the right chapter list by the storyID passed in
            cl = cl.GetByStoryID(storyID);
            //bind the list to ddlChapterList
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataTextField = "Title";
            ddlChapterList.DataValueField = "ID";
            ddlChapterList.DataBind();
        }
        protected void ddlChapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make a new guid called chapID, set it's value to the selected value of ddlChapterList
            Guid chapID = new Guid(this.ddlChapterList.SelectedValue);
            //populate the repeater of reviews, passing in new chapID
            rptReviews_Populate(chapID);
        }
        protected void rptReviews_Populate(Guid chapID)
        {
            //make a new ReviewList called rvwList
            ReviewList rvwList = new ReviewList();
            //get the right list by the chapID
            rvwList = rvwList.GetByChapterID(chapID);
            //bind the list to the repeater
            rptReviews.DataSource = rvwList.List;
            rptReviews.DataBind();
        }
    }
}