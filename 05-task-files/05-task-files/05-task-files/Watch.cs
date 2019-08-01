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
            using (FileStream fstream = new FileStream(disk + @":\Repo\Now\" + file + ".txt", FileMode.Append))
            {
                // string to bytes
                byte[] array = Encoding.Default.GetBytes(text + Environment.NewLine);
                // write array of bytes into file
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($@"Text is written to file: {disk}:\Repo\Now\{file}.txt");
            }
        }
        public static string Read_File(string disk, string file)
        {
            //Read from new file
            using (FileStream fstream = File.OpenRead(disk + @":\Repo\Now\" + file + ".txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(array);
                return textFromFile;
            }
        }
        public static void Create_Log(string disk, string textFromFile, string file)
        {
            //Log File:
            DateTime dt = DateTime.Now;
            using (FileStream fstream = new FileStream(disk + @":\Repo\Log\" + file + dt.ToString("_dd.MM.yyyy-HH.mm.ss") + ".txt", FileMode.Append))
            {
                byte[] array = Encoding.Default.GetBytes(textFromFile);
                fstream.Write(array, 0, array.Length);
            }
        }    
  
    }
}
