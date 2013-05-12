using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class UserPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            User usr = new User();
            StoryList sl = new StoryList();
            Guid userID = new Guid(Request.QueryString["UserID"]);

            sl.GetByUserID(userID);
            rptUsrStories.DataSource = sl.List;
            rptUsrStories.DataBind();

        }

        protected void rptUsrStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidnValue = (HiddenField)e.Item.FindControl("hidnID");
                HyperLink hlReviews = (HyperLink)e.Item.FindControl("hlReviews");
                if (hidnValue != null)
                {
                    getReviews(hidnValue, hlReviews);
                }
            }
        }

        protected void getReviews(HiddenField hidnValue, HyperLink hlReviews)
        {
            Guid storyID = new Guid();
            storyID = new Guid(hidnValue.Value);
            Guid chapID = new Guid();
            Chapter chap = new Chapter();
            chap = chap.GetFirstByStoryID(storyID);
            chapID = chap.Id;
            String navUrl = "~/ReviewsPage.aspx?ChapterID=" + chapID + "&StoryID=" + storyID;
            hlReviews.NavigateUrl = navUrl;
            
            
            
            
            
        }

    }
}