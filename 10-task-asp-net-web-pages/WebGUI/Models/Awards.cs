using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users.Entities;

namespace WebGUI.Models
{
    public class Awards
    {
        public static string ImageDirectory = AwardImage.AwardImageDirectory;
        public static string DefaultImage = AwardImage.DefaultAwardImage;
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageAddr { get; set; }
        public Awards()
        {

        }
        public Awards(string title)
        {
            Title = title;
            ImageAddr = Path.Combine(ImageDirectory,DefaultImage);
        }

        public Awards(Guid id, string title)
        {
            Id = id;
            Title = title;
            ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
        }
    }
}