using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Position
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _positionname;
        public string PositionName
        {
            get { return _positionname; }
            set { _positionname = value; }
        }
    }

}
