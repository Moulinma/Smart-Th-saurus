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
            if(word != "")
            {
                word = word.ToLower();
                word = word.Replace("û", "ã»");
                word = word.Replace("ù", "ã¹");
                word = word.Replace("î", "ã®");
                word = word.Replace("é", "ã©");
                word = word.Replace("è", "ã¨");
                word = word.Replace("ê", "ãª");
                word = word.Replace("ç", "ã§");
                word = word.Replace("à", "ã");

                if (folder.SearchFolders())
                {
                    foreach (string folder in arrayFolders)
                    {
                        file.SeekOccurence(folder);
                        if (tempFoldOcc > maxOccFoldNbr)
                        {
                            maxOccFoldNbr = tempFoldOcc;
                            tempArray = folder.Split('\\');
                            maxOccFoldName = tempArray[tempArray.Count() - 1];
                        }

                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("Analysed : " + ++analysed + "/" + arrayFolders.Count());
                        tempFoldOcc = 0;
                    }
                    word = word.Replace("ã»", "û");
                    word = word.Replace("ã¹", "ù");
                    word = word.Replace("ã®", "î");
                    word = word.Replace("ã©", "é");
                    word = word.Replace("ã¨", "è");
                    word = word.Replace("ãª", "ê");
                    word = word.Replace("ã§", "ç");
                    word = word.Replace("ã", "à");
                    if (maxOccFileNbr != 0)
                    {
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
                    else
                    {
                        Console.WriteLine("\n\n\nThe word \"" +
                            word +
                            "\" wasn't found in the database.");
                    }
                }
            }
        }
    }
}
