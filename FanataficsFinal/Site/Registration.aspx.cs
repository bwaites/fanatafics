using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Text;

namespace Site
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //register btnRegister.Click event
            this.btnRegister.Click += new EventHandler(btnRegister_Click);
        }

        void btnRegister_Click(object sender, EventArgs e)
        {
            //make new encrpytion object
            pEncryption pEncrypt = new pEncryption();
            //make new user object
            User user = new User();
            //set user properties to input values
            user.UserName = this.txtUserName.Value;
            //Encrypt password before saving (this enhances security)
            user.Password = pEncrypt.EncryptQueryString(this.txtPassword.Value);
            user.Email = this.txtEmail.Value; 
            user.SecurityQuestion = this.txtSecurityQuestion.Value;
            //Decided to encrypt the answer for extra security
            user.SecurityAnswer = pEncrypt.EncryptQueryString(this.txtSecurityAnswer.Value);
            user.UserBIO = string.Empty;

            if (user.IsSavable() == true)
            {
                //if user is savable, then save and reroute to default
                user = user.Save();
                Server.Transfer("Default.aspx", true);
            }
        }



    }
}