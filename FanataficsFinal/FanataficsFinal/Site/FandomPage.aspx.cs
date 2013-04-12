﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class FandomPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FandomList fl = new FandomList();
            Guid fandomID = new Guid(Request.QueryString["FandomID"]);
            fl = fl.GetByCategoryID(fandomID);

            rptFandoms.DataSource = fl.List;
            rptFandoms.DataBind();
        }
    }
}