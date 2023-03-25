using DictionaryLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeAnagramsMobile.ViewModels
{
    internal class DefinitionVM: BaseVM
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public DefinitionVM(WordInfo word)
        {
            Word = word.Word;
            Definition = word.Definition;
        }
    }
}
