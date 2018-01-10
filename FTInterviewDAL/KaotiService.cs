using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class KaotiService
    {
       public static int Add(Kaoti kt)
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

           sql = "insert into kaoti(title,zpgwid,ktstate,identy,createtime) values(@title,@zpgwid,@ktstate,@identy,@createtime)";
           List<MySqlParameter> para_list = new List<MySqlParameter>();

           para_list.Add(new MySqlParameter("@title", kt.Title));
           para_list.Add(new MySqlParameter("@zpgwid", kt.ZpgwId));
           para_list.Add(new MySqlParameter("@ktstate", 1));
           para_list.Add(new MySqlParameter("@identy", uni_str));
           para_list.Add(new MySqlParameter("@createtime", kt.CreateTime));

           MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());

           sql = "select id from kaoti where identy='" + uni_str + "'";

           DataTable resdt = MySqlDBHelper.GetDataSet(sql);
           int id = -1;
           if (resdt.Rows.Count > 0)
           {
               id = Convert.ToInt32(resdt.Rows[0]["id"]);
           }
           return id;
       }

       public static List<Kaoti> GetAllKaoti()
       {
           String sql = "select kaoti.id as Id," +
             "kaoti.title as Title," +
             "kaoti.zpgwid as ZpgwId," +
             "zpgw.zpbm as DepId," +
             "department.departname as ZpDepName," +
             "zpgw.zppos as ZpPosName," +
             " kaoti.ktstate, " +
             " kaoti.createtime "+
             " from kaoti,zpgw,department" +
             " where zpgw.zpbm=department.id and kaoti.zpgwid=zpgw.id and " +
             " kaoti.ktstate=1 and department.bmstate=1 "+" order by department.id ";
           DataTable dt = MySqlDBHelper.GetDataSet(sql);

           List<Kaoti> list = new List<Kaoti>();
           foreach (DataRow dr in dt.Rows)
           {
               Kaoti kt = new Kaoti();
               kt.Id = (int)dr["Id"];
               kt.Title = dr["title"].ToString();
               kt.ZpgwId = Convert.ToInt32(dr["ZpgwId"].ToString());
               kt.KtState = Convert.ToInt32(dr["ktstate"].ToString());
               if (dr["createtime"].ToString() != null && dr["createtime"].ToString() != "")
               {
                   DateTime date = (DateTime)dr["createtime"];
                   kt.CreateTime = date.ToShortDateString();
               }
               else
               {
                   kt.CreateTime = "";
               }

               kt.ZpBmName = dr["ZpDepName"].ToString();
               kt.ZpGmName = dr["ZpPosName"].ToString();
               list.Add(kt);
           }
           return list;
       }

       public static List<Kaoti> GetKaotiByParameters(int depid=-1,string zppos="")
       {
           String sql = "select kaoti.id as Id,"+
               "kaoti.title as Title,"+
               "kaoti.zpgwid as ZpgwId,"+
               "zpgw.zpbm as DepId,"+
               "department.departname as ZpDepName,"+
               "zpgw.zppos as ZpPosName,"+
               " kaoti.ktstate, "+
               " kaoti.createtime " +
               " from kaoti,zpgw,department"+
               " where zpgw.zpbm=department.id and kaoti.zpgwid=zpgw.id and " +
               " kaoti.ktstate=1 and department.bmstate=1 ";

           if (depid != -1)
           {
               sql += " and department.id="+depid+" ";
           }
           if(zppos !=""&& zppos !=null)
           {
               sql += " and zpgw.zppos='" + zppos + "' ";
           }

           DataTable dt = MySqlDBHelper.GetDataSet(sql);

           List<Kaoti> list = new List<Kaoti>();
           foreach (DataRow dr in dt.Rows)
           {
               Kaoti kt = new Kaoti();
               kt.Id = (int)dr["Id"];
               kt.Title = dr["title"].ToString();
               kt.ZpgwId = Convert.ToInt32(dr["ZpgwId"].ToString());
               kt.KtState = Convert.ToInt32(dr["ktstate"].ToString());
               if (dr["createtime"].ToString() != null && dr["createtime"].ToString() != "")
               {
                   DateTime date = (DateTime)dr["createtime"];
                   kt.CreateTime = date.ToShortDateString();
               }
               else
               {
                   kt.CreateTime = "";
               }

               kt.ZpBmName = dr["ZpDepName"].ToString();
               kt.ZpGmName = dr["ZpPosName"].ToString();
               list.Add(kt);
           }
           return list;
       }

       public static List<Kaoti> GetKaotiByZpgwID(int zpgwid = -1)
       {
           String sql = "select kaoti.id as Id," +
               "kaoti.title as Title," +
               "kaoti.zpgwid as ZpgwId," +
               "zpgw.zpbm as DepId," +
               "department.departname as ZpDepName," +
               "zpgw.zppos as ZpPosName," +
               " kaoti.ktstate, " +
               " kaoti.createtime " +
               " from kaoti,zpgw,department" +
               " where zpgw.zpbm=department.id and kaoti.zpgwid=zpgw.id and " +
               " kaoti.ktstate=1 and department.bmstate=1 ";

           if (zpgwid != -1)
           {
               sql += " and zpgw.id=" + zpgwid + " ";
           }

           DataTable dt = MySqlDBHelper.GetDataSet(sql);

           List<Kaoti> list = new List<Kaoti>();
           foreach (DataRow dr in dt.Rows)
           {
               Kaoti kt = new Kaoti();
               kt.Id = (int)dr["Id"];
               kt.Title = dr["title"].ToString();
               kt.ZpgwId = Convert.ToInt32(dr["ZpgwId"].ToString());
               kt.KtState = Convert.ToInt32(dr["ktstate"].ToString());
               if (dr["createtime"].ToString() != null && dr["createtime"].ToString() != "")
               {
                   DateTime date = (DateTime)dr["createtime"];
                   kt.CreateTime = date.ToShortDateString();
               }
               else
               {
                   kt.CreateTime = "";
               }

               kt.ZpBmName = dr["ZpDepName"].ToString();
               kt.ZpGmName = dr["ZpPosName"].ToString();
               list.Add(kt);
           }
           return list;
       }

       public static Kaoti GetKaotiByID(int id)
       {
           String sql = "select * "+
               "from kaoti,zpgw,department "+
               "where kaoti.zpgwid=zpgw.id and"+
               " zpgw.zpbm=department.id and department.bmstate=1"+
               "  and kaoti.ktstate=1 and kaoti.id=" + id;
           DataTable dt = MySqlDBHelper.GetDataSet(sql);
           Kaoti kt = new Kaoti();
           bool falg = false;
           foreach (DataRow dr in dt.Rows)
           {
               kt.Id = (int)dr["id"];
               kt.Title = dr["title"].ToString();
               kt.ZpgwId = Convert.ToInt32(dr["zpgwid"].ToString());
               if (dr["createtime"].ToString() != null && dr["createtime"].ToString() != "")
               {
                   DateTime date = (DateTime)dr["createtime"];
                   kt.CreateTime = date.ToShortDateString();
               }
               else
               {
                   kt.CreateTime = "";
               }
             

               kt.ZpBmName = dr["departname"].ToString();
               kt.ZpGmName = dr["zppos"].ToString();
               falg = true;
               break;
           }
           if (falg)
           { return kt; }
           return null;
       }

       public static int UpdateKaoti(Kaoti kt)
       {
           String sql = "update kaoti set title=@title,zpgwid=@zpgwid,createtime=@createtime where id=@id";
           List<MySqlParameter> para_list = new List<MySqlParameter>();

           para_list.Add(new MySqlParameter("@title", kt.Title));
           para_list.Add(new MySqlParameter("@zpgwid", kt.ZpgwId));
           para_list.Add(new MySqlParameter("@createtime", kt.CreateTime));

           return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
       }

       public static int Delete(int id)
       {
           String sqlstr = "delete from kaoti where id=@id";
           List<MySqlParameter> para_list = new List<MySqlParameter>();
           para_list.Add(new MySqlParameter("@id", id));
           return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
       }
       public static int DeleteKaoti(int id)
       {
           String sql = "update kaoti set ktstate=@ktstate where id=@id";
           List<MySqlParameter> para_list = new List<MySqlParameter>();

           para_list.Add(new MySqlParameter("@id", id));
           int s = 0;
           para_list.Add(new MySqlParameter("@ktstate", s));

           return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
       }

       public static int GetKaotiSumsInGw(int gwid)
       {
           int res = 0;
           string sql = "select * from kaoti where ktstate=1 and zpgwid="+gwid+" ";
           DataTable dt = MySqlDBHelper.GetDataSet(sql);
           res = dt.Rows.Count;
           return res;
       }

       public static List<Kaoti> GetKaotiByZpID(int zpid = -1)
       {
           String sql = "select kaoti.id as Id," +
               "kaoti.title as Title," +
               "kaoti.zpgwid as ZpgwId " +
               " from kaoti,zpfb,zpgw,zhaopin " +
               " where kaoti.ktstate=1 and zhaopin.zpfbid=zpfb.id and zhaopin.zpstate=1 "+
               " and zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.id=kaoti.zpgwid ";

         //  if (zpid != -1)
           {
               sql += " and zhaopin.id=" + zpid + " ";
           }

           DataTable dt = MySqlDBHelper.GetDataSet(sql);

           List<Kaoti> list = new List<Kaoti>();
           foreach (DataRow dr in dt.Rows)
           {
               Kaoti kt = new Kaoti();
               kt.Id = (int)dr["Id"];
               kt.Title = dr["title"].ToString();
               kt.ZpgwId = Convert.ToInt32(dr["ZpgwId"].ToString());
               list.Add(kt);
           }
           return list;
       }

    }
}
