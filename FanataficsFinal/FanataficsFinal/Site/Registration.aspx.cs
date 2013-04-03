using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnRegister.Click += new EventHandler(btnRegister_Click);
        }

        void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = this.txtUserName.Value;
            user.Password = this.txtPassword.Value;
            user.Email = this.txtEmail.Value;
            user.SecurityQuestion = this.txtSecurityQuestion.Value;
            user.SecurityAnswer = this.txtSecurityAnswer.Value;

            if (user.IsSavable() == true)
            {
                user = user.Save();
            }
        }



    }
}