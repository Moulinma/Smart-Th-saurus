using System;
using System.Linq;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Class that ask for the word that the user wants to search and calls the other methodes
    /// </summary>
    class Seeker : GlobalSeekers
    {
        //Variables
        int analysed = 0;
        string[] tempArray;

        //Objects
        FolderSeeker folder = FolderSeeker.GetFolder();
        FileSeeker file = FileSeeker.GetFile();

        /// <summary>
        /// Basic methode of the class which start the search and call each method needed before showing the result
        /// </summary>
        public void Start()
        {
            //Ask the word of the user
            analysed = 0;
            Console.Clear();
            Console.WriteLine("Which word do you want to research?");
            word = Console.ReadLine();
            //Verify if the word is real
            if(word != "")
            {
                //Change the word to make it seekable
                word = word.ToLower();
                word = word.Replace("û", "ã»");
                word = word.Replace("ù", "ã¹");
                word = word.Replace("î", "ã®");
                word = word.Replace("é", "ã©");
                word = word.Replace("è", "ã¨");
                word = word.Replace("ê", "ãª");
                word = word.Replace("ç", "ã§");
                word = word.Replace("à", "ã");

                //Verify that folders exists and return them
                if (folder.SearchFolders())
                {
                    //Analyse all folders and call the word searching
                    foreach (string folder in arrayFolders)
                    {
                        file.SeekOccurence(folder);
                        //If the current number of occurence of the directory is more than the current max, change the globals variables
                        if (tempFoldOcc > maxOccFoldNbr)
                        {
                            maxOccFoldNbr = tempFoldOcc;
                            tempArray = folder.Split('\\');
                            maxOccFoldName = tempArray[tempArray.Count() - 1];
                        }

                        //Show the current progression of the program
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("Analysed : " + ++analysed + "/" + arrayFolders.Count());
                        tempFoldOcc = 0;
                    }

                    //Replace the word to put it back in the form of the user
                    word = word.Replace("ã»", "û");
                    word = word.Replace("ã¹", "ù");
                    word = word.Replace("ã®", "î");
                    word = word.Replace("ã©", "é");
                    word = word.Replace("ã¨", "è");
                    word = word.Replace("ãª", "ê");
                    word = word.Replace("ã§", "ç");
                    word = word.Replace("ã", "à");

                    //Show results if they aren't null
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
