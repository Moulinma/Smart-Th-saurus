using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://www.etml.ch/";
            List<List<string>> TempWordLst = new List<List<string>>();
            List<string> lstLinks = new List<string>();
            List<string> lstLinksName = new List<string>();
            TXTCreating Creator = new TXTCreating();
            HTMLTxtAnalyser Analyser = new HTMLTxtAnalyser();

            //Recherche de liens présents sur le site
            HTMLLinkFinder Finder = new HTMLLinkFinder();
            lstLinks = Finder.Finder(Creator, URL);
            lstLinks.Add(URL);
            
            //Recherche des mots
            foreach(string link in lstLinks)
            {
                //TODO Gérer les exceptions
                if(link != "/lecole-2/presentation.html" && link.Substring(0, 1) != "#")
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

            //Création du Texte
            for(int x = 0; x < lstLinksName.Count(); ++x)
            {
                Creator.CreateTXT(lstLinksName[x], TempWordLst[x]);
            }

            Console.ReadLine();
        }
    }
}
