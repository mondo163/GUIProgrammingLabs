using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryLib
{
    public interface IWordList
    {
        string[] GetWords();
        string[] ReturnAnagramWords(string letters, int min = 3, int max = 7);
        string GetDefintion(string word);
    }
}
