using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class UserInfoManage
    {
        public static int Add(UserInfo userinfo)
        {
            return FTInterviewDAL.UserInfoService.Add(userinfo);
        }

        public static bool FindUser(string username, string password)
        {
            return FTInterviewDAL.UserInfoService.FindUser(username,password);
        }
         public static List<UserInfo> GetAllUserInfo()
        {
            return FTInterviewDAL.UserInfoService.GetAllUserInfo();
        }
       
        public static int UpdatePassword(string username,string password)
         {
             return FTInterviewDAL.UserInfoService.UpdatePassword(username,password);
         }
    }
}
