using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    public class Department
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        int _state;
        public int Bmstate
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
