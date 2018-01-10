using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Xiangdianbiaozhun
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _xdid;
        public int PjxdID
        {
            get { return _xdid; }
            set { _xdid = value; }
        }

        int _bzid;
        public int PjbzID
        {
            get { return _bzid; }
            set { _bzid = value; }
        }

        string _content;
        public string MyContent
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
