using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class RollBack
    {
        public static void DisplayBackUps(string log_path)
        {
            Console.WriteLine("\nArchive files:");
            string[] files = Directory.GetFiles(log_path);
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }
        public static void DeleteFileNow(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            Console.WriteLine($"File \"{path}\" deleted");
        }
        //Get file:
        public static void FindFile(string log_path, string rollback_datetime)
        {
            DirectoryInfo dir = new DirectoryInfo(log_path);
            FileInfo[] fileInDir = dir.GetFiles("*" + rollback_datetime + ".txt");
            foreach (FileInfo foundFile in fileInDir)
            {
                string fullName = foundFile.FullName;
                CopyToNow(fullName, rollback_datetime);
            }
        }
        //Copy arhive file to working directory
        public static void CopyToNow(string path, string rollback_datetime)
        {
            string filename = path.Replace("_" + rollback_datetime, "");
            string newPath = filename.Replace("Log", "Now");
            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine($"File: {fileInf.Name} rollback to working path");
            }
        }      
    }
}
