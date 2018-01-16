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
            HTMLLinkFinder linkFinder = new HTMLLinkFinder();
            linkFinder.Finder(URL);
            Console.ReadLine();
        }
    }
}
