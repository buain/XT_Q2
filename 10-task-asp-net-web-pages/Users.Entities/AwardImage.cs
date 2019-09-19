using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Users.Entities
{
    public class AwardImage
    {
        private string image;
        private static string defaultAwardImage = "default.jpg";
        private static string awardImageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "AwardImages");
        public string Image { get; set; }
        public AwardImage()
        {

        }
        public Guid AwardId { get; set; }
        public AwardImage(Guid id, string address)
        {
            AwardId = id;
            Image = address;
        }
        public static string DefaultAwardImage
        {
            get
            {
                return DefaultAwardImage;
            }
            private set
            {
                defaultAwardImage = value;
            }
        }

        public static string AwardImageDirectory
        {
            get
            {
                return AwardImageDirectory;
            }
            private set
            {
                awardImageDirectory = value;
            }
        }
    }
}
