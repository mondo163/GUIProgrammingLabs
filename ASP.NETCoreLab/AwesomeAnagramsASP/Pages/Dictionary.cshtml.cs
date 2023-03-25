using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DictionaryLib;

namespace AwesomeAnagramsASP.Pages
{
    public class DictionaryModel : PageModel
    {
        const int NUM_WORDS = 25;
        private readonly IWordList dictionary;

       // public string[] Words { get; set; }
        public PaginatedList<string> Words { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public DictionaryModel(IWordList wordList)
        {
            this.dictionary = wordList;
        }
        public void OnGet()
        {
            IEnumerable<string> words = dictionary.GetWords();
            
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                Words = PaginatedList<string>.Create(words, PageIndex, word => word.StartsWith(Filter));

            }
            else
            {
                Words = PaginatedList<string>.Create(words, PageIndex);
            }
            
        }
    }
}
