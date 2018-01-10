using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class YingpinzheZhaopinManage
    {
        public static int Add(YingpinzheZhaopin yz)
        {
            return FTInterviewDAL.YingpinzheZhaopinService.Add(yz);
        }

        public static int Delete(int id)
        {
            return FTInterviewDAL.YingpinzheZhaopinService.Delete(id);
        }

        public static YingpinzheZhaopin GetYPZZPbyId(int id)
        {
            return FTInterviewDAL.YingpinzheZhaopinService.GetYPZZPbyId(id);
        }

       public static int UpdateSubmitState(YingpinzheZhaopin ypzzp)
       {
            return FTInterviewDAL.YingpinzheZhaopinService.UpdateSubmitState(ypzzp);
       }
       public static int UpdateIndex(int id,int ord)
       {
            return FTInterviewDAL.YingpinzheZhaopinService.UpdateIndex(id,ord);
       }
       //hhy
       public static List<YingpinzheZhaopin> GetAllYingpinzheInzhaopinItemID(int zpitmid)
       {
           return FTInterviewDAL.YingpinzheZhaopinService.GetAllYingpinzheInzhaopinItemID(zpitmid);
       }
         //hhy
        public static DataTable GetAllYingpinzheResultInzhaopinItemId(int zpitmid,int zpbmid = -1,string pos = "", string st = "", string et = "")
       {
           return FTInterviewDAL.YingpinzheZhaopinService.GetAllYingpinzheResultInzhaopinItemId(zpitmid, zpbmid, pos, st, et);
       }



       public static DataTable GetAllYPZZPInzpId(int zpid)
       {
            return FTInterviewDAL.YingpinzheZhaopinService.GetAllYPZZPInzpId(zpid);
       }

       public static List<Yingpinzhe> GetAllYingpinzheInzhaopin(int zpid)
       {
             return FTInterviewDAL.YingpinzheZhaopinService.GetAllYingpinzheInzhaopin(zpid);
       }

       public static List<YingpinzheZhaopin> GetAllYingpinzheInzhaopinID(int zpid)
       {
              return FTInterviewDAL.YingpinzheZhaopinService.GetAllYingpinzheInzhaopinID(zpid);
       }

       public static DataTable GetAllYingpinzheResultInzhaopinID(int zpgwid = -1, string st = "", string et = "")
       {
           return FTInterviewDAL.YingpinzheZhaopinService.GetAllYingpinzheResultInzhaopinID(zpgwid, st, et);
       }
    }
}
