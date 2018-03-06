using System;
using System.Text.RegularExpressions;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Main class who launch the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method who launch the section that the User wants
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("What do you want to do?\n" +
                "1. Website Analyse\n" +
                "2. Word Research\n" +
                "3. Exit\n");
                Console.ReadLine();
                //TODO When User press a key analyse it
                bool x = true;
                bool y = false;
                bool z = false;

                //Execute if User wants to analyse a website
                if (x)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the link of the website you want to analyse");
                    string URL = Console.ReadLine();
                    if (URL.Substring(URL.Length - 2, 1) != "/")
                    {
                        URL += "/";
                    }
                    Console.WriteLine("Analysing the website...\n" +
                        "Please wait...");
                    Finder finder = new Finder();
                    finder.Start(URL);
                    Console.ReadLine();
                }

                //Execute if User wants to research a word
                else if (y)
                {
                    Console.Clear();
                    Seeker seeker = new Seeker();
                    seeker.Start();
                }

                //Exit application
                else if (z)
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }
    }
}
