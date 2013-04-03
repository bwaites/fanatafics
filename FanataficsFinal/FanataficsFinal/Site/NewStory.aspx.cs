using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class NewStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                

                CategoryList catList = new CategoryList();
                catList.GetAll();
                ddlCategory.DataSource = catList.List;
                ddlCategory.DataTextField = "Type";
                ddlCategory.DataValueField = "Type";
                ddlCategory.DataBind();
            }
            
            
            
            
            
        }



        
    }
}