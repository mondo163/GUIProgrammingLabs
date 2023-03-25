using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeAnagramsMobile
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavBarItem home = new NavBarItem("Home", new Pages.HomePage());

            List<NavBarItem> navItems = new List<NavBarItem>();

            navItems.Add(home);
            navItems.Add(new NavBarItem("Anagrams", new Pages.AnagramsPage()));
            navItems.Add(new NavBarItem("Dictionary", new Pages.DictionaryPage()));

            lstView.ItemsSource = navItems;

            Detail = new NavigationPage(home.Page);
        }

        private void lstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavBarItem selected = e.SelectedItem as NavBarItem;

            if (selected != null)
            {
                Detail = new NavigationPage(selected.Page);
                lstView.SelectedItem = null;
                IsPresented = false; //close the hamburger menu
            }
        }
    }
}
