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
using System.Windows.Shapes;

namespace AwesomeAnagramsWPF
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public int MinLetters { get; set; }
        public int MaxLetters { get; set; }
        public int RandomLetters { get; set; }
       
        private readonly string[] comboRandomLetters = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
        private readonly string[] comboCharacterLimit = { "2", "3", "4", "5", "6", "7", "8" };
        public SettingsWindow()
        {
            InitializeComponent();
            comboBoxMin.ItemsSource = comboCharacterLimit;
            comboBoxMax.ItemsSource = comboCharacterLimit;
            comboBoxRandom.ItemsSource = comboRandomLetters;
        }
        //creates the settings display with current settings
        public SettingsWindow(int min, int max, int letterBank)
        {
            InitializeComponent();
            //set minimum letters dropdown menu with already selected option in place
            MinLetters = min;
            comboBoxMin.ItemsSource = comboCharacterLimit;
            comboBoxMin.SelectedValue = MinLetters.ToString();

            //set maximum letters dropdown menu with already selected option in place
            MaxLetters = max;
            comboBoxMax.ItemsSource = comboCharacterLimit;
            comboBoxMax.SelectedValue = MaxLetters.ToString();
            
            //set letter bank letters with numbers allowed and already select
            RandomLetters = letterBank;
            comboBoxRandom.ItemsSource = comboRandomLetters;
            comboBoxRandom.SelectedValue = RandomLetters.ToString();

        }
        //saves settings, but makes sure values are valid. Otherwise the user has to change them
        private void SettingsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            int min = int.Parse(comboBoxMin.Text);
            int max = int.Parse(comboBoxMax.Text);
            int rand = int.Parse(comboBoxRandom.Text);

            if (min > max)
            {
                MessageBox.Show("Minimum characters cannot be less than the maximum characters.\n" +
                    "Please repick your options.", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (max > rand)
            {
                MessageBox.Show("Random letters cannot be less than the maximum characters.\n" +
                    "Please repick your options.", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MinLetters = min;
            MaxLetters = max;
            RandomLetters = rand;

            this.Close();

        }
        //closes the settings window without making changes. 
        private void SettingsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
