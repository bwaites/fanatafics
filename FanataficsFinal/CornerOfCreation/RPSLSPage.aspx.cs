using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CornerOfCreation
{
    public partial class RPSLSPage : System.Web.UI.Page
    {
        protected string sPlayerChoice = string.Empty;
        protected string sAIChoice = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              

            }
        }

        protected void btnRock_Click(object sender, EventArgs e)
        {
            lblPlayer.Text = "You chose Rock.";
            sPlayerChoice = "Rock";
            AIChoice();
        }

        protected void btnPaper_Click(object sender, EventArgs e)
        {
            lblPlayer.Text = "You chose Paper.";
            sPlayerChoice = "Paper";            
            AIChoice();
        }

        protected void btnScissors_Click(object sender, EventArgs e)
        {
            lblPlayer.Text = "You chose Scissors.";
            sPlayerChoice = "Scissors";
            AIChoice();
        }

        protected void btnLizard_Click(object sender, EventArgs e)
        {
            lblPlayer.Text = "You chose Lizard.";
            sPlayerChoice = "Lizard";
            AIChoice();
        }

        protected void btnSpock_Click(object sender, EventArgs e)
        {
            lblPlayer.Text = "You chose Spock.";
            sPlayerChoice = "Rock";
            AIChoice();
        }

        protected void AIChoice()
        {
            Random randNumb = new Random();

            Int32 iAIChoice = 0;
            iAIChoice = randNumb.Next(1, 5);

            switch (iAIChoice)
            {
                case 1:
                    lblBatAI.Text = "BatComputer choose Rock";
                    sAIChoice = "Rock";
                    if (sAIChoice == sPlayerChoice)
                    {
                        lblWords.Text = "You just threw rocks at eachother. A tie?";
                    }
                    if (sPlayerChoice == "Paper")
                    {
                        lblWords.Text = "Paper covers rock. You win!";
                    }
                    if (sPlayerChoice == "Scissors")
                    {
                        lblWords.Text = "Rock crushes scissors. You lose!";
                    }
                    if (sPlayerChoice == "Lizard")
                    {
                        lblWords.Text = "Rock crushes Lizard. You lose!";
                    }
                    if (sPlayerChoice == "Spock")
                    {
                        lblWords.Text = "Spock vaporizes Rock. You win!";
                    }
                    break;
                case 2:
                    lblBatAI.Text = "BatComputer choose Paper";
                    sAIChoice = "Paper";
                    if (sAIChoice == sPlayerChoice)
                    {
                        lblWords.Text = "You both chose Paper. Ties are so dull..";
                    }
                    if (sPlayerChoice == "Rock")
                    {
                        lblWords.Text = "Paper covers Rock. You lose!";
                    }
                    if (sPlayerChoice == "Scissors")
                    {
                        lblWords.Text = "Scissors cuts Paper. You win!";
                    }
                    if (sPlayerChoice == "Lizard")
                    {
                        lblWords.Text = "Lizard eats Paper. You win!";
                    }
                    if (sPlayerChoice == "Spock")
                    {
                        lblWords.Text = "Paper disproves Spock. You lose!";
                    }
                    break;

                case 3:
                    lblBatAI.Text = "BatComputer choose Scissors";
                    sAIChoice = "Scissors";
                    if (sAIChoice == sPlayerChoice)
                    {
                        lblWords.Text = "Tie. How boring.";
                    }
                    if (sPlayerChoice == "Paper")
                    {
                        lblWords.Text = "Scissors cuts Paper. You lose!";
                    }
                    if (sPlayerChoice == "Rock")
                    {
                        lblWords.Text = "Rock beats Scissors. You win!";
                    }
                    if (sPlayerChoice == "Lizard")
                    {
                        lblWords.Text = "Scissors decapitates Lizard. You lose!";
                    }
                    if (sPlayerChoice == "Spock")
                    {
                        lblWords.Text = "Spock crushes scissors. You win!";
                    }
                    break;
                case 4:
                    lblBatAI.Text = "BatComputer choose Lizard";
                    sAIChoice = "Lizard";
                    if (sAIChoice == sPlayerChoice)
                    {
                        lblWords.Text = "You both chose Lizard. Hurray.";
                    }
                    if (sPlayerChoice == "Paper")
                    {
                        lblWords.Text = "Lizard eats Paper. You lose!";
                    }
                    if (sPlayerChoice == "Scissors")
                    {
                        lblWords.Text = "Scissors decapitates Lizard. You win!";
                    }
                    if (sPlayerChoice == "Rock")
                    {
                        lblWords.Text = "Rock crushes Lizard. You win!";
                    }
                    if (sPlayerChoice == "Spock")
                    {
                        lblWords.Text = "Lizard poisons Spock. You lose!";
                    }
                    break;
                case 5:
                    lblBatAI.Text = "BatComputer choose Spock";
                    sAIChoice = "Spock";
                    if (sAIChoice == sPlayerChoice)
                    {
                        lblWords.Text = "You both chose Spock. How fascinating.";
                    }
                    if (sPlayerChoice == "Paper")
                    {
                        lblWords.Text = "Paper disproves Spock! You win!";
                    }
                    if (sPlayerChoice == "Scissors")
                    {
                        lblWords.Text = "Spock crushes Scissors. You lose!";
                    }
                    if (sPlayerChoice == "Lizard")
                    {
                        lblWords.Text = "Lizard poisons Spock. You win!";
                    }
                    if (sPlayerChoice == "Rock")
                    {
                        lblWords.Text = "Spock vaporizes Rock. You lose!";
                    }
                    break;
                default:
                    lblBatAI.Text = "BatComputer does not wish to play at this time.";
                    sAIChoice = "N/A";
                    break;
            }

        }

        protected void ProcessWinner()
        {
            if (sPlayerChoice == sAIChoice)
            {
                lblWords.Text = "It's a tie! You both win! Or lose, I guess...";

            }
        }
    }
}