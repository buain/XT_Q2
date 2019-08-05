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
                if (int.TryParse(line_m, out mode))
                {
                    if (mode == 1)
                    {
                        Console.WriteLine("Add text to file mode.");
                        return 1;
                    }
                    else if (mode == 2)
                    {
                        Console.WriteLine("Display text mode.");
                        return 2;
                    }
                    else if (mode == 3)
                    {
                        Console.WriteLine("Delete file mode.");
                        return 3;
                    }
                    else if (mode == 4)
                    {
                        Console.WriteLine("Clear file mode.");
                        return 4;
                    }
                    else if (mode == 5)
                    {
                        Console.WriteLine("Rollback old file.");
                        return 5;
                    }
                    else if (mode == 6)
                    {
                        Console.WriteLine("Exit. Press any key...");
                        return 6;
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

            Console.WriteLine("Input file name: ");
            string file_name = Console.ReadLine();
            string work_path = select_disk + @":\Repo\Now\";
            string file_path = select_disk + @":\Repo\Now\" + file_name + ".txt";
            string log_path = select_disk + @":\Repo\Log\";
            //Select mode for work:
            Console.WriteLine("What do you want to do with file?: " +
                              "\n1-Add text to file, " +
                              "\n2-Display text, " +
                              "\n3-Delete file, " +
                              "\n4-Clear file, " +
                              "\n5-Rollback old file, " +
                              "\n6-Exit");
            Console.WriteLine("If you first time here. Please, select 1.");
            int select_mode = Select_Mode();

            switch (select_mode)
            {
                case 1: //Add text to file
                    Repository.Create_Repository(select_disk);
                    Console.WriteLine("Your working path: \"work_path\"");
                    Console.WriteLine("Input text:");
                    string text = Console.ReadLine();

                    AddFile.Create_File(file_path, text);
                    string old_text = AddFile.Read_File(file_path);
                    AddFile.Create_Log(log_path, old_text);            
                    break;
                case 2: //Display text
                    if(File.Exists(file_path))
                    {
                        Display_text.PrintText(file_path);
                    }
                    else
                    {
                        Console.WriteLine("Where are no files to display, you are redirected to \"1-Add text to file\"");
                        goto case 1;
                    }
                    break;
                case 3: //Delete file
                    if (File.Exists(file_path))
                    {
                        RollBack.DeleteFileNow(file_path);
                    }
                    else
                    {
                        Console.WriteLine("Where are no files to delete, you are redirected to \"1-Add text to file\"");
                        goto case 1;
                    }
                    break;
                case 4: //Clear file
                    if (File.Exists(file_path))
                    {
                        AddFile.Clear_File(file_path);
                    }
                    else
                    {
                        Console.WriteLine("Where are no files to clear, you are redirected to \"1-Add text to file\"");
                        goto case 1;
                    }
                    break;

                case 5: //Rollback old file
                    if (File.Exists(file_path))
                    {
                        RollBack.DisplayBackUps(log_path);

                        Console.WriteLine("Choose file and input date and time, like in arhives (dd.MM.yyyy-HH.mm.ss), to rollback file:");
                        string rollback_datetime = Console.ReadLine();
                        RollBack.FindFile(select_disk, rollback_datetime);
                    }
                    else
                    {
                        Console.WriteLine("Where are no arhives to rollback, you are redirected to \"1-Add text to file\"");
                        goto case 1;
                    }
                    break;
                case 6:
                    break;
            }
            Console.ReadKey(); //Delay
        }
    }
}
