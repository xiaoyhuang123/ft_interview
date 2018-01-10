using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msSystem
{
    public partial class ShowScore : System.Web.UI.Page
    {
        private static int ypzzpid = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null && cok["ypzzpid"] != null)
            {
                ypzzpid = Convert.ToInt32(cok["ypzzpid"].ToString());
            }
            else
            {
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                Response.AppendCookie(cok);
                Response.Redirect("../login.aspx");
            }

            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null && cok["ypzzpid"] != null)
            {
                ypzzpid = Convert.ToInt32(cok["ypzzpid"].ToString());
            }
            if (ypzzpid!=-1)
            {
                YingpinzheZhaopin ypzzp = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);
                YpzName.Text = ypzzp.YpzName;

                double sc = FTInterviewBLL.PingfenManage.GetScoreSums(ypzzp.ID);
                ResultScore.Text = Convert.ToString(sc);
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Session["ypzzpid"] = null;
           /* HttpCookie cok = Request.Cookies["ftcook"];
            TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
            cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在

            Response.AppendCookie(cok);*/
            HttpCookie cok = Request.Cookies["ftcook"];
            cok.Values.Remove("ypzzpid");
            cok.Expires = DateTime.Now.AddDays(1);
            Response.AppendCookie(cok);
            Response.Redirect("OrderList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}