using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    [Serializable]
    public class YingpinzheZhaopin
    {
        int _id;
        public int ID
        {
            get { return _id;}
            set { _id = value; }
        }

        int _yingpinzheid;
        public int YpzID
        {
            get { return _yingpinzheid; }
            set { _yingpinzheid = value; }
        }

        int _zhaopinid;
        public int ZhaopinId
        {
            get { return _zhaopinid; }
            set { _zhaopinid = value; }
        }
		
		 int _index;
        public int MsIndex
        {
            get { return _index; }
            set { _index = value; }
        }

        int _submitstate;
        public int SubmitState
        {
            get { return _submitstate; }
            set { _submitstate = value; }
        }


        //extra
        string _ypzName;
        public string YpzName
        {
            get { return _ypzName; }
            set { _ypzName = value; }
        }

        string _ypzDepName;
        public string YpzDepName
        {
            get { return _ypzDepName; }
            set { _ypzDepName = value; }
        }

        string _ypzPosName;
        public string YpzPosName
        {
            get { return _ypzPosName; }
            set { _ypzPosName = value; }
        }

        string _ypzYpDepName;
        public string YpzYpDepName
        {
            get { return _ypzYpDepName; }
            set { _ypzYpDepName = value; }
        }
        string _ypzYpPosName;
        public string YpzYpPosName
        {
            get { return _ypzYpPosName; }
            set { _ypzYpPosName = value; }
        }

        int _index_temp;
        public int Index_temp
        {
            get { return _index_temp; }
            set { _index_temp = value; }
        }

    }
}
