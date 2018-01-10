using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    public class SystemManage
    {
        int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        string _tikupassword;
        public string TikuPwd
        {
            get { return _tikupassword; }
            set { _tikupassword = value; }
        }

        string _kaochangjilv;
        public string KaochangJilv
        {
            get { return _kaochangjilv; }
            set { _kaochangjilv = value; }
        }
    }
}
