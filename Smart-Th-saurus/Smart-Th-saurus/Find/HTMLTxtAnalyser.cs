using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Class which analyse the HTML to search for words
    /// </summary>
    class HTMLTxtAnalyser
    {
        //Objects
        private static HTMLTxtAnalyser txtAnalyser;

        /// <summary>
        /// Constructor that verify if an HTMLTxtAnalyser already exists and returns it
        /// </summary>
        /// <returns>HTMLTxtAnalyser</returns>
        public static HTMLTxtAnalyser GetHTMLTxt()
        {
            if(txtAnalyser == null)
            {
                txtAnalyser = new HTMLTxtAnalyser();
            }
            return txtAnalyser;
        }

        /// <summary>
        /// Method which returns a list of words for every links on the website
        /// </summary>
        /// <param name="Creator">TXTCreating object which will take the HTML and returns it to the HTMLTxtAnalyser</param>
        /// <param name="URL">URL of the HTML to analyse</param>
        /// <returns>List of words</returns>
        public List<string> WordSearching(TXTCreating Creator, string URL)
        {
            //Variables
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

            //Objects
            List<string> lstWords = new List<string>();

            //Taking HTML and cleaning it
            string HTML = Creator.TakeHTML(URL);
            if(HTML != null)
            {
                HTML = Regex.Replace(HTML, @"\n", " ");
                HTML = Regex.Replace(HTML, @"\r", " ");
                HTML = Regex.Replace(HTML, @"\t", " ");

                //Loop to search for words
                for (int x = 0; x < HTML.Length; ++x)
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
                    else if (currentChr == '<' && takeChr)
                    {
                        takeChr = false;
                    }
                    else if (takeChr && !scripted)
                    {
                        if (currentChr == ' ')
                        {
                            if (word != "")
                            {
                                word = word.ToLower();
                                lstWords.Add(word);
                                word = "";
                            }
                        }
                        else
                        {
                            word += currentChr;
                        }
                    }
                }
            }
            else
            {
                lstWords = null;
            }
            return lstWords;
        }

        /// <summary>
        /// Method to see if a part of the HTML is scripted or not
        /// </summary>
        /// <param name="chrOne">Character before the "script"</param>
        /// <returns>Boolean if it is a script or not</returns>
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
