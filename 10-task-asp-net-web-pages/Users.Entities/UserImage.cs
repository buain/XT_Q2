using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Users.Entities
{
    public class UserImage
    {
        private string image;
        private static string defaultUserImage = "default.jpg";
        private static string userImageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"App_Data", "UserImages");

        public string Image { get; set; }
        public UserImage()
        {

        }
        public Guid UserId { get; set; }
        public UserImage(Guid id, string address)
        {
            UserId = id;
            Image = address;
        }
        public static string DefaultUserImage
        {
            get
            {
                return DefaultUserImage;
            }
            private set
            {
                defaultUserImage = value;
            }
        }

        public static string UserImageDirectory
        {
            get
            {
                return UserImageDirectory;
            }
            private set
            {
                userImageDirectory = value;
            }
        }
    }
}
