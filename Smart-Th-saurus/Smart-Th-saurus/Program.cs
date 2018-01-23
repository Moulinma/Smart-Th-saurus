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
            List<string> TempWordLst = new List<string>();
            List<string> lstLinks = new List<string>();
            TXTCreating Creator = new TXTCreating();
            HTMLTxtAnalyser Analyser = new HTMLTxtAnalyser();

            //Recherche de liens présents sur le site
            HTMLLinkFinder Finder = new HTMLLinkFinder();
            lstLinks = Finder.Finder(Creator, URL);
            
            //Recherche des mots
            foreach(string link in lstLinks)
            {
                link.Replace("\n", "");
                if (link.Substring(0, 1) == "/")
                {
                    TempWordLst.Add(Analyser.WordSearching(Creator, URL + link.Substring(1, link.Length - 1)));
                }
                else
                {
                    TempWordLst.Add(Analyser.WordSearching(Creator, link));
                }
            }

            foreach(string element in TempWordLst)
            {
                Console.WriteLine(element);
            }

            //Création du Texte
            //Creator.CreateTXT(TempWordLst);

            Console.ReadLine();
        }
    }
}
