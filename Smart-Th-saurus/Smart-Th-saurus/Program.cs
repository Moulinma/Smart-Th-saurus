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
            TXTCreating Creator = new TXTCreating();
            HTMLTxtAnalyser Analyser = new HTMLTxtAnalyser();
            Creator.CreateTXT(Analyser.WordSearching(Creator, URL));
            Console.ReadLine();
        }
    }
}
