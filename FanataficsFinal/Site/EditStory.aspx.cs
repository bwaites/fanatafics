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
        //make a new story
        Story stry = new Story();
        protected void Page_Load(object sender, EventArgs e)
        {
            //runs if the page hasn't been loaded
            if (!Page.IsPostBack)
            {
                //Converts LoggedIn Session to a number called myNumb
                var myNumb = Convert.ToInt32(Session["LoggedIn"]);
                if (myNumb == 0)
                {
                    //if myNumb is equal to zero, a user isn't logged in
                }
                else
                {
                    //if myNumb is else, session is valid, populate following

                    ddlStory_Populate();
                    ddlCategory_Populate();
                    ddlFandom_Populate();
                    ddlGenre1_Populate();
                    ddlGenre2_Populate();
                    ddlMaturity_Populate();
                }
            }
            else
            {
                //ddlFandom_Populate();
                //ddlGenre1_Populate();
                //ddlGenre2_Populate();
                //ddlMaturity_Populate();
            }

        }

        protected void ddlStory_Populate()
        {
            //make a new storylist
            StoryList sl = new StoryList();
            //make a new guid called userID and give it a value from session
            Guid usrID = new Guid(Session["UserID"].ToString());
            //filter the list of stories by the userID
            sl = sl.GetByUserID(usrID);

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
                //make a new story
                stry = new Story();

                //filters the story by the value of ddlStory
                stry = stry.GetById(new Guid(this.ddlStory.SelectedValue));

                //sets the text value of txtTitle to the title from the Story
                txtTitle.Value = stry.Title;

                //sets the text value of txtSum to the summary from the Story
                txtSummary.Value = stry.Summary;

                //set the selected index of ddlFandom to the value of the fandomID from the story
                ddlFandom.SelectedIndex = ddlFandom.Items.IndexOf(ddlFandom.Items.FindByValue(stry.FandomID.ToString()));

                //set the selected index of ddlGenre1 to the value of the genreID1 from the story
                ddlGenre1.SelectedIndex = ddlGenre1.Items.IndexOf(ddlGenre1.Items.FindByValue(stry.GenreID1.ToString()));

                //set the selected index of ddlGenre2 to the value of the genreID2 from the story
                ddlGenre2.SelectedIndex = ddlGenre2.Items.IndexOf(ddlGenre2.Items.FindByValue(stry.GenreID2.ToString()));

                //set the selected index of ddlMaturity to the value of the maturityID from the story
                ddlMaturity.SelectedIndex = ddlMaturity.Items.IndexOf(ddlMaturity.Items.FindByValue(stry.MaturityID.ToString()));
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

            findCategory();
        }

        protected void findCategory()
        {
            //if the selected index of ddlCategory to zero
            if (ddlCategory.SelectedIndex >= 0)
            {
                try
                {
                    //try to do the following

                    //make a new category
                    Category cat = new Category();
                    //make a new guid called fandID and give it the fandomID from story
                    Guid fandID = new Guid(stry.FandomID.ToString());
                    //filter the category by the fandomID
                    cat = cat.GetByFandomId(fandID);

                    //set the ddlCategory selected index to the value from category
                    ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(cat.Id.ToString()));
                }
                catch
                {
                    ddlCategory.Focus();
                }
            }
        }


        protected void ddlFandom_Populate()
        {
            //Check and see if the items in ddlCategory were loaded
            //Get fandoms based on categoryID
            if (ddlCategory.SelectedIndex >= 0)
            {
                try
                {
                    FandomList fandList = new FandomList();
                    fandList = fandList.GetByCategoryID(new Guid(ddlCategory.SelectedValue));
                    //binds the list to ddlFandom
                    ddlFandom.DataSource = fandList.List;
                    ddlFandom.DataTextField = "FandomName";
                    ddlFandom.DataValueField = "ID";
                    ddlFandom.DataBind();
                }
                catch
                {
                    ddlCategory.Focus();
                }
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

        protected void ddlStory_DataBound(object sender, EventArgs e)
        {

        }
        protected void PopulateControls()
        {
            if (ddlStory.SelectedIndex >= 0)
            {
                //make a new story
                stry = new Story();
                //filter the story by the value from the ddlStory
                stry = stry.GetById(new Guid(this.ddlStory.SelectedValue));

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

        protected void ddlFandom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the fandomID of story to the SelectedValue from ddlFandom
            stry.FandomID = new Guid(this.ddlFandom.SelectedValue);
        }

        protected void ddlGenre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the genreID1 of story to the SelectedValue from ddlGenre1
            stry.GenreID1 = new Guid(this.ddlGenre1.SelectedValue);
        }

        protected void ddlGenre2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the genreID2 of story to the SelectedValue from ddlGenre2
            stry.GenreID2 = new Guid(this.ddlGenre2.SelectedValue);
        }

        protected void ddlMaturity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the MaturityID of story to the SelectedValue from ddlMaturity
            stry.MaturityID = new Guid(this.ddlMaturity.SelectedValue);
        }

        protected void Stry_Compile()
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
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //Compile all the properties of stry
            Stry_Compile();
            //runs if stry IsSavable returns true
            if (stry.IsSavable() == true)
            {
                //run the save property
                stry = stry.Save();
            }
        }

        protected void btnDeleteStory_Click(object sender, EventArgs e)
        {

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