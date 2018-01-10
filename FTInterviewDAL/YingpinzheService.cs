using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace FTInterviewDAL
{
    public class YingpinzheService
    {
        public static int Add ( Yingpinzhe ypz )
        {
            String sql = "insert into yingpinzhe(name,sex,birthday,jointime,xueli,departid,dutyname,politic,company,zpfbid,ypzstate) values(@name,@sex,@birthday,@jointime,@xueli,@departid,@dutyname,@politic,@company,@zpfbid,@ypzstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();

            para_list.Add(new MySqlParameter("@name", ypz.Name));
            para_list.Add(new MySqlParameter("@sex", ypz.Sex));
            para_list.Add(new MySqlParameter("@birthday", ypz.Birthday));
            para_list.Add(new MySqlParameter("@jointime", ypz.JoinTime));
            para_list.Add(new MySqlParameter("@xueli", ypz.XueliId));
            para_list.Add(new MySqlParameter("@politic", ypz.PoliticId));
            para_list.Add(new MySqlParameter("@departid", ypz.DepartId));
            para_list.Add(new MySqlParameter("@dutyname", ypz.PositionName));
            para_list.Add(new MySqlParameter("@company", ypz.Company));
            para_list.Add(new MySqlParameter("@zpfbid", ypz.ZpfbId));
            para_list.Add(new MySqlParameter("@ypzstate", 1));
            
            return MySqlDBHelper.ExecuteCommand ( sql,para_list.ToArray() );
        }

        public static int Delete(int id)
        {
            String sql = "delete from yingpinzhe where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
        public static int DeleteYingpinzheByID(int id)
        {
            String sql = "update yingpinzhe set ypzstate=@ypzstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            int s = 0;
            para_list.Add(new MySqlParameter("@ypzstate", s));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int Update ( Yingpinzhe ypz )
        {
            String sql = "update yingpinzhe set name=@name,sex=@sex,birthday=@birthday,jointime=@jointime,xueli=@xueli,departid=@departid,dutyname=@dutyname,politic=@politic,company=@company,zpfbid=@zpfbid where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", ypz.ID));

            para_list.Add(new MySqlParameter("@name", ypz.Name));
            para_list.Add(new MySqlParameter("@sex", ypz.Sex));
            para_list.Add(new MySqlParameter("@birthday", ypz.Birthday));
            para_list.Add(new MySqlParameter("@jointime", ypz.JoinTime));
            para_list.Add(new MySqlParameter("@xueli", ypz.XueliId));
            para_list.Add(new MySqlParameter("@politic", ypz.PoliticId));
            para_list.Add(new MySqlParameter("@departid", ypz.DepartId));
            para_list.Add(new MySqlParameter("@dutyname", ypz.PositionName));

            para_list.Add(new MySqlParameter("@zpfbid", ypz.ZpfbId));
           
            para_list.Add(new MySqlParameter("@company", ypz.Company));
            return MySqlDBHelper.ExecuteCommand ( sql, para_list.ToArray() );
        }

        //hhy
        public static List<Yingpinzhe> GetAllYingpinzheInZpItem(int itemid=-1)//hhy
        {
            String sql = "select yingpinzhe.id as Id, " +
                "yingpinzhe.name," +
                "yingpinzhe.sex," +
                "yingpinzhe.birthday," +
                "yingpinzhe.jointime," +
                "yingpinzhe.xueli as XueliId," +
                "xueli.degreename as XueName," +
                "yingpinzhe.departid as DepId," +
                "department.departname as DepName," +
                "yingpinzhe.dutyname," +
                "yingpinzhe.politic as PoliId," +
                "politic.politicname as PoliName," +
                "yingpinzhe.company," +
                "yingpinzhe.zpfbid as ZpfbId " +
                " from yingpinzhe,department,xueli,politic,zpfb,zhaopinitem " +
                " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id "+
                "and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 "+
                "  and yingpinzhe.zpfbid=zpfb.id and zpfb.fbstate=1 "+
                " and zpfb.zpitmid=zhaopinitem.id and zhaopinitem.zpitemstate=1";

            if (itemid!=-1)
            {
                sql += " and  zhaopinitem.id="+itemid;
            }
            sql += " order by ZpfbId asc,department.id ";

            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");

            sql = "select zpfb.id as Id,department.departname,zpgw.zppos " +
                "from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.zpbm=department.id and department.bmstate=1";

            DataTable ypgwdt = MySqlDBHelper.GetDataSet(sql);
            ypgwdt.PrimaryKey = new System.Data.DataColumn[] { ypgwdt.Columns["Id"] };

            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach (DataRow dr in dt.Rows)
            {
                Yingpinzhe ypz = new Yingpinzhe();
                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["name"].ToString();
                ypz.Sex = dr["sex"].ToString();

                DateTime date = (DateTime)dr["birthday"];
                ypz.Birthday = date.ToShortDateString();
                date = (DateTime)dr["jointime"];
                ypz.JoinTime = date.ToShortDateString();
                ypz.DepartId = Convert.ToInt32(dr["DepId"].ToString());
                ypz.PositionName = dr["dutyname"].ToString();
                ypz.XueliId = (int)dr["XueliId"];
                ypz.PoliticId = (int)dr["PoliId"];
                ypz.Company = dr["company"].ToString();

                ypz.ZpfbId = (int)dr["ZpfbId"];

                DataRow ddr = ypgwdt.Rows.Find(ypz.ZpfbId);

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["XueName"].ToString();

                ypz.YpDepName = ddr["departname"].ToString();
                ypz.YpPosName = ddr["zppos"].ToString();
                list.Add(ypz);
            }
            return list;
        }
         //hhy
        public static List<Yingpinzhe> GetYingpinzheInZpItemByParameters(int itemid = -1, string name = "", int dep = -1)
        {
            String sql = "select yingpinzhe.id as Id, " +
               "yingpinzhe.name," +
               "yingpinzhe.sex," +
               "yingpinzhe.birthday," +
               "yingpinzhe.jointime," +
               "yingpinzhe.xueli as XueliId," +
               "xueli.degreename as XueName," +
               "yingpinzhe.departid as DepId," +
               "department.departname as DepName," +
               "yingpinzhe.dutyname," +
               "yingpinzhe.politic as PoliId," +
               "politic.politicname as PoliName," +
               "yingpinzhe.company," +
               "yingpinzhe.zpfbid as ZpfbId " +
               " from yingpinzhe,department,xueli,politic,zpfb,zhaopinitem " +
               " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id " +
               "and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 " +
               "  and yingpinzhe.zpfbid=zpfb.id and zpfb.fbstate=1 " +
               " and zpfb.zpitmid=zhaopinitem.id and zhaopinitem.zpitemstate=1";

            if (itemid != -1)
            {
                sql += " and  zhaopinitem.id=" + itemid;
            }
            if (name != "")
            {
                  sql +=" and yingpinzhe.name like '%" + name + "%' ";
            }
            if (dep != -1)
            {
                 sql +=" and yingpinzhe.departid=" + dep ;
            }

            sql += " order by ZpfbId asc,department.id ";

            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");

            sql = "select zpfb.id as Id,department.departname,zpgw.zppos " +
                "from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.zpbm=department.id and department.bmstate=1";

            DataTable ypgwdt = MySqlDBHelper.GetDataSet(sql);
            ypgwdt.PrimaryKey = new System.Data.DataColumn[] { ypgwdt.Columns["Id"] };

            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach (DataRow dr in dt.Rows)
            {
                Yingpinzhe ypz = new Yingpinzhe();
                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["name"].ToString();
                ypz.Sex = dr["sex"].ToString();

                DateTime date = (DateTime)dr["birthday"];
                ypz.Birthday = date.ToShortDateString();
                date = (DateTime)dr["jointime"];
                ypz.JoinTime = date.ToShortDateString();
                ypz.DepartId = Convert.ToInt32(dr["DepId"].ToString());
                ypz.PositionName = dr["dutyname"].ToString();
                ypz.XueliId = (int)dr["XueliId"];
                ypz.PoliticId = (int)dr["PoliId"];
                ypz.Company = dr["company"].ToString();

                ypz.ZpfbId = (int)dr["ZpfbId"];

                DataRow ddr = ypgwdt.Rows.Find(ypz.ZpfbId);

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["XueName"].ToString();

                ypz.YpDepName = ddr["departname"].ToString();
                ypz.YpPosName = ddr["zppos"].ToString();
                list.Add(ypz);
            }
            return list;
        }

        public static List<Yingpinzhe>GetAllYingpinzhe()
        {
            String sql = "select yingpinzhe.id as Id, "+
                "yingpinzhe.name,"+
                "yingpinzhe.sex,"+
                "yingpinzhe.birthday,"+
                "yingpinzhe.jointime,"+
                "yingpinzhe.xueli as XueliId,"+
                "xueli.degreename as XueName," +
                "yingpinzhe.departid as DepId,"+
                "department.departname as DepName,"+
                "yingpinzhe.dutyname,"+
                "yingpinzhe.politic as PoliId,"+
                "politic.politicname as PoliName,"+
                "yingpinzhe.company,"+
                "yingpinzhe.zpfbid as ZpfbId " +
                " from yingpinzhe,department,xueli,politic "+
                " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 ";

            sql += " order by ZpfbId asc,department.id ";
            
            DataTable dt = MySqlDBHelper.GetDataSet ( sql );
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");

            sql = "select zpfb.id as Id,department.departname,zpgw.zppos " +
                "from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.zpbm=department.id and department.bmstate=1";

            DataTable ypgwdt = MySqlDBHelper.GetDataSet(sql);
            ypgwdt.PrimaryKey = new System.Data.DataColumn[] { ypgwdt.Columns["Id"]};

            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach ( DataRow dr in dt.Rows )
            {
                Yingpinzhe ypz = new Yingpinzhe();
                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["name"].ToString();
                ypz.Sex = dr["sex"].ToString();

                DateTime date = (DateTime)dr["birthday"];
                ypz.Birthday = date.ToShortDateString();
                date = (DateTime)dr["jointime"];
                ypz.JoinTime = date.ToShortDateString();
                ypz.DepartId = Convert.ToInt32(dr["DepId"].ToString());
                ypz.PositionName=dr["dutyname"].ToString();
                ypz.XueliId = (int)dr["XueliId"];
                ypz.PoliticId = (int)dr["PoliId"];
                ypz.Company = dr["company"].ToString();

                ypz.ZpfbId = (int)dr["ZpfbId"];

                DataRow ddr = ypgwdt.Rows.Find(ypz.ZpfbId);

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["XueName"].ToString();

                ypz.YpDepName = ddr["departname"].ToString();
                ypz.YpPosName = ddr["zppos"].ToString();
                list.Add(ypz);
            }
            return list;
        }

        public static Yingpinzhe GetYingpinzheById ( int id )
        {
            String sql = "select yingpinzhe.id as Id, " +
               "yingpinzhe.name," +
                "yingpinzhe.sex," +
                "yingpinzhe.birthday," +
                "yingpinzhe.jointime," +
                "yingpinzhe.xueli as XueliId," +
                "xueli.degreename as XueName," +
                "yingpinzhe.departid as DepId," +
                "department.departname as DepName," +
                "yingpinzhe.dutyname," +
                "yingpinzhe.politic as PoliId," +
                "politic.politicname as PoliName," +
                "yingpinzhe.company," +
                "yingpinzhe.zpfbid as ZpfbId " +
               " from yingpinzhe,department,xueli,politic " +
               " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 and yingpinzhe.id=" + id;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");

            //sql = "select zpgw.id as Id,department.departname,zpgw.zppos from department,zpgw where zpgw.zpbm=department.id and department.bmstate=1";
            sql = "select zpfb.id as Id,department.departname,zpgw.zppos " +
               "from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.zpbm=department.id and department.bmstate=1";

            DataTable ypgwdt = MySqlDBHelper.GetDataSet(sql);
            ypgwdt.PrimaryKey = new System.Data.DataColumn[] { ypgwdt.Columns["Id"] };

            Yingpinzhe ypz = new Yingpinzhe();
            foreach (DataRow dr in dt.Rows)
            {
                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["name"].ToString();
                ypz.Sex = dr["sex"].ToString();

                DateTime date = (DateTime)dr["birthday"];
                ypz.Birthday = date.ToShortDateString();
                date = (DateTime)dr["jointime"];
                ypz.JoinTime = date.ToShortDateString();
                ypz.DepartId = Convert.ToInt32(dr["DepId"].ToString());
                ypz.PositionName = dr["dutyname"].ToString();
                ypz.XueliId = (int)dr["XueliId"];
                ypz.PoliticId = (int)dr["PoliId"];
                ypz.Company = dr["company"].ToString();

                ypz.ZpfbId = (int)dr["ZpfbId"];

                DataRow ddr = ypgwdt.Rows.Find(ypz.ZpfbId);

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["XueName"].ToString();
                ypz.PolName = dr["PoliName"].ToString();

                ypz.YpDepName = ddr["departname"].ToString();
                ypz.YpPosName = ddr["zppos"].ToString();

                return ypz;
            }
            return null;
        }

        public static List<Yingpinzhe> GetYingpinzheByParameters(string name = "",  int dep =-1)
        {
            String sql = "select yingpinzhe.id as Id, " +
                "yingpinzhe.name," +
                "yingpinzhe.sex," +
                "yingpinzhe.birthday," +
                "yingpinzhe.jointime," +
                "yingpinzhe.xueli as XueliId," +
                "xueli.degreename as XueName," +
                "yingpinzhe.departid as DepId," +
                "department.departname as DepName," +
                "yingpinzhe.dutyname," +
                "yingpinzhe.politic as PoliId," +
                "politic.politicname as PoliName," +
                "yingpinzhe.company," +
                "yingpinzhe.zpfbid as ZpfbId " +
                " from yingpinzhe,department,xueli,politic " +
                " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 ";
            List<string> condi = new List<string>();
            if(name !="")
            {
                condi.Add(" yingpinzhe.name like '%"+name+"%' ");
            }
            if(dep !=-1)
            {
                condi.Add(" yingpinzhe.departid=" + dep + " ");
            }
            if (condi.Count >= 1)
            {
                int s = condi.Count;
                for (int i = 0; i < s;i++ )
                {
                        sql +=" and "+condi[i] + " ";
                }
            }

            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");
            //sql = "select zpgw.id as Id,department.departname,zpgw.zppos from department,zpgw where zpgw.zpbm=department.id and department.bmstate=1";
            sql = "select zpfb.id as Id,department.departname,zpgw.zppos " +
              "from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 and zpgw.zpbm=department.id and department.bmstate=1";


            DataTable ypgwdt = MySqlDBHelper.GetDataSet(sql);
            ypgwdt.PrimaryKey = new System.Data.DataColumn[] { ypgwdt.Columns["Id"] };

            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach (DataRow dr in dt.Rows)
            {
                Yingpinzhe ypz = new Yingpinzhe();
                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["name"].ToString();
                ypz.Sex = dr["sex"].ToString();

                DateTime date = (DateTime)dr["birthday"];
                ypz.Birthday = date.ToShortDateString();
                date = (DateTime)dr["jointime"];
                ypz.JoinTime = date.ToShortDateString();
                ypz.DepartId = Convert.ToInt32(dr["DepId"].ToString());
                ypz.PositionName = dr["dutyname"].ToString();
                ypz.XueliId = (int)dr["XueliId"];
                ypz.PoliticId = (int)dr["PoliId"];
                ypz.Company = dr["company"].ToString();

                ypz.ZpfbId = (int)dr["ZpfbId"];

                DataRow ddr = ypgwdt.Rows.Find(ypz.ZpfbId);

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["XueName"].ToString();
                ypz.PolName = dr["PoliName"].ToString();

                ypz.YpDepName = ddr["departname"].ToString();
                ypz.YpPosName = ddr["zppos"].ToString();

                list.Add(ypz);
            }
            return list;
        }


        //hhy
        public static List<Yingpinzhe> GetAllYingpinzheByZp(int zpid = -1, bool in_zp = true)
        {
            String sql = "select yingpinzhe.id as Id, " +
                "yingpinzhe.name as Name," +
                "department.departname as DepName," +
                "yingpinzhe.dutyname as DutyName, " +
                "xueli.degreename as DegreeName,"+
                "yingpinzhe.jointime as JinTime," +
                "politic.politicname as PolName "+
                "from yingpinzhe,department,xueli,politic,zhaopin,zpfb,zpgw " +
                "where yingpinzhe.departid=department.id and department.bmstate=1 and yingpinzhe.ypzstate=1 " +
                " and zhaopin.zpfbid=zpfb.id and zhaopin.zpstate=1 and zhaopin.id= "+zpid+" "+
                " and zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 "+
                " and yingpinzhe.zpfbid=zpfb.id " +
                " and yingpinzhe.xueli= xueli.id and yingpinzhe.politic=politic.id "+
              " and yingpinzhe.id not in (select distinct ypzid from yingpingzhezhaopin where zpid=" + zpid + ")";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach (DataRow dr in dt.Rows)
            {
                Yingpinzhe ypz = new Yingpinzhe();

                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["Name"].ToString();

                DateTime date = (DateTime)dr["JinTime"];
                ypz.JoinTime = date.ToShortDateString();

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["DegreeName"].ToString();

                ypz.PolName = dr["PolName"].ToString();
                list.Add(ypz);
            }
            return list;
        }

        //hhy
         public static List<Yingpinzhe> GetAllYingpinzheByZpAndParameters(int zpid = -1, bool in_zp = true,string ypzname="",int depid=-1)
        {
            String sql = "select yingpinzhe.id as Id, " +
              "yingpinzhe.name as Name," +
              "department.departname as DepName," +
              "yingpinzhe.dutyname as DutyName, " +
              "xueli.degreename as DegreeName," +
              "yingpinzhe.jointime as JinTime," +
              "politic.politicname as PolName " +
              "from yingpinzhe,department,xueli,politic,zhaopin,zpfb,zpgw " +
              "where yingpinzhe.departid=department.id and department.bmstate=1 and yingpinzhe.ypzstate=1 " +
              " and zhaopin.zpfbid=zpfb.id and zhaopin.zpstate=1 and zhaopin.id= " + zpid + " " +
              " and zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 " +
              " and yingpinzhe.zpfbid=zpfb.id " +
              " and yingpinzhe.xueli= xueli.id and yingpinzhe.politic=politic.id " +
            " and yingpinzhe.id not in (select distinct ypzid from yingpingzhezhaopin where zpid=" + zpid + ")";
            if(ypzname !="")
            {
                sql+=" and yingpinzhe.name='"+ypzname+"' ";
            }
             if(depid !=-1)
            {
                sql += " and yingpinzhe.departid=" + depid;
            }
             sql += " order by department.id asc ";

             DataTable dt = MySqlDBHelper.GetDataSet(sql);
            List<Yingpinzhe> list = new List<Yingpinzhe>();
            foreach (DataRow dr in dt.Rows)
            {
                Yingpinzhe ypz = new Yingpinzhe();

                ypz.ID = (int)dr["Id"];
                ypz.Name = dr["Name"].ToString();

                DateTime date = (DateTime)dr["JinTime"];
                ypz.JoinTime = date.ToShortDateString();

                ypz.DepName = dr["DepName"].ToString();
                ypz.XueliName = dr["DegreeName"].ToString();

                ypz.PolName = dr["PolName"].ToString();
                list.Add(ypz);
            }
            return list;
        }

    }
}
