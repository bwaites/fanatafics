using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            if (myNumb == 0)
            {
                dvLoggedIn.Visible = false;
            }
            else
            {
                dvLoggedIn.Visible = true;
            }
            

            if (Session["UserName"] != null)
            {
                hlLogin.Text = Session["UserName"].ToString();
                Guid usrID = new Guid(Session["UserID"].ToString());
                hlLogin.NavigateUrl = "~/AccountSettings.aspx?UserID=" + usrID;
                dvLoggedIn.Visible = true;
                btnLogin.InnerText = "Logout";
                Session["LoggedIn"] = 1;
                
            }
            
            
        }
    }
}