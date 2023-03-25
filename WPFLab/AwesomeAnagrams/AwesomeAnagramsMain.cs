using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib;

namespace AwesomeAnagrams
{
    public partial class AwesomeAnagramsMain : Form
    {

        private GameClass anagramGame;
        public AwesomeAnagramsMain()
        {
            InitializeComponent();
            anagramGame = new GameClass("wordgame_dictionary.txt");
            LetterBankBox.Text = "ABCDEF";
            UserEntryBox.Enabled = false;
            StopBut.Enabled = false;
            EnterButton.Enabled = false;

            ShowDefinitionsButton.Enabled = false;
            DefinitionsTextBox.ScrollBars = ScrollBars.Vertical;

            AnagramListBox.Items.Clear();

            GuessTextBox.ScrollBars = ScrollBars.Vertical;
        }

        private void AwesomeAnagramsMain_Load(object sender, EventArgs e)
        {

        }


        private void StopBut_Click(object sender, EventArgs e)
        {
            StopBut.Enabled = false;
            StartBut.Enabled = true;
            Timer.Enabled = false;
            UserEntryBox.Enabled = false;
            ShowDefinitionsButton.Enabled = true;

            AnagramListBox.Items.Clear();
            AnagramListBox.Items.AddRange(anagramGame.ReturnAllAnagrams());

            LetterBankBox.Text = "Game Over";
        }

        private void StartBut_Click(object sender, EventArgs e)
        {

            StartBut.Enabled = false;
            UserEntryBox.Enabled = true;
            EnterButton.Enabled = true;
            GuessTextBox.Clear();
            AnagramListBox.Items.Clear();

            //creates letter bank with good amount of anagrams. 
            anagramGame.CreateLetterBank();
            anagramGame.CreateAnagramList();
           
            LetterBankBox.Text = anagramGame.LetterBank;

            startTime = DateTime.Now;
            Timer.Enabled = true;

            AnagramListBox.Items.AddRange(anagramGame.GetGuesses());

            StopBut.Enabled = true;
        }

        DateTime startTime = DateTime.MinValue;
        TimeSpan gameTime = TimeSpan.FromMinutes(5);
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan current = DateTime.Now - startTime;
            TimeSpan elapsed = gameTime - current;
            TimerLabel.Text = elapsed.ToString(@"mm\:ss");

            if (elapsed.TotalSeconds < 30)
            {
                TimerLabel.ForeColor = Color.Red;
            }
            //if elapsed time is up. it will say game over. 
            if (elapsed.TotalMilliseconds <= 0)
            {
                Timer.Enabled = false;
                StopBut.Enabled = false;
                ShowDefinitionsButton.Enabled = true;

                AnagramListBox.Items.Clear();
                AnagramListBox.Items.AddRange(anagramGame.ReturnAllAnagrams());

                LetterBankBox.Text = "Game Over";
            }
            
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (!StopBut.Enabled)
            {
                MessageBox.Show("Game Has Not Been Started", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //checks for word in anagram list
            if (!anagramGame.GuessWord(UserEntryBox.Text.ToUpper()))
            {
                EnterButton.BackColor = Color.Red;
                EnterButton.BackColor = Color.Lime;
                EnterButton.BackColor = Color.Red;
                EnterButton.BackColor = Color.Lime;
                GuessTextBox.AppendText(UserEntryBox.Text.ToUpper() + Environment.NewLine);
            }
            else
            {
                anagramGame.AnagramList[UserEntryBox.Text.ToUpper()] = true;
                AnagramListBox.Items.Clear();
                AnagramListBox.Items.AddRange(anagramGame.GetGuesses());
            }
            //check for a win after everyword, will stop the game if its true and proceed to call you a winnter. 
            if (anagramGame.CheckForWin())
            {
                Timer.Enabled = false;
                StopBut.Enabled = false;
                ShowDefinitionsButton.Enabled = true;

                AnagramListBox.Items.Clear();
                AnagramListBox.Items.AddRange(anagramGame.ReturnAllAnagrams());

                LetterBankBox.Text = "WINNER!";
            }
            UserEntryBox.Clear();
        }

        private void TimerLabel_Click(object sender, EventArgs e)
        {

        }

        private void InstructionsLabel_Click(object sender, EventArgs e)
        {

        }

        //seperate function made to show each individual definition for the anagrams. 
        private void ShowDefinitionsButton_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string,bool> item in anagramGame.AnagramList)
            {
                DefinitionsTextBox.AppendText(item.Key + '-');
                DefinitionsTextBox.AppendText(anagramGame.ReturnDefinition(item.Key) + Environment.NewLine);
            }
            ShowDefinitionsButton.Enabled = false;
        }
    }
}
