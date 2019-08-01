using System;
using System.IO;
using System.Text;

namespace _05_task_files
{
    class Program
    {
        public static int Select_Mode() // Select file handling
        {
            while (true)
            {
                int mode;
                string line_m = Console.ReadLine();
                if (Int32.TryParse(line_m, out mode))
                {
                    if (mode == 1)
                    {
                        Console.WriteLine("Work with file mode.");
                        return 1;
                    }
                    else if (mode == 2)
                    {
                        Console.WriteLine("Restore file mode.");
                        return 2;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Try again");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again");
                }
            }
        }
        public static string Select_Drive() //Select disk Drive for repository
        {
            while (true)
            {
                string line_d = Console.ReadLine();

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
                    Console.WriteLine("Wrong drive.Try again");
                }
            }
        }
        public static void DiskInfo()
        {
            Console.WriteLine("Info about disks on PC:");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady && drive.TotalFreeSpace > 5242880)
                {
                    Console.WriteLine("Name: {0}", drive.Name);
                    //Console.WriteLine("DriveType: {0}", drive.DriveType);
                    Console.WriteLine("TotalSize: {0}", drive.TotalSize);
                    Console.WriteLine("TotalFreeSpace: {0}\n", drive.TotalFreeSpace);
                    //Console.WriteLine("VolumeLabel: {0}", drive.VolumeLabel);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to BackUp System!\n");
            DiskInfo();

            //Select drive for work:
            Console.WriteLine("Select Disk drive for work. Preferably C or D ");
            string select_disk = Select_Drive();
            Console.WriteLine($"You select drive: {select_disk}");

            //Select mode for work:
            Console.WriteLine("Select operating mode: 1-work with file, 2-restore file");
            Console.WriteLine("If you first time here. Please, select 1.");
            int select_mode = Select_Mode();

            switch (select_mode)
            {
                case 1: //Watch
                    Repository.Create_Repository(select_disk);

                    Console.WriteLine("Input file name: ");
                    string file_name = Console.ReadLine();

                    Console.WriteLine("Input text:");
                    string text = Console.ReadLine();

                    Watch.Create_File(select_disk, text, file_name);
                    string old_text = Watch.Read_File(select_disk, file_name);
                    Watch.Create_Log(select_disk, old_text, file_name);

                    Console.WriteLine("What do you want to do with file?: \n1-Add text to file, \n2-Show text, \n3-Delete file, \n4-CLear file, \n5-Restore old file");
                    break;
                case 2: //RollBack
                    if (Directory.Exists(select_disk + @":\Repo\Log\"))
                    {
                        RollBack.DisplayBackUps(select_disk);

                        Console.WriteLine("Choose file and input date and time, like in arhives (dd.MM.yyyy-HH.mm.ss), to restore file:");
                        string rollback_datetime = Console.ReadLine();
                        RollBack.FindFile(select_disk, rollback_datetime);
                    }
                    else
                    {
                        Console.WriteLine("Where are no arhives to restore, you are redirected to \"1-work with file\"");
                        goto case 1;
                    }
                    break;
            }
                



            
            

            

            Console.ReadKey(); //Delay
        }
    }
}
