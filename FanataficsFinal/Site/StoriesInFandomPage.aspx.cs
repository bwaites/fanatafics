using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class StoriesInFandom : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //make a new StoryList called sl
                StoryList sl = new StoryList();
                //make a fandomID guid, passing the value in a query string 
                //(value of query string is stored in repeater)
                Guid fandomID = new Guid(Request.QueryString["FandomID"]);
                //get all stories by the appropriate fandom
                sl = sl.GetByFandomID(fandomID);
                //bind list of stories to repeater
                rptStories.DataSource = sl.List;
                rptStories.DataBind();
            }
        }
        protected void rptStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if statement that will run if the event itemtype equals the item or alternating item types
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //make a hidden field called hidnValue, set it to hidnID in the repeater
                HiddenField hidnValue = (HiddenField)e.Item.FindControl("hidnID");
                //make a new guid called storyID, set it's value to hidnID
                Guid storyID = new Guid(hidnValue.Value);
                //find hlAuthor control                
                HyperLink hlAuthor = (HyperLink)e.Item.FindControl("hlAuthor");
                //find hlReviews control
                HyperLink hlReviews = (HyperLink)e.Item.FindControl("hlReviews");
                //if statement that will run if hidnValue is NOT null
                if (hidnValue != null)
                {
                    //call getauthor, passing in storyID and hlAuthor
                    getAuthor(storyID, hlAuthor);
                    //call getReviews, passing in storyID and hlReviews
                    getReviews(storyID, hlReviews);
                }
            }
        }
        protected void getAuthor(Guid storyID, HyperLink hlAuthor)
        {
            //make a new user
            User usr = new User();
            //try to get the user by storyID
            usr = usr.GetUserByStoryID(storyID);
            //set the text of hlAuthor to equal string usrName
            hlAuthor.Text = usr.UserName;
            //make a string called navUrl and store the navigation url in it
            string navUrl = "~/UserPage.aspx?UserID=" + usr.Id;
            //set hlAuthor.NavigateUrl equal to the string
            hlAuthor.NavigateUrl = navUrl;
        }
        protected void getReviews(Guid storyID, HyperLink hlReviews)
        {
            //make string called navUrl, set the value to a url with query parameters
            String navUrl = "~/ReviewsPage.aspx?StoryID=" + storyID;
            //set hyperlink navigateurl of hlReviews to navUrl
            hlReviews.NavigateUrl = navUrl;
        }
    }
}