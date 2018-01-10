using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class PingfenManage
    {
        public static int Add ( Pingfen pf )
        {
            return FTInterviewDAL.PingfenService.Add ( pf );
        }
        public static int batchAdd(List<Pingfen> pinfenList)
        {
            return FTInterviewDAL.PingfenService.batchAdd(pinfenList);
        }

        public static int Update(Pingfen pf)
        {
            return FTInterviewDAL.PingfenService.Update(pf);
        }

        public static int batchUpdate(List<Pingfen> pinfenList)
        {
            return FTInterviewDAL.PingfenService.batchUpdate(pinfenList);
        }
         public static int DeleteByShitiid(int stid,bool realdelete=false)
        {
            return FTInterviewDAL.PingfenService.DeleteByShitiid(stid, realdelete);
        }

         public static int DeleteByXdid(int xdid, bool realdelete = false)
        {
            return FTInterviewDAL.PingfenService.DeleteByXdid(xdid, realdelete);
        }
         public static int DeleteByYpzzpid(int ypzzpid, bool realdelete = false)
         {
             return FTInterviewDAL.PingfenService.DeleteByYpzzpid(ypzzpid, realdelete);
         }
         public static int DeleteByKgzpid(int kgzpid, bool realdelete = false)
         {
             return FTInterviewDAL.PingfenService.DeleteByKgzpid(kgzpid, realdelete);
         }
        public static double GetScoreSums(int ypzzpid,int kgzpid=-1)
        {
            return FTInterviewDAL.PingfenService.GetScoreSums(ypzzpid, kgzpid);
        }

        public static int GetScoreSumSingleTi(int ypzzpid, int kgzpid = -1,int shitiid=-1)
        {
            return FTInterviewDAL.PingfenService.GetScoreSumSingleTi(ypzzpid, kgzpid,shitiid);
        }

        public static Pingfen GetPfByParameter(int kgzpid,int ypzzpid,int stid,int xdid)
        {
            return FTInterviewDAL.PingfenService.GetPfByParameter( kgzpid, ypzzpid, stid, xdid);
        }
    }
}
