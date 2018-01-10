using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msap
{
    public partial class MsgList : System.Web.UI.Page
    {
        private static int zpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["addaction"] = 1;
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                cok.Values.Remove("addaction");
                cok.Values.Add("addaction","1");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);
            }

            if (Request.QueryString["zpid"] != null)
            {
                string tttt = Request["zpid"].ToString();
                zpid = Convert.ToInt32(Request["zpid"].ToString());
            }
            if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            List<Kaoguan> ls = FTInterviewBLL.KaoguanManage.GetAllKaoguanByZp(zpid);

            MsgGridview.DataSource = ls;
            MsgGridview.DataBind();
        }
        protected void MsgSearch_Click(object sender, EventArgs e)
        {
            int bmid = Convert.ToInt32(department.SelectedValue);
            if (bmid != -1)
            {
                List<Kaoguan> ls = FTInterviewBLL.KaoguanManage.GetKaoguanByParameters(bmid);

                MsgGridview.DataSource = ls;
                MsgGridview.DataBind();
            }
        }

        protected void AddYpz_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id = Convert.ToInt32(res[i]);
                //
                KaoguanZhaopin kgzp = new KaoguanZhaopin();
                kgzp.KaoguanID = id;
                kgzp.ZhaopinID = zpid;
                kgzp.Weight = 0;

                FTInterviewBLL.KaoguanZhaopinManage.Add(kgzp);
            }
            BindData();
        }
    }
}