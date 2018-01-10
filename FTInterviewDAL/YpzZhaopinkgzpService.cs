using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class YpzheZhaopinkgzpService
    {
        public static int Add(YpzZhaopinkgzp ypzkg)
        {
            String sql = "insert into ypzkgsubmit(ypzzpid,kgzpid,submitstate) values(@ypzzpid,@kgzpid,@submitstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@ypzzpid", ypzkg.YpzzpID));
            para_list.Add(new MySqlParameter("@kgzpid", ypzkg.KgzpID));
            para_list.Add(new MySqlParameter("@submitstate", ypzkg.KgYpzSubmitState));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static YpzZhaopinkgzp GetByID(int id)
        {
            String sql = "select ypzkgsubmit.id as Id," +
            "ypzkgsubmit.ypzzpid as YpzzpID," +
              "ypzkgsubmit.kgzpid as KgzpID," +
                "ypzkgsubmit.submitstate as SubmitState," +
            " from ypzkgsubmit" +
            " where ypzkgsubmit.id= " + id;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            foreach (DataRow dr in dt.Rows)
            {
                YpzZhaopinkgzp t = new YpzZhaopinkgzp();
                t.ID = Convert.ToInt32(dr["Id"].ToString());
                t.KgzpID = Convert.ToInt32(dr["KgzpID"].ToString());
                t.YpzzpID = Convert.ToInt32(dr["YpzzpID"].ToString());
                t.KgYpzSubmitState = Convert.ToInt32(dr["SubmitState"].ToString());

                return t;
            }
            return null;
        }

        public static YpzZhaopinkgzp GetByypzidkgid(int ypzzpid, int kgzpid)
        {
            String sql = "select ypzkgsubmit.id as Id," +
            "ypzkgsubmit.ypzzpid as YpzzpID," +
            "ypzkgsubmit.kgzpid as KgzpID," +
            "ypzkgsubmit.submitstate as SubmitState " +
            " from ypzkgsubmit  " +
            " where ypzkgsubmit.ypzzpid= " + ypzzpid+
            "   and  ypzkgsubmit.kgzpid= " + kgzpid;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            foreach (DataRow dr in dt.Rows)
            {
                YpzZhaopinkgzp t = new YpzZhaopinkgzp();
                t.ID = Convert.ToInt32(dr["Id"].ToString());
                t.KgzpID = Convert.ToInt32(dr["KgzpID"].ToString());
                t.YpzzpID = Convert.ToInt32(dr["YpzzpID"].ToString());
                t.KgYpzSubmitState = Convert.ToInt32(dr["SubmitState"].ToString());

                return t;
            }
            return null;
        }

        public static int GetByypzidkgidNoSubmit(int ypzzpid, int kgzpid)
        {
            String sql = "select ypzkgsubmit.id as Id," +
            "ypzkgsubmit.ypzzpid as YpzzpID," +
            "ypzkgsubmit.kgzpid as KgzpID," +
            "ypzkgsubmit.submitstate as SubmitState " +
            " from ypzkgsubmit  " +
            " where ypzkgsubmit.submitstate=0 and ypzkgsubmit.ypzzpid= " + ypzzpid +
            "   and  ypzkgsubmit.kgzpid= " + kgzpid;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            return dt.Rows.Count;
        }

        
        public static int Delete(int id)
        {
            string sqlstr = "delete from ypzkgsubmit where id=" + id;
            return MySqlDBHelper.ExecuteCommand(sqlstr);
        }

        public static int UpdateSubmitState(YpzZhaopinkgzp ypzzpkgzp)
        {
            String sql = "update ypzkgsubmit set submitstate=@submitstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", ypzzpkgzp.ID));
            para_list.Add(new MySqlParameter("@submitstate", ypzzpkgzp.KgYpzSubmitState));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int UpdateSubmitStateByypzzpkgzp(YpzZhaopinkgzp ypzzpkgzp)
        {
            String sql = "update ypzkgsubmit set submitstate=@submitstate "+
            " where ypzkgsubmit.ypzzpid= " + ypzzpkgzp.YpzzpID +
           "   and  ypzkgsubmit.kgzpid= " + ypzzpkgzp.KgzpID;
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", ypzzpkgzp.ID));
            para_list.Add(new MySqlParameter("@submitstate", ypzzpkgzp.KgYpzSubmitState));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
    }
}
