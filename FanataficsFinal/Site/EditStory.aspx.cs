using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace Site
{
    public partial class EditStory : System.Web.UI.Page
    {

        protected bool bIsLoggedIn = false;
        protected Guid userID = Guid.Empty;
        protected Story stry = new Story();
        protected void Page_Load(object sender, EventArgs e)
        {
            //runs if the page hasn't been loaded
            if (!Page.IsPostBack)
            {
                CheckIfLoggedIn(bIsLoggedIn);
            }
            else
            {
                ddlFandom_Populate();
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
                ddlStory_Populate();
                ShowStoryDetails();
                DropDownLists_LoadItems();
            }
        }
        protected void DropDownLists_ClearItems()
        {
            //clear items from ddlStory
            ddlStory.Items.Clear();
            //clear items from ddlCategory
            ddlCategory.Items.Clear();
            //clear items from ddlFandom
            ddlFandom.Items.Clear();
            //clear items from ddlGenre1
            ddlGenre1.Items.Clear();
            //clear items from ddlGenre2
            ddlGenre2.Items.Clear();
        }
        protected void DropDownLists_LoadItems()
        {            
            ddlCategory_Populate();
            ddlFandom_Populate();
            ddlGenre1_Populate();
            ddlGenre2_Populate();
            ddlMaturity_Populate();
        }
        protected void ddlStory_Populate()
        {
            //make a new storylist
            StoryList sl = new StoryList();
            //get the right list of stories by the userID
            sl = sl.GetByUserID(userID);
            //populate the ddl with the list of stories
            ddlStory.DataSource = sl.List;
            ddlStory.DataTextField = "Title";
            ddlStory.DataValueField = "ID";
            ddlStory.DataBind();
        }
        protected void ddlStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //runs if the selected index is greater and/or equal to zero
            if (ddlStory.SelectedIndex >= 0)
            {
                ShowStoryDetails();
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
            //call findCategory
            FindCategory();
        }
        protected void FindCategory()
        {
            //if the selected index of ddlCategory to zero
            if (ddlCategory.SelectedIndex >= 0)
            {
                    //make a new category called cat
                    Category cat = new Category();
                    //filter the category by fandomID of stry
                    cat = cat.GetByFandomId(new Guid(stry.FandomID.ToString()));
                    //set ddlCategory's SelectedIndex to the Id of cat
                    ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(cat.Id.ToString()));
            }
        }
        protected void ddlFandom_Populate()
        {
            //Check and see if the items in ddlCategory were loaded
            //Get fandoms based on categoryID
            if (ddlCategory.SelectedIndex >= 0)
            {
                //make a new FandomList called fandList
                FandomList fandList = new FandomList();
                //get the right fandList by the categoryID taken from ddlCategory's selected value
                fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                //bind the list to ddlFandom
                ddlFandom.DataSource = fandList.List;
                ddlFandom.DataTextField = "FandomName";
                ddlFandom.DataValueField = "ID";
                ddlFandom.DataBind();
            }
            else
            {
                //call Focus on ddlCategory
                ddlCategory.Focus();
            }
        }
        protected void ddlFandom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the fandomID of story to the SelectedValue from ddlFandom
            stry.FandomID = new Guid(this.ddlFandom.SelectedValue);
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
        protected void ddlGenre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the genreID1 of story to the SelectedValue from ddlGenre1
            stry.GenreID1 = new Guid(this.ddlGenre1.SelectedValue);
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
        protected void ddlGenre2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the genreID2 of story to the SelectedValue from ddlGenre2
            stry.GenreID2 = new Guid(this.ddlGenre2.SelectedValue);
        }
        protected void ddlMaturity_Populate()
        {
            //make a new MaturityList called matList
            MaturityList matList = new MaturityList();
            //Get all of maturity levels
            matList.GetAll();
            //Bind list to ddlMaturity
            ddlMaturity.DataSource = matList.List;
            ddlMaturity.DataTextField = "MaturityLevel";
            ddlMaturity.DataValueField = "ID";
            ddlMaturity.DataBind();
        }
        protected void ddlMaturity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the MaturityID of story to the SelectedValue from ddlMaturity
            stry.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
        }
        protected void ddlStory_DataBound(object sender, EventArgs e)
        {

        }
        protected void ShowStoryDetails()
        {
            if (ddlStory.SelectedIndex >= 0)
            {                             
                ////get the right story by the id taken from ddlStory's selected value
                stry = stry.GetById(new Guid(ddlStory.SelectedValue));

                //set the text value of txtTitle to the title of the Story
                txtTitle.Value = stry.Title;

                //set the text value of txtSummary to the summary of the Story
                txtSummary.Value = stry.Summary;
                //set the ddlFandom selected index to the value of fandomID from story 
                ddlFandom.SelectedIndex = ddlFandom.Items.IndexOf(ddlFandom.Items.FindByValue(stry.FandomID.ToString()));

                //set the ddlGenre selected index to the value of genreID1 from story
                ddlGenre1.SelectedIndex = ddlGenre1.Items.IndexOf(ddlGenre1.Items.FindByValue(stry.GenreID1.ToString()));
                
                //set the selected index of ddlGenre2 to the value of the Genre2ID from the story
                ddlGenre2.SelectedIndex = ddlGenre2.Items.IndexOf(ddlGenre2.Items.FindByValue(stry.GenreID2.ToString()));
                
                //set the selected index of ddlMaturity to the value of the MaturityID from the story
                ddlMaturity.SelectedIndex = ddlMaturity.Items.IndexOf(ddlMaturity.Items.FindByValue(stry.MaturityID.ToString()));
            }
        }
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //Compile all the properties of stry
            Stry_CompileDetails();
            //if statement will run if stry IsSavable returns true
            if (stry.IsSavable() == true)
            {
                //run the save property
                stry = stry.Save();
            }
        }
        protected void btnDeleteStory_Click(object sender, EventArgs e)
        {

        }
        protected void Stry_CompileDetails()
        {
            // get story by the Selectedvalue of ddlStory
            stry = stry.GetById(new Guid(this.ddlStory.SelectedValue));

            //set stry's title to the text value from txtTitle
            stry.Title = txtTitle.Value;

            //set stry's summary to the text value from txtSummary
            stry.Summary = txtSummary.Value;

            //set stry's FandomID to the selectedvalue from ddlFandom
            stry.FandomID = new Guid(this.ddlFandom.SelectedValue);

            //set stry's genreID1 to the selectedvalue from ddlGenreID1
            stry.GenreID1 = new Guid(this.ddlGenre1.SelectedValue);

            //set stry's genreID2 to the selectedvalue from ddlGenreID2
            stry.GenreID2 = new Guid(this.ddlGenre2.SelectedValue);

            //set stry's maturityID to the selectedvalue from ddlMaturity
            stry.MaturityID = new Guid(this.ddlMaturity.SelectedValue);

            //set stry isNew property to false so the db knows it's not a new stry
            stry.IsNew = false;
            //set stry isDirty property to true so the db knows that the stry has changed
            stry.IsDirty = true;
        }
        protected void DeleteChapters(Guid storyID)
        {
            Guid stryID = new Guid(this.ddlStory.SelectedValue);

            ChapterList chapL = new ChapterList();
            chapL = chapL.GetByStoryID(stryID);
            for (int i = 0; i <= chapL.List.Count; i++)
            {
            }

            ReviewList rvwList = new ReviewList();
        }
    }
}