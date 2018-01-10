using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class ZhaopinFbManage
    {
        public static int Add(ZhaopinFb zpfb)
        {
            return FTInterviewDAL.ZhaopinFbService.Add(zpfb);
        }

        public static int Update(ZhaopinFb zbfb)
        {
            return FTInterviewDAL.ZhaopinFbService.Update(zbfb);
        }

        public static int Delete(int id)
        {
            return FTInterviewDAL.ZhaopinFbService.Delete(id);
        }
        public static int DeleteZhaopinFb(int id)
        {
            return FTInterviewDAL.ZhaopinFbService.DeleteZhaopinFb(id);
        }

         //hhy
        public static List<ZhaopinFb> GetAllZhaopinItem(int zpitmid = -1)
        {
            return FTInterviewDAL.ZhaopinFbService.GetAllZhaopinItem(zpitmid);
        }


        public static DataTable GetAllZhaopinFb(int dep = -1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinFbService.GetAllZhaopinFb(dep, pos);
        }
        public static DataTable GetAllZhaopinFbInItem(int dep = -1, string pos = "", int itmid = -1)
        {
            return FTInterviewDAL.ZhaopinFbService.GetAllZhaopinFbInItem(dep, pos, itmid);
        }

        public static List<ZhaopinFb> GetAllZhaopinFbList(int dep = -1, string pos = "")
        {
            return FTInterviewDAL.ZhaopinFbService.GetAllZhaopinFbList(dep, pos);
        }

        public static ZhaopinFb GetZhaopinFbByid(int id)
        {
            return FTInterviewDAL.ZhaopinFbService.GetZhaopinFbByid(id);
        }

    }
}
