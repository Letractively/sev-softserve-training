using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsOnline { get; set; }
        public string Region { get; set; }

    }
}