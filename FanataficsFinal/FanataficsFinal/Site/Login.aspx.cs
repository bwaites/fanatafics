﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Site
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user is already logged in or not
            //Check if user is already logged in
            if ((Session["Check"] != null) && (Convert.ToBoolean(Session["Check"]) == true))
            {
                //If user is Authenticated then it's okay

                
            }
            
        }

      
    }
}