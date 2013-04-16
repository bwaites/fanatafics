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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.btnLogin.Click += new EventHandler(btnLogin_Click);
  
            
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            pEncryption pEncrypt = new pEncryption();
            String UserName = this.txtUsername.Value;
            String ecryptPassword = pEncrypt.EncryptQueryString(this.txtPassword.Value);

            User usr = new User();
            usr.Login(UserName, ecryptPassword);

            if (!usr.IsNew)
            {
                String usrNme = usr.UserName;
                Label mpLabel = (Label)Master.FindControl("lblLogin");
                if (mpLabel != null)
                {
                    mpLabel.Text = usrNme;
                    Session["UserName"] = mpLabel.Text;
                    Server.Transfer("Default.aspx", true);
                }                 
            }
            else
            {
                Server.Transfer("Registration.aspx", true);
            }
 
        }

      
    }
}