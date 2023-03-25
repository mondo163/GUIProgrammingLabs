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
    internal class DictionaryVM : BaseVM
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

        private WordInfo[] words;
        public WordInfo[] Words
        {
            get { return words; }
            set { words = value; NotifyProperty(); }

        }

        private WordInfo selectedItem;

        public WordInfo SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; GoToDefinition(); }
        }


        public ICommand SearchCommand { get; set; }

        private readonly INavigation navigation;

        public DictionaryVM(INavigation navigation)
        {
            SearchCommand = new RelayCommand(Search);
            this.navigation = navigation;
        }

        private void Search()
        {
            IWordList dictionary = DependencyService.Get<IWordList>();
            Words = dictionary.SearchWords(SearchText);
        }

        private async void GoToDefinition()
        {
            if (SelectedItem != null)
            {
                Pages.DefinitionPage definitionPage = new Pages.DefinitionPage(SelectedItem);
                await navigation.PushAsync(definitionPage);
            }
        }
    }
}
