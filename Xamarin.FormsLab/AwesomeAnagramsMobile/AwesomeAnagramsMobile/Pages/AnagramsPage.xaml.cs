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
    public partial class AnagramsPage : ContentPage
    {
        public AnagramsPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModels.AnagramsVM(Navigation);
        }
    }
}