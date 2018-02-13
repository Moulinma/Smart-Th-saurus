using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

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

        public void CreateTXT(string Name, List<string> lstWords)
        {
            Name = Regex.Replace(Name, @"/", "_");
            Name = Regex.Replace(Name, @"\?", "_");
            Name = Regex.Replace(Name, @"=", "_");
            string path = Name + ".txt";
            FileStream stream = File.Create(path);
            StreamWriter t = new StreamWriter(stream);
            foreach (string word in lstWords)
            {
                t.WriteLine(word);
            }
            t.Close();
            stream.Close();
        }
    }
}
