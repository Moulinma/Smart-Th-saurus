﻿using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Class to take HTML and create the TXT db
    /// </summary>
    class TXTCreating
    {
        //Variables
        private static string codeHTML;
        private static string directoryName;
        private static int nbrTooLong;

        //Object
        private static WebClient client = new WebClient();
        private static string[] TempDirectorySplit;
        private static string[] UrlTempArray = new string[2];
        private static TXTCreating creator;

        /// <summary>
        /// Constructor that creates a directory
        /// </summary>
        public static TXTCreating GetTXT(string URL)
        {
            if(creator == null)
            {
                creator = new TXTCreating();
            }
            TempDirectorySplit = URL.Split(':');
            directoryName = TempDirectorySplit[1].Substring(2, TempDirectorySplit[1].Length - 2);
            Directory.CreateDirectory(directoryName);

            //Reset values
            codeHTML = "";
            nbrTooLong = 0;

            return creator;
        }

        /// <summary>
        /// Method that take the HTML of a page
        /// </summary>
        /// <param name="URL">The link of the page to take the HTML of</param>
        /// <returns>Returns the HTML of the page</returns>
        public string TakeHTML(string URL)
        {
            try
            {
                if (URL.Contains("?"))
                {
                    UrlTempArray = URL.Split('?');
                    URL = UrlTempArray[0];
                }
                try
                {
                    codeHTML = client.DownloadString(URL);
                }
                catch(Exception){}
                return codeHTML;
            }
            catch (WebException)
            {
                return null;
            }
        }

        /// <summary>
        /// Method that Verify if the website is accessible
        /// </summary>
        /// <param name="URL">The link of the website</param>
        /// <returns>Returns if the website is accessible</returns>
        public bool VerifyURL(string URL)
        {
            if(URL != "")
            {
                bool Test = true;
                try
                {
                    codeHTML = client.DownloadString(URL);
                }
                catch (Exception)
                {
                    Console.WriteLine("The URL isn't valid");
                    Test = false;
                }
                return Test;
            }
            else
            {
                Console.WriteLine("The URL isn't valid");
                return false;
            }
            
        }

        /// <summary>
        /// Method that create the txt files and fill them with the words of the pages
        /// </summary>
        /// <param name="Name">Name of the link that has been analysed</param>
        /// <param name="lstWords">List of the words of the page</param>
        public void CreateTXT(string Name, List<string> lstWords)
        {
            Name = Regex.Replace(Name, @"/", "_");
            Name = Regex.Replace(Name, @"\?", "_");
            Name = Regex.Replace(Name, @"=", "_");
            Name = Regex.Replace(Name, @":", "_");
            string path = Name + ".txt";
            
            try
            {
                FileStream stream = File.Create(directoryName + "/" + path);
                StreamWriter t = new StreamWriter(stream, System.Text.Encoding.UTF8);
                t.WriteLine(Name);
                foreach (string word in lstWords)
                {
                    t.WriteLine(word);
                }
                t.Close();
                stream.Close();
            }
            catch (System.IO.PathTooLongException)
            {
                FileStream stream = File.Create(directoryName + "/" + "TooLongName" + nbrTooLong++ + ".txt"); StreamWriter t = new StreamWriter(stream);
                t.WriteLine(Name);
                foreach (string word in lstWords)
                {
                    t.WriteLine(word);
                }
                t.Close();
                stream.Close();
            }
        }
    }
}
