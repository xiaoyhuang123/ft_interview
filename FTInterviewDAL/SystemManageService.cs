using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class SystemManageService
    {
        public static SystemManage GetSystemManage()
        {
            String sql = "select * from systemmanage ";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            
            foreach ( DataRow dr in dt.Rows )
            {
                SystemManage sm = new SystemManage();
                sm.ID = Convert.ToInt32(dr["id"]);
                sm.TikuPwd = dr["tkpwd"].ToString();
                sm.KaochangJilv = dr["kcjl"].ToString();
                return sm;
            }
            return null;
        }

        public static int UpdateTikuPassword(string password)
        {
            String sql = "select * from systemmanage ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            SystemManage sm = new SystemManage();
            foreach (DataRow dr in dt.Rows)
            {
                sm.ID = Convert.ToInt32(dr["id"]);
                sm.TikuPwd = dr["tkpwd"].ToString();
                sm.KaochangJilv = dr["kcjl"].ToString();
                break;
            }

             sql = "update systemmanage set tkpwd=@tkpwd where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@tkpwd", password));
            para_list.Add(new MySqlParameter("@id", sm.ID));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int UpdateKaochangjilv(string kcjv)
        {
            String sql = "select * from systemmanage ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            SystemManage sm = new SystemManage();
            foreach (DataRow dr in dt.Rows)
            {
                sm.ID = Convert.ToInt32(dr["id"]);
                sm.TikuPwd = dr["tkpwd"].ToString();
                sm.KaochangJilv = dr["kcjl"].ToString();
                break;
            }

             sql = "update systemmanage set kcjl=@kcjl where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@kcjl", kcjv));
            para_list.Add(new MySqlParameter("@id", sm.ID));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

    }
}
