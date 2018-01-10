using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FTInterviewModel;

namespace FTInterviewDAL
{
    public class PingfenService
    {
        public static int Add(Pingfen pinfen)
        {
            String sql = "insert into pingfen(ypzzpid,kgzpid,shitiid,xdbzid,chengji,pfstate) values(@ypzzpid,@kgzpid,@shitiid,@xdbzid,@chengji,@pfstate)";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@ypzzpid", pinfen.YpzzpID));
            para_list.Add(new MySqlParameter("@kgzpid", pinfen.KgzpID));
            para_list.Add(new MySqlParameter("@shitiid", pinfen.ShitiID));
            para_list.Add(new MySqlParameter("@xdbzid", pinfen.XdbzID));
            para_list.Add(new MySqlParameter("@chengji", pinfen.Score));
            para_list.Add(new MySqlParameter("@pfstate", 1));
            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());

        }

        public static int batchAdd(List<Pingfen> pinfenList)
        {
            if(pinfenList.Count<1)
            {
                return 0;
            }
            String sql = "insert into pingfen(ypzzpid,kgzpid,shitiid,xdbzid,chengji,pfstate) values ";
            StringBuilder sb=new StringBuilder();
            sb.Append(sql);
            for (int i=0; i<pinfenList.Count; i++ )
            {
                Pingfen pingfen=pinfenList[i];
                sb.Append("(").
                    Append(pingfen.YpzzpID).Append(",").
                    Append(pingfen.KgzpID).Append(",").
                    Append(pingfen.ShitiID).Append(",").
                    Append(pingfen.XdbzID).Append(",").
                    Append(pingfen.Score).Append(",").
                    Append(1).Append(" )");
                if (i < pinfenList.Count-1)
                {
                    sb.Append(",");
                }
            }
            sql = sb.ToString();
            return MySqlDBHelper.ExecuteCommand(sql);
        }


        public static int Update(Pingfen pf)
        {
            String sql = "update pingfen set chengji=@chengji where id=@id";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@id", pf.Id));
            para_list.Add(new MySqlParameter("@chengji", pf.Score));

            return MySqlDBHelper.ExecuteCommand(sql, para_list.ToArray());
        }

        public static int batchUpdate(List<Pingfen> pinfenList)
        {
            if(pinfenList.Count<1){
                return 0;
            }

            String sql = "";
            for (int i = 0; i < pinfenList.Count; i++)
            {
                 Pingfen pingfen=pinfenList[i];
                 sql += " update pingfen set chengji=" + pingfen.Score + " where id=" + pingfen.Id + " ;";
            }
            /*

            String sql = "insert into pingfen(id,chengji) values ";
            StringBuilder sb=new StringBuilder();
            sb.Append(sql);

             for (int i=0; i<pinfenList.Count; i++ )
            {
                Pingfen pingfen=pinfenList[i];
                sb.Append("(").
                    Append(pingfen.Id).Append(",").
                    Append(pingfen.Score).Append(")");
                if (i < pinfenList.Count-1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(" ON DUPLICATE KEY UPDATE chengji=VALUES(chengji);");
            */
            return MySqlDBHelper.ExecuteCommand(sql);
        }

        public static int DeleteByShitiid(int stid, bool realdelete = false)
        {
            String sql ="";//
            if (realdelete)
            {
                sql = "delete from pingfen where shitiid=" + stid;
            }
            else
            {
                sql = "update pingfen set pfstate=0 where shitiid=" + stid;
            }
            return MySqlDBHelper.ExecuteCommand(sql);
        }

         public static int DeleteByXdid(int xdid, bool realdelete = false)
        {
            String sql = "";//
            if (realdelete)
            {
                sql = "delete from pingfen where xdbzid=" + xdid;
            }
            else
            {
                sql = "update pingfen set pfstate=0 where xdbzid=" + xdid;
            }
            return MySqlDBHelper.ExecuteCommand(sql);
        }
         public static int DeleteByKgzpid(int kgzpid, bool realdelete = false)
         {
             String sql = "";//
             if (realdelete)
             {
                 sql = "delete from pingfen where kgzpid=" + kgzpid;
             }
             else
             {
                 sql = "update pingfen set pfstate=0 where kgzpid=" + kgzpid;
             }
             return MySqlDBHelper.ExecuteCommand(sql);
         }
         public static int DeleteByYpzzpid(int ypzzpid, bool realdelete = false)
         {
             String sql = "";//
             if (realdelete)
             {
                 sql = "delete from pingfen where ypzzpid=" + ypzzpid;
             }
             else
             {
                 sql = "update pingfen set pfstate=0 where ypzzpid=" + ypzzpid;
             }
             return MySqlDBHelper.ExecuteCommand(sql);
         }


