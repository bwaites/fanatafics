using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class StoryPage : System.Web.UI.Page
    {
        //make a new story
        protected Story story = new Story();
        // make a new chapter
        protected Chapter c = new Chapter();
        //make a new chapter list 
        protected ChapterList cl = new ChapterList();
        //make a new user
        protected User usr = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            //call getAuthor to get the author of the story            
            getAuthor();
            //call getTitle to get the title of the story
            getTitle();

            if (!Page.IsPostBack)
            {
                //call ddlChapters_Populate to populate ddlChapters
                ddlChapters_Populate();
            }
        }

        protected void ddlChapters_Populate()
        {
            //make a storyID guid, passing the value in a query string 
            //(value of query string is stored in repeater on StoryByFandom page)
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //get all chapters by storyID
            cl = cl.GetByStoryID(storyID);
            //bind the list to the ddlChapter
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataTextField = "Title";
            ddlChapterList.DataValueField = "ID";
            ddlChapterList.DataBind();
        }

        protected void ddlChapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make a new guid for the chapterID, getting the value from ddlChapterList selected value
            Guid chapterID = new Guid(this.ddlChapterList.SelectedValue);
            //make a new chapter object called selectedChapter
            Chapter selectedChapter = new Chapter();
            //get the selectedChapter by the ChapterID
            selectedChapter = selectedChapter.GetById(chapterID);
            //set dvChapterContent's innerhtml to the selectedChapter.ChapterContent
            dvChapterContent.InnerHtml = selectedChapter.ChapterContent;
        }
        protected void ddlChapterList_DataBound(object sender, EventArgs e)
        {
            //after the items have been bound to the list, get the reviews
            getReviews();
            //get the chapter based on the id of selectedvalue from ddlChapterList
            c = c.GetById(new Guid(this.ddlChapterList.SelectedValue));
            //set dvChapterContent to equal c.chaptercontent
            dvChapterContent.InnerHtml = c.ChapterContent;
        }

        protected void getTitle()
        {
            //make a guid for the StoryID, filling it using a querystring
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //use StoryID to get the proper story
            story = story.GetById(storyID);
            //set the text of lblStoryTitle to story.Title
            lblStoryTitle.Text = story.Title;
        }

        protected void getAuthor()
        {
            //make a new userstory
            UserStory usrStry = new UserStory();
            //make a StoryId and fill it with a query string
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //make a new user
            User usr = new User();
            //get the user by the story's id
            usr = usr.GetUserByStoryID(storyID);
            //set lblAuthor.Text to username of story
            lblAuthor.Text = usr.UserName;
        }

        protected void getReviews()
        {
            //make a new guid called chapterID
            Guid chapterID = new Guid();
            //make a new guid called storyID
            Guid storyID = new Guid();
            //set chapterID guid to the value of ddlChapterList
            chapterID = new Guid(this.ddlChapterList.SelectedValue);
            //set story ID to the value stored in querystring on storiesbyfandompage
            storyID = new Guid(Request.QueryString["StoryID"]);
            //make string called navUrl, set the value to a url with query parameters
            String navUrl = "~/ReviewsPage.aspx?ChapterID=" + chapterID.ToString() + "&StoryID=" + storyID.ToString();
            //set hyperlink navigateurl of hlReviews to navUrl
            hlReviews.NavigateUrl = navUrl;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //checks to see if the text area containing the review isn't null
            if (txtaReview.Value != null)
            {
                //checks to see if either txtGuestReviewer or lblReviewer.Text !=null
                if (txtGuestReviewer.Text != null || lblReviewerName.Text != null)
                {
                    //call submit review
                    submitReview();
                }
            }
        }

        protected void submitReview()
        {
            //make a new review object
            Review review = new Review();
            //set the chapter ID to the selected value of ddlChapterList
            review.ChapterID = new Guid(this.ddlChapterList.SelectedValue);
            //set reviewername to txtGuestReviewer.Text
            review.ReviewerName = this.txtGuestReviewer.Text;
            //call checkIfLoggedIn()
            checkIfLoggedIn();
            //set review content to the text area value
            review.ReviewContent = txtaReview.Value;
            //check if review is savable
            if (review.IsSavable() == true)
            {
                //if savable, save it
                review = review.Save();
                //empty txta and txtG
                txtaReview.Value = null;
                txtGuestReviewer.Text = null;
            }
        }

        protected void checkIfLoggedIn()
        {
            //set usr to a new instance
            usr = new User();
            //try to get the user by a session called UserID (only exists if they're logged in)
            try
            {
                usr = usr.GetById(new Guid(Session["UserID"].ToString()));
            }
            catch
            {
                //if it can't, then usr.Id = guid.empty
                usr.Id = Guid.Empty;
            }
        }


    }
}