using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;



namespace FTInterviewDAL
{
    public class PingjiaxiangdianService
    {
        public static int Add(Pingjiaxiangdian pjxd)
        {
            String sql = "insert into pingjiaxiangdian(content,score) values(@content,@score)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@content", pjxd.Content));
            para_list.Add(new MySqlParameter("@score", pjxd.Score));

            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );

        }

         public static List<Pingjiaxiangdian> GetAll()
        {
            String sql = "select * from pingjiaxiangdian order by id asc ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Pingjiaxiangdian> list = new List<Pingjiaxiangdian>();
            foreach (DataRow dr in dt.Rows)
            {
                Pingjiaxiangdian st = new Pingjiaxiangdian();
                st.Id = Convert.ToInt32(dr["id"].ToString());
                st.Content = dr["content"].ToString();
                st.Score = Convert.ToInt32(dr["score"].ToString());
                list.Add(st);
            }
            return list;
        }

        public static int Update(Pingjiaxiangdian pjxd)
        {
            String sql = "update pingjiaxiangdian set content=@content,score=@score where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", pjxd.Id));
            para_list.Add(new MySqlParameter("@content", pjxd.Content));
            para_list.Add(new MySqlParameter("@score", pjxd.Score));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

         public static int UpdateScore(int id,int score)
        {
            String sql = "update pingjiaxiangdian set score=@score where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            para_list.Add(new MySqlParameter("@score", score));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }


        public static Pingjiaxiangdian GetPXXDbyId(int xdid)
        {
            String sql = "select * from pingjiaxiangdian where id="+xdid;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
             Pingjiaxiangdian st = new Pingjiaxiangdian();
            foreach (DataRow dr in dt.Rows)
            {
                st.Id = Convert.ToInt32(dr["id"].ToString());
                st.Content = dr["content"].ToString();
                st.Score = Convert.ToInt32(dr["score"].ToString());
                return st;
            }
            return null;
        }


        public static int DeleteByID(int _id)
        {
            String sql = "delete from pingjiaxiangdian where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", _id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

         public static int GetPingjiaxiangdianScoreSum()
        {
            String sql = "select * from pingjiaxiangdian ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            int scoresum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                scoresum += Convert.ToInt32(dr["score"].ToString());
            }
            return scoresum;
        }

    }
}
