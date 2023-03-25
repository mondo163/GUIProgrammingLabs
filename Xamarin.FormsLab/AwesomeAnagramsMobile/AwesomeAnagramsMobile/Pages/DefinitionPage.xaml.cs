using DictionaryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeAnagramsMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefinitionPage : ContentPage
    {
        public DefinitionPage(WordInfo wordInfo)
        {
            InitializeComponent();

            this.BindingContext = new ViewModels.DefinitionVM(wordInfo);
        }
    }
}