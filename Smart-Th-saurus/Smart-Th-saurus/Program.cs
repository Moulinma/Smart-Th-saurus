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
            TXTCreating txt = new TXTCreating();
            string URL = "https://www.etml.ch/";
            HTMLTxtAnalyser Analyser = new HTMLTxtAnalyser();
            Analyser.WordSearching(txt, URL);
            Console.ReadLine();
        }
    }
}
