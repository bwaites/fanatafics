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
            //registering the handle of btnLogin
            this.btnLogin.Click += new EventHandler(btnLogin_Click);  
            
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            //make new encrpytion object
            pEncryption pEncrypt = new pEncryption();
            //set UserName to equal txtUsername text
            String UserName = this.txtUsername.Value;
            //encrypt password
            String ecryptPassword = pEncrypt.EncryptQueryString(this.txtPassword.Value);
            //make new user object
            User usr = new User();
            //calls Login property of user that uses storage procedure to check login
            usr.Login(UserName, ecryptPassword);
            
            if (!usr.IsNew)
            { 
                //store username in string
                String usrNme = usr.UserName;
                //store UserID in guid
                Guid usrID = new Guid(usr.Id.ToString());
                //make a label called mpLabel, find the label called lblLogin in Master page
                HyperLink mpHyperLink = (HyperLink)Master.FindControl("hlLogin");
                
                if (mpHyperLink != null)
                {
                    //if mpLabel is not null then the mpLabel.Text equals login name
                    mpHyperLink.Text = usrNme;
                    //save user name to session
                    Session["UserName"] = mpHyperLink.Text;
                    //save user id to session
                    Session["UserID"] = usrID;
                    
                    //transfer to the default page upon success
                    Server.Transfer("Default.aspx", true);
                }                 
            }
            else
            {
                //if not successful, transfer user to registration page
                Server.Transfer("Registration.aspx", true);
            }
 
        }

      
    }
}