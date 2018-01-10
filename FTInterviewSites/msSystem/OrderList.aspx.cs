using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msSystem
{
    public partial class OrderList : System.Web.UI.Page
    {
        private static int zpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["zpid"] != null)
            {
                zpid = Convert.ToInt32(Request["zpid"]);

                HttpCookie cok = Request.Cookies["ftcook"];
                if (cok != null)
                {
                    cok.Values.Remove("zpid");
                    cok.Values.Add("zpid", "" + zpid);
                    cok.Expires = DateTime.Now.AddDays(1);
                    Response.AppendCookie(cok);
                }
            }
            if(!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                zpid = Convert.ToInt32(cok["zpid"]);
            }
          if (zpid!=-1)
          {
              string xuantistate = "抽选考题";
              Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(zpid);
              if(zp.KaotiID !=-1)
              {
                  xuantistate="已"+xuantistate;
                  XuanTi.ControlStyle.ForeColor = System.Drawing.Color.Green;

                   ResultID.Visible = true;
                   LabelRes.Text = zp.KaotiID + "";
              }
              else
              {
                   xuantistate="未"+xuantistate;
                   XuanTi.ControlStyle.ForeColor = System.Drawing.Color.Red;
                  
                  ResultID.Visible = false;
                  
              }
               XuanTi.Text = xuantistate;
              List<YingpinzheZhaopin> ls = 
                  FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheInzhaopinID(zpid);
              MsOrderGridview.DataSource = ls;
              MsOrderGridview.DataBind();
          }
        }
    }
}