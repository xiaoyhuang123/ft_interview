using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class PingjiaxiangdianManage
    {
        public static int Add(Pingjiaxiangdian pjxd)
        {
            return FTInterviewDAL.PingjiaxiangdianService.Add(pjxd);
        }

        public static List<Pingjiaxiangdian> GetAll()
        {
            return FTInterviewDAL.PingjiaxiangdianService.GetAll();
        }

        public static Pingjiaxiangdian GetPXXDbyId(int xdid)
        {
            return FTInterviewDAL.PingjiaxiangdianService.GetPXXDbyId(xdid);
        }

        public static int Update(Pingjiaxiangdian pjxd)
        {
            return FTInterviewDAL.PingjiaxiangdianService.Update(pjxd);
        }

        public static int UpdateScore(int id,int score)
        {
            return FTInterviewDAL.PingjiaxiangdianService.UpdateScore(id,score);
        }


        public static int DeleteByID(int _id)
        {
            return FTInterviewDAL.PingjiaxiangdianService.DeleteByID(_id);
        }

        public static int GetPingjiaxiangdianScoreSum()
        {
            return FTInterviewDAL.PingjiaxiangdianService.GetPingjiaxiangdianScoreSum();
        }

    }
}
