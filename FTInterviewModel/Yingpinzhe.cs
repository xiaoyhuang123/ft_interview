using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    [Serializable]
    public class Yingpinzhe
    {
        int _id;
        public int ID
        {
            get { return _id;}
            set { _id = value; }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _sex;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        string _birthday;
        public string Birthday
        {
            get { return _birthday;}
            set { _birthday = value;}
        }

        string _jointime;
        public string JoinTime
        {
            get { return _jointime; }
            set { _jointime = value; }
        }

        int _xueli;
        public int XueliId
        {
            get { return _xueli; }
            set { _xueli = value; }
        }

        int _politic;
        public int PoliticId
        {
            get { return _politic; }
            set { _politic = value; }
        }

        int _depart;
        public int DepartId
        {
            get { return _depart; }
            set { _depart = value; }
        }

        string _position;
        public string PositionName
        {
            get { return _position; }
            set { _position = value; }
        }

        string _company;
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        int _state;
        public int Ypzstate
        {
            get { return _state; }
            set { _state = value; }
        }

        int _zpfbid;
        public int ZpfbId
        {
            get { return _zpfbid; }
            set { _zpfbid = value; }
        }

        /************************************************************************/
        /*                                                                      */
        /************************************************************************/
        string _xueliname;
        public string XueliName
        {
            get { return _xueliname; }
            set { _xueliname = value; }
        }
        string _depname;
        public string DepName
        {
            get { return _depname; }
            set { _depname = value; }
        }
        string _ypdepname;
        public string YpDepName
        {
            get { return _ypdepname; }
            set { _ypdepname = value; }
        }
        string _ypposname;
        public string YpPosName
        {
            get { return _ypposname; }
            set { _ypposname = value; }
        }
        string _polname;
        public string PolName
        {
            get { return _polname; }
            set { _polname = value; }
        }


        //
        double _weight;
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        //
        int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
