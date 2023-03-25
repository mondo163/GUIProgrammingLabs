using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using GameLib;

namespace AwesomeAnagramsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        GameClass anagramGame;

        //timer variables
        //Timer Code help from https://www.youtube.com/watch?v=o_F_v_ISeDk
        private DispatcherTimer timer;
        private int time;
        public MainWindow()
        {
            InitializeComponent();
            anagramGame = new GameClass();
            //sets buttons that should be available
            wordBank.Text = "A B C D E F G";
            EndGameButtonEnables();
            showDefinButton.IsEnabled = false;

            //timer code
            time = anagramGame.Time;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timerBox.Text = string.Format("0{0}:00", time / 60);

            //initial messagebox on how to manually load the dictionary.
            MessageBox.Show("To start a game, please first click on File->Load Dictionary to\n" +
                            "upload wordgame_dictionary.txt. Once file upload is complete, you\n" +
                            "can edit File->settings such as time, min and max letters", "Start-Up", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //begins the game and creates the game board based on the settings. 
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (loadDictionaryOption.IsEnabled)
            {
                MessageBox.Show("Dictionary has not been loaded.\n" +
                                "Click on File->Load Dictionary to\n" +
                                "upload dictionary to begin game", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StartGameButtonEnables();

            guessesBox.Items.Clear();
            definBox.Items.Clear();

            anagramGame.CreateLetterBank();
            anagramGame.CreateAnagramList();
            anagramBox.Items.Clear();
            string[] anagrams = anagramGame.GetGuesses();
            foreach (string ana in anagrams)
            {
                anagramBox.Items.Add(ana);
            }

            wordBank.Text = anagramGame.LetterBank;

            time = anagramGame.Time;
            timerBox.Text = string.Format("0{0}:00", time / 60);
            timer.Tick += Timer_Tick;
            timer.Start();
            stopButton.IsEnabled = true;
        }
        //timer event handler
        void Timer_Tick(object sender, EventArgs e)
        {
            if (time < 10 && time > 0)
            {
                time--;
                timerBox.Text = string.Format("0{0}:0{1}", time / 60, time % 60);
            }
            else if (time > 0)
            {
                time--;
                timerBox.Text = string.Format("0{0}:{1}", time / 60, time % 60);
            }
            else if (time <= 0)
            {
                timer.Stop();
                EndGameButtonEnables();

                anagramBox.Items.Clear();
                string[] anagrams = anagramGame.ReturnAllAnagrams();
                foreach (string ana in anagrams)
                {
                    anagramBox.Items.Add(ana);
                }

                wordBank.Text = "Loser...";
            }


            if (time == 30)
            {
                timerBox.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        //stops game and allows for settings to be adjusted
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            EndGameButtonEnables();

            anagramBox.Items.Clear();
            string[] anagrams = anagramGame.ReturnAllAnagrams();
            foreach (string ana in anagrams)
            {
                anagramBox.Items.Add(ana);
            }

            if (!anagramGame.CheckForWin())
            {
                wordBank.Text = "Game Over";
            }
        }
        //used to search for anagrams that you have typed in
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!stopButton.IsEnabled)
            {
                MessageBox.Show("Game Has Not Been Started!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!anagramGame.GuessWord(wordGuess.Text.ToUpper()))
            {
                guessesBox.Items.Add(wordGuess.Text.ToUpper());
            }
            else
            {
                anagramGame.AnagramList[wordGuess.Text.ToUpper()] = true;
                anagramBox.Items.Clear();
                string[] anagrams = anagramGame.GetGuesses();
                foreach (string ana in anagrams)
                {
                    anagramBox.Items.Add(ana);
                }
            }
            wordGuess.Clear();

            if (anagramGame.CheckForWin())
            {
                timer.Stop();
                stopButton.IsEnabled = false;
                showDefinButton.IsEnabled = true;

                anagramBox.Items.Clear();
                string[] anagrams = anagramGame.ReturnAllAnagrams();
                foreach (string ana in anagrams)
                {
                    anagramBox.Items.Add(ana);
                }

                wordBank.Text = "WINNER!!!";
            }
        }
        //how manually upload the dictionary
        private void LoadDictionaryOption_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text | *.txt";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                result = anagramGame.UploadDictionaryFromFile(openFileDialog.FileName);
                if (result == false)
                {
                    MessageBox.Show("Dictionary upload failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                loadDictionaryOption.IsEnabled = false;
            }
        }
        //if exit is selected. settings are saved and the window is closed. 
        private void ExitOption_Click(object sender, RoutedEventArgs e)
        {
            anagramGame.SaveSettings();
            this.Close();
        }
        //shows the user the definitions once the game is over
        private void ShowDefinButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (KeyValuePair<string, bool> item in anagramGame.AnagramList)
            {
                definBox.Items.Add(item.Key + '-' + anagramGame.ReturnDefinition(item.Key) + Environment.NewLine);
            }
        }
        //Outputs the games directions to a messagebox
        private void HelpItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(anagramGame.ReturnInstructions(), "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //opens settings window so they can be adjusted.
        private void SettingsOption_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(anagramGame.MinLetters, anagramGame.MaxLetters, anagramGame.LetterBankCount);
            settings.ShowDialog();

            anagramGame.MinLetters = settings.MinLetters;
            anagramGame.MaxLetters = settings.MaxLetters;
            anagramGame.LetterBankCount = settings.RandomLetters;

        }
        //makes sure settings are save if the window is close from the red x in the corner
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            anagramGame.SaveSettings();
        }
        //shuffles the letter bank and redisplays it
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            wordBank.Text = anagramGame.ShuffleLetterBank();
        }
        //Helper functions that enable and disable buttons depending on if the game is starting or stopping
        private void StartGameButtonEnables()
        {
            enterButton.IsEnabled = true;
            wordGuess.IsEnabled = true;
            stopButton.IsEnabled = true;
            shuffleButton.IsEnabled = true;

            settingsOption.IsEnabled = false;
            startButton.IsEnabled = false;
        }
        private void EndGameButtonEnables()
        {
            settingsOption.IsEnabled = true;
            startButton.IsEnabled = true;
            showDefinButton.IsEnabled = true;

            wordGuess.IsEnabled = false;
            enterButton.IsEnabled = false;
            stopButton.IsEnabled = false;
            shuffleButton.IsEnabled = false;
        }
    }
}
