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
    public partial class StoryPage : System.Web.UI.Page
    {
        //make a protected bool called bIsLoggedIn, set it's value to false
        protected bool bIsLoggedIn = false;
        //make a protected Chapter called chapter
        protected Chapter chapter = new Chapter();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //call checkIfLoggedIn, passing in bIsLoggedIn
            checkIfLoggedIn(bIsLoggedIn);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if statement that will run if the page is loading for the first time   
            if (!Page.IsPostBack)
            {
                //set storyID's guid value to the querystring from StoriesInFandomPage
                Guid storyID = new Guid(Request.QueryString["StoryID"]);
                //call ddlChapters_Populate to populate ddlChapters, passing in storyID
                ddlChapters_Populate(storyID);
                //call getAuthor to get the author of the story            
                getAuthor(storyID);
                //call getTitle to get the title of the story
                getTitle(storyID);
                //call getReviews to get the reviews of the story
                getReviews(storyID);
                //call loadChapterContent to load the chapter content
                loadChapterContent();
                //call checkIfLoggedIn, passing in bIsLoggedIn                
            }
        }
        protected void checkIfLoggedIn(bool bIsLoggedIn)
        {
            //make a variable called myNumb, and set its value to a converted number of Session "LoggedIn"
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            //if statement that will run if myNumb value is equal to 0
            if (myNumb == 0)
            {
                //the user must be a guest so show the textbox for the Guest to put their name in
                txtGuestReviewer.Visible = true;
                //set the visible property of lblReviewername to 'false'
                lblReviewerName.Visible = false;
                //set bIsLoggedIn to 'false'
                bIsLoggedIn = false;
            }
            //else that will run if myNumb value is NOT equal to zero
            else
            {
                //make a string called sUserName, set its value to the Session "UserName"
                string sUserName = Session["UserName"].ToString();
                //set the visible property of lblReviewerName to 'true'
                lblReviewerName.Visible = true;
                //set text property of  lblReviewerName to sUserName
                lblReviewerName.Text = sUserName;
                //set visible property of txtGuestReviewer to 'false'
                txtGuestReviewer.Visible = false;
                //set bIsLoggedIn to 'true'
                bIsLoggedIn = true;
            }
        }
        protected void ddlChapters_Populate(Guid storyID)
        {
            //make a new chapter list 
            ChapterList cl = new ChapterList();
            //get all chapters by storyID
            cl = cl.GetByStoryID(storyID);
            //bind the list to the ddlChapter
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataTextField = "Title";
            ddlChapterList.DataValueField = "ID";
            ddlChapterList.DataBind();

            ddlChapterList.SelectedIndex = ddlChapterList.Items.IndexOf(ddlChapterList.Items.FindByValue(chapter.Id.ToString()));
        }
        protected void ddlChapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call loadChapterContent
            loadChapterContent();
        }
        protected void getTitle(Guid storyID)
        {
            //make a new story object
            Story story = new Story();
            //find the right story object by storyID
            story = story.GetById(storyID);
            //set the text of lblStoryTitle to the value of story.Title
            lblStoryTitle.Text = story.Title;
        }
        protected void getAuthor(Guid storyID)
        {
            //make a new user
            User usr = new User();
            //get the user by the story's id
            usr = usr.GetUserByStoryID(storyID);
            //set lblAuthor.Text to username of story
            hlAuthor.Text = usr.UserName;
            //set navigation url of hlAuthor to the appropriate userpage
            hlAuthor.NavigateUrl = "~/UserPage.aspx?UserID=" + usr.Id;
        }
        protected void getReviews(Guid storyID)
        {
            //make a new guid called chapterID
            Guid chapterID = new Guid();
            //set chapterID guid to the value of ddlChapterList
            chapterID = new Guid(this.ddlChapterList.SelectedValue);

            //make string called navUrl, set the value to a url with query parameters
            String navUrl = "~/ReviewsPage.aspx?ChapterID=" + chapterID + "&StoryID=" + storyID;
            //set hyperlink navigateurl of hlReviews to navUrl
            hlReviews.NavigateUrl = navUrl;
        }
        protected void loadChapterContent()
        {
            //set ddlChapterList's seletected index to the index of chapter
            ddlChapterList.SelectedIndex = ddlChapterList.Items.IndexOf(ddlChapterList.Items.FindByValue(chapter.Id.ToString()));
            //make a new guid called ID
            Guid chapterID = new Guid(this.ddlChapterList.SelectedValue);        
            //get the chapter by the ChapterID
            chapter = chapter.GetById(chapterID);
            //set dvChapterContent's innerhtml to the chapter.ChapterContent            
            dvChapContent.InnerHtml = chapter.ChapterContent;
            //replace all of the '&nbsp;' with actual spaces, so the text will wrap in the div
            dvChapContent.InnerHtml = Regex.Replace(dvChapContent.InnerHtml, @"(\s*)?&nbsp;(\s*)?", " ");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            //if statement that will run if the text in txtReview is NOT null
            if (txtReview.Text.Trim() != null)
            {
                //if statement that will run if either txtGuestReviewer or lblReviewerName.Text are NOT null
                if (txtGuestReviewer.Text.Trim() != null || lblReviewerName.Text.Trim() != null)
                {
                    submitReview(bIsLoggedIn);
                }
            }
        }
        protected void submitReview(bool bIsLoggedIn)
        {
            //make a new review object
            Review review = new Review();
            //set the chapter ID to the selected value of ddlChapterList
            review.ChapterID = new Guid(this.ddlChapterList.SelectedValue);
            //set reviewername to txtGuestReviewer.Text
            review.ReviewerName = this.txtGuestReviewer.Text;
            //if statement that will run if bIsLoggedIn is equal to 'true'
            if (bIsLoggedIn == true)
            {
                //set ReviewerName property of review to text from lblReviewerName
                review.ReviewerName = lblReviewerName.Text;
                //set UserId property of review to a guid taken from Session "UserID"
                review.UserID = new Guid(Session["UserID"].ToString());
            }
            //else bIsLoggedIn is equal to 'false' so do this
            else
            {
                //set ReviewerName property of review to text from txtGuestReviewer
                review.ReviewerName = txtGuestReviewer.Text;
                //set UserId property of review to an empty guid
                review.UserID = Guid.Empty;
            }        
            //set ReviewContent property of review to text from txtReview
            review.ReviewContent = txtReview.Text;
            //if statement that will run if review is savable
            if (review.IsSavable() == true)
            {
                //if savable, save it
                review = review.Save();
                //empty the text of txtReview and txtGuestReviewer
                txtReview.Text = null;
                txtGuestReviewer.Text = null;
            }
        }
    }
}