using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class YpzZhaopinkgzpManage
    {
        public static int Add(YpzZhaopinkgzp ypzzpkgzp)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.Add(ypzzpkgzp);
        }

        public static int Delete(int id)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.Delete(id);
        }

        public static YpzZhaopinkgzp GetByID(int id)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.GetByID(id);
        }

        public static YpzZhaopinkgzp GetByypzidkgid(int ypzzpid, int kgzpid)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.GetByypzidkgid(ypzzpid,kgzpid);
        }

        public static int GetByypzidkgidNoSubmit(int ypzzpid, int kgzpid)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.GetByypzidkgidNoSubmit(ypzzpid, kgzpid);
        }

        public static int UpdateSubmitState(YpzZhaopinkgzp ypzzpkgzp)
       {
           return FTInterviewDAL.YpzheZhaopinkgzpService.UpdateSubmitState(ypzzpkgzp);
       }

        public static int UpdateSubmitStateByypzzpkgzp(YpzZhaopinkgzp ypzzpkgzp)
        {
            return FTInterviewDAL.YpzheZhaopinkgzpService.UpdateSubmitStateByypzzpkgzp(ypzzpkgzp);
        }

    }
}
