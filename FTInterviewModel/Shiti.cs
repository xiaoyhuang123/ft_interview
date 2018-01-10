using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Shiti
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _question;
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        int _kaotiid;
        public int KaotiID
        {
            get { return _kaotiid; }
            set { _kaotiid = value; }
        }

        int _kaotiindex;
        public int KaotiIndex
        {
            get { return _kaotiindex; }
            set { _kaotiindex = value; }
        }

        int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        int _sstime;
        public int StTime
        {
            get { return _sstime; }
            set { _sstime = value; }
        }
    }

}
