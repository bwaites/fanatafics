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
    {   //Make a category list
        protected CategoryList catList = new CategoryList();
        //make a fandom list
        protected FandomList fandList = new FandomList();
        //Make a genre list
        protected GenreList genList = new GenreList();
        //Make a maturity list
        protected MaturityList matList = new MaturityList();
        //Make a storyGenre
        protected StoryGenre stryGenre = new StoryGenre();
        //Make a storyFandom
        protected StoryFandom stryFandom = new StoryFandom();
        //Make a userStory
        protected UserStory strysUsers = new UserStory();
        //Make a User
        protected User usr = new User();

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

        protected void ddlCategory_Populate()
        {
            //Get all categories
            catList = catList.GetAll();
            //Bind the types of Categories to ddlCategory
            ddlCategory.DataSource = catList.List;
            ddlCategory.DataTextField = "Type";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }
        protected void ddlFandom_Populate()
        {
            //Check and see if the items in ddlCategory were loaded
            if (ddlCategory.Items.Count > 0)
            {
                //Get fandoms based on categoryID
                fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                //binds the list to ddlFandom
                ddlFandom.DataSource = fandList.List;
                ddlFandom.DataBind();
            }
        }
        protected void ddlGenre_Populate()
        {
            //Get all of the list
            genList.GetAll();
            //Bind list to ddlGenre, displaying GenreType
            ddlGenre.DataSource = genList.List;
            ddlGenre.DataTextField = "GenreType";
            ddlGenre.DataValueField = "ID";
            ddlGenre.DataBind();
        }
        protected void ddlMaturity_Populate()
        {
            //Get all of maturity levels
            matList.GetAll();
            //Bind levels to ddlMaturity, displaying level
            ddlMaturity.DataSource = matList.List;
            ddlMaturity.DataTextField = "MaturityLevel";
            ddlMaturity.DataValueField = "ID";
            ddlMaturity.DataBind();
        }

        protected void btnAddStory_Click(object sender, EventArgs e)
        {
            //calls Add_Story method
            Add_Story();
        }
        protected void Add_Story()
        {
            //make a new story object
            Story story = new Story();
            //set title, summary, maturity id equal to input options
            story.Title = this.txtTitle.Value;
            story.Summary = this.txtSummary.Value;
            story.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
            //set stryUser UserID to the User's ID (stored in session)
            strysUsers.UserID = new Guid(Session["UserID"].ToString());
            //set stryGenre GenreID to ID taken from ddlGenre's selected value
            stryGenre.GenreID = new Guid(this.ddlGenre.SelectedValue);
            //set fandom FandomID to ID taken from ddlFandom's selected value
            stryFandom.FandomID = new Guid(this.ddlFandom.SelectedValue);

            //Check if the story is savable, and if so, save it
            if (story.IsSavable() == true)
            {
                story = story.Save();
                //set the storyIDs of stryUsers, stryGenre and StryFandom to be the id of the story
                strysUsers.StoryID = story.Id;
                stryGenre.StoryID = story.Id;
                stryFandom.StoryID = story.Id;
                //call save_Bridges
                save_Bridges();
                //get user by ID based on session
                usr = usr.GetById(new Guid(Session["UserID"].ToString()));
                //increase storyamount by 1
                usr.StoryAmount = usr.StoryAmount + 1;
            }
        }
        protected void save_Bridges()
        {
            //check if each bridge is savable, if it is, save them.
            if (stryFandom.IsSavable() == true)
            {
                stryFandom.Save();
            }

            if (stryGenre.IsSavable() == true)
            {
                stryGenre.Save();
            }
            if (strysUsers.IsSavable() == true)
            {
                strysUsers.Save();
            }
        }
    }
}