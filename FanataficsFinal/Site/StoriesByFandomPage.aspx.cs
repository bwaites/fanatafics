using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class StoriesByFandom : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            StoryList sl = new StoryList();      

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
                HyperLink hlAuthor = (HyperLink)e.Item.FindControl("hlAuthor");
                //if hidnValue is NOT null then get author
                if (hidnValue != null)
                {
                    //call get author
                    getAuthor(hidnValue, hlAuthor);
                }
            }
            
        }
        protected void getAuthor(HiddenField hidnValue, HyperLink hlAuthor)
        {
            //make a new user
            User usr = new User();

            //make a new storyID
            Guid storyID = new Guid();

            //make a new userID
            Guid usrID = new Guid();

            //set storyID to the value from hidnValue
            storyID = new Guid(hidnValue.Value);
            
            try
            {
                //try to get the user by storyID
                usr = usr.GetUserByStoryID(storyID);
         
            }
            catch
            {
                //if it can't find the author, display so in the text
                hlAuthor.Text = "Author Not Found";
            }
            //make an empty string called usrName
            string usrName = String.Empty;
            //set the empty string usrName to equal usr.UserName
            usrName = usr.UserName;
            //set the guid usrID equal to the ID of the user
            usrID = usr.Id;
            //set the text of hlAuthor to equal string usrName
            hlAuthor.Text = usrName;
            //make a string called navUrl and store the navigation url in it
            string navUrl = "~/UserPage.aspx?UserID=" + usrID;
            //set hlAuthor.NavigateUrl equal to the string
            hlAuthor.NavigateUrl = navUrl;
                                
        }
    }
}