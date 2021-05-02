using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class User : DataCollectionObject
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Usercode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public List<UserRight> UserRights { get; set; }
        public List<Role> Roles { get; set; }
        public bool Enabled { get; set; }
    }
}
