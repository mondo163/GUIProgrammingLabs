using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DictionaryLib;

namespace AwesomeAnagramsASP.Pages
{
    public class DefinitionModel : PageModel
    {
        private readonly IWordList dictionary;
        [BindProperty(SupportsGet =true)]
        public string Word { get; set; }
        public string Definition { get; set; }

        public DefinitionModel(IWordList wordList)
        {
            this.dictionary = wordList;
        }
        public IActionResult OnGet()
        {
            Definition = dictionary.GetDefintion(Word);

            if (string.IsNullOrWhiteSpace(Definition))
            {
                return RedirectToPage("/WordNotFound");
            }

            return Page();
        }
    }
}
