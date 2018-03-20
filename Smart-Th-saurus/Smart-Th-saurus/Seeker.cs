using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class Seeker : GlobalSeekers
    {
        //Variables
        string word;
        string[] tempNameArray;
        int analysed = 0;

        //Objects
        FolderSeeker folder = FolderSeeker.GetFolder();
        FileSeeker file = FileSeeker.GetFile();

        public void Start()
        {
            analysed = 0;
            Console.Clear();
            Console.WriteLine("Which word do you want to research?");
            word = Console.ReadLine();

            if (folder.SearchFolders())
            {
                foreach(string folder in arrayFolders)
                {
                    file.SeekOccurence(folder);
                    if(tempFoldOcc < maxOccFoldNbr)
                    {
                        maxOccFoldNbr = tempFoldOcc;
                        tempNameArray = folder.Split('\\');
                        maxOccFoldName = tempNameArray[tempNameArray.Count()-1];
                    }

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Analysed : " + ++analysed + "/" + arrayFolders.Count());
                    tempFoldOcc = 0;
                }
                //TODO Show results

                maxOccFileNbr = 0;
                maxOccFoldNbr = 0;
            }
        }
    }
}
