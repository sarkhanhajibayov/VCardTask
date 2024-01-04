using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCardTask.Models
{
    public class User
    {
        public NameData Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public LocationData Location { get; set; }
    }
    public class NameData
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
    public class LocationData
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
