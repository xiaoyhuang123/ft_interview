using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class XiangdianBiaozhunManage
    {
        public static int Add(Xiangdianbiaozhun xb)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.Add(xb);
        }

        public static List<Xiangdianbiaozhun> GetAll()
        {
            return FTInterviewDAL.XiangdianBiaozhunService.GetAll();
        }

        public static Xiangdianbiaozhun GetXDBZby2id(int xdid,int bzid)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.GetXDBZby2id(xdid,bzid);
        }

        public static int Update(Xiangdianbiaozhun xb)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.Update(xb);
        }

        public static int DeleteByID(int _id)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.DeleteByID(_id);
        }

        public static int DeleteByXDID(int _id)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.DeleteByXDID(_id);
        }
        public static int DeleteByBZID(int _id)
        {
            return FTInterviewDAL.XiangdianBiaozhunService.DeleteByBZID(_id);
        }

    }
}
