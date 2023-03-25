//Game Engine Class
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryLib;
using Newtonsoft.Json;

namespace GameLib
{
    public class GameClass
    {
        private WordList dictionary;
        public Dictionary<string, bool> AnagramList { get; set; }
        public string LetterBank { get; set; }
        public int MinLetters { get; set; }
        public int MaxLetters { get; set; }
        public int LetterBankCount { get; set; }
        public int Time { get; set; }
        private readonly int maxWords = 30;
        private readonly int minWords = 5;
        //Default constructor with settings check if settings file has already been created. 
        public GameClass(int min = 3, int max = 7, int defaultTime = 300, int letterBankAmountDefault = 7)
        {
            
            string path = System.IO.Directory.GetCurrentDirectory() + "\\GameSettings.json";
            if (System.IO.File.Exists(path))
            {
                LoadSettings();
            }
            else
            {
                MinLetters = min;
                MaxLetters = max;
                LetterBankCount = letterBankAmountDefault;
                Time = defaultTime;
            }

            dictionary = new WordList();
            AnagramList = new Dictionary<string, bool>();
            LetterBank = "";
        }
        //constructor with file name for manual loading of file
        public GameClass(string file, int min = 3, int max = 7, int defaultTime = 300, int letterBankAmountDefault = 7)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\GameSettings.json";
            if (System.IO.File.Exists(path))
            {
                LoadSettings();
            }
            else
            {
                MinLetters = min;
                MaxLetters = max;
                LetterBankCount = letterBankAmountDefault;
                Time = defaultTime;
            }

            dictionary = new WordList();
            path = System.IO.Directory.GetCurrentDirectory() + "\\"+file;
            try
            {
                dictionary.LoadDictionary(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Dictionary Not Loaded!", "Dictionary Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            AnagramList = new Dictionary<string, bool>();
            LetterBank = "";

        }
        //constructor used for deserializting json files into gameclass objects. 
        [JsonConstructor]
        public GameClass(Dictionary<string, bool> anagramLis, string letterBan, int min = 3, int max = 7, int letterBankAmountDefault = 7, int defaultTime = 300)
        {
            MinLetters = min;
            MaxLetters = max;
            LetterBankCount = letterBankAmountDefault;
            Time = defaultTime;
            dictionary = new WordList();
            AnagramList = new Dictionary<string, bool>();
            LetterBank = "";
        }

        //Gets all words that have been guessed correctly for output and underscores
        public string[] GetGuesses()
        {
            List<string> guesses = new List<string>();
            foreach (KeyValuePair<string,bool> item in AnagramList)
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
        //creates anagrams list and checks for doubles. 
        public void CreateAnagramList()
        {
            
            List<string> words = dictionary.ReturnAnagramWords(LetterBank, MinLetters, MaxLetters);
            while (words.Count() < minWords || words.Count() > maxWords)
            {
                CreateLetterBank();
                words = dictionary.ReturnAnagramWords(LetterBank, MinLetters, MaxLetters);
            }

            AnagramList = new Dictionary<string, bool>();
            foreach (var item in words)
            {
                try
                {
                    AnagramList.Add(item.ToUpper(), false);
                }
                catch (ArgumentException)
                {
                    continue;
                }

            }
            
            
        }
        public void CreateLetterBank()
        {
            //checks if the letter bank has letters in it. If it does it leaves a blank string.
            if (LetterBank.Length > 0)
            {
                LetterBank = "";
            }

            Random random = new Random();
            for (int i = 0; i < LetterBankCount; i++)
            {
                LetterBank += (char)random.Next('A', ('Z' +1));
            }
        }
        //checks for word in anagrams
        public bool GuessWord(string word)
        {
            return AnagramList.ContainsKey(word);
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
            foreach (KeyValuePair<string,bool> item in AnagramList)
            {
                allAnagrams.Add(item.Key);
            }

            return allAnagrams.ToArray();
        }
        //shuffles the letter bank 
        public string ShuffleLetterBank()
        {
            Random rand = new Random();
            char[] newLetterBank = LetterBank.ToCharArray();
            int index = newLetterBank.Length;
            while(index > 1)
            {
                index--;
                int altIndex = rand.Next(index + 1);
                char value = newLetterBank[altIndex];
                newLetterBank[altIndex] = newLetterBank[index];
                newLetterBank[index] = value;
            }

            LetterBank = new string(newLetterBank);
            return LetterBank;
        }
        //checks to see if all words were found. 
        public bool CheckForWin()
        {
            foreach (KeyValuePair<string, bool> item in AnagramList)
            {
                if (item.Value == false)
                {
                    return false;
                }
          
            }
            return true;
        }
        //used to upload the dictionary from a selected file 
        public bool UploadDictionaryFromFile(string file)
        {
            try
            {
                dictionary.LoadDictionary(file);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //returns game instructions in one edited string
        public string ReturnInstructions()
        {
            return "To begin playing:\n" +
                    "  - Click on Load Dictionary in the File menu option to upload the wordgame_dictionary.txt file to upload the\n" +
                    "    dictionary to play from.\n" +
                    "  - Once dictionary is uploaded, you can edit the max number of letters and minimum number of letters from the\n" +
                    "    Settings option in the File menu. If no settings are adjusted, default settings of maximum 7 letter anagrams,\n" +
                    "    minimum 3 letter anagrams, and a letter bank of 7 letters will be set. Settings can only be adjusted when the\n" +
                    "    game is stopped.\n" +
                    "  - From here, simply click on the start button to begin your game.\n" +
                    "  - The game is either over once the time runs out or you have found every anagram.\n" +
                    "  - Once the game is over, you may select the show definitions button to learn about every anagram that appeared\n" +
                    "    in the previous game.\n" +
                    "  - Adjust settings at this point if you'd like. Otherwise, click the start button again and restart the game with\n" +
                    "    a fresh letter bank and set of anagrams.";
        }
        //loads settings from a json file
        private void LoadSettings()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\GameSettings.json";
            StreamReader sr = new StreamReader(path);

            string jsonResults = sr.ReadLine();

            GameClass temp = JsonConvert.DeserializeObject<GameClass>(jsonResults);

            this.MinLetters = temp.MinLetters;
            this.MaxLetters = temp.MaxLetters;
            this.LetterBankCount = temp.LetterBankCount;
            this.Time = temp.Time;

            sr.Close();
        }
        //saves settings to a json file
        public void SaveSettings()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\GameSettings.json";
            StreamWriter sw = new StreamWriter(path,false);

            string jsonObject = JsonConvert.SerializeObject(this);
            sw.WriteLine(jsonObject);

            sw.Close();
        }
    }
}
