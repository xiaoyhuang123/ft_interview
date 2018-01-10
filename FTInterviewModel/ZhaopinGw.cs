using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class ZhaopinGw
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        int _zpbm;
        public int ZpDepart
        {
            get { return _zpbm; }
            set { _zpbm = value; }
        }

        string _zppos;
        public string ZpPosition
        {
            get { return _zppos; }
            set { _zppos = value; }
        }
		
// 		  int _nums;
//         public int ZpSums
//         {
//             get { return _nums; }
//             set { _nums = value; }
//         }


        /************************************************************************/
        /*                                                                      */
        /************************************************************************/
        string _zpbmname;
        public string ZpBmName
        {
            get { return _zpbmname; }
            set { _zpbmname = value; }
        }
    }
}
