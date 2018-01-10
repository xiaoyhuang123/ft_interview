using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class SystemManageManage
    {
        public static SystemManage GetSystemManage()
        {
            return FTInterviewDAL.SystemManageService.GetSystemManage();
        }

        public static int UpdateTikuPassword(string password)
        {
            return FTInterviewDAL.SystemManageService.UpdateTikuPassword(password);
        }

        public static int UpdateKaochangjilv(string kcjv)
        {
            return FTInterviewDAL.SystemManageService.UpdateKaochangjilv(kcjv);
        }
    }
}
