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
       
        //Make a userStory
        protected UserStory strysUsers = new UserStory();


        protected void Page_Load(object sender, EventArgs e)
        {
            //runs if the page hasn't been loaded
            if (!Page.IsPostBack)
            {
                //convert LoggedIn Session to a number called myNumb
                var myNumb = Convert.ToInt32(Session["LoggedIn"]);
                if (myNumb == 0)
                {
                    //if myNumb is equal to 0 a user isn't logged in
                }
                else
                {
                    //if myNumb is equal to else, a user is logged in
                    ddlCategory_Populate();
                    ddlGenre1_Populate();
                    ddlGenre2_Populate();
                    ddlMaturity_Populate();
                }
            }
            else
            {
                //if page /has/ been loaded, then populate the ddlFandom
                ddlFandom_Populate();
                
            }
        }

        protected void ddlCategory_Populate()
        {
            CategoryList catList = new CategoryList();
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
                FandomList fandList = new FandomList();

                //Get fandoms based on categoryID
                fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                //binds the list to ddlFandom
                ddlFandom.DataSource = fandList.List;
                ddlFandom.DataBind();
            }
        }
        protected void ddlGenre1_Populate()
        {
            GenreList genList = new GenreList();
            //Get all of the list
            genList.GetAll();
            //Bind list to ddlGenre, displaying GenreType
            ddlGenre1.DataSource = genList.List;
            ddlGenre1.DataTextField = "GenreType";
            ddlGenre1.DataValueField = "ID";
            ddlGenre1.DataBind();
        }

        protected void ddlGenre2_Populate()
        {
            GenreList genList = new GenreList();
            //Get all of the list
            genList.GetAll();
            //Bind list to ddlGenre, displaying GenreType
            ddlGenre2.DataSource = genList.List;
            ddlGenre2.DataTextField = "GenreType";
            ddlGenre2.DataValueField = "ID";
            ddlGenre2.DataBind();
        }
        protected void ddlMaturity_Populate()
        {
            MaturityList matList = new MaturityList();
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
            //set title, summary, fandom id, genre id, maturity id equal to input options
            story.Title = this.txtTitle.Value;
            story.Summary = this.txtSummary.Value;
            story.FandomID = new Guid(this.ddlFandom.SelectedValue);
            story.GenreID1 = new Guid(this.ddlGenre1.SelectedValue);
            story.GenreID2 = new Guid(this.ddlGenre2.SelectedValue);
            story.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
            //set stryUser UserID to the User's ID (stored in session)
            strysUsers.UserID = new Guid(Session["UserID"].ToString());            

            //Check if the story is savable, and if so, save it
            if (story.IsSavable() == true)
            {
                story = story.Save();
                //set the storyIDs of stryUsers, stryGenre and StryFandom to be the id of the story
                strysUsers.StoryID = story.Id;
                //call save_Bridges
                //get user by ID based on session 
                User usr = new User();
                usr = usr.GetById(new Guid(Session["UserID"].ToString()));
                                
                //increase storyamount by 1
                usr.StoryAmount = usr.StoryAmount + 1;
                strysUsers.UserID = usr.Id;
                save_Bridges();
                Server.Transfer("AddChapter.aspx", true);
            }
        }
        protected void save_Bridges()
        {
            //check if each bridge is savable, if it is, save them.
            
            if (strysUsers.IsSavable() == true)
            {
                strysUsers.Save();
            }
        }
    }
}