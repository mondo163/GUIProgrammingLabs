//Game Engine Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryLib;

namespace GameLib
{
    public class GameClass
    {
        private WordList dictionary;
        public Dictionary<string, bool> anagramList { get; set; }
        public string letterBank { get; set; }
        private int minLetters;
        private int maxLetters;
        public GameClass(string file, int min = 3, int max = 6)
        {
            dictionary = new WordList();
            try
            {
                dictionary.LoadDictionary(file);
            }
            catch (Exception)
            {
                MessageBox.Show("Dictionary Not Loaded!", "Dictionary Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            anagramList = new Dictionary<string,bool>();
            letterBank = "";
            createLetterBank();
            minLetters = min;
            maxLetters = max;
        }

        //Gets all words that have been guessed correctly for output and underscores
        public string[] GetGuesses()
        {
            List<string> guesses = new List<string>();
            foreach (KeyValuePair<string,bool> item in anagramList)
            {
                if (item.Value)
                {
                    guesses.Add(item.Key);
                }
                else
                {
                    StringBuilder s = new StringBuilder();
                    for (int i = 0; i < item.Key.Length; i++)
                    {
                        s.Append("_ ");
                    }
                    guesses.Add(s.ToString());
                }
            }

            return guesses.ToArray();
        }
        public void createLetterBank()
        {
            //checks if the letter bank has letters in it. If it does it leaves a blank string.
            if (letterBank.Length > 0)
            {
                letterBank = "";
            }

            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                letterBank += (char)random.Next('A', ('Z' +1));
            }
        }

        //creates anagrams list and checks for doubles. 
        public void createAnagramList()
        {
            List<string> words = dictionary.ReturnAnagramWords(letterBank, minLetters, maxLetters);
            foreach (string item in words)
            {
                try
                {
                    anagramList.Add(item, false);
                }
                catch (ArgumentException)
                {
                    continue;
                }
                
            }
            
        }

        //checks for word in anagrams
        public bool GuessWord(string word)
        {
            return anagramList.ContainsKey(word);
        }

        //returns word definition
        public string ReturnDefinition(string word)
        {
            return dictionary.GetDefintion(word);
        }

        //returns all anagrams for output
        public string[] ReturnAllAnagrams()
        {
            List<string> allAnagrams = new List<string>();
            foreach (KeyValuePair<string,bool> item in anagramList)
            {
                allAnagrams.Add(item.Key);
            }

            return allAnagrams.ToArray();
        }

        //checks to see if all words were found. 
        public bool CheckForWin()
        {
            foreach (KeyValuePair<string, bool> item in anagramList)
            {
                if (item.Value == false)
                {
                    return false;
                }
          
            }
            return true;
        }

    }
}
