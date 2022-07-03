using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors_Game
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool GameOver = false;

        string[] CpuChoiceList = { "Rock", "Paper", "Scissor", "Paper", "Scissor", "Rock" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CPU_choice;
        string Player_choice;

        int Player_Score;
        int CPU_Score;

        public Form1()
        {
            InitializeComponent();

            CountDownTimer.Enabled = true;
            Player_choice = "none";
            txtRound.Text = "5";
        }
        #region "Forms Buttons"
        private void picCpu_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
                      
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion "Forms Buttons"

        #region Game Buttons
        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            Player_choice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            Player_choice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            Player_choice = "scissors";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Player_Score = 0;
            CPU_Score = 0;
            rounds = 3;

            label3.Text = "Player: " + Player_Score + "-" + CPU_Score + "CPU: ";

            Player_choice = "none";

            CountDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCpu.Image = Properties.Resources.qq;

            GameOver = false;
        }

        private void CountDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            label4.Text = timerPerRound.ToString();

            txtRound.Text = "Round: " + rounds;

            if (timerPerRound < 1)
            {
                CountDownTimer.Enabled = false;

                timerPerRound = 6;

                randomNumber = rnd.Next(0, CpuChoiceList.Length);

                CPU_choice = CpuChoiceList[randomNumber];

                switch (CPU_choice)
                {
                    case "Rock":
                        picCpu.Image = Properties.Resources.rock;

                        break;

                    case "Paper":
                        picCpu.Image = Properties.Resources.paper;

                        break;

                    case "Scissor":
                        picCpu.Image = Properties.Resources.scissors;

                        break;
                }

                if (rounds >0)
                    CheckGameWin();
                
                else
                    if (Player_Score > CPU_Score)
                        MessageBox.Show("Player won the game");
                    
                    else
                        MessageBox.Show("Cpu won the game");

                    GameOver = true;
            }
        }
        #endregion "Game Buttons

        private void CheckGameWin()
        {
            if (Player_choice == "rock" && CPU_choice == "Paper")
            {
                CPU_Score += 1;
                rounds -= 1;

                MessageBox.Show("Cpu Wins the party, Paper covers the rock");
            }

            else if (Player_choice == "scissors" && CPU_choice == "Rock")
            {
                CPU_Score += 1;
                rounds -= 1;

                MessageBox.Show("Cpu Wins the party, Rock break the scissors");
            }

            else if (Player_choice == "paper" && CPU_choice == "Scissor")
            {
                CPU_Score += 1;
                rounds -= 1;

                MessageBox.Show("Cpu Wins the party, Scissor cut paper");
            }

            else if (Player_choice == "rock" && CPU_choice == "Scissor")
            {
                Player_Score += 1;
                rounds -= 1;

                MessageBox.Show("Player Wins the party, rrock break Scissor");
            }

            else if (Player_choice == "paper" && CPU_choice == "Rock")
            {
                Player_Score += 1;
                rounds -= 1;

                MessageBox.Show("Player Wins the party, paper covers Rock");
            }

            else if (Player_choice == "scissors" && CPU_choice == "Paper")
            {
                Player_Score += 1;
                rounds -= 1;

                MessageBox.Show("Player Wins the party, Scissor cut paper");
            }

            else if (Player_choice == "none")
            {
                MessageBox.Show("please make sure that you make a choice !");
            }
            else
            {
                MessageBox.Show("Draw!!");
            }

            StartNextLevel();
        }

        private void StartNextLevel()
        {
            if (GameOver == true)
            {
                return;
            }

            label3.Text = "Player: " + Player_Score + "-" + CPU_Score + "CPU: ";

            Player_choice = "none";

            CountDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCpu.Image = Properties.Resources.qq;
        }
    }
}
