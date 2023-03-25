using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AwesomeAnagramsMobile
{
   internal class NavBarItem
    {
        public string DisplayName { get; set; }
        public Page Page { get; set; }
        public NavBarItem(string displayName, Page page)
        {
            DisplayName = displayName;
            Page = page;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
