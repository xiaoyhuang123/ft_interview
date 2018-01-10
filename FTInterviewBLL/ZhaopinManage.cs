using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class ZhaopinManage
    {
        public static int Add(Zhaopin zp)
        {
            return FTInterviewDAL.ZhaopinService.Add(zp);
        }

         public static int AddReturnID(Zhaopin zp)
        {
            return FTInterviewDAL.ZhaopinService.AddReturnID(zp);
        }

        public static int Update(Zhaopin zp)
        {
            return FTInterviewDAL.ZhaopinService.Update(zp);
        }

        public static int UpdateKaotiIndex(int id,int ktid)
        {
            return FTInterviewDAL.ZhaopinService.UpdateKaotiIndex(id,ktid);
        }

        public static int DeleteZhaopinByID(int id)
        {
            return FTInterviewDAL.ZhaopinService.DeleteZhaopinByID(id);
        }


        //hhy
        public static List<Zhaopin> GetAllZhaopinListInZpItemId(int itmid, int depid = -1, string posname = "", string st = "", string et = "")
        {
            return FTInterviewDAL.ZhaopinService.GetAllZhaopinListInZpItemId(itmid,depid,posname,st,et);
        }


        public static DataTable GetAllZhaopin(int dep =-1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinService.GetAllZhaopin(dep,pos);
        }

        public static List<Zhaopin> GetAllZhaopinList(int dep = -1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinService.GetAllZhaopinList(dep, pos);
        }

        public static List<Zhaopin> GetAllZhaopinListByparameters(int dep = -1, string pos = "",string st="",string et="")
        {
            return FTInterviewDAL.ZhaopinService.GetAllZhaopinListByparameters(dep, pos, st, et);
        }

        public static Zhaopin GetZhaopinById(int zpid)
        {
            return FTInterviewDAL.ZhaopinService.GetZhaopinById(zpid);
        }


        public static DataTable GetAllZhaopinListByKaoguan(int kgid,int dep=-1,string pos="")
        {
            return FTInterviewDAL.ZhaopinService.GetAllZhaopinListByKaoguan(kgid,dep,pos);
        }
         public static DataTable GetAllZhaopinListInItemIdByKaoguan(int zpitmid,int kgid, int dep = -1, string pos = "")
        {
             return FTInterviewDAL.ZhaopinService.GetAllZhaopinListInItemIdByKaoguan(zpitmid,kgid,dep,pos);
        }

    }
}
