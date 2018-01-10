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
    public partial class YpzList : System.Web.UI.Page
    {
        private static int zpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["addaction"] = 1;
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                cok.Values.Remove("addaction");
                cok.Values.Add("addaction", "1");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);
            }

            if(!IsPostBack)
            {
                if (Request.QueryString["zpid"]!=null)
                {
                    zpid = Convert.ToInt32(Request["zpid"]);
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
          
            List<Yingpinzhe> ls = FTInterviewBLL.YingpinzheManage.GetAllYingpinzheByZp(zpid);

            YpzGridview.DataSource = ls;
            YpzGridview.DataBind();
        }
        //search
        protected void StuffSearch_Click(object sender, EventArgs e)
        {
            string ypzname = YpzName.Value;
            int depid =Convert.ToInt32( department.SelectedValue );
            List<Yingpinzhe> ls = FTInterviewBLL.YingpinzheManage.GetAllYingpinzheByZpAndParameters(zpid,true,ypzname,depid);

            YpzGridview.DataSource = ls;
            YpzGridview.DataBind();
        }

        //add result
        protected void AddYpz_Click(object sender, EventArgs e)
        {
            if ( zpid!=-1)
            {
                string[] res = hdfWPBH.Value.Split(',');
                for (int i = 0; i < res.Length - 1; i++)
                {
                    int id = Convert.ToInt32(res[i]);

                    YingpinzheZhaopin yzp = new YingpinzheZhaopin();
                    yzp.YpzID = id;
                    yzp.ZhaopinId = zpid;
                    yzp.MsIndex = 32767;
                    yzp.SubmitState = 1;

                    FTInterviewBLL.YingpinzheZhaopinManage.Add(yzp);
                }

                BindData();
            }
        }
    }
}