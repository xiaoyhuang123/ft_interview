using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class UserInfoService
    {

        public static int Add(UserInfo userinfo)
        {
            String sql = "insert into userinfo(uname,pwd) values(@uname,@pwd)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@uname", userinfo.Username));
            para_list.Add(new MySqlParameter("@pwd", userinfo.Password));
            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

        public static bool FindUser(string username,string password)
        {
            String sql = "select * from userinfo where uname='"+username+"' and pwd='"+password+"'";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            return dt.Rows.Count>0 ? true:false;
        }

        public static List<UserInfo> GetAllUserInfo()
        {
            String sql = "select * from userinfo";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<UserInfo> list = new List<UserInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                UserInfo uifo = new UserInfo();
                uifo.ID = Convert.ToInt32(dr["id"]);
                uifo.Username = dr["uname"].ToString();
                uifo.Password = "";
                list.Add(uifo);
            }
            return list;
        }

        public static int UpdatePassword(string username, string password)
        {
            String sql = "update userinfo set pwd=@pwd where uname=@uname";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@pwd", password));
            para_list.Add(new MySqlParameter("@uname", username));
          
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

    }
}
