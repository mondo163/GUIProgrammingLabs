using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryLib
{
    public interface IWordList
    {
        string[] GetWords();
        WordInfo[] SearchWords(string text);
        string[] ReturnAnagramWords(string letters, int min = 3, int max = 7);
        string GetDefintion(string word);
    }
}
