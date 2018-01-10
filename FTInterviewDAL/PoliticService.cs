using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class PoliticService
    {

        public static int Add(Politic politic)
        {
            String sql = "insert into politic(politicname) values(@politicname)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@politicname", politic.PoliticName));
            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

        public static List<Politic> GetAllPolitic()
        {
            String sql = "select * from politic";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            List<Politic> list = new List<Politic>();
            foreach ( DataRow dr in dt.Rows )
            {
                Politic pic = new Politic();
                pic.ID =Convert.ToInt32( dr["id"]);
                pic.PoliticName = dr["politicname"].ToString();
                list.Add ( pic );
            }
            return list;
        }

    }
}
