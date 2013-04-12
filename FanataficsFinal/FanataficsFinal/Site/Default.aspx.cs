using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using BusinessObjects;
namespace Site
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpCategory_Populate();

            if (!IsPostBack)
            {

            }
            
        }

        void rpCategory_Populate()
        {
            CategoryList catList = new CategoryList();
            
            catList = catList.GetAll();

            rptCategories.DataSource = catList.List;
            rptCategories.DataBind();
        }
        

    }
}