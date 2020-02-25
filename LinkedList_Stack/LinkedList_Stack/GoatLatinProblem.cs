using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinkedList_Stack
{
    class GoatLatinProblem
    {
        public string ToGoatLatin(string S)
        {

            string[] wordArray = S.Split(' ');

            int counter = 0;
            string finalWord = string.Empty;
           
            foreach (string word in wordArray)
            {
                counter++;

                if (!checkIfVowel(word))
                {
                    finalWord = flipFirstChar(word, 2);
                }
                

                finalWord = AppendMAAtEndVowelWord(finalWord);

                finalWord = AppendAAtEndEachWord(finalWord, counter);
            }

            return finalWord;
        }

        public Boolean checkIfVowel(string word)
        {
            string c = word.Substring(0, 1);

            string[] vowelString = { "a", "e", "i", "o", "u" };

            if (vowelString.Any(s => s.ToLower() == c.ToLower()))
            {
                return true;
            }

            return false;
        }

        public string AppendAAtEndEachWord(string word, int noOfA)
        {
            for (int i = 0; i < noOfA; i++)
            {
                word = word.Insert(word.Length, "a");
            }

            return word;
        }

        public string AppendMAAtEndVowelWord(string word)
        {
            return word.Insert(word.Length, "ma");                       
        }

        public string flipFirstChar(string word, int noOfA)
        {
            string firstChar = word.Substring(0, 1);
            string restOfWord = word.Substring(1);

            return restOfWord.Insert(restOfWord.Length, firstChar);          

        }
    }
}
