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
                    Console.WriteLine("Wrong input! Try again");
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
                return "Wrong drive. Try again";
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
            //Select mode for work:
            Console.WriteLine("Select file handling: 1-watching, 2-rollback");
            int select_mode = Select_Mode(Console.ReadLine());

            //Info about disks on PC:
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
            //Select drive for work:
            Console.WriteLine("Select Disk drive. Preferably C or D ");
            string select_disk = Select_Drive(Console.ReadLine());
            Console.WriteLine($"You select drive: {select_disk}");

            Repository.Create_Repository(select_disk);

            switch (select_mode)
            {
                case 1: //Watch
                    Console.WriteLine("Input file name: ");
                    string file_name = Console.ReadLine();
                    Console.WriteLine("Input text:");
                    string text = Console.ReadLine();
                    Watch.Create_File(select_disk, text, file_name);
                    break;
                case 2: //RollBack
                    RollBack.DisplayBackUps(select_disk);
                    Console.WriteLine("Choose file and input date and time, like in arhives (dd.MM.yyyy-HH.mm.ss), to rollback file:");
                    string rollback_datetime = Console.ReadLine();
                    RollBack.FindFile(select_disk, rollback_datetime);
                    //RollBack.CopyToNow(select_disk, rollback_datetime);
                    break;
            }
                



            
            

            

            Console.ReadKey(); //Delay
        }
    }
}
