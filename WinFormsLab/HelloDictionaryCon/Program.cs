using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryLib;

namespace HelloDictionaryCon
{
    public class Program
    {
        static void Main(string[] args)
        {
            WordList words = new WordList();
            string file;

            

            try
            {
                words.LoadDictionary(@"wordgame_dictionary.txt");
                Console.WriteLine("Dictionary loaded successfully.");
            }
            catch (Exception)
            {
                System.Environment.Exit(1);
            }

            string letterBank = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                letterBank += (char)random.Next('A', ('Z' + 1));
            }
            Console.WriteLine(letterBank);
            List<string> anagrams = words.ReturnAnagramWords(letterBank,2,6);
            foreach (string item in anagrams)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Exiting.");
            Console.ReadKey();
        }
    }
}
