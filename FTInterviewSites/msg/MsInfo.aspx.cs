using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Wuqi.Webdiyer;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msg
{
    public partial class MsInfo : System.Web.UI.Page
    {
        private static int zpid = -1;
        private static int kgzpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["zpid"] != null)
                {
                    HttpCookie cok = Request.Cookies["ftcook"];
                    if (cok != null)
                    {
                        zpid = Convert.ToInt32(Request["zpid"]);

                        int _zpid = zpid;// Convert.ToInt32(Session["zpid"]);
                        int _kgid = Convert.ToInt32(cok["kgid"]);
                        kgzpid = FTInterviewBLL.KaoguanZhaopinManage.GetKgZPbyKgIdZpid(_kgid, _zpid).Id;

                        cok.Values.Remove("zpid");
                        cok.Values.Remove("kgzpid");
                        cok.Values.Add("zpid", "" + zpid);
                        cok.Values.Add("kgzpid", "" + kgzpid);

                        cok.Expires = DateTime.Now.AddDays(1);
                        Response.AppendCookie(cok);
                    }
                    
                }
                else
                {
                    zpid = -1;
                    HttpCookie cok = Request.Cookies["ftcook"];
                    //Response.Cookies.Remove("zpid");
                    cok.Values.Remove("zpid");
                    cok.Expires = DateTime.Now.AddDays(1);
                    Response.AppendCookie(cok);
                }
                BindData();
            }
        }

        protected void BindData()
        {
             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 zpid = Convert.ToInt32(cok["zpid"]);
                 kgzpid = Convert.ToInt32(cok["kgzpid"]);
             }


            if (zpid != -1 && kgzpid!=-1)
            {
                try
                {
                    Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(zpid);
                    MsTitle.Text = zp.Title;

                    ZhaopinFb fb = FTInterviewBLL.ZhaopinFbManage.GetZhaopinFbByid(zp.ZpfbId);
                    DataProcess.DepartmentBind(department, fb.FbBmId);
                    department.Enabled = false;
                    DataProcess.PositionBind(Position, fb.FbBmId);
                    Position.SelectedValue = fb.ZpPosName;
                    Position.Enabled = false;

                    ZpSum.Value = fb.ZpSums + "";
                    PubTime.Value = zp.InterviewTime;
                    ZpSum.Disabled = true;
                    PubTime.Disabled = true;

                    DataTable dt = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYPZZPInzpId(zpid);

                    dt.Columns.Add("Score", typeof(string));
                    dt.Columns.Add("State", typeof(string));
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["SubState"] = FTInterviewBLL.YpzZhaopinkgzpManage.GetByypzidkgid(
                            Convert.ToInt32(dr["Id"].ToString()), kgzpid).KgYpzSubmitState + "";

                        if (dr["SubState"].ToString() == "1")
                        {
                            dr["State"] = "已提交";
                        }
                        else if (dr["SubState"].ToString() == "0")
                        {
                            dr["State"] = "未提交";
                        }

                        dr["Score"] = FTInterviewBLL.PingfenManage.GetScoreSums(Convert.ToInt32(dr["Id"].ToString()),
                            kgzpid);
                    }
                    /*
                    DataTable dtCopy = dt.Copy();
                    DataView dv = dt.DefaultView;
                    dv.Sort = "Score desc";
                    dtCopy = dv.ToTable();
                    */

                    MszGridview.DataSource = dt;
                    AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                    MszGridview.DataBind();
                }
                catch (System.Exception ex)
                {
                	
                }
              
            }
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MszGridview.PageIndex = e.NewPageIndex - 1;
            BindData();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        //submit
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] res = hdfWPBH.Value.Split(',');
                for (int i = 0; i < res.Length - 1; i++)
                {
                    int id_ypz = Convert.ToInt32(res[i]);
                    //更新
                    /*  YingpinzheZhaopin ypzzp = new YingpinzheZhaopin();
                      ypzzp.ID = id_ypz;
                      ypzzp.SubmitState = 1;
                      FTInterviewBLL.YingpinzheZhaopinManage.UpdateSubmitState(ypzzp);*/
                    YpzZhaopinkgzp yk = new YpzZhaopinkgzp();
                    yk.YpzzpID = id_ypz;
                    yk.KgzpID = kgzpid;
                    yk.KgYpzSubmitState = 1;
                    FTInterviewBLL.YpzZhaopinkgzpManage.UpdateSubmitStateByypzzpkgzp(yk);

                }
                BindData();
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('提交成功！')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('" + ex .ToString()+ "！')</script>");
            }

        }

    }
}