using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class ZhaopinService
    {
        public static int Add(Zhaopin zp)
        {
            String sqlstr = "insert into zhaopin(title,interviewtime,zpfbid,ktid,hege,zpstate) values(@title,@interviewtime,@zpfbid,@ktid,@hege,@zpstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@title", zp.Title));
            para_list.Add(new MySqlParameter("@interviewtime", zp.InterviewTime));
            para_list.Add(new MySqlParameter("@zpfbid", zp.ZpfbId));
            para_list.Add(new MySqlParameter("@ktid", zp.KaotiID));
            para_list.Add(new MySqlParameter("@hege", zp.HegeLine));
            para_list.Add(new MySqlParameter("@zpstate", 1));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int AddReturnID(Zhaopin zp)
        {

            String sql = "select uuid()";
            string uni_str = "";
            while (true)
            {
                DataTable dt = MySqlDBHelper.GetDataSet(sql);
                if (dt.Rows.Count == 1)
                {
                    uni_str = dt.Rows[0][0].ToString();
                    dt.Clear();
                    break;
                }
            }

            String sqlstr = "insert into zhaopin(title,interviewtime,zpfbid,ktid,hege,zpstate,identifity) values(@title,@interviewtime,@zpfbid,@ktid,@hege,@zpstate,@identifity)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@title", zp.Title));
            para_list.Add(new MySqlParameter("@interviewtime", zp.InterviewTime));
            para_list.Add(new MySqlParameter("@zpfbid", zp.ZpfbId));
            para_list.Add(new MySqlParameter("@ktid", zp.KaotiID));
            para_list.Add(new MySqlParameter("@hege", zp.HegeLine));
            para_list.Add(new MySqlParameter("@zpstate", 1));
            para_list.Add(new MySqlParameter("@identifity", uni_str));

            MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());

            sqlstr = "select id from zhaopin where identifity='" + uni_str + "'";

            DataTable resdt = MySqlDBHelper.GetDataSet(sqlstr);
            int id = -1;
            if (resdt.Rows.Count > 0)
            {
                id = Convert.ToInt32(resdt.Rows[0]["id"]);
            }
            return id;
        }


        public static int Update(Zhaopin zp)
        {
            String sqlstr = "update zhaopin set title=@title,interviewtime=@interviewtime,zpfbid=@zpfbid,ktid=@ktid,hege=@hege where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", zp.Id));
            para_list.Add(new MySqlParameter("@title", zp.Title));
            para_list.Add(new MySqlParameter("@interviewtime", zp.InterviewTime));
            para_list.Add(new MySqlParameter("@zpfbid", zp.ZpfbId));
            para_list.Add(new MySqlParameter("@ktid", zp.KaotiID));
            para_list.Add(new MySqlParameter("@hege", zp.HegeLine));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }


         public static int UpdateKaotiIndex(int id,int ktid)
        {
            String sqlstr = "update zhaopin set ktid=@ktid where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            para_list.Add(new MySqlParameter("@ktid", ktid));
            return   MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }

        public static int Delete(int id)
        {
            String sql = "delete from zhaopin where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }
        public static int DeleteZhaopinByID(int id)
        {
            String sqlstr = "update zhaopin set zpstate=@zpstate where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", id));
            int s = 0;
            para_list.Add(new MySqlParameter("@zpstate",s));

            return MySqlDBHelper.ExecuteCommand(sqlstr, para_list.ToArray());
        }


        //hhy
        public static List<Zhaopin> GetAllZhaopinListInZpItemId(int itmid,int depid=-1,string posname="",string st="",string et="")
        {
            string sqlstr = "select zhaopin.id as Id," +
                         "zhaopin.title as Title," +
                         "zhaopin.zpfbid as ZPfbId," +
                         "zhaopin.interviewtime as PubTime," +
                         "department.departname as Bm," +
                         "zpgw.zppos as Position," +
                         "zpfb.sums as ZpSum," +
                          "zhaopin.hege as HegeLine, " +
                         "zhaopin.ktid as KTID " +
                         "from zhaopin,zpfb,zpgw,department,zhaopinitem" +
                         " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id"+
                         " and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 "+
                         " and zpfb.zpitmid=zhaopinitem.id and zhaopinitem.zpitemstate=1 ";

            if (itmid != -1)
            {
                sqlstr += " and zpfb.zpitmid=" + itmid + " ";
            }
            if (depid != -1)
            {
                sqlstr += " and department.id=" + depid + " ";
            }
            if(posname!="")
            {
                sqlstr += " and zpgw.zppos=" + posname + " ";
            }
            if (st != "")
            {
                sqlstr += " and zhaopin.interviewtime >='" + st + "' ";
            }
            if (et != "")
            {
                sqlstr += " and zhaopin.interviewtime<='" + et + "' ";
            }
            sqlstr += " order by zhaopin.interviewtime DESC";


            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<Zhaopin> ls = new List<Zhaopin>();
            if (dt.Rows.Count < 1)
            {
                return ls;
            }
            foreach (DataRow dr in dt.Rows)
            {
                Zhaopin zp = new Zhaopin();
                zp.Id = Convert.ToInt32(dr["Id"].ToString());
                zp.Title = dr["Title"].ToString();

                // DateTime date = (DateTime)dr["PubTime"];
                //zp.InterviewTime = date.ToShortDateString();
                zp.InterviewTime = dr["PubTime"].ToString();
                zp.ZpfbId = Convert.ToInt32(dr["ZPfbId"].ToString());

                zp.KaotiID = dr["KTID"].ToString() == "" ? 0 : Convert.ToInt32(dr["KTID"].ToString());
                zp.HegeLine = Convert.ToInt32(dr["HegeLine"].ToString());

                zp.ZpbmName = dr["Bm"].ToString();
                zp.ZpgwName = dr["Position"].ToString();
                zp.ZpSums = Convert.ToInt32(dr["ZpSum"].ToString());

                ls.Add(zp);
            }
            return ls;
        }





        public static DataTable GetAllZhaopin(int dep=-1,string pos="")
        {
           string sqlstr = "select zhaopin.id as Id," +
                          "zhaopin.title as Title," +
                          "zhaopin.zpfbid,"+
                          "zhaopin.interviewtime as InterviewTime," +
                          "department.departname as ZpbmName," +
                          "zpgw.zppos as ZpgwName," +
                          "zpfb.sums as ZpSums," +
                          "zhaopin.hege as HegeLine, " +
                           "zhaopin.ktid as KTID " +
                          "from zhaopin,zpfb,zpgw,department"+
                          " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 ";
            if (dep !=-1)
            {
                 sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            sqlstr += " order by InterviewTime desc ";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }

        public static List<Zhaopin> GetAllZhaopinList(int dep = -1, string pos = "")
        {
            string sqlstr = "select zhaopin.id as Id," +
                          "zhaopin.title as Title," +
                          "zhaopin.zpfbid as ZPfbId," +
                          "zhaopin.interviewtime as PubTime," +
                          "department.departname as Bm," +
                          "zpgw.zppos as Position," +
                          "zpfb.sums as ZpSum," +
                           "zhaopin.hege as HegeLine, " +
                          "zhaopin.ktid as KTID " +
                          "from zhaopin,zpfb,zpgw,department" +
                          " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 ";
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
                if (pos != "")
                {
                    sqlstr += " and zpgw.zppos='" + pos + "' ";
                }
            }
            sqlstr += " order by zhaopin.interviewtime DESC";


            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<Zhaopin> ls = new List<Zhaopin>();
            foreach (DataRow dr in dt.Rows)
            {
                Zhaopin zp = new Zhaopin();
                zp.Id = Convert.ToInt32(dr["Id"].ToString());
                zp.Title = dr["Title"].ToString();

               // DateTime date = (DateTime)dr["PubTime"];
                //zp.InterviewTime = date.ToShortDateString();
                zp.InterviewTime = dr["PubTime"].ToString();
                zp.ZpfbId = Convert.ToInt32(dr["ZPfbId"].ToString());

                zp.KaotiID =dr["KTID"].ToString()==""?0: Convert.ToInt32(dr["KTID"].ToString());
                zp.HegeLine = Convert.ToInt32(dr["HegeLine"].ToString());

                zp.ZpbmName = dr["Bm"].ToString();
                zp.ZpgwName = dr["Position"].ToString();
                zp.ZpSums = Convert.ToInt32(dr["ZpSum"].ToString());


                ls.Add(zp);
            }

            return ls;
        }

        public static List<Zhaopin> GetAllZhaopinListByparameters(int dep = -1, string pos = "", string st = "", string et = "")
        {
            string sqlstr = "select zhaopin.id as Id," +
                         "zhaopin.title as Title," +
                         "zhaopin.zpfbid as ZPfbId," +
                         "zhaopin.interviewtime as PubTime," +
                         "department.departname as Bm," +
                         "zpgw.zppos as Position," +
                         "zpfb.sums as ZpSum," +
                          "zhaopin.hege as HegeLine, " +
                         "zhaopin.ktid as KTID " +
                         "from zhaopin,zpfb,zpgw,department" +
                         " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 ";
                        
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
                if (pos != "")
                {
                    sqlstr += " and zpgw.zppos='" + pos + "' ";
                }
            }
           
            if (st != "")
            {
                sqlstr += " and zhaopin.interviewtime >='" + st + "' ";
            }
            if (et != "")
            {
                sqlstr += " and zhaopin.interviewtime<='" + et + "' ";
            }
            sqlstr += " order by zhaopin.interviewtime DESC";

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            List<Zhaopin> ls = new List<Zhaopin>();
            foreach (DataRow dr in dt.Rows)
            {
                Zhaopin zp = new Zhaopin();
                zp.Id = Convert.ToInt32(dr["Id"].ToString());
                zp.Title = dr["Title"].ToString();

                // DateTime date = (DateTime)dr["PubTime"];
                //zp.InterviewTime = date.ToShortDateString();
                zp.InterviewTime = dr["PubTime"].ToString();
                zp.ZpfbId = Convert.ToInt32(dr["ZPfbId"].ToString());

                zp.KaotiID = dr["KTID"].ToString() == "" ? 0 : Convert.ToInt32(dr["KTID"].ToString());
                zp.HegeLine = Convert.ToInt32(dr["HegeLine"].ToString());

                zp.ZpbmName = dr["Bm"].ToString();
                zp.ZpgwName = dr["Position"].ToString();
                zp.ZpSums = Convert.ToInt32(dr["ZpSum"].ToString());


                ls.Add(zp);
            }

            return ls;
        }

        public static Zhaopin GetZhaopinById(int zpid)
        {
            string sqlstr = "select zhaopin.id as Id," +
                        "zhaopin.title as Title," +
                        "zhaopin.zpfbid as ZPfbId," +
                        "zhaopin.interviewtime as PubTime," +
                        "department.departname as Bm," +
                        "zpgw.zppos as Position," +
                        "zpfb.sums as ZpSum," +
                         "zhaopin.hege as HegeLine, " +
                        "zhaopin.ktid as KTID " +
                        "from zhaopin,zpfb,zpgw,department" +
                        " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id "+
                        " and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 and zhaopin.id="+zpid;
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            Zhaopin zp = new Zhaopin();
            foreach (DataRow dr in dt.Rows)
            {
               
                zp.Id = Convert.ToInt32(dr["Id"].ToString());
                zp.Title = dr["Title"].ToString();

                zp.InterviewTime = dr["PubTime"].ToString();
                zp.ZpfbId = Convert.ToInt32(dr["ZPfbId"].ToString());

                zp.KaotiID = dr["KTID"].ToString() == "" ? 0 : Convert.ToInt32(dr["KTID"].ToString());
                zp.HegeLine = Convert.ToInt32(dr["HegeLine"].ToString());

                zp.ZpbmName = dr["Bm"].ToString();
                zp.ZpgwName = dr["Position"].ToString();
                zp.ZpSums = Convert.ToInt32(dr["ZpSum"].ToString());

                return zp;
            }
            return null;
        }

        public static DataTable GetAllZhaopinListByKaoguan(int kgid, int dep = -1, string pos = "")
        {
            string sqlstr = "select zhaopin.id as Id," +
                         "zhaopin.title as Title," +
                         "zhaopin.zpfbid," +
                         "zhaopin.interviewtime as InterviewTime," +
                         "department.departname as ZpbmName," +
                         "zpgw.zppos as ZpgwName," +
                         "zpfb.sums as ZpSums," +
                         "zhaopin.hege as HegeLine, " +
                          "zhaopin.ktid as KTID " +
                         "from zhaopin,zpfb,zpgw,department" +
                         " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 ";
                        // + "and zhaopin.id in (select distinct zpid from kaoguanzhaopin where kgid= "+kgid+" )";
            if (dep !=-1)
            {
                sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            sqlstr += " and zhaopin.id in (select distinct zpid from kaoguanzhaopin where kgid= " + kgid + " )";

            sqlstr += " order by InterviewTime desc ";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
         }

         //hhy
        public static DataTable GetAllZhaopinListInItemIdByKaoguan(int zpitmid,int kgid, int dep = -1, string pos = "")
        {
            string sqlstr = "select zhaopin.id as Id," +
                         "zhaopin.title as Title," +
                         "zhaopin.zpfbid," +
                         "zhaopin.interviewtime as InterviewTime," +
                         "department.departname as ZpbmName," +
                         "zpgw.zppos as ZpgwName," +
                         "zpfb.sums as ZpSums," +
                         "zhaopin.hege as HegeLine, " +
                          "zhaopin.ktid as KTID " +
                         "from zhaopin,zpfb,zpgw,department" +
                         " where zhaopin.zpfbid=zpfb.id and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and zpfb.fbstate=1 and zhaopin.zpstate=1 and department.bmstate=1 "+
                         " and zhaopin.id in (select distinct zpid from kaoguanzhaopin,kaoguan,department where kaoguanzhaopin.kgid=kaoguan.id and kaoguan .kgstate=1 and kaoguan.depart=department.id and department.bmstate=1 and kaoguanzhaopin.kgid= "+kgid+" )";
            if (zpitmid!=-1)
            {
                sqlstr += " and zpfb.zpitmid=" + zpitmid + " ";
            }
            if (dep != -1)
            {
                sqlstr += " and department.id=" + dep + " ";
            }
            if (pos != "")
            {
                sqlstr += " and zpgw.zppos='" + pos + "' ";
            }
            sqlstr += " and zhaopin.id in (select distinct zpid from kaoguanzhaopin where kgid= " + kgid + " )";

            sqlstr += " order by InterviewTime desc ";
            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr);
            return dt;
        }
    }
}
