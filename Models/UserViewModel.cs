using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTask.Models
{
    public class UserViewModel
    {
        public string first { get; set; }
        public string last { get; set; }
        public string gender { get; set; }
        public DateTime date { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string thumbnail { get; set; }
    }
}
