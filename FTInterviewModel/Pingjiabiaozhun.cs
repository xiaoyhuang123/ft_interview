using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Pingjiabiaozhun
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        int _pjxdid;
        public int PjxdID
        {
            get { return _pjxdid; }
            set { _pjxdid = value; }
        }

        int _ckscore;
        public int CkScore
        {
            get { return _ckscore; }
            set { _ckscore = value; }
        }
    }
}
