using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLib
{
    public class WordList
    {
        public bool IsLoaded { get { return Words.Count > 0; } set { } }
        public List<WordInfo> Words { get; set; }

        public WordList()
        {
            Words = new List<WordInfo>();
        }
        public void LoadDictionary(string file)
        {
            string line;
            //checks if file location exists
            if (!File.Exists(file))
            {
                throw new Exception();
            }
    
            //open file location
            StreamReader stream = new StreamReader(file);
            IsLoaded = true;
            
            //throw away first two lines of file
            stream.ReadLine();
            stream.ReadLine();

            //parse file contents by word and definition and add to the data collection
            line = stream.ReadLine();
            
            while (line != null)
            {   
                string[] lineSplit = line.Split('\t');
                Words.Add(new WordInfo() { Word = lineSplit[0], Definition = lineSplit[1] });
                line = stream.ReadLine();
            }

        }

        public string GetDefintion(string word)
        {
            //check to see if dictionary is loaded
            if (IsLoaded == false)
            {
                return "Dictionary not loaded.";
            }
            //check to see if the word exists within the collection.
            //If found it returns the definition. 
            foreach  (var dictWord in Words)
            {
                if (dictWord.Word == word)
                {
                    return dictWord.Definition;
                }
            }

            //if word is not found, return null. 
            return null;
        }

        public List<string> ReturnAnagramWords(string letters, int min, int max)
        {
            //checking for edge cases for min and max values. 
            if (min < 2)
            {
                min = 2;
            }
            if (max > letters.Length)
            {
                max = letters.Length;
            }
            if (min>=max)
            {
                min = max;
            }
            

            List<string> anagrams = new List<string>();

            //For loop to go through each word in the dictionary.
            foreach (WordInfo word in Words)
            { 
                //checks to see if word is greater than anagram characters to skip word
                if (word.Word.Length < min || word.Word.Length > max)
                {
                    continue;
                }

                List<char> randomLetters = letters.ToCharArray().ToList();

                bool foundWord = true;
                foreach (char c in word.Word) 
                {
                    int index = randomLetters.IndexOf(c); 
                    
                    if (index == -1)
                    {
                        foundWord = false;
                        break;
                    }

                    randomLetters.RemoveAt(index);
                }

                //if letters found matches the letter count. its an anagram. 
                if (foundWord)
                {
                    anagrams.Add(word.Word);
                }
            }

            return anagrams;
        }
    }
}
