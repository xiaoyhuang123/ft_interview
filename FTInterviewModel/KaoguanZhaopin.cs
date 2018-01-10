using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
     [Serializable]
    public class KaoguanZhaopin
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _kaoguanid;
        public int KaoguanID
        {
            get { return _kaoguanid; }
            set { _kaoguanid = value; }
        }

        int _zhaopinid;
        public int ZhaopinID
        {
            get { return _zhaopinid; }
            set { _zhaopinid = value; }
        }

        int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }


         //extra
        string _kgName;
        public string KgName
        {
            get { return _kgName; }
            set { _kgName = value; }
        }

        string _kgDepName;
        public string KgDepName
        {
            get { return _kgDepName; }
            set { _kgDepName = value; }
        }

        string _kgPosName;
        public string KgPosName
        {
            get { return _kgPosName; }
            set { _kgPosName = value; }
        }

    }
}
