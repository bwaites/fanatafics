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
            if (!Page.IsPostBack)
            {
                Guid chapterID = new Guid(Request.QueryString["ChapterID"]);
                Guid storyID = new Guid(Request.QueryString["StoryID"]);
                getTitle(storyID);
                ddlChapterList_Populate(storyID);
                rptReviews_Populate(chapterID);
                
            }
        }

        protected void getTitle(Guid storyID)
        {
            //make a new story object
            Story stry = new Story();
            //get the right story by the storyID passed in
            stry = stry.GetById(storyID);
            lblStoryTitle.Text = stry.Title;
        }

        protected void ddlChapterList_Populate(Guid storyID)
        {
            ChapterList cl = new ChapterList();

            cl = cl.GetByStoryID(storyID);
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataTextField = "Title";
            ddlChapterList.DataValueField = "ID";
            ddlChapterList.DataBind();
        }
        protected void ddlChapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid chapID = new Guid(this.ddlChapterList.SelectedValue);
            rptReviews_Populate(chapID);
        }

        protected void rptReviews_Populate(Guid chapID)
        {
            ReviewList rvwList = new ReviewList();

            rvwList = rvwList.GetByChapterID(chapID);

            rptReviews.DataSource = rvwList.List;
            rptReviews.DataBind();
        }

    }
}