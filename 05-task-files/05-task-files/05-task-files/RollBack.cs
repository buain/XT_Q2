using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class RollBack
    {
        public static void DisplayBackUps()
        {

        }
        public static void CopyToNow(string disk)
        {
            string path = @"C:\apache\hta.txt";
            string newPath = @"C:\SomeDir\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                // альтернатива с помощью класса File
                // File.Copy(path, newPath, true);
            }
        }
       
    }
}
