using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

using log4net;
using log4net.Config;

namespace FTInterviewSites.msg
{
    public partial class QuestionScore : System.Web.UI.Page
    {
        private static int index = 1;
        private static int kaotiid = -1;
        private static int ypzzpid = -1;
        private static int kgzpid = -1;
        private static Dictionary<int, int> shitils = new Dictionary<int, int>();//存放试题列表
        private static Dictionary<int, Pingjiaxiangdian> xdls = new Dictionary<int, Pingjiaxiangdian>();//存放项点

        private static int xdn = 0;
        private static int bzn =0;
        private static int sn = 0;

        private static bool flag = false;

        private static log4net.ILog logger = LogManager.GetLogger(typeof(QuestionScore));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cok = Request.Cookies["ftcook"];
                if (cok["ypzzpid"] != null)
                {
                    ypzzpid = Convert.ToInt32(cok["ypzzpid"].ToString());
                }
            
               
                if (cok != null )
                {
                    int _zpid = Convert.ToInt32(cok["zpid"]);
                    int _kgid = Convert.ToInt32(cok["kgid"]);

                   
                    KaoguanZhaopin kgzp = FTInterviewBLL.KaoguanZhaopinManage.GetKgZPbyKgIdZpid(_kgid, _zpid);
                    if(kgzp !=null){
                        kgzpid = kgzp.Id;
                    }
                }

