using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class ZhaopinGwService
    {
        public static int Add(ZhaopinGw zpgw)
        {
            String sqlstr = "insert into zpgw(zpbm,zppos) values(@zpbm,@zppos)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@zpbm", zpgw.ZpDepart));
            para_list.Add(new MySqlParameter("@zppos", zpgw.ZpPosition));

            if (GetZhaopinGwID(zpgw.ZpDepart,zpgw.ZpPosition) == -1)
            {
                return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
            }
            return -1;
        }

        public static int Update(ZhaopinGw zpgw)
        {
            String sqlstr = "update zpgw set zpbm=@zpbm,zppos=@zppos";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@zpbm", zpgw.ZpDepart));
            para_list.Add(new MySqlParameter("@zppos", zpgw.ZpPosition));
             para_list.Add(new MySqlParameter("@id", zpgw.Id));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int DeleteZhaopinGw(int id)
        {
            String sql = "delete from zpgw where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
      
        public static DataTable GetAllZhaopinGw(int dep=-1,string pos="")
        {
            string sqlstr = "select zpgw.id as Id," +
                            "zpgw.zpbm as ZpBmID,"+
                          "department.departname as Zpbm," +
                          "zpgw.zppos as Zppos " +
                         "from zpgw,department  where zpgw.zpbm=department.id and department.bmstate=1 ";
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }

        public static List<ZhaopinGw> GetAllZhaopinGwList(int dep = -1, string pos = "")
        {
            DataTable dt = GetAllZhaopinGw(dep, pos);
            List<ZhaopinGw> ls = new List<ZhaopinGw>();
            foreach (DataRow dr in dt.Rows)
            {
                ZhaopinGw zg = new ZhaopinGw();
                zg.Id = Convert.ToInt32(dr["Id"]);
                zg.ZpDepart =  Convert.ToInt32(dr["ZpBmID"].ToString());
                zg.ZpPosition = dr["Zppos"].ToString();

                zg.ZpBmName = dr["Zpbm"].ToString();
                ls.Add(zg);
            }
            return ls;
        }

        public static ZhaopinGw GetZhaopinGwByid(int id)
        {
            string sqlstr = "select zpgw.id as Id,zpgw.zpbm,department.departname,zpgw.zppos "+
                " from zpgw,department where zpgw.zpbm=department.id and department.bmstate=1 and zpgw.id =" + id;

            ZhaopinGw zg = new ZhaopinGw();
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                zg.Id =Convert.ToInt32(dr["Id"].ToString());
                zg.ZpDepart =(int)dr["zpbm"];

                zg.ZpBmName = dr["departname"].ToString();

                zg.ZpPosition = dr["zppos"].ToString();
               
                return zg;
            }
            return null;
        }

        public static int GetZhaopinGwID(int depid,string posname)
        {
            String sqlstr = "select zpgw.id from zpgw,department "+
                " where zpgw.zpbm=department.id and department.bmstate=1 and zpbm=@zpbm and zppos=@zppos";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@zpbm", depid));
            para_list.Add(new MySqlParameter("@zppos", posname));

           DataTable dt= MySqlDBHelper.GetDataSet(sqlstr, para_list.ToArray());
           if (dt.Rows.Count==1)
            {
                return (int)dt.Rows[0][0];
            }
           else
           {
               return -1;
           }

        }
    }
}
