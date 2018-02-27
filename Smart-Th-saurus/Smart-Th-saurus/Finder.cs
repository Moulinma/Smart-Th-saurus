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
            //Objects
            List<List<string>> TempWordLst = new List<List<string>>();
            List<string> lstLinks = new List<string>();
            List<string> lstLinksName = new List<string>();
            TXTCreating Creator = new TXTCreating();
            HTMLTxtAnalyser Analyser = new HTMLTxtAnalyser();

            //Search of links on the website
            HTMLLinkFinder Finder = new HTMLLinkFinder();
            lstLinks = Finder.Finder(Creator, URL);
            lstLinks.Add(URL);

            //Search of words
            foreach (string link in lstLinks)
            {
                //TODO Control exceptions
                if (link != "/lecole-2/presentation.html" && link.Substring(0, 1) != "#")
                {
                    if (link.Substring(0, 1) == "/")
                    {
                        TempWordLst.Add(Analyser.WordSearching(Creator, URL + link.Substring(1, link.Length - 1)));
                        lstLinksName.Add(link.Substring(1, link.Length - 1));
                    }
                    else if (link == URL)
                    {
                        TempWordLst.Add(Analyser.WordSearching(Creator, link));
                        lstLinksName.Add("Base");
                    }
                }
            }

            //TEST WRITE CONSOLE
            //foreach(List<string> lstWords in TempWordLst)
            //{
            //    foreach(string word in lstWords)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine("--------------------------------------------");
            //}

            //Text creation
            for (int x = 0; x < lstLinksName.Count(); ++x)
            {
                Creator.CreateTXT(lstLinksName[x], TempWordLst[x]);
            }
        }
    }
}
