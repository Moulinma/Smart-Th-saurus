
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class HTMLLinkFinder
    {
        public List<string> Finder(TXTCreating Creator, string URL)
        {
            char chrOne = ' ';
            char chrTwo = ' ';
            char chrThree = ' ';
            char chrFour = ' ';
            string Link = "";
            List<string> lstLinks = new List<string>();
            bool takeCar = false;
            bool isLink = false;
            int chrRemaining = 0;
            string HTML = Creator.TakeHTML(URL);
            for (int x = 0; x < HTML.Length; ++x)
            {
                chrOne = chrTwo;
                chrTwo = chrThree;
                chrThree = chrFour;
                chrFour = Convert.ToChar(HTML.Substring(x, 1));

                if (chrFour == 'a' && chrThree == '<')
                {
                    isLink = true;
                }
                else if (chrOne == '<' && chrTwo == '/' && chrThree == 'a' && chrFour == '>')
                {
                    isLink = false;
                }

                if (isLink)
                {
                    if (chrOne == 'h' && chrTwo == 'r' && chrThree == 'e' && chrFour == 'f')
                    {
                        takeCar = true;
                        chrRemaining = 2;
                    }
                    else if (chrFour == '"' && chrRemaining == 0 && takeCar)
                    {
                        takeCar = false;
                        lstLinks.Add(Link);
                        Link = "";
                    }
                    else if (takeCar)
                    {
                        if (chrRemaining != 0)
                        {
                            chrRemaining--;
                        }
                        else
                        {
                            Link += chrFour;
                        }
                    }
                }
            }
            return lstLinks;
        }
    }
}
