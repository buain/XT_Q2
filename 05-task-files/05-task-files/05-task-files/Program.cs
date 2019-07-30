using System;
using System.IO;
using System.Text;

namespace _05_task_files
{
    class Program
    {
        public static int Select_Mode(string line_m) // Select file handling
        {
            int mode;
            //переделать на try again
            if (Int32.TryParse(line_m, out mode))
            {
                if (mode == 1)
                {
                    Console.WriteLine("Watching method");
                    // Watching method
                }
                else if (mode == 2)
                {
                    Console.WriteLine("Rollback method");
                    // Rollback method
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            return mode;
        }
        public static string Select_Drive(string line_d) //Select disk Drive for repository
        {
            //переделать на try again

            if (line_d == "c" || line_d == "C")
            {
                return "C";
            }
            if (line_d == "d" || line_d == "D")
            {
                return "D";
            }
            else
            {
                return "Wrong drive";
                
            }
        }
        public static void Create_Directory()
        {
            string path = @"D:\";
            string subpath = @"program\avalon";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }

        static void Main(string[] args)
        {
            //Info about disks on users PC:
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Name: {0}", drive.Name);
                Console.WriteLine("DriveType: {0}", drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine("TotalSize: {0}", drive.TotalSize);
                    Console.WriteLine("TotalFreeSpace: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("VolumeLabel: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Select Disk drive. Preferably C or D ");
            string select_disk = Select_Drive(Console.ReadLine());
            Console.WriteLine($"You select drive: {select_disk}");

            Console.WriteLine("Select file handling: 1-watching, 2-rollback");      
            int select_mode = Select_Mode(Console.ReadLine());
           

            Console.ReadKey(); //Delay
        }
    }
}
