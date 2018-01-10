using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class KaotiManage
    {
        public static int Add(Kaoti kt)
        {
            return FTInterviewDAL.KaotiService.Add(kt);
        }

        public static List<Kaoti> GetAllKaoti()
        {
            return FTInterviewDAL.KaotiService.GetAllKaoti();
        }

         public static List<Kaoti> GetKaotiByParameters(int depid=-1,string zppos="")
        {
            return FTInterviewDAL.KaotiService.GetKaotiByParameters(depid, zppos);
        }

         public static List<Kaoti> GetKaotiByZpgwID(int zpgwid = -1)
         {
             return FTInterviewDAL.KaotiService.GetKaotiByZpgwID(zpgwid);
         }


        public static Kaoti GetKaotiByID(int id)
        {
            return FTInterviewDAL.KaotiService.GetKaotiByID(id);
        }

        public static int UpdateKaoti(Kaoti kt)
        {
            return FTInterviewDAL.KaotiService.UpdateKaoti(kt);
        }

        public static int DeleteKaoti(int id)
        {
            return FTInterviewDAL.KaotiService.DeleteKaoti(id);
        }

        public static int GetKaotiSumsInGw(int gwid)
        {
            return FTInterviewDAL.KaotiService.GetKaotiSumsInGw(gwid);
        }

        public static List<Kaoti> GetKaotiByZpID(int zpid = -1)
        {
            return FTInterviewDAL.KaotiService.GetKaotiByZpID(zpid);
        }
    }
}
