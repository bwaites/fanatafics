using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            if (myNumb == 0)
            {
                showLoginArea();
            }
            else
            {                
                string sUserName = Session["UserName"].ToString();
                Guid usrID = new Guid(Session["UserID"].ToString());
                showLoggedIn(sUserName, usrID);
            }
        }

        protected void LoginUser(string userEmail, string userPass)
        {
            //make new encrpytion object
            pEncryption pEncrypt = new pEncryption();
            //set UserName to equal txtUsername text
            userEmail = txtUserEmail.Value;
            //encrypt password
            String ecryptPassword = pEncrypt.EncryptQueryString(userPass);
            //make new user object
            User usr = new User();
            //calls Login property of user that uses storage procedure to check login
            usr.Login(userEmail, ecryptPassword);

            if (!usr.IsNew)
            {
                //make a string called usrNme, set its value to usr.UserName
                String usrNme = usr.UserName;
                //make a new guid called usrID, set its value to usr.Id
                Guid usrID = new Guid(usr.Id.ToString());
                showLoggedIn(usrNme, usrID);
            }
            else
            {
                //if not successful, transfer user to registration page
                Session["LoggedIn"] = 0;
                Response.Redirect("Registration.aspx");
            }
        }



        protected void showLoggedIn(string userName, Guid userID)
        {
            hlLoginName.Text = userName;
            hlLoginName.NavigateUrl = "~/ScribblersCorner.aspx?UserID=" + userID;            
            //save user name to session
            Session["UserName"] = userName;
            //save user id to session
            Session["UserID"] = userID;
            Session["LoggedIn"] = 1;

            dvLoginArea.Style.Add("Display", "none");
            dvLoggedIn.Style.Add("Display", "inline-block");
            //transfer to the default page upon success
        }

        protected void showLoginArea()
        {
            Session["LoggedIn"] = 0;
            dvLoggedIn.Style.Add("Display", "none");
            dvLoginArea.Style.Add("Display", "inline-block");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            showLoginArea();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUserEmail.Value.Trim() !=null) && (txtPassword.Value.Trim() !=null))
            {
                LoginUser(txtUserEmail.Value, txtPassword.Value);
            }            
        }
    }
}