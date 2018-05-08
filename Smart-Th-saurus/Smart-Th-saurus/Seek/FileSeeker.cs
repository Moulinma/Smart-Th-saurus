using System.IO;
using System.Linq;
namespace Smart_Th_saurus
{
    /// <summary>
    /// Class that seek the occurences in each files of the current directory
    /// </summary>
    class FileSeeker : GlobalSeekers
    {
        //Variables
        private string wordInFile;
        private string[] arrayFile;
        private string[] tempArray;
        private int foldOcc;
        private bool containsPlus;
        private bool isValide;

        //Objects
        private static FileSeeker file;

        /// <summary>
        /// Base constructor of the class
        /// </summary>
        /// <returns>Return the unique file</returns>
        public static FileSeeker GetFile()
        {
            if (file == null)
            {
                file = new FileSeeker();
            }
            return file;
        }

        /// <summary>
        /// Seek the number of occurence in each file and increment the globals variables
        /// </summary>
        /// <param name="directoryName"></param>
        public void SeekOccurence(string directoryName)
        {
            arrayFile = Directory.GetFiles(directoryName);
            //Analyse each file
            foreach(string files in arrayFile)
            {
                containsPlus = false;
                isValide = true;

                StreamReader reader = new StreamReader(files, true);
                while((wordInFile = reader.ReadLine()) != null)
                {
                    //Increment occurence if same word
                    if(wordInFile == word)
                    {
                        ++tempFileOcc;
                        ++foldOcc;
                    }
                    if (multiple)
                    {
                        if(wordInFile == wordPlus)
                        {
                            containsPlus = true;
                        }
                    }
                }
                //Change globals variables if the current number of occurence is more that the current max
                if (multiple)
                {
                    if(!plus && containsPlus || plus && !containsPlus)
                    {
                        isValide = false;
                    }
                }
                if (tempFileOcc > maxOccFileNbr || isValide)
                {
                    tempFoldOcc += foldOcc;
                    maxOccFileNbr = tempFileOcc;
                    tempArray = files.Split('\\');
                    maxOccFileName = tempArray[tempArray.Count() - 1].Substring(0, tempArray[tempArray.Count() - 1].Length - 4);
                    tempArray = directoryName.Split('\\');
                    maxOccFileFold = tempArray[tempArray.Count() - 1];
                }
                tempFileOcc = 0;
                foldOcc = 0;
                reader.Close();
            }
        }
    }
}
