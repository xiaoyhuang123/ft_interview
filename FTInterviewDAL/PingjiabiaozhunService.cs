using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class PingjiabiaozhunService
    {

        public static int Add ( Pingjiabiaozhun pjbz )
        {
            String sql = "insert into pingjiabiaozhun(content,pjxdid,ckscore) values(@content,@pjxdid,@ckscore)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@content", pjbz.Content));
            para_list.Add(new MySqlParameter("@pjxdid", pjbz.PjxdID));
            para_list.Add(new MySqlParameter("@ckscore", pjbz.CkScore));

            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

         public static List<Pingjiabiaozhun> GetAll()
        {
            String sql = "select * from pingjiabiaozhun ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Pingjiabiaozhun> list = new List<Pingjiabiaozhun>();
            foreach (DataRow dr in dt.Rows)
            {
                Pingjiabiaozhun st = new Pingjiabiaozhun();
                st.Id = Convert.ToInt32(dr["id"].ToString());
                st.Content = dr["content"].ToString();
                st.CkScore = Convert.ToInt32(dr["ckscore"].ToString());
                st.PjxdID = Convert.ToInt32(dr["pjxdid"].ToString());
                list.Add(st);
            }
            return list;
        }

         public static int Update(Pingjiabiaozhun pjbz)
         {
             String sql = "update pingjiabiaozhun set content=@content,ckscore=@ckscore where id=@id";
             List<MySqlParameter> para_list = new List<MySqlParameter>();
             para_list.Add(new MySqlParameter("@id", pjbz.Id));
             para_list.Add(new MySqlParameter("@content", pjbz.Content));
             para_list.Add(new MySqlParameter("@score", pjbz.CkScore));

             return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
         }

         public static Pingjiabiaozhun GetPXBZbyId(int bzid)
         {
             String sql = "select * from pingjiabiaozhun where id=" + bzid;
             DataTable dt = MySqlDBHelper.GetDataSet(sql);
             Pingjiabiaozhun st = new Pingjiabiaozhun();
             foreach (DataRow dr in dt.Rows)
             {
                 st.Id = Convert.ToInt32(dr["id"].ToString());
                 st.Content = dr["content"].ToString();
                 st.CkScore = Convert.ToInt32(dr["ckscore"].ToString());
                 return st;
             }
             return null;
         }


         public static int DeleteByID(int _id)
         {
             String sql = "delete from pingjiabiaozhun where id=@id";
             List<MySqlParameter> para_list = new List<MySqlParameter>();
             para_list.Add(new MySqlParameter("@id", _id));
             return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
         }
    }

}
