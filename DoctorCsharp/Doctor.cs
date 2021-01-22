using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorCsharp
{
    class Doctor
    {
        static string[] hedges = {"Please tell me more.",
          "Many of my patients tell me the same thing.",
          "Please coninue." };

        static string[] qualifiers = {"Why do you say that ",
              "You seem to think that ",
              "Can you explain why " };

        static Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            {"i", "you" },
            {"me", "you" },
            {"we", "you" },
            {"us", "you" },
            {"mine", "yours"},
            {"my", "your" },
            {"am", "are" },
        };

        List<string> history;

        public Doctor()
        {
            history = new List<string>();
        }

        public string Greeting()
        {
            return "Good morning, I hope you are well today.\nWhat can I do for you ? ";

        }

        public string Farewell()
        {
            return "Have a nice day!";
        }
        public string Reply(string sentence)
        {
            Random rand = new Random();
            int probability = rand.Next(1, 6);
            int choice;

            if (probability == 1)
            {
                choice = rand.Next(0, hedges.Length);
                history.Add(sentence);
                return hedges[choice];

            }
            else if(probability == 3 && history.Count > 3)
            {
                choice = rand.Next(0, history.Count);
                history.Add(sentence);

                return "Earlier you said that " + ChangePerson(history[choice]);
            }
            else
            {
                choice = rand.Next(0, qualifiers.Length);
                history.Add(sentence);
                return qualifiers[choice] + ChangePerson(sentence);
            }
        }

        /*
         * ChangePerson
         * Goes through th inputed sentence and changes pronouns from 
         * first person to second person
         * 
         */
        public string ChangePerson(string sentence)
        {
            List<string> replyWords = new List<string>();
            string[] words = sentence.Split(' '); //creating array of substrings split apart where the original string has spaces


            foreach (string word in words)
            {

                /*
                 * Checking to see if our key is in the dictionary and saving value to the reply if if it is
                 * else we use the key as part of the reply 
                 */
                if (replacements.TryGetValue(word.ToLower(), out string wordValue))
                {
                    replyWords.Add(wordValue);
                }
                else
                {
                    replyWords.Add(word.ToLower());
                }

            }

            return string.Join(" ", replyWords);
        }
    }
}
