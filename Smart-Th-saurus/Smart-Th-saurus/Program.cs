using System;
using System.Runtime.InteropServices;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Main class who launch the program
    /// </summary>
    class Program
    {
        //Hook to the windows API
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        /// <summary>
        /// Main method who launch the section that the User wants
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main(string[] args)
        {
            //TODO [GLO] Tests
            //TODO [GLO] Opérateurs
            while (true)
            {
                Console.Write("What do you want to do?\n" +
                "1. Website Analyse\n" +
                "2. Word Research\n" +
                "3. Exit\n");

                //Appel de l'api
                Console.ReadKey();
                int keyState1 = GetAsyncKeyState(49);
                int keyState2 = GetAsyncKeyState(50);
                int keyState3 = GetAsyncKeyState(51);

                //Execute if User wants to analyse a website
                if (keyState1 == 1 || keyState1 == -32767)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the link of the website you want to analyse");
                    string URL = Console.ReadLine();
                    if(URL != "")
                    {
                        if (URL.Substring(URL.Length - 1, 1) != "/")
                        {
                            URL += "/";
                        }
                        Console.WriteLine("Analysing the website...\n" +
                            "Please wait...");
                        Finder finder = new Finder();
                        finder.Start(URL);
                    }
                }
                
                //Execute if User wants to research a word
                if (keyState2 == 1 || keyState2 == -32767)
                {
                    Console.Clear();
                    Console.WriteLine("Searching occurences...\n" +
                        "Please wait...");
                    Seeker seeker = new Seeker();
                    seeker.Start();
                }

                //Exit application
                if (keyState3 == 1 || keyState3 == -32767)
                {
                    Environment.Exit(0);
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
