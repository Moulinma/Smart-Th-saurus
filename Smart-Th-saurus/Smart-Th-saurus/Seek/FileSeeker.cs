using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class FileSeeker : GlobalSeekers
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

        public void SeekOccurence(string directoryName)
        {
            //TODO Search files
            //TODO Foreach file analyse and incremente TempFileOcc/TempFoldOcc
            //TODO Compare TempFileOcc and MaxFileOccNbr && if more change MaxInfos
            //TODO Reset TempFileOcc && end Foreach
        }
    }
}
