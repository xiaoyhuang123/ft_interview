using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FTInterviewModel
{
    /************************************************************************/
    /************************************************************************/
    [Serializable]
    public class Kaoguan
    {
        int _id;
        public int Id
        {
            get{return _id; }
            set{ _id = value;}
        }

        string _workid;
        public string WorkID
        {
            get { return _workid; }
            set { _workid = value; }
        }

        string _name;
        public string Name
        {
            get{ return _name;  }
            set { _name = value;}
        }

        int _department;
        public int DepID
        {
            get { return _department; }
            set { _department = value; }
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

        string _password;
        public string Pwd
        {
            get { return _password; }
            set { _password = value; }
        }

        int _state;
        public int KGstate
        {
            get { return _state; }
            set { _state = value; }
        }
        /************************************************************************/
        /*                                                                      */
        /************************************************************************/
        string _depname;
        public string DepName
        {
            get { return _depname; }
            set { _depname = value; }
        }
    }
}
