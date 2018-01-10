using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTInterviewModel
{
    [Serializable]
    public class Pingjiaxiangdian
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
      
    }
}
