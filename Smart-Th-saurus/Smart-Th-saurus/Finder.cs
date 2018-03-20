using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Class who analyse websites to enter words in db
    /// </summary>
    class Finder
    {
        /// <summary>
        /// Method who will start the analyse and control other methods
        /// </summary>
        /// <param name="URL">URL of the website to analyse</param>
        public void Start(string URL)
        {
            //Variables
            int Analysed = 0;
            int Created = 0;

            //Objects
            List<List<string>> TempWordLst = new List<List<string>>();
            List<string> lstLinks = new List<string>();
            List<string> lstLinksName = new List<string>();
            List<string> TempLst = new List<string>();
            TXTCreating Creator = TXTCreating.GetTXT(URL);
            HTMLTxtAnalyser Analyser = HTMLTxtAnalyser.GetHTMLTxt();

            //Verify the link of the website
            if (Creator.VerifyURL(URL))
            {
                //TODO Fix bug Of links which begin by the site name (unknown bug location)
                //Search of links on the website
                HTMLLinkFinder Finder = HTMLLinkFinder.GetHTMLLink();
                lstLinks = Finder.Finder(Creator, URL);
                foreach(string link in lstLinks)
                {
                    if (link.Substring(0, 1) == "/")
                    {
                        TempLst = Finder.Finder(Creator, URL.Substring(0, URL.Length-2) + link);
                        if(TempLst != null)
                        {
                            lstLinks = lstLinks.Union(TempLst).ToList();
                        }
                    }
                    else
                    {
                        if (link.Contains(URL))
                        {
                            TempLst = Finder.Finder(Creator, link);
                            if (TempLst != null)
                            {
                                lstLinks = lstLinks.Union(TempLst).ToList();
                            }
                        }
                    }
                }
                if(!lstLinks.Contains(URL))
                {
                    lstLinks.Add(URL);
                }

                //Search of words
                foreach (string link in lstLinks)
                {
                    if (link.Substring(0, 1) == "/")
                    {
                        TempLst = Analyser.WordSearching(Creator, URL + link.Substring(1, link.Length - 1));
                        if (TempLst != null)
                        {
                            TempWordLst.Add(TempLst);
                            lstLinksName.Add(link.Substring(1, link.Length - 1));
                        }
                    }
                    else if (link == URL)
                    {
                        TempLst = Analyser.WordSearching(Creator, link);
                        if (TempLst != null)
                        {
                            TempWordLst.Add(TempLst);
                            lstLinksName.Add("Base");
                        }
                    }
                    Analysed++;
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Analysed : " + Analysed * 100 / lstLinks.Count + "%");
                }

                //Text creation
                for (int x = 0; x < lstLinksName.Count(); ++x)
                {
                    Creator.CreateTXT(lstLinksName[x], TempWordLst[x]);
                    Created++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Created : " + Created * 100 / lstLinksName.Count + "%");
                }
                Console.WriteLine("\n\nWebsite analysed!!!");
            }
        }
    }
}
