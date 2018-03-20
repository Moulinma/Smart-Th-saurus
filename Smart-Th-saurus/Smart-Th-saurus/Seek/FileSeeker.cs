using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class FileSeeker
    {
        private static FileSeeker file;

        public static FileSeeker GetFile()
        {
            if (file == null)
            {
                file = new FileSeeker();
            }
            return file;
        }
    }
}
