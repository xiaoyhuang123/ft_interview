using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Pingfen
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _ypzid;
        public int YpzzpID
        {
            get { return _ypzid; }
            set { _ypzid = value; }
        }

        int _kgid;
        public int KgzpID
        {
            get { return _kgid; }
            set { _kgid = value; }
        }

        int _shitiid;
        public int ShitiID
        {
            get { return _shitiid; }
            set { _shitiid = value; }
        }

        int _xiangdianbiaozhunid;
        public int XdbzID
        {
            get { return _xiangdianbiaozhunid; }
            set { _xiangdianbiaozhunid = value; }
        }

        int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        int _state;
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
