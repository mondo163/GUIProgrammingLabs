using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DictionaryLib;

namespace AwesomeAnagramsASP.Pages
{
    public class AnagramsModel : PageModel
    {
        const int NUM_WORDS = 25;
        private readonly IWordList dictionary;

        [BindProperty(SupportsGet = true)]
        public string Letters { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public PaginatedList<string> Words { get; set; }
        public AnagramsModel(IWordList dictionary)
        {
            this.dictionary = dictionary;
        }
        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Letters))
            {
                Words = PaginatedList<string>.Create(dictionary.ReturnAnagramWords(Letters.ToUpper(), 2), PageIndex);
            }
            else
            {
                Words = PaginatedList<string>.Create(new string[0], PageIndex);
            }


        }
    }
}
