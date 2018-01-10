using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;



namespace FTInterviewDAL
{
    public class XiangdianBiaozhunService
    {
        public static int Add(Xiangdianbiaozhun xb)
        {
            String sql = "insert into xdbz(xdid,bzid,mycontent) values(@xdid,@bzid,@mycontent)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@xdid", xb.PjxdID));
            para_list.Add(new MySqlParameter("@bzid", xb.PjbzID));
            para_list.Add(new MySqlParameter("@mycontent", xb.MyContent));

            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

        public static List<Xiangdianbiaozhun> GetAll()
        {
            String sql = "select * from xdbz order by xdid,bzid ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Xiangdianbiaozhun> list = new List<Xiangdianbiaozhun>();
            foreach (DataRow dr in dt.Rows)
            {
                Xiangdianbiaozhun st = new Xiangdianbiaozhun();
                st.Id = Convert.ToInt32(dr["id"].ToString());
                st.PjxdID =  Convert.ToInt32(dr["xdid"].ToString());
                st.PjbzID = Convert.ToInt32(dr["bzid"].ToString());
                st.MyContent = dr["mycontent"].ToString();
                list.Add(st);
            }
            return list;
        }

        public static int Update(Xiangdianbiaozhun xb)
        {
            String sql = "update xdbz set mycontent=@mycontent where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", xb.Id));
            para_list.Add(new MySqlParameter("@mycontent", xb.MyContent));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static Xiangdianbiaozhun GetXDBZby2id(int xd_id,int bz_id)
        {
            String sql = "select * from xdbz where xdid="+xd_id+" and bzid="+bz_id+" ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            Xiangdianbiaozhun list = new Xiangdianbiaozhun();
            foreach (DataRow dr in dt.Rows)
            {
                Xiangdianbiaozhun st = new Xiangdianbiaozhun();
                st.Id = Convert.ToInt32(dr["id"].ToString());
                st.PjxdID = Convert.ToInt32(dr["xdid"].ToString());
                st.PjbzID = Convert.ToInt32(dr["bzid"].ToString());
                st.MyContent = dr["mycontent"].ToString();
                return st;
            }
            return list;
        }

        public static int DeleteByID(int _id)
        {
            String sql = "delete from xdbz where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", _id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int DeleteByXDID(int _id)
        {
            String sql = "delete from xdbz where xdid=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", _id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
        public static int DeleteByBZID(int _id)
        {
            String sql = "delete from xdbz where bzid=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", _id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
    }
}
