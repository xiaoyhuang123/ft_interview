using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class KaoguanService
    {
        public static int Add(Kaoguan kaoguan)
        {
            String sql = "insert into kaoguan(workid,name,depart,position,company,password,kgstate) values(@workid,@name,@depart,@position,@company,@password,@kgstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@workid", kaoguan.WorkID));
            para_list.Add(new MySqlParameter("@name", kaoguan.Name));
            para_list.Add(new MySqlParameter("@depart", kaoguan.DepID));
            para_list.Add(new MySqlParameter("@position", kaoguan.PositionName));
            para_list.Add(new MySqlParameter("@company", kaoguan.Company));
            para_list.Add(new MySqlParameter("@password", kaoguan.Pwd));

            para_list.Add(new MySqlParameter("@kgstate", 1));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static List<Kaoguan> GetAllKaoguan()
        {
            String sql = "select kaoguan.*,department.departname from kaoguan,department" +
                " where kaoguan.depart=department.id and kaoguan.kgstate=1"+
                " and department.bmstate=1 " + " order by department.id asc";
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            List<Kaoguan> list = new List<Kaoguan>();
            if (dt.Rows.Count < 1)
            {
                return list;
            }
            foreach ( DataRow dr in dt.Rows )
            {
                Kaoguan kg = new Kaoguan();
                kg.Id = (int)dr["id"];
                kg.WorkID = dr["workid"].ToString();
                kg.Name = dr["name"].ToString();
                kg.DepID =Convert.ToInt32(dr["depart"].ToString());
                kg.PositionName = dr["position"].ToString();
                kg.Company = dr["company"].ToString();
                kg.Pwd = dr["password"].ToString();
               
                kg.DepName=dr["departname"].ToString();
                list.Add(kg);
            }
            return list;
        }

        public static Kaoguan GetKaoguanByID(int id)
        {
            String sql = "select kaoguan.*,department.departname from kaoguan,department where kaoguan.depart=department.id and kaoguan.kgstate=1 and kaoguan.id=" + id;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            if (dt.Rows.Count < 1)
            {
                return null;
            }

            Kaoguan kg = new Kaoguan();
            bool falg = false;
            foreach (DataRow dr in dt.Rows)
            {
                kg.Id = (int)dr["id"];
                kg.WorkID = dr["workid"].ToString();
                kg.Name = dr["name"].ToString();
                kg.DepID = Convert.ToInt32(dr["depart"].ToString());
                kg.PositionName = dr["position"].ToString();
                kg.Company = dr["company"].ToString();
                kg.Pwd = dr["password"].ToString();

                kg.DepName=dr["departname"].ToString();
                falg = true;
                break;
            }
            if (falg)
            { return kg; }
            return null;
        }

        public static int UpdateKaoguan(Kaoguan kg)
        {
            String sql = "update kaoguan set workid=@workid,name=@name,depart=@depart,position=@position,company=@company,password=@password where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@workid", kg.WorkID));
            para_list.Add(new MySqlParameter("@name", kg.Name));
            para_list.Add(new MySqlParameter("@depart", kg.DepID));
            para_list.Add(new MySqlParameter("@position", kg.PositionName));
            para_list.Add(new MySqlParameter("@company", kg.Company));
            para_list.Add(new MySqlParameter("@password", kg.Pwd));

            para_list.Add(new MySqlParameter("@id", kg.Id));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int Delete(int id)
        {
            String sqlstr = "delete from kaoguan where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }
        public static int DeleteKaoguan(int id)
        {
            String sql = "update kaoguan set kgstate=@kgstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@id", id));
            int s = 0;
            para_list.Add(new MySqlParameter("@kgstate", s));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static List<Kaoguan> GetKaoguanByParameters(int depid = -1, string kgname = "")
        {
            String sql = "select kaoguan.*,department.departname from kaoguan,department " +
                " where kaoguan.depart=department.id and kaoguan.kgstate=1 "+
                " and department.bmstate=1 ";

            List<string> condi = new List<string>();
            if (depid != -1)
            {
                sql +=" and department.id=" + depid ;
            }
            if (kgname != "")
            {
                sql +=" and kaoguan.name like '%" + kgname + "%' ";
            }
           
            sql += " order by department.id asc";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Kaoguan> list = new List<Kaoguan>();
            if (dt.Rows.Count <1)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                Kaoguan kg = new Kaoguan();
                kg.Id = (int)dr["id"];
                kg.WorkID = dr["workid"].ToString();
                kg.Name = dr["name"].ToString();
                kg.DepID = Convert.ToInt32(dr["depart"].ToString());
                kg.PositionName = dr["position"].ToString();
                kg.Company = dr["company"].ToString();
                kg.Pwd = dr["password"].ToString();

                kg.DepName=dr["departname"].ToString();
                list.Add(kg);
            }
            return list;
        }

        public static int UpdataPassword(int id,string pwd)
        {
            String sql = "update kaoguan set password=@password where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@id", id));
            para_list.Add(new MySqlParameter("@password", pwd));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

         public static List<Kaoguan> GetAllKaoguanByZp(int zpid=-1,bool in_zp=true)
        {

            String sql = "select kaoguan.*,department.departname from kaoguan,department where kaoguan.depart=department.id and kaoguan.kgstate=1 " +
                " and kaoguan.id not in (select distinct kgid from kaoguanzhaopin where zpid="+zpid+")";

            sql += " order by department.id asc";
             DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            List<Kaoguan> list = new List<Kaoguan>();
            if (dt.Rows.Count < 1)
            {
                return list;
            }

            foreach ( DataRow dr in dt.Rows )
            {
                Kaoguan kg = new Kaoguan();
                kg.Id = (int)dr["id"];
                kg.WorkID = dr["workid"].ToString();
                kg.Name = dr["name"].ToString();
                kg.DepID =Convert.ToInt32(dr["depart"].ToString());
                kg.PositionName = dr["position"].ToString();
                kg.Company = dr["company"].ToString();
                kg.Pwd = dr["password"].ToString();
               
                kg.DepName=dr["departname"].ToString();
                list.Add(kg);
            }
            return list;
        }

         public static Kaoguan FindKaoGuan(string name, string password)
         {
             String sql = "select kaoguan.*,department.departname from kaoguan,department where kaoguan.depart=department.id and kaoguan.kgstate=1 and kaoguan.name='" + name + "' and password='" + password + "'";
             DataTable dt = MySqlDBHelper.GetDataSet(sql);
             if (dt.Rows.Count < 1)
             {
                 return null;
             }

             Kaoguan kg = new Kaoguan();
             bool falg = false;
             foreach (DataRow dr in dt.Rows)
             {
                 kg.Id = (int)dr["id"];
                 kg.WorkID = dr["workid"].ToString();
                 kg.Name = dr["name"].ToString();
                 kg.DepID = Convert.ToInt32(dr["depart"].ToString());
                 kg.PositionName = dr["position"].ToString();
                 kg.Company = dr["company"].ToString();
                 kg.Pwd = dr["password"].ToString();

                 kg.DepName = dr["departname"].ToString();
                 falg = true;
                 break;
             }
             if (falg)
             { return kg; }
             return null;
         }
    }
}
