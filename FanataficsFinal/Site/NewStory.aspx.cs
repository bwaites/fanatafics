﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class NewStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if page hasn't been loaded, then load the following ddls
                ddlCategory_Populate();
                ddlGenre_Populate();
                ddlMaturity_Populate();

            }

            else
            {
                //if page /has/ been loaded, then populate the ddlFandom
                ddlFandom_Populate();
                
            }

            
        }

        void ddlCategory_Populate()
        {
            //Make a category list
            CategoryList catList = new CategoryList();
            //Get all categories
            catList = catList.GetAll();
            //Bind the types of Categories to ddlCategory
            ddlCategory.DataSource = catList.List;
            ddlCategory.DataTextField = "Type";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }

        void ddlFandom_Populate()
        {
            //Check and see if the items in ddlCategory were loaded
            if (ddlCategory.Items.Count > 0)
            {
                //make a fandom list
                FandomList fandList = new FandomList();
                //Get fandoms based on categoryID
                fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                //binds the list to ddlFandom
                ddlFandom.DataSource = fandList.List;
                ddlFandom.DataBind();
                               
            }
        }

        void ddlGenre_Populate()
        {
            //Make a genre list
            GenreList genList = new GenreList();
            //Get all of the list
            genList.GetAll();
            //Bind list to ddlGenre, displaying GenreType
            ddlGenre.DataSource = genList.List;
            ddlGenre.DataTextField = "GenreType";
            ddlGenre.DataValueField = "ID";
            ddlGenre.DataBind();
        }

        void ddlMaturity_Populate()
        {
            //Make a maturity list
            MaturityList matList = new MaturityList();
            //Get all of maturity levels
            matList.GetAll();
            //Bind levels to ddlMaturity, displaying level
            ddlMaturity.DataSource = matList.List;
            ddlMaturity.DataTextField = "MaturityLevel";
            ddlMaturity.DataValueField = "ID";
            ddlMaturity.DataBind();
        }

        void Add_Story()
        {
            //make a new story object
            Story story = new Story();
            //set title, summary, maturity id equal to input options
            story.Title = this.txtTitle.Value;
            story.Summary = this.txtSummary.Value;
            story.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
            //Check if the story is savable, and if so, save it
            if (story.IsSavable() == true)
            {
                story = story.Save();
            }
        }


        protected void btnAddStory_Click(object sender, EventArgs e)
        {
            //calls Add_Story method
            Add_Story();
        }

        
    }
}