                if (ypzzpid != -1)
                {
                    YingpinzheZhaopin t = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);
                    Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(t.ZhaopinId);
                    kaotiid = zp.KaotiID;
                    if (cok != null)
                    {
                        cok.Values.Remove("kaotiid");
                        cok.Values.Add("kaotiid", kaotiid + "");
                        cok.Expires = DateTime.Now.AddDays(1);
                        Response.AppendCookie(cok);
                    }


                }
                flag = false;
                shitils.Clear(); 
                xdls.Clear();
            }
            BindData();
        }

         protected void BindData()
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                ypzzpid = Convert.ToInt32(cok["ypzzpid"]);
                kgzpid = Convert.ToInt32(cok["kgzpid"]);
                kaotiid = Convert.ToInt32(cok["kaotiid"]);
            }
           
            List<Shiti> sls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(kaotiid);
            GridView1.DataSource = sls;
            GridView1.DataBind();

             if(sls.Count<1)
             {
                 submitButton.Visible = false;
                 //NextButton.Visible = false;
             }

            List<Pingjiaxiangdian> ps = FTInterviewBLL.PingjiaxiangdianManage.GetAll();
            List<Pingjiabiaozhun> pz = FTInterviewBLL.PingjiabiaozhunManage.GetAll();
            List<Xiangdianbiaozhun> xdbzls = FTInterviewBLL.XiangdianBiaozhunManage.GetAll();

             xdn = ps.Count;
             bzn = pz.Count;
             sn = sls.Count;

             if (!flag)
             {
                 for (int i = 1; i <= sls.Count; i++)
                 {
                     shitils.Add(i, sls[i - 1].Id);
                 }
                 for (int i = 1; i <= ps.Count; i++)
                 {
                     xdls.Add(i, ps[i - 1]);
                 }
                 flag = true;
             }

            DataTable dt = new DataTable("msg");
            dt.Columns.Add("pjxd", typeof(string));
            for (int i = 1; i <= bzn;i++ )
            {
                dt.Columns.Add("bz"+i, typeof(string));
            }
            for (int i = 1; i <= sn; i++)
            {
                dt.Columns.Add("ti" + i, typeof(string));
            }

            DataRow dr = dt.NewRow();
            dr["pjxd"] = "项点";
            for (int i = 1; i <= bzn; i++)
            {
                dr["bz" + i] = pz[i - 1].Content;
            }
            for (int i = 1; i <= sn; i++)
            {
                dr["ti" + i] = "第"+i+"题";
            }
            dt.Rows.Add(dr);

            foreach (Pingjiaxiangdian pd in ps)
            {
                dr = dt.NewRow();
                dr["pjxd"] = pd.Content;
                dt.Rows.Add(dr);
            }

            ScoreDetail.DataSource = dt;
            ScoreDetail.DataBind();

            int ide = 0;
            for (int ri = 1; ri <= xdn; ri++)
            {
                for (int ci = 1; ci <= bzn; ci++)
                {
                    Label t_text = new Label();
                    t_text.Text = xdbzls[ide].MyContent;
                    ide++;
                    ScoreDetail.Rows[ri].Cells[ci].Controls.Add(t_text);
                }
            }

            for (int ri = 1; ri <= xdls.Count; ri++)
            {
                for (int ci = bzn+1; ci < bzn+1+sn; ci++)
                {
                    DropDownList dl = new DropDownList();
                    dl.ID = ri+"DropDownList"+ci;
                    
                    dl.Width = 60;
                    int stid = shitils[ci - bzn];
                    int xdid = xdls[ri].Id;
                    Pingfen p = FTInterviewBLL.PingfenManage.GetPfByParameter(kgzpid,ypzzpid,stid,xdid);
                    if (p != null)
                    {
                        DataProcess.ScoreBind(dl, xdls[ri].Score, p.Score);
                    }
                    else
                    {
                        DataProcess.ScoreBind(dl, xdls[ri].Score, -1);
                    }
                    dl.Attributes.Add("onchange", "auto_submit()");

                    ScoreDetail.Rows[ri].Cells[ci].Controls.Add(dl);
                }
            }
        }

         protected void SaveButton_Click(object sender, EventArgs e)
         {
             logger.Info("SaveButton_Click - start");
             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 ypzzpid = Convert.ToInt32(cok["ypzzpid"]);
                 kgzpid = Convert.ToInt32(cok["kgzpid"]);
                 kaotiid = Convert.ToInt32(cok["kaotiid"]);
                 logger.Info("SaveButton_Click - info, ypzzpid:" + ypzzpid + " ,kgzpid:" + kgzpid + ",kaotiid: "+kaotiid);
             }
            
             if( kaotiid == -1|| ypzzpid == -1|| kgzpid == -1){
                 Response.Redirect("../login.aspx");
             }
             logger.Info("SaveButton_Click - info1");

             List<Pingfen> pfList = new List<Pingfen>();
             List<Pingfen> updatePfList = new List<Pingfen>();

             logger.Info("SaveButton_Click - info1," + "xdls.Count:" + xdls.Count+", bzn: "+bzn);

             for (int ri = 1; ri <= xdls.Count; ri++)
             {
                 for (int ci = bzn+1; ci < bzn+sn+1; ci++)
                 {
                     int nn = ScoreDetail.Rows[ri].Cells[ci].Controls.Count;
                     DropDownList dl = (DropDownList)ScoreDetail.Rows[ri].Cells[ci].Controls[0];

                     int vale = dl.SelectedIndex-1;
                     if (vale !=-1)
                     {
                         int stid = shitils[ci-bzn];
                         int xdid = xdls[ri].Id;
                         Pingfen pf = FTInterviewBLL.PingfenManage.GetPfByParameter(kgzpid, ypzzpid, stid, xdid);
                         if (pf != null)
                         {
                             pf.Score = vale;
                             //FTInterviewBLL.PingfenManage.Update(pf);
                             updatePfList.Add(pf);
                         }
                         else
                         {
                             pf = new Pingfen();
                             pf.KgzpID = kgzpid;
                             pf.YpzzpID = ypzzpid;
                             pf.ShitiID = stid;
                             pf.XdbzID = xdid;
                             pf.Score = vale;
                            // FTInterviewBLL.PingfenManage.Add(pf);
                             pfList.Add(pf);
                         }
                     }
                 }
             }
             logger.Info("SaveButton_Click - info1," + "pfList:" + pfList + ", updatePfList: " + updatePfList);
             FTInterviewBLL.PingfenManage.batchAdd(pfList);
             FTInterviewBLL.PingfenManage.batchUpdate(updatePfList);

             
             YpzZhaopinkgzp yk = new YpzZhaopinkgzp();
             yk.YpzzpID = ypzzpid;
             yk.KgzpID = kgzpid;
             yk.KgYpzSubmitState = 0;
             FTInterviewBLL.YpzZhaopinkgzpManage.UpdateSubmitStateByypzzpkgzp(yk);

            
             

           //  Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            // Response.Write("<script language=javascript>alert('操作成功！'); </script>");  
             //Response.Write("<script language=javascript>alert('操作成功！');self.location='index.aspx'; </script>");  
         }



         protected void SubmitButton_Click(object sender, EventArgs e)
         {
             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 int _zpid = Convert.ToInt32(cok["zpid"]);
                 Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                 Response.Write("<script language=javascript>alert('提交成功！');self.location='MsInfo.aspx?zpid=" +_zpid+ "'; </script>");  
             }
            
         }

         protected void BackButton_Click(object sender, EventArgs e)
         {
             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 int _zpid = Convert.ToInt32(cok["zpid"]);
                 Response.Redirect("MsInfo.aspx?zpid=" + _zpid);
             }
            
         }

       
    }
}