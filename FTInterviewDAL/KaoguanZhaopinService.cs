using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;


namespace FTInterviewDAL
{
    public class KaoguanZhaopinService
    {
        public static int Add(KaoguanZhaopin kz)
        {
            String sql = "insert into kaoguanzhaopin(kgid,zpid,weight) values(@kgid,@zpid,@weight)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@kgid", kz.KaoguanID));
            para_list.Add(new MySqlParameter("@zpid", kz.ZhaopinID));
            para_list.Add(new MySqlParameter("@weight", kz.Weight));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int UpdateWeight(int kgzpid,int w)
        {
            String sql = "update kaoguanzhaopin set weight=@weight where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", kgzpid));
            para_list.Add(new MySqlParameter("@weight", w));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int Delete(int id)
        {
            string sqlstr = "delete from kaoguanzhaopin where id=" + id;
            return MySqlDBHelper.ExecuteCommand(sqlstr);
        }

        public static KaoguanZhaopin GetKgZPbyId(int id)
        {
            String sql = "select kaoguanzhaopin.id as Id, " +
              "kgid," +
               "zpid," +
               "weight " +
              " from kaoguanzhaopin,kaoguan,zhaopin,department " +
              " where kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 "+
              " and kaoguanzhaopin.zpid= zhaopin.id "+
               " and zhaopin.id in (select zhaopin.id from zhaopin,zpfb,zpgw,department "+
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) "+
              " and department.id=kaoguan.depart and department.bmstate=1 "+
              " and kaoguanzhaopin.id=" + id;
            DataTable dt = MySqlDBHelper.GetDataSet(sql);


            KaoguanZhaopin kgzp = new KaoguanZhaopin();
            foreach (DataRow dr in dt.Rows)
            {
                kgzp.Id = (int)dr["Id"];
                kgzp.KaoguanID = Convert.ToInt32(dr["kgid"].ToString());
                kgzp.ZhaopinID = Convert.ToInt32(dr["zpid"].ToString());
                kgzp.Weight = Convert.ToInt32(dr["weight"].ToString());
                return kgzp;
            }
            return null;
        }

        public static List<KaoguanZhaopin> GetKgZPbyzpId(int zpid)
        {
            String sql = "select kaoguanzhaopin.id as Id, " +
              "kgid," +
               "zpid," +
               "weight, " +
               " kaoguan.name as KgName,"+
               " department.departname as KgDepName,"+
               " kaoguan.position as KgDuty "+
              " from kaoguanzhaopin,kaoguan,department,zhaopin " +
              " where kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 "+
              " and kaoguan.depart=department.id and department.bmstate=1 " +
              " and zhaopin.id=kaoguanzhaopin.zpid " +
                " and zhaopin.id in (select zhaopin.id from zhaopin,zpfb,zpgw,department " +
              "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 ) " +
              "and kaoguanzhaopin.zpid=" + zpid+" order by department.id ";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            List<KaoguanZhaopin> lsres = new List<KaoguanZhaopin>();
            if (dt.Rows.Count < 1)
            {
                return lsres;
            }

            foreach (DataRow dr in dt.Rows)
            {
                KaoguanZhaopin kgzp = new KaoguanZhaopin();
                kgzp.Id = (int)dr["Id"];
                kgzp.KaoguanID = Convert.ToInt32(dr["kgid"].ToString());
                kgzp.ZhaopinID = Convert.ToInt32(dr["zpid"].ToString());
                kgzp.Weight = Convert.ToInt32(dr["weight"].ToString());


                //
                kgzp.KgName = dr["KgName"].ToString();
                kgzp.KgDepName = dr["KgDepName"].ToString();
                kgzp.KgPosName = dr["KgDuty"].ToString();


                lsres.Add(kgzp);
            }
            return lsres;
        }

        public static KaoguanZhaopin GetKgZPbyKgIdZpid(int kgid, int zpid)
        {
            String sql = "select kaoguanzhaopin.id as Id, " +
             "kgid," +
              "zpid," +
              "weight " +
             " from kaoguanzhaopin,kaoguan,department,zhaopin " +
             " where kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 " +
             " and kaoguan.depart=department.id and department.bmstate=1 " +
             " and zhaopin.id=kaoguanzhaopin.zpid " +
             "and kaoguanzhaopin.kgid=" + kgid + " and kaoguanzhaopin.zpid=" + zpid +
             " and zhaopin.id in (select zhaopin.id from zhaopin,zpfb,zpgw,department "
             + "  where zhaopin.zpfbid=zpfb.id and zpfb.fbstate=1 and zhaopin.zpstate=1 " +
             " and zpfb.zpgwid=zpgw.id and zpgw.zpbm=department.id and department.bmstate=1 )";
            DataTable dt = MySqlDBHelper.GetDataSet(sql);

            KaoguanZhaopin kgzp = new KaoguanZhaopin();
            foreach (DataRow dr in dt.Rows)
            {
                kgzp.Id = (int)dr["Id"];
                kgzp.KaoguanID = Convert.ToInt32(dr["kgid"].ToString());
                kgzp.ZhaopinID = Convert.ToInt32(dr["zpid"].ToString());
                kgzp.Weight = Convert.ToInt32(dr["weight"].ToString());
                return kgzp;
            }
            return null;
        }

    }
}
