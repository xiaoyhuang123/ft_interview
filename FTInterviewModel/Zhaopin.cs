using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    [Serializable]
    public class Zhaopin
    {

        int _id;
        public int Id
        {
            get{return _id;}
            set {_id = value;}
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        string _interviewtime;
        public string InterviewTime
        {
            get { return _interviewtime; }
            set { _interviewtime = value; }
        }

        int _zhaopingwfb;
        public int ZpfbId
        {
            get { return _zhaopingwfb; }
            set { _zhaopingwfb = value; }
        }

        int _ktid;
        public int KaotiID
        {
            get { return _ktid; }
            set { _ktid = value; }
        }

        int _hegeline;
        public int HegeLine
        {
            get { return _hegeline; }
            set { _hegeline = value; }
        }
		
		 int _state;
        public int ZpState
        {
            get { return _state; }
            set { _state = value; }
        }
		
        /************************************************************************/
        /* 用于显示                                                            */
        /************************************************************************/
        string _bmname;
        public string ZpbmName
        {
            get { return _bmname; }
            set { _bmname = value; }
        }
        string _gwname;
        public string ZpgwName
        {
            get { return _gwname; }
            set { _gwname = value; }
        }
        int _peoplesums;
        public int ZpSums
        {
            get { return _peoplesums; }
            set { _peoplesums = value; }
        }

    }
}
