using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class Watch
    {

        public static void Create_File(string disk, string text)
        {
            //File:
            //string file = "note.txt";
            using (FileStream fstream = new FileStream(disk + @":\Repo\Now\note.txt", FileMode.OpenOrCreate))
            {
                // string to bytes
                byte[] array = Encoding.Default.GetBytes(text);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($@"Text wrote to file: {disk}:\Repo\Now\note.txt");
            }
            DateTime dt = DateTime.Now;
            //Log File:
            using (FileStream fstream = new FileStream(disk + @":\Repo\Log\note_(" + dt.ToString("dd.mm.yyyy-hh.mm.ss") + @").txt", FileMode.OpenOrCreate))
            {
                // string to bytes
                byte[] array = Encoding.Default.GetBytes(text);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
            }
        }
        
        
    }
}
