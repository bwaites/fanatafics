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
            user.UserName = this.userName.Value;
            user.Password = this.password.Value;
            user.Email = this.email.Value;
            user.SecurityQuestion = this.securityQuestion.Value;
            user.SecurityAnswer = this.securityAnswer.Value;

            if (user.IsSavable() == true)
            {
                user = user.Save();
            }
        }



    }
}