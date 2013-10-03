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
       
        //Make new UserStory called usersStories
        protected UserStory usersStories = new UserStory();
        //make a bool called bIsLoggedIn, set it to 'false'
        protected bool bIsLoggedIn = false;
        //make an empty guid called userID
        protected Guid userID = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if statement will run if the page has NOT posted back
            if (!Page.IsPostBack)
            {
                //call CheckIfLoggedIn, passing in bIsLoggedIn
                CheckIfLoggedIn(bIsLoggedIn);
            }

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //call CheckIfLoggedIn, passing in bIsLoggedIn
                CheckIfLoggedIn(bIsLoggedIn);
            }
        }
        protected void CheckIfLoggedIn(bool bIsLoggedIn)
        {
            //make a variable called myNumb, and set its value to a converted number of Session "LoggedIn"
            var myNumb = Convert.ToInt32(Session["LoggedIn"]);
            //if statement that will run if myNumb value is equal to 0
            if (myNumb == 0)
            {
                //call ddlList_ClearItems to clear items in all dropdownlists
                DropDownLists_ClearItems();
                //set bIsLoggedIn to 'false'
                bIsLoggedIn = false;
            }
            //else that will run if myNumb value is NOT equal to zero
            else
            {
                //set bIsLoggedIn to 'true'
                bIsLoggedIn = true;
                //make a new guid called userID and give it a value from session
                userID = new Guid(Session["UserID"].ToString());
                DropDownLists_LoadItems();
            }
        }

        protected void DropDownLists_ClearItems()
        {
            //clear items from the following drop down lists
            ddlCategory.Items.Clear();
            ddlFandom.Items.Clear();
            ddlGenre1.Items.Clear();
            ddlGenre2.Items.Clear();
            ddlMaturity.Items.Clear();
        }
        protected void DropDownLists_LoadItems()
        {
            //populate the following drop down lists
            ddlCategory_Populate();
            ddlFandom_Populate();
            ddlGenre1_Populate();
            ddlGenre2_Populate();
            ddlMaturity_Populate();
        }

        protected void ddlCategory_Populate()
        {
            //make a new CategoryList called catList
            CategoryList catList = new CategoryList();
            //Get all categories
            catList = catList.GetAll();
            //Bind the list to ddlCategory
            ddlCategory.DataSource = catList.List;
            ddlCategory.DataTextField = "Type";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }
        protected void ddlFandom_Populate()
        {
            //if statement will run if selectedIndex of ddlCategory is greater or equal to zero
            if (ddlCategory.SelectedIndex >=0)
            {
                //make a new FandomList called fandList
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
            //make a new GenreList called genList
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
            //make a new GenreList called genList
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
            //make a new MaturityList called matList
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
            //call Add_Story method
            Add_Story();
        }
        protected void Add_Story()
        {
            //make a new story object
            Story story = new Story();
            //set story's Title property to value from txtTitle
            story.Title = this.txtTitle.Value;
            //set story's Summary property to value from txtSummary
            story.Summary = this.txtSummary.Value;
            //set story's FandomID property to selected value of ddlFandom
            story.FandomID = new Guid(this.ddlFandom.SelectedValue);
            //set story's GenreID1 property to selected value of ddlGenre1
            story.GenreID1 = new Guid(this.ddlGenre1.SelectedValue);
            //set story's GenreID2 property to selected value of ddlGenre2
            story.GenreID2 = new Guid(this.ddlGenre2.SelectedValue);
            //set story's MaturityID property to selected value of ddlMaturityID
            story.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
            //set stryUser UserID to the User's ID (stored in session)
            usersStories.UserID = userID;            

            //if statement will run if story.IsSavable equals true
            if (story.IsSavable() == true)
            {
                //if the story is savable, save it
                story = story.Save();
                //set the storyID of stryUsers to the id of story
                usersStories.StoryID = story.Id;
                
                //make a new User called usr
                User usr = new User();
                //get the right user by userID (taken from Session["UserID"])
                usr = usr.GetById(userID);                                
                //set usr's StoryAmount property to equal itself plus 1
                usr.StoryAmount = usr.StoryAmount + 1;
                //set usersStories' UserId property to value of userID
                usersStories.UserID = userID;
                //call save_Bridges
                save_Bridges();
                //redirect user to AddChapter page
                Server.Transfer("AddChapter.aspx", true);
            }
        }
        protected void save_Bridges()
        {
            //if statement will run if usersStories' IsSavable property equals true            
            if (usersStories.IsSavable() == true)
            {
                //if the bridge is savable, save it
                usersStories.Save();
            }
        }

        protected void ddlFandom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}