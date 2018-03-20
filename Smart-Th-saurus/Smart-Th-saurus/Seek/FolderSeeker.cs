using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class FolderSeeker
    {
        private static FolderSeeker folder;

        public static FolderSeeker GetFolder()
        {
            if(folder == null)
            {
                folder = new FolderSeeker();
            }
            return folder;
        }
    }
}
