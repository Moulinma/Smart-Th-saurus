
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class HTMLLinkFinder
    {
        public void Finder(string URL)
        {
            char chrOne = ' ';
            char chrTwo = ' ';
            char chrThree = ' ';
            char chrFour = ' ';
            string Link = @"";
            bool takeCar = false;
            int chrRemaining = 0;
            TXTCreating txt = new TXTCreating();
            string HTML = txt.TakeHTML(URL);
            for (int x = 0; x < HTML.Length; ++x)
            {
                chrOne = chrTwo;
                chrTwo = chrThree;
                chrThree = chrFour;
                chrFour = Convert.ToChar(HTML.Substring(x, 1));

                if(chrThree == '<' && chrFour == 'a')
                {
                    takeCar = true;
                    chrRemaining = 4;
                }
                if(chrOne == '<' && chrTwo == '/' && chrThree == 'a' && chrFour == '>')
                {
                    takeCar = false;
                    Console.WriteLine(Link + "\n\n");
                    Link = "";
                }
                if (takeCar)
                {
                    if(chrRemaining == 0)
                    {
                        Link += chrOne;
                    }
                    else
                    {
                        --chrRemaining;
                    }
                }
            }
        }
    }
}
