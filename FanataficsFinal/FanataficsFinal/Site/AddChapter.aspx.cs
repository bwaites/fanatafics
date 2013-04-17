using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
namespace Site
{
    public partial class AddChapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                ddlStoryList_Populate();
            }            
        }

        void ddlStoryList_Populate()
        {
            StoryList sl = new StoryList();
            Guid storyID = new Guid(this.ddlStoryList.SelectedValue);
            sl = sl.GetByUserID(storyID);
            ddlStoryList.DataSource = sl.List;
            ddlStoryList.DataTextField = "Title";
            ddlStoryList.DataValueField = "ID";
            ddlStoryList.DataBind();

        }

    }
}