using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class ZhaopinFbService
    {
        public static int Add(ZhaopinFb zpfb)
        {
            String sqlstr = "insert into zpfb(zpgwid,sums,fbtime,fbstate,zpitmid) values(@zpgwid,@sums,@fbtime,@fbstate,@zpitmid)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@zpgwid", zpfb.ZpGwID));
            para_list.Add(new MySqlParameter("@sums", zpfb.ZpSums));
            para_list.Add(new MySqlParameter("@fbtime", zpfb.ZpFbTime));
            para_list.Add(new MySqlParameter("@fbstate", zpfb.FbState));
            para_list.Add(new MySqlParameter("@zpitmid", zpfb.ZpitmId));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int Update(ZhaopinFb zbfb)
        {
            String sqlstr = "update zpfb set zpgwid=@zpgwid,sums=@sums,fbtime=@fbtime,zpitmid=@zpitmid where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@zpgwid", zbfb.ZpGwID));
            para_list.Add(new MySqlParameter("@sums", zbfb.ZpSums));
            para_list.Add(new MySqlParameter("@fbtime", zbfb.ZpFbTime));
            para_list.Add(new MySqlParameter("@zpitmid", zbfb.ZpitmId));
            para_list.Add(new MySqlParameter("@id", zbfb.Id));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int Delete(int id)
        {
            String sql = "delete from zpfb where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
        public static int DeleteZhaopinFb(int id)
        {
            int s = 0;
            String sqlstr = "update zpfb set fbstate=@fbstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@fbstate", s));
            para_list.Add(new MySqlParameter("@id", id));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }
      
        //hhy
        public static List<ZhaopinFb> GetAllZhaopinItem(int zpitmid = -1)
        {
            string sqlstr = "select zpfb.id as Id," +
                           "zpfb.zpgwid as ZpgwId," +
                           "zpgw.zpbm as ZpBmID," +
                           "department.departname as ZpBm," +
                           "zpgw.zppos as Zppos," +
                         "zpfb.sums as ZpSums," +
                          "zpfb.fbtime as FbTime, " +
                         "zpfb.zpitmid as ZpItmId " +
                        "from zpfb,zpgw,department " +
                        " where zpfb.fbstate=1 and zpfb.zpgwid=zpgw.id" +
                        " and zpgw.zpbm=department.id and department.bmstate=1 ";
            if(zpitmid !=-1)
            {
                sqlstr += " and zpfb.zpitmid="+zpitmid;
            }
            sqlstr += " order by  department.id asc";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<ZhaopinFb> ls = new List<ZhaopinFb>();
            foreach (DataRow dr in dt.Rows)
            {
                ZhaopinFb zf = new ZhaopinFb();
                zf.Id = Convert.ToInt32(dr["Id"].ToString());
                zf.ZpGwID = Convert.ToInt32(dr["ZpgwId"].ToString());
                zf.ZpSums = Convert.ToInt32(dr["ZpSums"].ToString());
                zf.ZpFbTime = dr["FbTime"].ToString();
                zf.ZpitmId = Convert.ToInt32(dr["ZpItmId"].ToString());

                zf.ZpBmName = dr["ZpBm"].ToString() +"--"+ dr["Zppos"].ToString();
                zf.ZpPosName = dr["Zppos"].ToString();

                ls.Add(zf);
            }
            return ls;
        }

        public static DataTable GetAllZhaopinFb(int dep=-1,string pos="")
        {
            string sqlstr = "select zpfb.id as Id," +
                            "zpfb.zpgwid as ZpgwId,"+
                            "zpgw.zpbm as ZpBmID,"+
                            "department.departname as ZpBm,"+
                            "zpgw.zppos as Zppos,"+
                          "zpfb.sums as ZpSums," +
                           "zpfb.fbtime as FbTime, " +
                          "zpfb.zpitmid as ZpItmId " +
                         "from zpfb,zpgw,department "+
                         " where zpfb.fbstate=1 and zpfb.zpgwid=zpgw.id"+
                         " and zpgw.zpbm=department.id and department.bmstate=1 ";
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            sqlstr += " order by FbTime desc ";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }

        public static List<ZhaopinFb> GetAllZhaopinFbList(int dep = -1, string pos = "")
        {
            DataTable dt = GetAllZhaopinFb(dep, pos);
            List<ZhaopinFb> ls = new List<ZhaopinFb>();
            foreach (DataRow dr in dt.Rows)
            {
                ZhaopinFb zf = new ZhaopinFb();
                zf.Id=Convert.ToInt32(dr["Id"].ToString());
                zf.ZpGwID = Convert.ToInt32(dr["ZpgwId"].ToString());
                zf.ZpSums = Convert.ToInt32(dr["ZpSums"].ToString());
                zf.ZpFbTime = dr["FbTime"].ToString();
                zf.ZpitmId = Convert.ToInt32(dr["ZpItmId"].ToString());

                zf.ZpBmName = dr["ZpBm"].ToString();
                zf.ZpPosName = dr["Zppos"].ToString();

                ls.Add(zf);
            }
            return ls;
        }

        public static ZhaopinFb GetZhaopinFbByid(int id)
        {
            string sqlstr = "select zpfb.id as Id," +
                            "zpfb.zpgwid as ZpgwId," +
                            "zpgw.zpbm as ZpBmID," +
                            "department.departname as ZpBm," +
                            "zpgw.zppos as Zppos," +
                          "zpfb.sums as ZpSums," +
                          "zpfb.fbtime as FbTime, " +
                          "zpfb.zpitmid as ZpItmId " +
                         "from zpfb,zpgw,department "+
                         " where zpfb.fbstate=1 and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 and zpfb.id="+id;
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                ZhaopinFb zf = new ZhaopinFb();
                zf.Id = Convert.ToInt32(dr["Id"].ToString());
                zf.ZpGwID = Convert.ToInt32(dr["ZpgwId"].ToString());
                zf.ZpSums = Convert.ToInt32(dr["ZpSums"].ToString());
                zf.ZpFbTime = dr["FbTime"].ToString();
                zf.ZpitmId = Convert.ToInt32(dr["ZpItmId"]);

                zf.ZpBmName = dr["ZpBm"].ToString();
                zf.ZpPosName = dr["Zppos"].ToString();
                zf.FbBmId = Convert.ToInt32(dr["ZpBmID"].ToString());
                return zf;
            }
            return null;
        }

        public static DataTable GetAllZhaopinFbInItem(int dep = -1, string pos = "",int itmid=-1)
        {
            string sqlstr = "select zpfb.id as Id," +
                            "zpfb.zpgwid as ZpgwId," +
                            "zpgw.zpbm as ZpBmID," +
                            "department.departname as ZpBm," +
                            "zpgw.zppos as Zppos," +
                          "zpfb.sums as ZpSums," +
                          "zpfb.fbtime as FbTime, " +
                          "zpfb.zpitmid as ZpItmId " +
                         "from zpfb,zpgw,department " +
                         " where zpfb.fbstate=1 and zpfb.zpgwid=zpgw.id" +
                         " and zpgw.zpbm=department.id and department.bmstate=1 ";
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            if (itmid != -1)
            {
                sqlstr += " and zpfb.zpitmid='" + itmid + "' ";
            }

            sqlstr += " order by FbTime desc ";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }

    }
}
