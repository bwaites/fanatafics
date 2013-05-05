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
        protected HiddenField hidnID;
        protected StoryList sl = new StoryList();

        
        protected StoryList stryByFandList = new StoryList();
        protected UserStoryList usrStryList = new UserStoryList();
        protected HyperLink pHyperlink = new HyperLink();
        protected void Page_Load(object sender, EventArgs e)
        {
            //make a storylist

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

        void getAuthor(HiddenField hidnValue, Label lblAuthor)
        {
            User usr = new User();

            Guid storyID = new Guid();
            storyID = new Guid(hidnValue.Value);
            try
            {
                usr = usr.GetUserByStoryID(storyID);
                string usrName = String.Empty;
                usrName = usr.UserName;
                lblAuthor.Text = usrName;
            }
            catch
            {
                lblAuthor.Text = "Author Not Found";
            }
            

            


            //    //make a new userstory
            //    Guid fandomID = new Guid(Request.QueryString["FandomID"]);

            //    sl = sl.GetByFandomID(fandomID);
            //    List<Guid> storyIDList = new List<Guid>();

            //    for (int i = 0; i < sl.List.Count; i++)
            //    {
            //        storyIDList.Add
            //    }
            //    usrStryList = usrStryList.GetByStoryID(sl.List);
            //   usr = usr.GetUserByFandomID(fandomID);

            //    //set lblAuthor.Text to username of story

            //    Label lblAuthor = (Label)Page.FindControl("lblAuthor");

            //    lblAuthor.Text = usr.UserName;
        }

        protected void rptStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidnValue = (HiddenField)e.Item.FindControl("hidnID");
                Label lblAuthor = (Label)e.Item.FindControl("lblAuthor");
                if (hidnValue != null)
                {
                    getAuthor(hidnValue, lblAuthor);
                }
            }
            
        }

        protected void rptStories_DataBinding(object sender, EventArgs e)
        {
            
        }
    }
}