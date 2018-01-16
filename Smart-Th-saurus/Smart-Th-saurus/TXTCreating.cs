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
            //TODO Find a way to create a folder
            //Directory.CreateDirectory(@"C:\Users\%username%\Desktop\TXTResult");
        }

        public string TakeHTML(string URL)
        {
            string codeHTML = client.DownloadString(URL);
            return codeHTML;
        }

        public void CreateTXT(string URL)
        {
            //TODO Find a way to create a txt
        }
    }
}
