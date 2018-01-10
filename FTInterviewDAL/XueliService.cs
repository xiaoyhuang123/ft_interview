using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class XueliService
    {
        public static int Add(Xueli xl)
        {
            String sql = "insert into Xueli(degreename) values(@degreename)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@degreename", xl.XueliName));
            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

        public static List<Xueli> GetAll()
        {
            String sql = "select * from Xueli";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            List<Xueli> list = new List<Xueli>();
            foreach ( DataRow dr in dt.Rows )
            {
                Xueli xl = new Xueli();
                xl.ID =Convert.ToInt32( dr["id"]);
                xl.XueliName = dr["degreename"].ToString();
                list.Add ( xl );
            }
            return list;
        }

    }
}
