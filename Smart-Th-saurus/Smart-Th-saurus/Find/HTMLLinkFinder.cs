using System;
using System.Collections.Generic;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Class which search links in the HTML
    /// </summary>
    class HTMLLinkFinder
    {
        //Objects
        private static HTMLLinkFinder linkFinder;

        /// <summary>
        /// Constructor that will verify if a HTMLLinkFinder already exist and return it
        /// </summary>
        /// <returns>HTMLLinkFinder</returns>
        public static HTMLLinkFinder GetHTMLLink()
        {
            if(linkFinder == null)
            {
                linkFinder = new HTMLLinkFinder();
            }
            return linkFinder;
        }

        /// <summary>
        /// Method to search links
        /// </summary>
        /// <param name="Creator">TXTCreating object which will take the HTML and returns it to the HTMLLinkFinder</param>
        /// <param name="URL">URL of the HTML to analyse</param>
        /// <returns>Return a list of links</returns>
        public List<string> Finder(TXTCreating Creator, string URL)
        {
            //Variables
            char chrOne = ' ';
            char chrTwo = ' ';
            char chrThree = ' ';
            char chrFour = ' ';
            string Link = "";
            bool takeCar = false;
            bool isLink = false;
            int chrRemaining = 0;

            //Objects
            List<string> lstLinks = new List<string>();

            //Taking HTML
            string HTML = Creator.TakeHTML(URL);

            if(HTML != null)
            {
                //Loop to search for links
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
            }
            else
            {
                lstLinks = null;
            }
            
            return lstLinks;
        }
    }
}
