using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    class Award
    {
        public Guid Id { get; set; }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != null)
                {
                    this.title = value;
                }
                else
                {
                    throw new ArgumentException("Wrong! Title is empty.");
                }
            }
        }
        public Award()
        {

        }
        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
