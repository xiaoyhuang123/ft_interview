using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class ShitiManage
    {
        public static int Add(Shiti shiti)
        {
            return FTInterviewDAL.ShitiService.Add(shiti);
        }

        public static List<Shiti> GetAllShiti()
        {
            return FTInterviewDAL.ShitiService.GetAllShiti();
        }

        public static List<Shiti> GetAllShitiByKaotiId(int ktid=-1)
        {
            return FTInterviewDAL.ShitiService.GetAllShitiByKaotiId(ktid);
        }

        public static int getShitiWeightsInkaoti(int ktid = -1,int seceptid=-1)
        {
            return FTInterviewDAL.ShitiService.getShitiWeightsInkaoti(ktid,seceptid);
        }


        public static Shiti GetShitiById(int stid = -1)
        {
            return FTInterviewDAL.ShitiService.GetShitiById(stid);
        }

        public static int DeleteByID(int id)
        {
            return FTInterviewDAL.ShitiService.DeleteByID(id);
        }

        public static int Update(Shiti st)
        {
            return FTInterviewDAL.ShitiService.Update(st);
        }

        public static int UpdateWeight_Time(int id,int new_weight,int new_time)
        {
            return FTInterviewDAL.ShitiService.UpdateWeight_Time(id,new_weight,new_time);
        }


    }
}
