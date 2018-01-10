using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class ZhaopinItemManage
    {
        public static int Add(ZhaopinItem zp)
        {
            return FTInterviewDAL.ZhaopinItemService.Add(zp);
        }

        public static int AddReturnID(ZhaopinItem zp)
        {
            return FTInterviewDAL.ZhaopinItemService.AddReturnID(zp);
        }

        public static int Update(ZhaopinItem zpitem)
        {
            return FTInterviewDAL.ZhaopinItemService.Update(zpitem);
        }

        public static int UpdateZhaopinItemTitle(int id, string title_t)
        {
            return FTInterviewDAL.ZhaopinItemService.UpdateZhaopinItemTitle(id, title_t);
        }

        public static int Delete(int id)
        {
            return FTInterviewDAL.ZhaopinItemService.Delete(id);
        }
        public static int DeleteZhaopinByID(int id)
        {
            return FTInterviewDAL.ZhaopinItemService.DeleteZhaopinItemByID(id);
        }

        public static DataTable GetAllZhaopinItem()
        {
            return FTInterviewDAL.ZhaopinItemService.GetAllZhaopinItem();
        }

        public static List<ZhaopinItem> GetAllZhaopinItemList()
        {
            return FTInterviewDAL.ZhaopinItemService.GetAllZhaopinItemList();
        }

        //hhy
        public static List<ZhaopinItem> GetAllZhaopinItemListWithKgaoguan(int kgid,string name="")
        {
            return FTInterviewDAL.ZhaopinItemService.GetAllZhaopinItemListWithKgaoguan(kgid,name);
        }

        public static List<ZhaopinItem> GetAllZhaopinItemListByTitle(string titlename="")
        {
            return FTInterviewDAL.ZhaopinItemService.GetAllZhaopinItemListByTitle(titlename);
        }

        public static ZhaopinItem GetZhaopinItemById(int zpitemid)
        {
            return FTInterviewDAL.ZhaopinItemService.GetZhaopinItemById(zpitemid);
        }
    }
}
