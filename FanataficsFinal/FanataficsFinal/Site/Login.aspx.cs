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
            String ecryptUserName = pEncrypt.EncryptQueryString(this.txtUsername.Value);
            String ecryptPassword = pEncrypt.EncryptQueryString(this.txtPassword.Value);

            User usr = new User();
            usr.Login(ecryptUserName, ecryptPassword);

            if (!usr.IsNew)
            {
                
                Server.Transfer("Default.aspx", true);
            }

          

            
        }

      
    }
}