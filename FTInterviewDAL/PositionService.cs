using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class PositionService
    {

        public static int Add(Position p)
        {
            String sql = "insert into gwposition(positionname) values(@positionname)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@positionname", p.PositionName));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static List<Position> GetAllPosition()
        {
            String sql = "select * from gwposition";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Position> list = new List<Position>();

            foreach (DataRow dr in dt.Rows)
            {
                Position ps = new Position();
                ps.Id = (int)dr["id"];
                ps.PositionName = dr["positionname"].ToString();
                list.Add(ps);
            }
            return list;
        }

        public static int GetPositionIDbyName(string gwname)
        {
            int positionid=-1;
            String sqlstr = "select id from gwposition where positionname='" + gwname + "'";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                positionid = Convert.ToInt32(dr["id"].ToString());
            }
            return positionid;
        }

    }
}
