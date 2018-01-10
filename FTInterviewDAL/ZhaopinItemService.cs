using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class ZhaopinItemService
    {
        public static int Add(ZhaopinItem zp)
        {
            String sqlstr = "insert into zhaopinitem(title,pubtime,zpitemstate) values(@title,@pubtime,@zpitemstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@title", zp.Title));
            para_list.Add(new MySqlParameter("@pubtime", zp.PubTime));
            para_list.Add(new MySqlParameter("@zpitemstate", 1));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int AddReturnID(ZhaopinItem zp)
        {
            String sql = "select uuid()";
            string uni_str = "";
            while (true)
            {
                DataTable dt = MySqlDBHelper.GetDataSet(sql);
                if (dt.Rows.Count == 1)
                {
                    uni_str = dt.Rows[0][0].ToString();
                    dt.Clear();
                    break;
                }
            }

            String sqlstr = "insert into zhaopinitem(title,pubtime,zpitemstate,identifg) values(@title,@pubtime,@zpitemstate,@identifg)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@title", zp.Title));
            para_list.Add(new MySqlParameter("@pubtime", zp.PubTime));
            para_list.Add(new MySqlParameter("@zpitemstate", 1));
            para_list.Add(new MySqlParameter("@identifg", uni_str));

            MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());

            sqlstr = "select id from zhaopinitem where identifg='" + uni_str + "'";

            DataTable resdt = MySqlDBHelper.GetDataSet(sqlstr);
            int id = -1;
            if (resdt.Rows.Count > 0)
            {
                id = Convert.ToInt32(resdt.Rows[0]["id"]);
            }
            return id;
        }

        public static int Update(ZhaopinItem zpitem)
        {
            String sqlstr = "update zhaopinitem set title=@title,pubtime=@pubtime,zpitemstate=@zpitemstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", zpitem.Id));
            para_list.Add(new MySqlParameter("@title", zpitem.Title));
            para_list.Add(new MySqlParameter("@pubtime", zpitem.PubTime));
            para_list.Add(new MySqlParameter("@zpitemstate", zpitem.ZpitemState));
           
            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int UpdateZhaopinItemTitle(int id, string title_t)
        {
            String sqlstr = "update zhaopinitem set title=@title where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            para_list.Add(new MySqlParameter("@title", title_t));
            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int Delete(int id)
        {
            String sql = "delete from zhaopinitem where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
        public static int DeleteZhaopinItemByID(int id)
        {
            String sqlstr = "update zhaopinitem set zpitemstate=@zpitemstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            int s = 0;
            para_list.Add(new MySqlParameter("@zpitemstate", s));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static DataTable GetAllZhaopinItem()
        {
           string sqlstr = "select zhaopinitem.id as Id," +
                          "zhaopinitem.title as Title," +
                          "zhaopinitem.pubtime as PubTime  from zhaopinitem " +
                          " where zhaopinitem.zpitemstate=1 order by PubTime desc";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }

        public static List<ZhaopinItem> GetAllZhaopinItemList()
        {
            string sqlstr = "select zhaopinitem.id as Id," +
                           "zhaopinitem.title as Title," +
                           "zhaopinitem.pubtime as PubTime from zhaopinitem " +
                           " where zhaopinitem.zpitemstate=1 order by PubTime desc";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<ZhaopinItem> ls = new List<ZhaopinItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ZhaopinItem zpitem = new ZhaopinItem();
                zpitem.Id = Convert.ToInt32(dr["Id"]);
                zpitem.Title = dr["Title"].ToString();
                zpitem.PubTime = dr["PubTime"].ToString();
                ls.Add(zpitem);
            }

            return ls;
        }

        public static List<ZhaopinItem> GetAllZhaopinItemListWithKgaoguan(int kgid,string name)
        {
            string sqlstr = "select zhaopinitem.id as Id," +
                           "zhaopinitem.title as Title," +
                           "zhaopinitem.pubtime as PubTime from zhaopinitem " +
                           " where zhaopinitem.zpitemstate=1 "+
                           " and zhaopinitem.id in(select zhaopinitem.id from zhaopinitem,zpfb,zhaopin,kaoguanzhaopin,kaoguan "+
                           " where zhaopinitem.id= zpfb.zpitmid and zhaopin.id= kaoguanzhaopin.zpid and zhaopin.zpfbid=zpfb.id and kaoguanzhaopin.kgid=kaoguan.id "+
                           " and zhaopinitem.zpitemstate=1 and zpfb.fbstate=1 and zhaopin.zpstate=1 and kaoguan.kgstate=1 " +
                           " and kaoguan.id="+kgid+") ";//+
                          ;// " order by PubTime desc";
            if(name != "")
            {
                sqlstr += " and zhaopinitem.title Like '%" + name + "%'";
            }
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);

            List<ZhaopinItem> ls = new List<ZhaopinItem>();
            foreach (DataRow dr in dt.Rows)
            {


                ZhaopinItem zpitem = new ZhaopinItem();
                zpitem.Id = Convert.ToInt32(dr["Id"]);
                zpitem.Title = dr["Title"].ToString();
                zpitem.PubTime = dr["PubTime"].ToString();
                ls.Add(zpitem);
            }

            return ls;
        }


         public static List<ZhaopinItem> GetAllZhaopinItemListByTitle(string titlename="")
        {
            string sqlstr = "select zhaopinitem.id as Id," +
                         "zhaopinitem.title as Title," +
                         "zhaopinitem.pubtime as PubTime  from zhaopinitem " +
                         " where zhaopinitem.zpitemstate=1 ";//+
                         //"order by PubTime desc";
             if(titlename !="")
             {
                 sqlstr += " and zhaopinitem.title Like '%" + titlename + "%'";
             }
             sqlstr += " order by PubTime desc";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<ZhaopinItem> ls = new List<ZhaopinItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ZhaopinItem zpitem = new ZhaopinItem();
                zpitem.Id = Convert.ToInt32(dr["Id"]);
                zpitem.Title = dr["Title"].ToString();
                zpitem.PubTime = dr["PubTime"].ToString();
                ls.Add(zpitem);
            }
            return ls;
        }

        public static ZhaopinItem GetZhaopinItemById(int zpitemid)
        {
            string sqlstr = "select zhaopinitem.id as Id," +
                          "zhaopinitem.title as Title," +
                          "zhaopinitem.pubtime as PubTime  from zhaopinitem " +
                          " where zhaopinitem.zpitemstate=1 and id="+zpitemid+
                          "  order by PubTime desc";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            ZhaopinItem zpitm = new ZhaopinItem();
            foreach (DataRow dr in dt.Rows)
            {

                zpitm.Id = Convert.ToInt32(dr["Id"].ToString());
                zpitm.Title = dr["Title"].ToString();

                zpitm.PubTime = dr["PubTime"].ToString();
                return zpitm;
            }
            return null;
        }
    }
}
