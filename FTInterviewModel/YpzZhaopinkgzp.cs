using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    [Serializable]
    public class YpzZhaopinkgzp
    {
        int _id;
        public int ID
        {
            get { return _id;}
            set { _id = value; }
        }

        int _yingpinzhezhaopinid;
        public int YpzzpID
        {
            get { return _yingpinzhezhaopinid; }
            set { _yingpinzhezhaopinid = value; }
        }

        int _kaoguanzhaopinid;
        public int KgzpID
        {
            get { return _kaoguanzhaopinid; }
            set { _kaoguanzhaopinid = value; }
        }

        int _kgypzsubmitstate;
        public int KgYpzSubmitState
        {
            get { return _kgypzsubmitstate; }
            set { _kgypzsubmitstate = value; }
        }
		
    }
}
