using System;
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
                ddlCategory_Populate();
                ddlGenre_Populate();
                ddlMaturity_Populate();

            }

            else
            {
                ddlFandom_Populate();
                
            }

            
        }

        void ddlCategory_Populate()
        {
            CategoryList catList = new CategoryList();
            catList = catList.GetAll();
            ddlCategory.DataSource = catList.List;
            ddlCategory.DataTextField = "Type";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }

        void ddlFandom_Populate()
        {
            if (ddlCategory.Items.Count > 0)
            {
                FandomList fandList = new FandomList();
                fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                ddlFandom.DataSource = fandList.List;
                ddlFandom.DataBind();
                               
            }
        }

        void ddlGenre_Populate()
        {
            GenreList genList = new GenreList();
            genList.GetAll();
            ddlGenre.DataSource = genList.List;
            ddlGenre.DataTextField = "GenreType";
            ddlGenre.DataValueField = "ID";
            ddlGenre.DataBind();
        }

        void ddlMaturity_Populate()
        {
            MaturityList matList = new MaturityList();
            matList.GetAll();
            ddlMaturity.DataSource = matList.List;
            ddlMaturity.DataTextField = "MaturityLevel";
            ddlMaturity.DataValueField = "ID";
            ddlMaturity.DataBind();
        }

        void Add_Story()
        {
            Story story = new Story();
            story.Title = this.txtTitle.Value;
            story.Summary = this.txtSummary.Value;
            story.MaturityID = new Guid(this.ddlMaturity.SelectedValue);

            if (story.IsSavable() == true)
            {
                story = story.Save();
            }
        }


        protected void btnAddStory_Click(object sender, EventArgs e)
        {
            Add_Story();
        }

        
    }
}