        public static double GetScoreSums(int ypzzpid, int kgzpid = -1)
        {
            double sum = 0;
            if (kgzpid != -1)
            {
                string sql = "select pingfen.shitiid,pingfen.chengji  from pingfen,yingpingzhezhaopin,yingpinzhe,kaoguanzhaopin,kaoguan,zhaopin,shiti " +
               " where pfstate=1 and ypzzpid=" + ypzzpid + " and kgzpid=" + kgzpid+
               " and pingfen.ypzzpid=yingpingzhezhaopin.id and pingfen.kgzpid=kaoguanzhaopin.id "+
               " and zhaopin.id=yingpingzhezhaopin.zpid and pingfen.shitiid=shiti.id and shiti.ktid=zhaopin.ktid " +
               " and yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpinzhe.ypzstate=1 "+
               " and kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 ";
                DataTable dt = MySqlDBHelper.GetDataSet(sql);
                Dictionary<int, int> temp = new Dictionary<int, int>();
               
                foreach(DataRow dr in dt.Rows)
                {
                    int stid = Convert.ToInt32(dr["shitiid"]);
                    int chengji = Convert.ToInt32(dr["chengji"]);
                    if(!temp.ContainsKey(stid))
                    {
                        temp.Add(stid, chengji);
                    }
                    else
                    {
                        temp[stid] += chengji;
                    }
                }

                foreach (int k in temp.Keys)
                {
                    Shiti st = ShitiService.GetShitiById(k);
                    if(st != null)
                    {
                        int w = st.Weight;
                        sum += temp[k] * w * 0.01;
                    }
                }
            }
            else//获取全部
            {
                string sql = "select pingfen.kgzpid as Kgzpid," +
                    " pingfen.shitiid as ShitiId," +
                    "pingfen.xdbzid as XdId," +
                    "shiti.weight as Weight,"+
                    "kaoguanzhaopin.weight as KgWeight," +
                    "pingfen.chengji as CJ " +
                    "from pingfen,shiti,kaoguanzhaopin,kaoguan,yingpingzhezhaopin,yingpinzhe,zhaopin " +
                    " where pingfen.pfstate=1 and pingfen.ypzzpid=" + ypzzpid + 
                    " and pingfen.shitiid=shiti.id and kaoguanzhaopin.id= pingfen.kgzpid"+
                      " and zhaopin.id=yingpingzhezhaopin.zpid and pingfen.shitiid=shiti.id and shiti.ktid=zhaopin.ktid " +
                    " and pingfen.ypzzpid=yingpingzhezhaopin.id " +
                    " and yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpinzhe.ypzstate=1 " +
                    " and kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 ";
                DataTable dt = MySqlDBHelper.GetDataSet(sql);

                Dictionary<int, double> wei = new Dictionary<int, double>();
                Dictionary<int, double> kgwei = new Dictionary<int, double>();
                Dictionary<int, Dictionary<int, int>> _myres = new Dictionary<int, Dictionary<int, int>>();
               
                foreach (DataRow dr in dt.Rows)
                {
                    int kgzpid_t = Convert.ToInt32(dr["Kgzpid"]);
                    int stid = Convert.ToInt32(dr["ShitiId"]);
                    int xdid = Convert.ToInt32(dr["XdId"]);
                    int chengji = Convert.ToInt32(dr["CJ"]);

                    double weight_kg = Convert.ToDouble(dr["KgWeight"]);
                    double weight_st = Convert.ToDouble(dr["Weight"]);

                    if (!wei.ContainsKey(stid))
                    {
                        wei.Add(stid, weight_st);
                    }
                    if (!kgwei.ContainsKey(kgzpid_t))
                    {
                        kgwei.Add(kgzpid_t, weight_kg);
                    }

                    if (!_myres.ContainsKey(kgzpid_t))
                    {
                        Dictionary<int, int> mt = new Dictionary<int, int>();
                        mt.Add(stid, chengji);
                        _myres.Add(kgzpid_t, mt);
                    }
                    else
                    {
                        Dictionary<int, int> mt=_myres[kgzpid_t];
                       if(mt.ContainsKey(stid))
                       {
                           mt[stid] += chengji;
                       }
                       else
                       {
                           mt.Add(stid, chengji);
                       }
                    }
                }

                foreach(int kgkeys in _myres.Keys)
                {
                    double kgw = kgwei[kgkeys];
                    double sum_temp = 0;
                    Dictionary<int,int> temp_sc=_myres[kgkeys];
                    foreach (int stkeys in temp_sc.Keys)
                    {
                        double stw = wei[stkeys];
                        sum_temp += stw * 0.01 * temp_sc[stkeys];
                    }
                    sum+=(0.01*kgw*sum_temp);
                }
            }
            return sum;
        }

