using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.mstgl
{
    public partial class SelectOrder : System.Web.UI.Page
    {
        private static int ypzzpid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie cok = Request.Cookies["ftcook"];
                if (Request.QueryString["ypzid"] != null)
                {
                    ypzzpid = Convert.ToInt32(Request["ypzid"].ToString());

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

            if (ypzzpid != -1)
            {
                Dictionary<int, int> temp = new Dictionary<int, int>();
                YingpinzheZhaopin yz = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);

                Yingpinzhe mypz = FTInterviewBLL.YingpinzheManage.GetYingpinzheById(yz.YpzID);
                YpzName.Text = mypz.Name;

                DataTable dt = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYPZZPInzpId(yz.ZhaopinId);
                foreach(DataRow dr in dt.Rows)
                {
                    int my_id = Convert.ToInt32(dr["msIndex"].ToString());
                    if(!temp.ContainsKey(my_id))
                    {
                        temp.Add(my_id, 1);
                    }
                }
                string res = "";
                for (int i = 1; i <= dt.Rows.Count;i++ )
                {
                    if(!temp.ContainsKey(i))
                    {
                        res += i + ",";
                    }
                }
                if(res.Length>1)
                {
                    res = res.Substring(0, res.Length - 1);
                }
                HiddenField1.Value = res;
            }
        }

       
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int RandKey = ran.Next(0, 26);
            Result.Text =( 'A' + RandKey).ToString();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                ypzzpid = Convert.ToInt32(cok["ypzzpid"]);
            }
            string val = HiddenField2.Value;
            if (ypzzpid != -1 && val != "")
            {
                int idx = Convert.ToInt32(val);
                FTInterviewBLL.YingpinzheZhaopinManage.UpdateIndex(ypzzpid, idx);
               
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>window.alert('操作成功');</script>");
            }
        }
    }
}