using System;
using System.Linq;

namespace Smart_Th_saurus
{
    class Seeker : GlobalSeekers
    {
        //Variables
        int analysed = 0;
        string[] tempArray;

        //Objects
        FolderSeeker folder = FolderSeeker.GetFolder();
        FileSeeker file = FileSeeker.GetFile();

        public void Start()
        {
            analysed = 0;
            Console.Clear();
            Console.WriteLine("Which word do you want to research?");
            word = Console.ReadLine();
            word = word.ToLower();
            word = word.Replace("é", "Ã©");
            word = word.Replace("è", "Ã¨");
            word = word.Replace("à", "Ã");

            if (folder.SearchFolders())
            {
                foreach(string folder in arrayFolders)
                {
                    file.SeekOccurence(folder);
                    if(tempFoldOcc > maxOccFoldNbr)
                    {
                        maxOccFoldNbr = tempFoldOcc;
                        tempArray = folder.Split('\\');
                        maxOccFoldName = tempArray[tempArray.Count() - 1];
                    }

                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Analysed : " + ++analysed + "/" + arrayFolders.Count());
                    tempFoldOcc = 0;
                }

                word = word.Replace("Ã©", "é");
                word = word.Replace("Ã¨", "è");
                word = word.Replace("Ã", "à");
                Console.WriteLine("\n\n\nResults for the word \"" +
                    word +
                    "\" :\n\n" +
                    //Page
                    "Page with the most occurences is \"" +
                    maxOccFileName +
                    "\" on the website \"" +
                    maxOccFileFold +
                    "\" with a total of " +
                    maxOccFileNbr +
                    " occurences.\n\n" +
                    //Website
                    "And the entire website with the most occurences is \"" +
                    maxOccFoldName +
                    "\" with a total of " +
                    maxOccFoldNbr +
                    " occurences.\n");
                
                maxOccFileNbr = 0;
                maxOccFoldNbr = 0;
            }
        }
    }
}
