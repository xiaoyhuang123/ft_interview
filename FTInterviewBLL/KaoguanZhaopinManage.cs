using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class KaoguanZhaopinManage
    {
        public static int Add(KaoguanZhaopin kz)
        {
            return FTInterviewDAL.KaoguanZhaopinService.Add(kz);
        }

         public static int UpdateWeight(int kgzpid,int w)
        {
            return FTInterviewDAL.KaoguanZhaopinService.UpdateWeight(kgzpid, w);
        }

        public static int Delete(int id)
        {
            return FTInterviewDAL.KaoguanZhaopinService.Delete(id);
        }

        public static KaoguanZhaopin GetKgZPbyId(int id)
        {
            return FTInterviewDAL.KaoguanZhaopinService.GetKgZPbyId(id);
        }

        public static List<KaoguanZhaopin> GetKgZPbyzpId(int zpid)
        {
            return FTInterviewDAL.KaoguanZhaopinService.GetKgZPbyzpId(zpid);
        }

        public static KaoguanZhaopin GetKgZPbyKgIdZpid(int kgid,int zpid)
        {
            return FTInterviewDAL.KaoguanZhaopinService.GetKgZPbyKgIdZpid(kgid,zpid);
        }
    }
}
