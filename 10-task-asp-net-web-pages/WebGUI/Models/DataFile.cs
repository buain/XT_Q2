using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebGUI.Models
{
    public class DataFile
    {
        public static string FileName { get; private set; }
        public static void SaveFile(HttpPostedFileBase file, string path)
        {
            file.SaveAs(path);
            FileName = file.FileName;
        }
        public static void SaveFile(HttpPostedFileBase file)
        {
            file.SaveAs("D:\\EpamTask");
            FileName = file.FileName;
        }
        public static byte[] GetFile(string path)
        {
            return File.ReadAllBytes(path);
        }
        public static byte[] GetFile()
        {
            return File.ReadAllBytes(FileName);
        }
    }
}