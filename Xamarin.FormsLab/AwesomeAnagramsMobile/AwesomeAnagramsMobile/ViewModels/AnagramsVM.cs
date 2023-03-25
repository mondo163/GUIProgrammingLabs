using DictionaryLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AwesomeAnagramsMobile.ViewModels
{
    internal class AnagramsVM : BaseVM
    {
        private string testString;
        public string TestString
        {
            get { return testString; }
            set { testString = value; NotifyProperty(); }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; NotifyProperty(); }
        }

        private string[] words;
        public string[] Words
        {
            get { return words; }
            set { words = value; NotifyProperty(); }

        }

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; GoToDefinition(); }
        }


        public ICommand SearchCommand { get; set; }

        private readonly INavigation navigation;

        public AnagramsVM(INavigation navigation)
        {
            SearchCommand = new RelayCommand(Search);
            this.navigation = navigation;
        }

        private void Search()
        {
            IWordList dictionary = DependencyService.Get<IWordList>();
            Words = dictionary.ReturnAnagramWords(SearchText.ToUpper().Trim()); ;
        }

        private async void GoToDefinition()
        {
            if (SelectedItem != null)
            {
                IWordList dictionary = DependencyService.Get<IWordList>();

                WordInfo wordInfo = new WordInfo();
                wordInfo.Word = selectedItem;
                wordInfo.Definition = dictionary.GetDefintion(SelectedItem);
                Pages.DefinitionPage definitionPage = new Pages.DefinitionPage(wordInfo);
                await navigation.PushAsync(definitionPage);
            }
        }
    }
}
