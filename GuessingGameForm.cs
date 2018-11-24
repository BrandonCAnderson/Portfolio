using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomNumberGuessingGame
{
/****************************************************
    Brandon Anderson
    MiniProject
    Project III: Random Number Guessing Game
*****************************************************/
    public partial class Form1 : Form
    {
        int Guesses; 
        int Number;
        public Form1()
        {
            InitializeComponent();
            GenerateNumber();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            int Answer = int.Parse(ABox.Text);
            Guesses++;
            PlayGame(Answer);
            
        }
        public void PlayGame(int Answer)
        {
            if (Answer > Number)
            {
                MessageBox.Show("You guessed too high", "Guess again!");
                ABox.Clear();
            }
            if (Answer < Number)
            {
                MessageBox.Show("You guessed too low", "Guess again!");
                ABox.Clear();
            }
            if (Answer == Number)
            {
                MessageBox.Show("You guessed the number correctly! It took you " + Guesses + " guesses!", "You Win!");
                var PlayAgain = MessageBox.Show("Do you want to play again?", "Play Again?", MessageBoxButtons.YesNo);
                if (PlayAgain == DialogResult.Yes)
                {
                    GenerateNumber();
                    ABox.Clear();
                    ScoreListBox.Items.Add(Guesses + " guesses");
                    Guesses = 0;
                }
                else
                    Close();
            }
        }
        public void GenerateNumber()
        {
            Random rnd = new Random();
            Number = rnd.Next(1, 101);
        }


    }

}
