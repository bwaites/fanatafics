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
            //make a guid called StoryID and get appropriate guid from query string
            
            getAuthor();
            getTitle();
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            if (!Page.IsPostBack)
            {
                //binds the cl to the datalist and also makes it populate if 
                //page is not postback
                ddlChapterList.DataSource = cl.List;
                ddlChapters_Populate();
            }
            else
            {
                //get the first chapter based on story ID if it's not post back
                c = c.GetFirstByStoryID(storyID);
                //set the chapterContent div's innerhtml to c.ChapterContent
                dvChapterContent.InnerHtml = c.ChapterContent;
            }              
        }

        void ddlChapters_Populate()
        {            
            //make a storyID guid, passing the value in a query string 
            //(value of query string is stored in repeater on StoryByFandom page)
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //get all chapters by storyID
            cl = cl.GetByStoryID(storyID);
            //bind the list to the ddlChapter
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

        void getTitle()
        {
            //make a guid for the StoryID, filling it using a querystring
            Guid storyID = new Guid(Request.QueryString["StoryID"]);
            //use StoryID to get the proper story
            story = story.GetById(storyID);
            //set the text of lblStoryTitle to story.Title
            lblStoryTitle.Text = story.Title;
        }

        void getAuthor()
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
    }
}