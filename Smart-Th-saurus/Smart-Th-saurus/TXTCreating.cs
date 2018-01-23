using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Smart_Th_saurus
{
    class TXTCreating
    {
        WebClient client = new WebClient();
        public TXTCreating()
        {
            //Trouver un moyen de créer un dossier si il n'existe pas
        }

        public string TakeHTML(string URL)
        {
            string codeHTML = client.DownloadString(URL);
            return codeHTML;
        }

        public void CreateTXT(List<string> lstWords)
        {
            string currentString;
            bool WaitChar = false;
            foreach(string listWord in lstWords)
            {
                //TODO Trouver un moyen de créer un txt
                for (int x = 0; x < listWord.Length - 1; ++x)
                {
                    currentString = listWord.Substring(x, 2);
                    if (currentString == "\n")
                    {
                        WaitChar = true;
                        //TODO mettre les mots à la ligne
                    }
                    else if (x == listWord.Length - 2 && !WaitChar)
                    {
                        //TODO rajoute le string entier
                    }
                    else if (!WaitChar)
                    {
                        //TODO rajouter seulement le premier caractère du string
                    }
                    else
                    {
                        WaitChar = false;
                    }
                }
            }
        }
    }
}
