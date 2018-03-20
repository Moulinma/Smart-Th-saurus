using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Th_saurus
{
    class FolderSeeker : GlobalSeekers
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

        public bool SearchFolders()
        {
            try
            {
                arrayFolders = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (arrayFolders.Count() == 0)
                {
                    Console.WriteLine("You need to fill the database first!");
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
