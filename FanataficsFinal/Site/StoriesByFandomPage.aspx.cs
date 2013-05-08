using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class BatmanFandom : System.Web.UI.Page
    {
        protected StoryList sl = new StoryList();      
        protected StoryList stryByFandList = new StoryList();
        protected UserStoryList usrStryList = new UserStoryList();
        protected HyperLink pHyperlink = new HyperLink();
        protected void Page_Load(object sender, EventArgs e)
        {
            //make a fandomID guid, passing the value in a query string 
            //(value of query string is stored in repeater)
            Guid fandomID = new Guid(Request.QueryString["FandomID"]);
            //get all stories by the appropriate fandom
            sl = sl.GetByFandomID(fandomID);

            //bind list of stories to repeater
            rptStories.DataSource = sl.List;
            //rptStories.ItemDataBound += new RepeaterItemEventHandler(getAuthor);
            rptStories.DataBind();
        }
        
        protected void rptStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //make a hidden field called hidnValue, set it to hidnID in the repeater
                HiddenField hidnValue = (HiddenField)e.Item.FindControl("hidnID");
                //find lblAuthor control
                Label lblAuthor = (Label)e.Item.FindControl("lblAuthor");
                //if hidnValue is NOT null then get author
                if (hidnValue != null)
                {
                    //call get author
                    getAuthor(hidnValue, lblAuthor);
                }
            }
            
        }
        protected void getAuthor(HiddenField hidnValue, Label lblAuthor)
        {
            //make a new user
            User usr = new User();
            //make a new storyID
            Guid storyID = new Guid();
            //set storyID to the value from hidnValue
            storyID = new Guid(hidnValue.Value);
            try
            {
                //try to get the user by storyID
                usr = usr.GetUserByStoryID(storyID);
                //make an empty string called usrName
                string usrName = String.Empty;
                //set the empty string usrName to equal usr.UserName
                usrName = usr.UserName;
                //set the text of lblAuthor to equal string usrName
                lblAuthor.Text = usrName;
            }
            catch
            {
                //if it can't find the author, display so in the text
                lblAuthor.Text = "Author Not Found";
            }
        }
    }
}