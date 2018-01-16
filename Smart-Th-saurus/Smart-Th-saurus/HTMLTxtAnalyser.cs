using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class HTMLTxtAnalyser
    {
        public void WordSearching(TXTCreating txt, string URL)
        {
            bool takeChr = false;
            string word = "";
            string HTML = txt.TakeHTML(URL);
            for(int x = 0; x < HTML.Length; ++x)
            {
                char currentChr = Convert.ToChar(HTML.Substring(x, 1));
                if(currentChr == '>')
                {
                    takeChr = true;
                }
                else if(currentChr == '<')
                {
                    takeChr = false;
                    word += "\n";
                }
                else if (takeChr)
                {
                    word += currentChr;
                }
            }
            Console.WriteLine(word);
        }
    }
}
