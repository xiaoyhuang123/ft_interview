using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class ShitiService
    {

        public static int Add ( Shiti shiti )
        {
            String sql = "insert into shiti(question,ktid,ktindex,weight,sttime) values(@question,@ktid,@ktindex,@weight,@sttime)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@question", shiti.Question));
            para_list.Add(new MySqlParameter("@ktid", shiti.KaotiID));
            para_list.Add(new MySqlParameter("@ktindex", shiti.KaotiIndex));
            para_list.Add(new MySqlParameter("@weight", shiti.Weight));
            para_list.Add(new MySqlParameter("@sttime", shiti.StTime));
           
            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );

        }

         public static int DeleteByID(int id)
        {
            String sql = "delete from shiti where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static List<Shiti>GetAllShiti()
        {
            String sql = "select shiti.id as Id,question,ktid,ktindex,weight,sttime from shiti,kaoti where shiti.ktid=kaoti.id order by Id asc ";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            List<Shiti> list = new List<Shiti>();
            foreach ( DataRow dr in dt.Rows )
            {
                Shiti st = new Shiti();
                st.Id = Convert.ToInt32(dr["Id"].ToString());
                st.Question = dr["question"].ToString();
                st.KaotiID = Convert.ToInt32(dr["ktid"].ToString());
                st.KaotiIndex = Convert.ToInt32(dr["ktindex"].ToString());
                st.Weight = Convert.ToInt32(dr["weight"]);
                st.StTime = Convert.ToInt32(dr["sttime"]);
                list.Add ( st );
            }
            return list;
        }

         public static List<Shiti> GetAllShitiByKaotiId(int ktid=-1)
        {
            String sql = "select shiti.id as Id,question,ktid,ktindex,weight,sttime "+
                " from shiti,kaoti,zpgw,department "+
                " where kaoti.ktstate=1 and shiti.ktid=kaoti.id "+
                " and kaoti.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ";
            //if(ktid !=-1)
            {
                sql += " and shiti.ktid=" + ktid + " ";
            }
            sql += " order by Id asc";

             DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Shiti> list = new List<Shiti>();
            foreach (DataRow dr in dt.Rows)
            {
                Shiti st = new Shiti();
                st.Id = Convert.ToInt32(dr["Id"].ToString());
                st.Question = dr["question"].ToString();
                st.KaotiID = Convert.ToInt32(dr["ktid"].ToString());
                st.KaotiIndex = Convert.ToInt32(dr["ktindex"].ToString());
                st.Weight = Convert.ToInt32(dr["weight"]);
                st.StTime = Convert.ToInt32(dr["sttime"]);
                list.Add(st);
            }
            return list;
        }

         public static Shiti GetShitiById(int stid = -1)
         {
             String sql = "select shiti.id as Id,question,ktid,ktindex,weight,sttime from shiti,kaoti where shiti.ktid=kaoti.id and kaoti.ktstate=1 ";
             if (stid !=-1)
             {
                 sql += " and shiti.id=" + stid + "";
             }
            else
            {
                return null;
            }
             DataTable dt = MySqlDBHelper.GetDataSet(sql);
             Shiti st = new Shiti();
             foreach (DataRow dr in dt.Rows)
             {
                // Shiti st = new Shiti();
                 st.Id = Convert.ToInt32(dr["Id"].ToString());
                 st.Question = dr["question"].ToString();
                 st.KaotiID = Convert.ToInt32(dr["ktid"].ToString());
                 st.KaotiIndex = Convert.ToInt32(dr["ktindex"].ToString());
                 st.Weight = Convert.ToInt32(dr["weight"]);
                 st.StTime = Convert.ToInt32(dr["sttime"]);
                 return st;
             }
             return null;
         }


         public static int getShitiWeightsInkaoti(int ktid = -1, int seceptid = -1)
         {
             String sql = "select SUM(weight) from kaoti,shiti where kaoti.ktstate=1 and shiti.ktid=kaoti.id ";

             int weight_sum = 0;
             if (ktid != -1)
             {
                 sql += " and shiti.ktid=" + ktid + " ";
             }
             if(seceptid !=-1)
             {
                 sql += " and shiti.id <> "+seceptid;
             }

             DataTable dt = MySqlDBHelper.GetDataSet(sql);
            if(dt.Rows.Count >0)
            {
                if(dt.Rows[0][0].ToString()!="")
                {
                    weight_sum = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            return weight_sum;
         }

         public static int UpdateWeight_Time(int id, int new_weight, int new_time)
         {
             String sql = "update shiti set weight=@weight,sttime=@sttime where id=@id";
             List<MySqlParameter> para_list = new List<MySqlParameter>();
             para_list.Add(new MySqlParameter("@id", id));
             para_list.Add(new MySqlParameter("@weight", new_weight));
             para_list.Add(new MySqlParameter("@sttime", new_time));
            
             return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
         }

         public static int Update(Shiti st)
         {
             String sql = "update shiti set question=@question,weight=@weight,sttime=@sttime where id=@id";
             List<MySqlParameter> para_list = new List<MySqlParameter>();
             para_list.Add(new MySqlParameter("@id", st.Id));

             para_list.Add(new MySqlParameter("@question", st.Question));
             //para_list.Add(new MySqlParameter("@ktid", st.KaotiID));
             para_list.Add(new MySqlParameter("@weight", st.Weight));
             para_list.Add(new MySqlParameter("@sttime", st.StTime));

             return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
         }

    }
}
