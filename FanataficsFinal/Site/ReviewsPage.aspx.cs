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
                ddlChapterList_Populate();

            }
        }

        protected void ddlChapterList_Populate()
        {
            Guid storyID = new Guid(Request.QueryString["StoryID"]);

            ChapterList cl = new ChapterList();

            cl = cl.GetByStoryID(storyID);
            ddlChapterList.DataSource = cl.List;
            ddlChapterList.DataTextField = "Title";
            ddlChapterList.DataValueField = "ID";
            ddlChapterList.DataBind();
        }
        protected void ddlChapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid chapterID = new Guid(this.ddlChapterList.SelectedValue);
            rptReviews_Populate(chapterID);
        }
        protected void ddlChapterList_DataBound(object sender, EventArgs e)
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