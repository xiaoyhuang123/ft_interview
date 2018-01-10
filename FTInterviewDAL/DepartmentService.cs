using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class DepartmentService
    {
        public static int Add ( Department department )
        {
            string sqlstr = "";
            StringBuilder sb = new StringBuilder();

            sb.Append("select id from department where departname=").Append("'").Append(department.Name).Append("' and bmstate=1;");
            sqlstr = sb.ToString();
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            if (dt.Rows.Count > 0) 
            { return -1; }

            sqlstr = "insert into department(departname,info,bmstate) values(@name,@info,@bmstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add ( new MySqlParameter ( "@name", department.Name ) );
            para_list.Add ( new MySqlParameter ( "@info", department.Info ) );
            para_list.Add(new MySqlParameter("@bmstate", 1));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());

        }

        public static int Delete(int d_id)//真删
        {
            string sqlstr = "delete from department where id=" + d_id;
            return MySqlDBHelper.ExecuteCommand(sqlstr);
        }
        public static int DeleteDepartMent(int did)//假删
        {
            String sqlstr = "update department set bmstate=@bmstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@id", did)); int s = 0;
            para_list.Add(new MySqlParameter("@bmstate", s));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static List<Department> GetAllDepartment()
        {
            String sqlstr = "select * from department";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);

            List<Department> list = new List<Department>();
            if (dt.Rows.Count < 1)
            {
                return list;
            }
            foreach ( DataRow dr in dt.Rows )
            {
                Department department = new Department();
                department.Id = ( int ) dr["id"];
                department.Name = dr["departname"].ToString();
                department.Info = dr["info"].ToString();
                list.Add ( department );
            }
            return list;
        }

        public static List<Department> GetDepartmentByName(string depname)
        {
            String sqlstr = "select * from department where bmstate=1 ";
            if (depname !=""&& depname !=null)
            {
                sqlstr += " and departname Like '%" + depname + "%'";
            }
            //String sqlstr = "select * from department where bmstate=1 and departname='"+depname+"'";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
           
            List<Department> list = new List<Department>();
            if (dt.Rows.Count <1)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                Department department = new Department();
                department.Id = (int)dr["id"];
                department.Name = dr["departname"].ToString();
                department.Info = dr["info"].ToString();
                department.Bmstate = Convert.ToInt32(dr["bmstate"].ToString());
                list.Add(department);
            }
            return list;
        }

        public static Department GetDepartmentByID(int dep_id)
        {
            String sql = "select * from department where bmstate=1 and id="+dep_id ;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            Department department = new Department();
            foreach (DataRow dr in dt.Rows)
            {
                department.Id = (int)dr["id"];
                department.Name = dr["departname"].ToString();
                department.Info = dr["info"].ToString();
                department.Bmstate = Convert.ToInt32(dr["bmstate"].ToString());
                break;
            }
            return department;
        }

        public static int UpdateDepartment(Department department)
        {
            String sqlstr = "update department set departname=@departname,info=@info where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@id",department.Id)) ;
            para_list.Add(new MySqlParameter("@departname", department.Name));
            para_list.Add(new MySqlParameter("@info", department.Info));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());

        }
    }
}
