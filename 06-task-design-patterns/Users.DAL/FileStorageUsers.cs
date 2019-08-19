using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.IO;

namespace Users.DAL
{
    public class FileStorageUsers : IStorable
    {
        private static List<User> Users { get; set; }
        string file_users = @"C:\Task6\users.txt";
        public void AddUser(Guid id, string name, DateTime birthday, int age) //Сделать запись в файл с помощью StreamWriter
        {
            //using (FileStream fstream = new FileStream(@"C:\Task6\users.txt", FileMode.Append))
            //{
            //    // string to bytes
            //    byte[] array = Encoding.Default.GetBytes(id, name, birthday, age + Environment.NewLine);
            //    // write array of bytes into file
            //    fstream.Write(array, 0, array.Length);
            //    Console.WriteLine($@"Text is written to file: C:\Task6\users.txt");
            //}
            using (StreamWriter w = new StreamWriter(@"C:\Task6\users.txt", true))
            {
                w.Write(id);
                w.Write(name);
                w.Write(birthday);
                w.Write(age);
            }
        }
        public void DeleteUser()
        {

        }
        public bool AddUser(User user)
        {
            if (Users.Any(n => n.Id == user.Id))
                return false;
            Users.Add(user);
            return true;
        }
        public ICollection<User> GetAllUsers()
        {
            return Users;
        }
    }
    
}
