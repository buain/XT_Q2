using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class Watch
    {
        public static void Create_File(string disk, string text, string file)
        {

            //File:   
            using (FileStream fstream = new FileStream(disk + @":\Repo\Now\" + file + ".txt", FileMode.Create))
            {
                // string to bytes
                byte[] array = Encoding.Default.GetBytes(text);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($@"Text is written to file: {disk}:\Repo\Now\{file}.txt");
            }
            DateTime dt = DateTime.Now;

            //Log File:
            using (FileStream fstream = new FileStream(disk + @":\Repo\Log\"+ file + dt.ToString("_dd.MM.yyyy-HH.mm.ss") + ".txt", FileMode.Create))
            {
                // string to bytes
                byte[] array = Encoding.Default.GetBytes(text);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
            }
        }
        
        
    }
}
