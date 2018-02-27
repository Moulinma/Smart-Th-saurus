using System;

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
            Console.Write("What do you want to do?\n" +
                "1. Website Analyse\n" +
                "2. Word Research\n" +
                "3. Exit\n");
            //TODO When User press a key analyse it
            bool x = false;
            bool y = true;
            bool z = false;

            //Execute if User wants to analyse a website
            if (x)
            {
                Console.Clear();
                //TODO analyse all websites
                string URL = "https://etml.ch/";
                Console.WriteLine("Analysing the ETML website...\n" +
                    "Please wait...");
                Finder finder = new Finder();
                finder.Start(URL);
                Console.WriteLine("\n\nWebsite analysed!!!");
            }

            //Execute if User wants to research a word
            else if (y)
            {
                Console.Clear();
            }

            //Exit application
            else if (z)
            {
                Environment.Exit(0);
            }
        }
    }
}
