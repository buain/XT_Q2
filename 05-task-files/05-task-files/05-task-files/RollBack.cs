using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class RollBack
    {
        public static void DisplayBackUps(string disk)
        {
            if (Directory.Exists(disk + @":\Repo\Log\"))
            {
                Console.WriteLine();
                Console.WriteLine("Archive files:");
                string[] files = Directory.GetFiles(disk + @":\Repo\Log\");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void DeleteFileNow(string disk, string file_delete)
        {
            FileInfo fileInf = new FileInfo(disk + @":\Repo\Now\" + file_delete + ".txt");
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
        //Get file:
        public static void FindFile(string disk, string rollback_datetime)
        {
            DirectoryInfo dir = new DirectoryInfo(disk + @":\Repo\Log\");
            FileInfo[] fileInDir = dir.GetFiles("*" + rollback_datetime + "*.*");
            foreach (FileInfo foundFile in fileInDir)
            {
                string fullName = foundFile.FullName;
                CopyToNow(fullName, disk, rollback_datetime);
            }
        }
        //Copy arhive file to working directory
        public static void CopyToNow(string path, string disk, string rollback_datetime)
        {
            string filename = path.Replace("_" + rollback_datetime, "");
            string newPath = filename.Replace("Log", "Now");
            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine($"File: {fileInf.Name} restored to working path");
            }
        }      
    }
}
