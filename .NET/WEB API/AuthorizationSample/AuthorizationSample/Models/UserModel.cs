using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationSample.Models
{
    public class UserModel
    {
        public string username { get; set; }

        public string password { get; set; }
        public string role { get; set; }
    }
}