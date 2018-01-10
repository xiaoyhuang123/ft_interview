using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    [Serializable]
    public class ZhaopinItem
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

        string _pubtime;
        public string PubTime
        {
            get { return _pubtime; }
            set { _pubtime = value; }
        }

        int _zpitemstate;
        public int ZpitemState
        {
            get { return _zpitemstate; }
            set { _zpitemstate = value; }
        }

        string _identifg;
        public string Identifg
        {
            get { return _identifg; }
            set { _identifg = value; }
        }
    }
}
