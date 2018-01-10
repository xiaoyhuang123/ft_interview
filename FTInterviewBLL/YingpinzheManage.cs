using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;
using System.Data;

namespace FTInterviewBLL
{
    public class YingpinzheManage
    {
        public static int Add ( Yingpinzhe ypz )
        {
            return FTInterviewDAL.YingpinzheService.Add(ypz);
        }

        public static int DeleteYingpinzheByID(int id)
        {
            return FTInterviewDAL.YingpinzheService.DeleteYingpinzheByID(id);
        }

        public static int Update(Yingpinzhe ypz)
        {
            return FTInterviewDAL.YingpinzheService.Update ( ypz );

        }

        //hhy
         public static List<Yingpinzhe> GetAllYingpinzheInZpItem(int itemid=-1)//hhy
        {
            return FTInterviewDAL.YingpinzheService.GetAllYingpinzheInZpItem(itemid);
        }
        //hhy
         public static List<Yingpinzhe> GetYingpinzheInZpItemByParameters(int itemid=-1,string name = "", int dep = -1)
         {
             return FTInterviewDAL.YingpinzheService.GetYingpinzheInZpItemByParameters(itemid,name, dep);
         }



        public static List<Yingpinzhe> GetAllYingpinzhe()
        {
            return FTInterviewDAL.YingpinzheService.GetAllYingpinzhe();
        }

        public static Yingpinzhe GetYingpinzheById(int id)
        {
            return FTInterviewDAL.YingpinzheService.GetYingpinzheById(id);
        }

        public static List<Yingpinzhe> GetYingpinzheByParameters(string name = "", int dep = -1)
        {
            return FTInterviewDAL.YingpinzheService.GetYingpinzheByParameters(name,dep);
        }

        public static List<Yingpinzhe> GetAllYingpinzheByZp(int zpid = -1, bool in_zp = true)
        {
            return FTInterviewDAL.YingpinzheService.GetAllYingpinzheByZp(zpid);
        }

        public static List<Yingpinzhe> GetAllYingpinzheByZpAndParameters(int zpid = -1, bool in_zp = true,string ypzname="",int depid=-1)
        {
            return FTInterviewDAL.YingpinzheService.GetAllYingpinzheByZpAndParameters(zpid, in_zp, ypzname, depid);
        }
    }
}
