using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class ZhaopinFb
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _zpgwid;
        public int ZpGwID
        {
            get { return _zpgwid; }
            set { _zpgwid = value; }
        }
		
		  int _nums;
        public int ZpSums
        {
            get { return _nums; }
            set { _nums = value; }
        }

        string _fbtime;
        public string ZpFbTime
        {
            get { return _fbtime; }
            set { _fbtime = value; }
        }

        int _fbstate;
        public int FbState
        {
            get { return _fbstate; }
            set { _fbstate = value; }
        }

        int _zpitmid;
        public int ZpitmId
        {
            get { return _zpitmid; }
            set { _zpitmid = value; }
        }

        /************************************************************************/
        /*                                                                      */
        /************************************************************************/
       
        string _zpbmname;
        public string ZpBmName
        {
            get { return _zpbmname; }
            set { _zpbmname = value; }
        }

        int _zpbmid;
        public int FbBmId
        {
            get { return _zpbmid; }
            set { _zpbmid = value; }
        }

        string _zppos;
        public string ZpPosName
        {
            get { return _zppos; }
            set { _zppos = value; }
        }


        string _zpitmtitle;
        public string ZpItmTitle
        {
            get { return _zpitmtitle; }
            set { _zpitmtitle = value; }
        }
        string _zpitmpubtime;
        public string ZpItmPubTime
        {
            get { return _zpitmpubtime; }
            set { _zpitmpubtime = value; }
        }
    }
}
