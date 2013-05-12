using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class AccountSettings : System.Web.UI.Page
    {
        protected User usr = new User();
        protected pEncryption pEncrypt = new pEncryption();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HyperLink mpHlink = (HyperLink)Master.FindControl("hlLogin");
                if (mpHlink != null && mpHlink.Text != "Login")
                {
                    usr = usr.GetById(new Guid(Session["UserID"].ToString()));
                    lblUserName.Text = usr.UserName;
                    lblPassword.Text = "hidden";
                    lblEmail.Text = usr.Email;
                    lblSecQuest.Text = usr.SecurityQuestion;
                    lblSecAns.Text = "hidden";
                }
            }
            
        }

        protected void btnEditUsrName_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != null)
            {
                changeSettings("UserName");
            }          
        }

        protected void btnEditPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != null)
            {
                changeSettings("Password");
            }
        }

        protected void btnEditEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() != null)
            {
                changeSettings("Email");
            }

        }

        protected void changeSettings(string setting)
        {
            User usr = new User();
            usr = usr.GetById(new Guid(Session["UserID"].ToString()));
            
            switch (setting)
            {
                case "UserName":
                    usr.UserName = txtUserName.Text;
                    break;
                case "Password":
                    usr.Password = pEncrypt.EncryptQueryString(txtPassword.Text);
                    break;
                case "Email":
                    usr.Email = txtEmail.Text;
                    break;
            }
            usr.IsNew = false;
            usr.IsDirty = true;
            
            if (usr.IsSavable() == true)
            {
                usr = usr.Save();
            }
        }
    }
}