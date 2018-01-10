using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class YingpinzheZhaopinService
    {
        public static int Add(YingpinzheZhaopin yz)
        {
            String sql = "insert into yingpingzhezhaopin(ypzid,zpid,ranindex) values(@ypzid,@zpid,@ranindex)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@ypzid", yz.YpzID));
            para_list.Add(new MySqlParameter("@zpid", yz.ZhaopinId));
            para_list.Add(new MySqlParameter("@ranindex", yz.MsIndex));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());

        }

        public static int Delete(int id)
        {
            string sqlstr = "delete from yingpingzhezhaopin where id=" + id;
            return MySqlDBHelper.ExecuteCommand(sqlstr);
        }

        public static YingpinzheZhaopin GetYPZZPbyId(int id)
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
              "ypzid," +
               "zpid," +
               "ranindex, " +
               "submitstate,"+
              " yingpinzhe.name as Name," +
              " department.departname as DepName," +
              " yingpinzhe.dutyname as DutyName " +
              " from yingpingzhezhaopin,yingpinzhe,department,zhaopin " +
              " where yingpingzhezhaopin.ypzid=yingpinzhe.id "+
               " and yingpingzhezhaopin.zpid= zhaopin.id " +
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpfb,zpgw,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
              " and department.id = yingpinzhe.departid and department.bmstate =1 " +
              "and yingpinzhe.ypzstate=1 and yingpingzhezhaopin.id=" + id;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            YingpinzheZhaopin ypzzp = new YingpinzheZhaopin();
            foreach (DataRow dr in dt.Rows)
            {
                ypzzp.ID = (int)dr["Id"];
                ypzzp.YpzID =  Convert.ToInt32(dr["ypzid"].ToString());
                ypzzp.ZhaopinId = Convert.ToInt32( dr["zpid"].ToString());
                ypzzp.MsIndex = Convert.ToInt32(dr["ranindex"].ToString());
                ypzzp.SubmitState = Convert.ToInt32(dr["submitstate"].ToString());

                ypzzp.YpzName = dr["Name"].ToString();
                ypzzp.YpzDepName = dr["DepName"].ToString();
                ypzzp.YpzPosName = dr["DutyName"].ToString();
                return ypzzp;
            }
            return null;
        }

        public static int UpdateSubmitState(YingpinzheZhaopin ypzzp)
        {
            String sql = "update yingpingzhezhaopin set submitstate=@submitstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", ypzzp.ID));
            para_list.Add(new MySqlParameter("@submitstate", ypzzp.SubmitState));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

         public static int UpdateIndex(int id,int ord)
        {
            String sql = "update yingpingzhezhaopin set ranindex=@ranindex where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            para_list.Add(new MySqlParameter("@ranindex", ord));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
       
        //hhy
       public static List<YingpinzheZhaopin> GetAllYingpinzheInzhaopinItemID(int zpitmid)
       {
           String sql = "select yingpingzhezhaopin.id as Id, " +
            "yingpingzhezhaopin.ypzid as YpzId," +
            "yingpinzhe.name as Name," +
            "department.departname as DepName," +
            "yingpinzhe.dutyname as DutyName," +
            " yingpingzhezhaopin.ranindex as OrderIndex " +
            " from yingpinzhe,yingpingzhezhaopin,department,zhaopin " +
            " where yingpinzhe.ypzstate=1 and yingpingzhezhaopin.ypzid=yingpinzhe.id " +
            " and yingpinzhe.departid=department.id and department.bmstate=1 " +
            " and yingpingzhezhaopin.zpid= zhaopin.id " +
            " and zhaopin.id in (select zhaopin.id from zhaopin,zpgw,zpfb,department " +
            "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
            " and zpfb.zpitmid="+zpitmid+
            " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
           " order by ranindex asc";
           DataTable dt = MySqlDBHelper.GetDataSet(sql);

           List<YingpinzheZhaopin> list = new List<YingpinzheZhaopin>();
           foreach (DataRow dr in dt.Rows)
           {
               YingpinzheZhaopin ypzzp = new YingpinzheZhaopin();
               ypzzp.ID = Convert.ToInt32(dr["Id"].ToString());
               ypzzp.YpzName = dr["Name"].ToString();
               ypzzp.YpzDepName = dr["DepName"].ToString();
               ypzzp.YpzPosName = dr["DutyName"].ToString();

               int id_ypz = Convert.ToInt32(dr["YpzId"].ToString());
               Yingpinzhe ypz_t = YingpinzheService.GetYingpinzheById(id_ypz);
               ypzzp.YpzYpDepName = ypz_t.YpDepName;
               ypzzp.YpzYpPosName = ypz_t.YpPosName;


               ypzzp.MsIndex = dr["OrderIndex"].ToString() == "" ? 0 : Convert.ToInt32(dr["OrderIndex"].ToString());

               list.Add(ypzzp);
           }
           return list;
         }



        public static DataTable GetAllYPZZPInzpId(int zpid)
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
                "yingpinzhe.id as Ypzid," +
              "yingpinzhe.name as YpzName,"+
              "yingpinzhe.departid as DepID," +
               "department.departname as DepName," +
               "yingpinzhe.dutyname as DutyName, " +
               "yingpingzhezhaopin.ranindex as msIndex, " +
               "yingpingzhezhaopin.submitstate as SubState " +
              " from yingpingzhezhaopin,yingpinzhe,department,zhaopin " +
              " where yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpinzhe.departid=department.id "+
              "and department.bmstate=1 and yingpingzhezhaopin.zpid= zhaopin.id " +
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpfb,zpgw,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1" +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
              " and yingpinzhe.ypzstate=1 and yingpingzhezhaopin.zpid=" + zpid +" order by ranindex asc;";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            return dt;
        }

        //hhy-sp
        public static List<Yingpinzhe> GetAllYingpinzheInzhaopin(int zpid)
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
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
                " from yingpinzhe,department,xueli,politic,yingpingzhezhaopin,zhaopin " +
                " where yingpinzhe.departid=department.id and yingpinzhe.xueli=xueli.id and yingpinzhe.politic=politic.id and department.bmstate=1 and  yingpinzhe.ypzstate=1 and yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpingzhezhaopin.zpid="+zpid+
                 " and yingpingzhezhaopin.zpid= zhaopin.id " +
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpgw,zpfb,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
                " order by department.id ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);
            dt.Columns.Add("YPBm");
            dt.Columns.Add("YPPos");

            sql = "select zpfb.id as Id,department.departname,zpgw.zppos from department,zpgw,zpfb where zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 and zpfb.fbstate=1";

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
        public static DataTable GetAllYingpinzheResultInzhaopinItemId(int zpitmid, int zpbmid = -1, string pos = "", string st = "", string et = "")
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
             "yingpinzhe.name as Name," +
             " zhaopin.title as Title, " +
             " department.departname as DepName, " +
             " zpgw.zppos as ZpPosName," +
             " zhaopin.interviewtime as ViewTime " +
             " from yingpinzhe,yingpingzhezhaopin,department,zhaopin,zpfb,zpgw " +
             " where yingpinzhe.ypzstate=1 and yingpingzhezhaopin.ypzid=yingpinzhe.id " +
             " and yingpingzhezhaopin.zpid=zhaopin.id " +
             " and zpgw.zpbm=department.id and department.bmstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 " +
             " and zhaopin.zpfbid=zpfb.id " +
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpgw,zpfb,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) ";
            
            if(zpitmid !=-1)
            {
                sql += " and zpfb.zpitmid=" + zpitmid;
            }
            if (zpbmid != -1)
            {
                sql += " and zpgw.zpbm=" + zpbmid;
            }
            if (pos != "")
            {
                sql += " and zpgw.zppos=" + pos;
            }
            if (st != "")
            {
                sql += " and zhaopin.interviewtime>='" + st + "' ";
            }
            if (et != "")
            {
                sql += " and zhaopin.interviewtime<='" + et + "' ";
            }

            sql += " order by ViewTime desc";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            return dt;
        }


        public static List<YingpinzheZhaopin> GetAllYingpinzheInzhaopinID(int zpid)
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
             "yingpinzhe.name as Name," +
              "department.departname as DepName," +
               "yingpinzhe.dutyname as DutyName," +
           " yingpingzhezhaopin.ranindex as OrderIndex " +
             " from yingpinzhe,yingpingzhezhaopin,department,zhaopin " +
             " where yingpinzhe.ypzstate=1 and yingpingzhezhaopin.ypzid=yingpinzhe.id "+
             " and yingpinzhe.departid=department.id and department.bmstate=1 " +
              " and yingpingzhezhaopin.zpid= zhaopin.id " +
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpgw,zpfb,department,zhaopinitem " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
              " and zhaopinitem.id=zpfb.zpitmid and zhaopinitem.zpitemstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
             "and yingpingzhezhaopin.zpid=" + zpid+ " order by ranindex asc";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            List<YingpinzheZhaopin> list = new List<YingpinzheZhaopin>();
            int index_t = 0;
            foreach (DataRow dr in dt.Rows)
            {
                index_t++;
                YingpinzheZhaopin ypzzp = new YingpinzheZhaopin();
                ypzzp.ID = Convert.ToInt32(dr["Id"].ToString());
                ypzzp.YpzName = dr["Name"].ToString();
                ypzzp.YpzDepName = dr["DepName"].ToString();
                ypzzp.YpzPosName = dr["DutyName"].ToString();

               
                ypzzp.MsIndex =(int)dr["OrderIndex"];
              //  if (ypzzp.MsIndex != 32767)
                {
                    ypzzp.Index_temp = ypzzp.MsIndex;// index_t;
                }
             //   else
                {
                //    ypzzp.Index_temp = 32767;
                }
                

                list.Add(ypzzp);
            }
            return list;
        }


        public static DataTable GetAllYingpinzheResultInzhaopinID(int zpgwid=-1,string st="",string et="")
        {
            String sql = "select yingpingzhezhaopin.id as Id, " +
             "yingpinzhe.name as Name," +
             " zhaopin.title as Title, " +
             " department.departname as DepName, " +
             " zpgw.zppos as ZpPosName,"+
             " zhaopin.interviewtime as ViewTime "+
             " from yingpinzhe,yingpingzhezhaopin,department,zhaopin,zpfb,zpgw " +
             " where yingpinzhe.ypzstate=1 and yingpingzhezhaopin.ypzid=yingpinzhe.id " +
             " and yingpingzhezhaopin.zpid=zhaopin.id " +
             " and zpgw.zpbm=department.id and department.bmstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpfb.fbstate=1 "+
             " and zhaopin.zpfbid=zpfb.id "+
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpgw,zpfb,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) ";
            if (zpgwid != -1)
            {
                sql += "and zpgw.id=" + zpgwid;
            }
            if(st!="")
            {
                sql += "and zhaopin.interviewtime>='" + st+"'";
            }
            if(et!="")
            {
                sql += "and zhaopin.interviewtime<='" + et + "'";
            }

            sql += " order by ViewTime desc";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            return dt;
        }
    }
}
