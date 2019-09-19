using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users.Entities;

namespace WebGUI.Models
{
    public class Users
    {
        public static string DefaultImage = UserImage.DefaultUserImage;
        public static string ImageDirectory = UserImage.UserImageDirectory;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public string ImageAddr { get; set; }

        public List<Guid> awardList = new List<Guid>();
        public List<Awards> awardNotHasList = new List<Awards>();
        public Users()
        {

        }
        public Users(string name, DateTime birthday)
        {
            Name = name;
            BirthDay = birthday;
            ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
        }
        public Users(Guid id, string name, DateTime birthday, int age)
        {
            Id = id;
            Name = name;
            BirthDay = birthday;
            Age = age;
            ImageAddr = Path.Combine(Users.ImageDirectory, Users.DefaultImage);
        }
        public Users(Guid id, string name, DateTime birthday, int age, IEnumerable<Guid> inputList) :
            this(id, name, birthday, age)
        {
            Id = id;
            Name = name;
            BirthDay = birthday;
            awardList = inputList.ToList();
            Age = age;
            ImageAddr = Path.Combine(Users.ImageDirectory, Users.DefaultImage);
        }

        public static IEnumerable<Users> GetAllUsers()
        {
            var list = BL.usersmanager.GetAllUsers();
            foreach (var item in list)
            {
                Users user = new Users(item.Id, item.Name, item.BirthDay, item.Age, item.GetAwardList());
                if (BL.usersmanager.GetUserImage(user.Id))
                {
                    user.ImageAddr = Path.Combine(ImageDirectory, user.Id.ToString());
                }
                else
                {
                    user.ImageAddr = VirtualPathUtility.Combine(ImageDirectory, DefaultImage);
                }
                yield return user;
            }
        }
        public static Users GetUser(Guid Id)
        {
            var item = BL.usersmanager.GetUserId(Id);
            Users user = new Users(item.Id, item.Name, item.BirthDay, item.Age, item.GetAwardList());
            if (BL.usersmanager.GetUserImage(user.Id))
            {
                user.ImageAddr = Path.Combine(ImageDirectory, user.Id.ToString());
            }
            else
            {
                user.ImageAddr = Path.Combine(ImageDirectory, DefaultImage);
            }
            user.GetUserNotHasAwards(user.Id);
            return user;
        }
        public void GetUserNotHasAwards(Guid id)
        {
            this.awardNotHasList.Clear();
            User nu = BL.usersmanager.GetUserId(id);
            List<Award> list = BL.usersmanager.GetUserAwards(nu).ToList();
            List<Award> all = BL.usersmanager.GetAllAwards().ToList();

            if (list.Count() == 0)
            {
                foreach (var item in all)
                {
                    Awards award = new Awards(item.Id, item.Title);
                    if (BL.usersmanager.GetAwardImage(award.Id))
                    {
                        award.ImageAddr = Path.Combine(Awards.ImageDirectory, award.Id.ToString());
                    }
                    else
                    {
                        award.ImageAddr = Path.Combine(Awards.ImageDirectory, Awards.DefaultImage);
                    }
                    this.awardNotHasList.Add(award);
                }
            }
            else
            {
                foreach (var item in all)
                {
                    bool contains = false;
                    foreach (var other in list)
                    {
                        if ((item.Id == other.Id))
                        {
                            contains = true;
                        }
                    }

                    if (!contains)
                    {
                        Awards award = new Awards(item.Id, item.Title);
                        if (BL.usersmanager.GetAwardImage(award.Id))
                        {
                            award.ImageAddr = Path.Combine(Awards.ImageDirectory, award.Id.ToString());
                        }
                        else
                        {
                            award.ImageAddr = Path.Combine(Awards.ImageDirectory, Awards.DefaultImage);
                        }
                        this.awardNotHasList.Add(award);
                    }
                }
            }
        }
        public static void CreateUser(Users model)
        {
            BL.usersmanager.AddUser(model.Name, model.BirthDay);
        }
        public static void DeleteUser(Guid id)
        {
            User nu = BL.usersmanager.GetUserId(id);
            BL.usersmanager.DeleteUser(nu);
        }
        public static bool AddAwardToUser(Guid UserId, Guid AwardId)
        {
            User nu = BL.usersmanager.GetUserId(UserId);
            return BL.usersmanager.AddAwardToUser(UserId, AwardId);
        }
        public static IEnumerable<Awards> GetUserAwards(Guid id)
        {
            User nu = BL.usersmanager.GetUserId(id);
            var list = BL.usersmanager.GetUserAwards(nu);
            foreach (var item in list)
            {
                Awards award = new Awards(item.Id, item.Title);
                if (BL.usersmanager.GetAwardImage(award.Id))
                {
                    award.ImageAddr = Path.Combine(Awards.ImageDirectory, award.Id.ToString());
                }
                else
                {
                    award.ImageAddr = Path.Combine(Awards.ImageDirectory, Awards.DefaultImage);
                }
                yield return award;

            }
        }
    }
}