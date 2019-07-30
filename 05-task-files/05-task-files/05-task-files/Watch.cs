using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class Watch
    {
        string text = "blablabla";
        public void Create_File()
        {
            using (FileStream fstream = new FileStream(@"D:\Repo\Now\note.txt", FileMode.OpenOrCreate))
            {
                // string to bytes
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Text wrote to file");
            }
        }
        
        
    }
}
