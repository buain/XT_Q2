using System;
using System.IO;
using System.Text;

namespace _05_task_files
{
    class Repository
    {
        public static void Create_Repository(string disk)
        {
            string path = disk + @":\Repo";
            string rollback = @"RollBack";
            string now = @"Now";
            string log = @"Log";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(rollback);
            dirInfo.CreateSubdirectory(now);
            dirInfo.CreateSubdirectory(log);
        }
    }
}
