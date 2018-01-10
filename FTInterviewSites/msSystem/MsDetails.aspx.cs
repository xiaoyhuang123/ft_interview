using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using FTInterviewBLL;
using FTInterviewModel;


namespace FTInterviewSites.msSystem
{
    public partial class MsDetails : System.Web.UI.Page
    {
        private int zp_id = -1;

        //public static List<int> orderlist = new List<int>();

        private static List<YingpinzheZhaopin> ls = new List<YingpinzheZhaopin>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["zpid"] != null)
            {
                zp_id = Convert.ToInt32(Request["zpid"].ToString());
                HttpCookie cok = Request.Cookies["ftcook"];
                if(cok!=null){
                    cok.Expires = DateTime.Now.AddDays(1);
                    cok.Values.Remove("zpid");
                    cok.Values.Add("zpid", "" + zp_id);
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
                zp_id = Convert.ToInt32(cok["zpid"]);
            }
            if(zp_id !=-1)
            {
                Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(zp_id);
                ZhaopinFb zfb = FTInterviewBLL.ZhaopinFbManage.GetZhaopinFbByid(zp.ZpfbId);
                DataProcess.DepartmentBind(department);
                department.SelectedValue = "" + zfb.FbBmId;

                DataProcess.PositionBind(Position, zfb.FbBmId);
                Position.SelectedValue = zfb.ZpPosName;

                ZpSum.Value = zfb.ZpSums + "";
                PubTime.Value = zp.InterviewTime;

                department.Enabled = false;
                Position.Enabled = false;
                ZpSum.Disabled = true;
                PubTime.Disabled = true;

                /*List<YingpinzheZhaopin>*/ 
                ls = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheInzhaopinID(zp_id);

                YpSum.Text = ls.Count+"人";

                MsOrderGridview.DataSource = ls;
                MsOrderGridview.DataBind();
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                zp_id = Convert.ToInt32(cok["zpid"]);
            }
            Response.Redirect("OrderList.aspx?zpid="+zp_id);
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            foreach(YingpinzheZhaopin z in ls)
            {
                FTInterviewBLL.YingpinzheZhaopinManage.UpdateIndex(z.ID, 32767);
            }
            BindData();
        }

    }
}