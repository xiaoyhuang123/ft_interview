using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class PingjiabiaozhunManage
    {
        public static int Add(Pingjiabiaozhun pz)
        {
            return FTInterviewDAL.PingjiabiaozhunService.Add(pz);
        }

        public static List<Pingjiabiaozhun> GetAll()
        {
            return FTInterviewDAL.PingjiabiaozhunService.GetAll();
        }

        public static int Update(Pingjiabiaozhun pjbz)
        {
            return FTInterviewDAL.PingjiabiaozhunService.Update(pjbz);
        }

        public static Pingjiabiaozhun GetPXBZbyId(int bzid)
        {
            return FTInterviewDAL.PingjiabiaozhunService.GetPXBZbyId(bzid);
        }


        public static int DeleteByID(int _id)
        {
            return FTInterviewDAL.PingjiabiaozhunService.DeleteByID(_id);
        }

    }
}
