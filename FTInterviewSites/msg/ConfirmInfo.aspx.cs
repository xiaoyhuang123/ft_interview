using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msg
{
    public partial class ConfirmInfo : System.Web.UI.Page
    {
        private static int ypzzpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if(!IsPostBack)
            {
                if (Request.QueryString["ypzzp_id"]!=null)
                {
                   ypzzpid = Convert.ToInt32(Request["ypzzp_id"].ToString());

                   cok.Values.Remove("ypzzpid");
                   cok.Values.Add("ypzzpid", ypzzpid + "");
                   cok.Expires = DateTime.Now.AddDays(1);
                   Response.AppendCookie(cok);

                }
                BindData();
            }
        }

        protected void BindData()
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok!=null)
            {
                ypzzpid = Convert.ToInt32(cok["ypzzpid"]);
            }
           
            if(ypzzpid != -1)
            {
                YingpinzheZhaopin ypzzp = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);
                Yingpinzhe ypz = FTInterviewBLL.YingpinzheManage.GetYingpinzheById(ypzzp.YpzID);

                yName.Text = ypz.Name;
                BirthDay.Text = ypz.Birthday;
                yDegree.Text = ypz.XueliName;
                yJoinTime.Text = ypz.JoinTime;
                yDepart.Text = ypz.YpDepName;
                yPosition.Text = ypz.YpPosName;
                yPolitic.Text = ypz.PolName;
            }
            if (cok != null)
            {
                KGName.Text = Server.UrlDecode(cok["kgname"]); //cok["kgname"];

                cok.Values.Remove("ypzzpid");
                cok.Values.Add("ypzzpid", ypzzpid + "");
                cok.Expires.AddDays(1);
                Response.Cookies.Add(cok);
            }
           
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionScore.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            int zpitmid = -1;
            if (cok != null)
            {
                zpitmid = Convert.ToInt32(cok["zpitmid"].ToString());
            }
            Response.Redirect("index.aspx?zpitmid=" + zpitmid);
        }
    }
}