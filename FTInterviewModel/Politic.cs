using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    public class Politic
    {
        int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        string _politicname;
        public string PoliticName
        {
            get { return _politicname; }
            set { _politicname = value; }
        }
    }
}
