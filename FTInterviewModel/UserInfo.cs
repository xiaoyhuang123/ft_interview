using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    public class UserInfo
    {
        int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
