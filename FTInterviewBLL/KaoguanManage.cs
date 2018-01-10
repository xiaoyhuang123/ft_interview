using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class KaoguanManage
    {
        public static int Add(Kaoguan kg)
        {
            return FTInterviewDAL.KaoguanService.Add(kg);
        }

        public static List<Kaoguan> GetAll()
        {
            return FTInterviewDAL.KaoguanService.GetAllKaoguan();
        }
         public static List<Kaoguan> GetAllKaoguanByZp(int zpid=-1,bool in_zp=true)
        {
            return FTInterviewDAL.KaoguanService.GetAllKaoguanByZp(zpid);
        }

        public static Kaoguan GetKaoguanByID(int id)
        {
            return FTInterviewDAL.KaoguanService.GetKaoguanByID(id);
        }

        public static int UpdateKaoguan(Kaoguan kg)
        {
            return FTInterviewDAL.KaoguanService.UpdateKaoguan(kg);
        }

        public static int DeleteKaoguan(int id)
        {
            return FTInterviewDAL.KaoguanService.DeleteKaoguan(id);
        }

        public static List<Kaoguan> GetKaoguanByParameters(int bmanme = -1, string kgname = "")
        {
            return FTInterviewDAL.KaoguanService.GetKaoguanByParameters(bmanme,kgname);
        }

        public static int UpdataPassword(int id,string pwd)
        {
            return FTInterviewDAL.KaoguanService.UpdataPassword(id, pwd);
        }

        public static Kaoguan FindKaoGuan(string name, string password)
        {
            return FTInterviewDAL.KaoguanService.FindKaoGuan(name, password);
        }
    }
}
