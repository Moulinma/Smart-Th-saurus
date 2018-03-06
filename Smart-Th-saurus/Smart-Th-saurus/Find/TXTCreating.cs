using System.Collections.Generic;
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
        string codeHTML;
        int nbrTooLong;

        //Object
        WebClient client = new WebClient();
        string[] UrlTempArray = new string[2];

        /// <summary>
        /// Method that create a folder to db
        /// </summary>
        public TXTCreating()
        {
            //TODO Find a way to create a folder if not exist
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
                codeHTML = client.DownloadString(URL);
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
                catch (WebException)
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
            string path = Name + ".txt";
            
            try
            {
                FileStream stream = File.Create(path); StreamWriter t = new StreamWriter(stream);
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
                FileStream stream = File.Create("TooLongName" + nbrTooLong++ + ".txt"); StreamWriter t = new StreamWriter(stream);
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
