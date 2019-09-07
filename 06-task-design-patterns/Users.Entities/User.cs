using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class User
    {
        // There is characters of User (Id, Name, BirthDay, Age)
        
        public Guid Id { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value != null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Wrong! Your name is empty.");
                }
            }
        }
        private DateTime birthday;
        public DateTime BirthDay
        {
            get
            {
                return this.birthday;
            }
            set
            {
                if(DateTime.Now < value)
                {
                    throw new ArgumentException("Wrong input BirthDay! You have not yet been born.");
                }
                else if(DateTime.Now.Year - value.Year > 150)
                {
                    throw new ArgumentException("Wrong input BirthDay! You are very very old.");
                }
                else
                {
                    this.birthday = value;
                }
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = DateTime.Today.Year - birthday.Year;
            }
        }
        public User(string name, DateTime birthday)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.BirthDay = birthday;
        }
        public User(string name, DateTime birthday, IEnumerable<Guid> _list):
            this(name, birthday)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.BirthDay = birthday;
            this.Age = age;
        }
    }
}
