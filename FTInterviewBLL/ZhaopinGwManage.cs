using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class ZhaopinGwManage
    {
        public static int Add(ZhaopinGw zpgw)
        {
            return FTInterviewDAL.ZhaopinGwService.Add(zpgw);
        }

        public static int Update(ZhaopinGw zp)
        {
            return FTInterviewDAL.ZhaopinGwService.Update(zp);
        }

        public static int DeleteZhaopinGwByID(int id)
        {
            return FTInterviewDAL.ZhaopinGwService.DeleteZhaopinGw(id);
        }

        public static DataTable GetAllZhaopinGw(int dep = -1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinGwService.GetAllZhaopinGw(dep, pos);
        }

        public static List<ZhaopinGw> GetAllZhaopinGwList(int dep = -1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinGwService.GetAllZhaopinGwList(dep, pos);
        }

        public static ZhaopinGw GetZhaopinGwByid(int id)
        {
            return FTInterviewDAL.ZhaopinGwService.GetZhaopinGwByid(id);
        }

         public static int GetZhaopinGwID(int depid,string posname)
        {
            return FTInterviewDAL.ZhaopinGwService.GetZhaopinGwID(depid, posname);
        }

    }
}
