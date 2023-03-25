using DictionaryLib;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeAnagramsMobile
{
    public partial class App : Application
    {
        public App(string dictionaryPath)
        {
            InitializeComponent();

            //WordList dictionary = new WordList();
            DependencyService.Register<WordList>();
            WordList dictionary = DependencyService.Get<IWordList>() as WordList;
            dictionary.LoadDictionary(dictionaryPath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
