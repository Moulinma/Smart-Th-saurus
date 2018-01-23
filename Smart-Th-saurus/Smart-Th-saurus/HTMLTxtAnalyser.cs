using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class HTMLTxtAnalyser
    {
        public string WordSearching(TXTCreating Creator, string URL)
        {
            char chrOne = ' ';
            char chrTwo = ' ';
            char chrThree = ' ';
            char chrFour = ' ';
            char chrFive = ' ';
            char chrSix = ' ';
            char chrSeven = ' ';
            bool takeChr = false;
            bool scripted = false;
            string word = "";
            string HTML = Creator.TakeHTML(URL);
            for(int x = 0; x < HTML.Length; ++x)
            {
                char currentChr = Convert.ToChar(HTML.Substring(x, 1));

                chrOne = chrTwo;
                chrTwo = chrThree;
                chrThree = chrFour;
                chrFour = chrFive;
                chrFive = chrSix;
                chrSix = chrSeven;
                chrSeven = currentChr;
                if (chrTwo == 's' && chrThree == 'c' && chrFour == 'r' && chrFive == 'i' && chrSix == 'p' && chrSeven == 't')
                {
                    scripted = IsScript(chrOne);
                }
                
                if (currentChr == '>')
                {
                    takeChr = true;
                }
                else if(currentChr == '<' && takeChr)
                {
                    takeChr = false;
                }
                else if (takeChr && !scripted)
                {
                    if(currentChr == ' ')
                    {
                        word += "\n";
                    }
                    else
                    {
                        word += currentChr;
                    }
                }
            }
            return word;
        }

        private bool IsScript(char chrOne)
        {
            if (chrOne == '/')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
