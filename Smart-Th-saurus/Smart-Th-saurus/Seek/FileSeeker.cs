using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class FileSeeker : GlobalSeekers
    {
        string[] arrayFile;
        string[] tempNameArray;

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
            arrayFile = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + directoryName));
            foreach(string files in arrayFile)
            {
                //TODO Analyse and incremente TempFileOcc/TempFoldOcc
                if(tempFileOcc > maxOccFileNbr)
                {
                    maxOccFileNbr = tempFileOcc;
                    tempNameArray = files.Split('\\');
                    maxOccFileName = tempNameArray[tempNameArray.Count() - 1];
                    maxOccFileFold = directoryName;
                }
                tempFileOcc = 0;
            }
        }
    }
}
