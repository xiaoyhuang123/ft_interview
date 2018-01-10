using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class XueliManage
    {
        public static int Add(Xueli xl)
        {
            return FTInterviewDAL.XueliService.Add(xl);
        }

        public static List<Xueli> GetAll()
        {
            return FTInterviewDAL.XueliService.GetAll();
        }

    }
}
