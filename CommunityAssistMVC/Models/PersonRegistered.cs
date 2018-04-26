using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC.Models
{
    public class PersonRegistered
    {
        public String lastName { set; get; }
        public String firstName { set; get; }
        public String email { set; get; }
        public String password { set; get; }
        public String apartmentNumber { set; get; }
        public String street { set; get; }
        public String city { set; get; }
        public String state { set; get; }
        public String zipcode { set; get; }
        public String phone { set; get; }

    }
}