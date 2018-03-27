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
        //Variables
        private string wordInFile;
        private string[] arrayFile;
        private string[] tempArray;

        //Objects
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
            arrayFile = Directory.GetFiles(directoryName);
            foreach(string files in arrayFile)
            {
                StreamReader reader = new StreamReader(files, true);
                while((wordInFile = reader.ReadLine()) != null)
                {
                    if(wordInFile == word)
                    {
                        ++tempFileOcc;
                        ++tempFoldOcc;
                    }
                }
                if(tempFileOcc > maxOccFileNbr)
                {
                    maxOccFileNbr = tempFileOcc;
                    tempArray = files.Split('\\');
                    maxOccFileName = tempArray[tempArray.Count() - 1].Substring(0, tempArray[tempArray.Count() - 1].Length - 4);
                    tempArray = directoryName.Split('\\');
                    maxOccFileFold = tempArray[tempArray.Count() - 1];
                }
                tempFileOcc = 0;
                reader.Close();
            }
        }
    }
}