         public static int GetScoreSumSingleTi(int ypzzpid, int kgzpid = -1,int shitiid=-1)
        {
            int sum = 0;
            if (kgzpid != -1)
            {
                string sql = "select sum(chengji) as CJ " + "from pingfen,yingpingzhezhaopin,yingpinzhe,kaoguanzhaopin,kaoguan " +
               " where pingfen.pfstate=1 and ypzzpid=" + ypzzpid + " and kgzpid=" + kgzpid + " and shitiid=" + shitiid+
               " and pingfen.ypzzpid=yingpingzhezhaopin.id and pingfen.kgzpid=kaoguanzhaopin.id " +
               " and yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpinzhe.ypzstate=1 " +
               " and kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 ";
                DataTable dt = MySqlDBHelper.GetDataSet(sql);
                if(dt.Rows.Count>0)
                {
                    DataRow dr = dt.Rows[0];
                    string mt=dr["CJ"].ToString();
                    if(mt!="")
                    {
                        sum = Convert.ToInt32(dr["CJ"]);
                    }

                }
            }
            return sum;
        }


        public static Pingfen GetPfByParameter(int kgzpid, int ypzzpid, int stid, int xdbzid)
        {
            String sqlstr = "select pingfen.id as Id,pingfen.ypzzpid,pingfen.kgzpid,pingfen.shitiid,pingfen.xdbzid,pingfen.chengji,"+
                "pingfen.pfstate from pingfen,yingpingzhezhaopin,yingpinzhe,kaoguanzhaopin,kaoguan " +
                 "where pingfen.pfstate=1 and kgzpid=@kgzpid and ypzzpid=@ypzzpid and shitiid=@stid and xdbzid=@xdbzid "+
                 " and pingfen.ypzzpid=yingpingzhezhaopin.id and pingfen.kgzpid=kaoguanzhaopin.id " +
                 " and yingpingzhezhaopin.ypzid=yingpinzhe.id and yingpinzhe.ypzstate=1 " +
                 " and kaoguanzhaopin.kgid=kaoguan.id and kaoguan.kgstate=1 ";
            List<MySqlParameter> para_list = new List<MySqlParameter>();
            para_list.Add(new MySqlParameter("@kgzpid", kgzpid));
            para_list.Add(new MySqlParameter("@ypzzpid", ypzzpid));
            para_list.Add(new MySqlParameter("@stid", stid));
            para_list.Add(new MySqlParameter("@xdbzid", xdbzid));

            DataTable dt = MySqlDBHelper.GetDataSet(sqlstr,para_list.ToArray());
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Pingfen pf = new Pingfen();
                pf.Id = Convert.ToInt32(dr["Id"].ToString());
                pf.KgzpID = Convert.ToInt32(dr["kgzpid"].ToString());
                pf.ShitiID = Convert.ToInt32(dr["shitiid"].ToString());
                pf.YpzzpID = Convert.ToInt32(dr["ypzzpid"].ToString());
                pf.XdbzID = Convert.ToInt32(dr["xdbzid"].ToString());

                pf.State = Convert.ToInt32(dr["pfstate"].ToString());

                pf.Score = Convert.ToInt32(dr["chengji"].ToString());
                return pf;
            }
            return null;
        }
    }
}
