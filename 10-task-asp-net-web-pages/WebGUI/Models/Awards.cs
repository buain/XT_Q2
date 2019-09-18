using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGUI.Models
{
    public class Awards
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageAddr { get; set; }
        public Awards()
        {

        }
    }
}