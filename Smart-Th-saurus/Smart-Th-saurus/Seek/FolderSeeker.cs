using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Smart_Th_saurus
{
    /// <summary>
    /// Seek every folder in the "database"
    /// </summary>
    class FolderSeeker : GlobalSeekers
    {
        //Objects
        private static FolderSeeker folder;

        /// <summary>
        /// Base constructor of the class
        /// </summary>
        /// <returns>Return the unique Folder object</returns>
        public static FolderSeeker GetFolder()
        {
            if(folder == null)
            {
                folder = new FolderSeeker();
            }
            return folder;
        }

        /// <summary>
        /// Search the directories in the database and return them
        /// </summary>
        /// <returns>Return an array of directories</returns>
        public bool SearchFolders()
        {
            try
            {
                //Seek directories and write an error if the database is empty
                arrayFolders = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (arrayFolders.Count() == 0)
                {
                    Console.WriteLine("\nYou need to fill the database first!");
                    return false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("The program can't access to folders because of the security access level!");
                return false;
            }
            return true;
        }
    }
}
