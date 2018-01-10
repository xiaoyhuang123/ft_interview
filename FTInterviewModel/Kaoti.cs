using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{

    [Serializable]
    public class Kaoti
    {

        int _id;
        public int Id
        {
            get{ return _id;}
            set{_id = value;}
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        int _zhaopingangweiid;
        public int ZpgwId
        {
            get { return _zhaopingangweiid; }
            set { _zhaopingangweiid = value; }
        }
        int _ktstate;
        public int KtState
        {
            get { return _ktstate; }
            set { _ktstate = value; }
        }

        string _createtime;
        public string CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /************************************************************************/
        /*                                                                      */
        /************************************************************************/
        string _bmname;
        public string ZpBmName
        {
            get { return _bmname; }
            set { _bmname = value; }
        }
        string _gmname;
        public string ZpGmName
        {
            get { return _gmname; }
            set { _gmname = value; }
        }
    }
}
