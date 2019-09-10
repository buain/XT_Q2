using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _05_task_files
{
    class AddFile
    {
        public static void Create_File(string path, string text)
        {
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                //string to bytes
                byte[] array = Encoding.Default.GetBytes(text + Environment.NewLine);
                //write array of bytes into file
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($"Text is written to file: \"{path}\"");
            }
        }
        public static string Read_File(string path)
        {
            //Read from new file
            using (FileStream fstream = File.OpenRead(path))
            {
                //string to bytes
                byte[] array = new byte[fstream.Length];
                //read data
                fstream.Read(array, 0, array.Length);
                //decode bytes to a string
                string textFromFile = Encoding.Default.GetString(array);
                return textFromFile;
            }
        }
        public static void Create_Log(string log_path, string textFromFile)
        {
            DateTime dt = DateTime.Now;
            string path = log_path + dt.ToString("_dd.MM.yyyy-HH.mm.ss") + ".txt";
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                byte[] array = Encoding.Default.GetBytes(textFromFile);
                fstream.Write(array, 0, array.Length);
            }
        }
        public static void Clear_File(string path)
        {
            string text = null;
            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                byte[] array = Encoding.Default.GetBytes(text + Environment.NewLine);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($"File: \"{path}\" is cleared");
            }
        }
    }
}
