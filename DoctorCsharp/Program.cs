using System;
using System.Collections.Generic;

namespace DoctorCsharp
{
    public class Program
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

        static void Main(string[] args)
        {
            string sentence;
            //Give greeting at start
            Console.WriteLine("Good morning, I hope you are well today.");
            Console.WriteLine("What can I do for you ? ");
            while(true)
            {
                //Prompt user for input
                Console.Write(">> ");
                sentence = Console.ReadLine();

                //Check to see if user wants to stop
                if(sentence.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Have a nice day!");
                    break;
                }

                //Reply using the words the user typed
                Console.WriteLine(Reply(sentence));
            }

        }

    }
}
