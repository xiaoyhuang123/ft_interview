using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.systemmanage
{
    public partial class HistoryDetails : System.Web.UI.Page
    {
        private static int ypzzpid = -1;
        private static int zpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ypzzpid"]!=null)
            {
                ypzzpid = Convert.ToInt32(Request["ypzzpid"]);
            }
            if (!IsPostBack)
            {
                BindData(ypzzpid, zpid);
            }
        }

        private void BindData(int ypzid = -1, int zpid = -1)
        {

            YingpinzheZhaopin ypzzp = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);
            Yingpinzhe ypz= FTInterviewBLL.YingpinzheManage.GetYingpinzheById(ypzzp.YpzID);
            Zhaopin zp=FTInterviewBLL.ZhaopinManage.GetZhaopinById(ypzzp.ZhaopinId);
            yName.Text = ypz.Name;
            BirthDay.Text =ypz.Birthday;
            yDegree.Text = ypz.XueliName;
            yJoinTime.Text = ypz.JoinTime;
            yDepart.Text = ypz.YpDepName;
            yPosition.Text = ypz.YpPosName;
            yPolitic.Text = ypz.XueliName;

            double sum = 0;

            List<KaoguanZhaopin> kgls = FTInterviewBLL.KaoguanZhaopinManage.GetKgZPbyzpId(ypzzp.ZhaopinId);
            int kgnum = kgls.Count;
            if (kgnum <1)
            {
                return;
            }
            DataTable dt = new DataTable("Result");
            dt.Columns.Add("title", typeof(string));
            for (int i = 1; i <= kgnum; i++)
            {
                dt.Columns.Add("kg" + i, typeof(string));
            }
            DataRow dr = dt.NewRow();
            dr["title"] = "";
            for (int i = 1; i <= kgnum; i++)
            {
                dr["kg" + i] = kgls[i - 1].KgName;
            }
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr["title"] = "权重";
            for (int i = 1; i <= kgnum; i++)
            {
                dr["kg" + i] = "" + (Convert.ToDouble(kgls[i - 1].Weight) * 0.01);
            }
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["title"] = "实际得分";
            for (int i = 1; i <= kgnum; i++)
            {
                double sco = FTInterviewBLL.PingfenManage.GetScoreSums(ypzzpid, kgls[i-1].Id);
                dr["kg" + i] = "" + sco;
                sum+=kgls[i-1].Weight * (double)sco*0.01;
            }
            dt.Rows.Add(dr);
          
            dr = dt.NewRow();
            dr["title"] = "面试得分";
            dr["kg1"] = sum + "";//Convert.ToInt32(sum)+"";
            dt.Rows.Add(dr);

            ScoreDetailAll.DataSource = dt;
            ScoreDetailAll.DataBind();
            ScoreDetailAll.Rows[3].Cells[1].ColumnSpan = kgnum;
            for (int i = 2; i <= kgnum;i++ )
            {
                ScoreDetailAll.Rows[3].Cells[i].Visible = false;
            }

            List<Shiti> stls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(zp.KaotiID);
            int tinum = stls.Count;
            //if(tinum>0)
            {
                DataTable dt1 = new DataTable("details");
                dt1.Columns.Add("title", typeof(string));
                for (int i = 1; i <= tinum; i++)
                {
                    dt1.Columns.Add("ti" + i, typeof(string));
                }

                DataRow dr1 = dt1.NewRow();
                dr1["title"] = "";
                for (int i = 1; i <= tinum; i++)
                {
                    dr1["ti" + i] = "试题" + i;
                }
                dt1.Rows.Add(dr1);


                for (int i = 0; i < kgls.Count; i++)
                {
                    dr1 = dt1.NewRow();
                    dr1["title"] = kgls[i].KgName;
                    dt1.Rows.Add(dr1);

                    dr1 = dt1.NewRow();
                    dr1["title"] = "权重";
                    for (int j = 1; j <= tinum; j++)
                    {
                        dr1["ti" + j] = stls[j - 1].Weight * 0.01;
                    }
                    dt1.Rows.Add(dr1);

                    List<double> realvalue = new List<double>();
                    double sum_t = 0;
                    dr1 = dt1.NewRow();
                    dr1["title"] = "实际得分";
                    for (int j = 0; j < tinum; j++)
                    {
                        int val = FTInterviewBLL.PingfenManage.GetScoreSumSingleTi(ypzzpid, kgls[i].Id, stls[j].Id);
                        double val_new = val * 0.01 * stls[j].Weight;
                        realvalue.Add(val_new);
                        sum_t += val_new;
                        dr1["ti" + (j + 1)] = val;
                    }
                    dt1.Rows.Add(dr1);

                    dr1 = dt1.NewRow();
                    dr1["title"] = "权重得分";
                    for (int j = 0; j < tinum; j++)
                    {
                        dr1["ti" + (j + 1)] = realvalue[j];
                    }
                    dt1.Rows.Add(dr1);

                    dr1 = dt1.NewRow();
                    dr1["title"] = "总分";
                    if(tinum>0)
                    { dr1["ti1"] = sum_t + ""; }
                    dt1.Rows.Add(dr1);

                }

                ScoreDetailEach.DataSource = dt1;
                ScoreDetailEach.DataBind();

                for (int k = 0; k < kgnum; k++)
                {
                    int myid = 1 + 5 * k;
                    ScoreDetailEach.Rows[myid].Cells[0].ColumnSpan = tinum + 1;
                    ScoreDetailEach.Rows[myid].Cells[0].ForeColor = System.Drawing.Color.Red;

                    if(tinum>0)
                    {
                        ScoreDetailEach.Rows[myid + 4].Cells[1].ColumnSpan = tinum;
                    }
                    for (int n = 1; n <= tinum; n++)
                    {
                        ScoreDetailEach.Rows[myid].Cells[n].Visible = false;
                    }
                    for (int n = 2; n <= tinum; n++)
                    {
                        ScoreDetailEach.Rows[myid + 4].Cells[n].Visible = false;
                    }
                }
            }
        }
    }
}