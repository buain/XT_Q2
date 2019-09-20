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
        public static IEnumerable<Awards> GetAllAwards()
        {
            var list = BL.usersmanager.GetAllAwards();
            foreach(var item in list)
            {
                Awards award = new Awards(item.Id, item.Title);
                if (BL.usersmanager.GetAwardImage(award.Id))
                {
                    award.ImageAddr = Path.Combine(ImageDirectory, award.Id.ToString());
                }
                else
                {
                    award.ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
                }
                yield return award;
            }
        }
        public static Awards GetAward(Guid id)
        {
            var item = BL.usersmanager.GetAwardId(id);
            Awards award = new Awards(item.Id, item.Title);
            if (BL.usersmanager.GetAwardImage(award.Id))
            {
                award.ImageAddr = Path.Combine(ImageDirectory, award.Id.ToString());
            }
            else
            {
                award.ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
            }
            return award;
        }
        public static void CreateAward(Award model)
        {
            BL.usersmanager.AddAward(model.Title);
        }
        public static bool CheckAwardTitle(string title)
        {
            var list = BL.usersmanager.GetAllAwards();
            foreach (var aw in list)
            {
                if (aw.Title == title)
                {
                    return false;
                }
            }
            return true;
        }
        public void SetImage()
        {
            BL.usersmanager.SetAwardImage(Id);
            ImageAddr = Path.Combine(ImageDirectory, Id.ToString());
        }
        public void RemoveImage()
        {
            BL.usersmanager.RemoveAwardImage(Id);
            ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
        }
    }
}