using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;
using System.Data;

namespace FTInterviewBLL
{
    public class PositionManage
    {
        public static int Add(Position ps)
        {
            return FTInterviewDAL.PositionService.Add(ps);
        }

        public static List<Position> GetAllPosition()
        {
            return FTInterviewDAL.PositionService.GetAllPosition();
        }

        public static int GetPositionIDbyName(string gwname)
        {
            return FTInterviewDAL.PositionService.GetPositionIDbyName(gwname);
        }
    }
}
