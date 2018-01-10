using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msSystem
{
    public partial class Question : System.Web.UI.Page
    {
        private static int index = 1;

        private static int ktid = -1;
        private static int zpid = -1;
        private static List<Shiti> stls = new List<Shiti>();


        protected void Page_Load(object sender, EventArgs e)
        {
             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 if (cok["zpid"] != null)
                 {
                     zpid = Convert.ToInt32(cok["zpid"].ToString());
                     Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(zpid);
                     ktid = zp.KaotiID;

                     cok.Values.Remove("ktid");
                     cok.Values.Add("ktid", ktid + "");
                     cok.Expires = DateTime.Now.AddDays(1);
                     Response.AppendCookie(cok);
                 }
                 else
                 {
                     Response.Redirect("../login.aspx");
                 }
             }
             else
             {
                 Response.Redirect("../login.aspx");
             }
          
            if (Request.QueryString["ms_id"] != null)
            {
                int ypzzpid = Convert.ToInt32(Request["ms_id"]);
                YingpinzheZhaopin y = FTInterviewBLL.YingpinzheZhaopinManage.GetYPZZPbyId(ypzzpid);

                cok.Values.Remove("ypzzpid");
                cok.Values.Add("ypzzpid", y.ID + "");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);
            }

            if(!IsPostBack)
            {
                stls.Clear();
                index = 1;
                BindData(); 
            }
        }

        protected void BindData()
        {
            if(ktid !=-1)
            {
                QuestionID.Text = Convert.ToString(index);
                if(stls.Count==0)
                {
                    stls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(ktid);
                }
              if(stls.Count >= index)
                {
                    CurrentID.Text = Convert.ToString(index);
                    Totals.Text = Convert.ToString(stls.Count);
                    QuestionName.Text = stls[index - 1].Question;
                    HiddenField1.Value = stls[index - 1].StTime.ToString();

                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "RestTime();", true);
                }
            }
            if(index==stls.Count)
            {
                NextButton.Enabled=false;
            }
            else
            {
                NextButton.Enabled = true;
            }

            if (index == 1)
            {
                PreButton.Enabled = false;
            }
            else
            {
                PreButton.Enabled = true;
            }
        }


        protected void NextButton_Click(object sender, EventArgs e)
        {
            index++;
            if (index >=stls.Count)
            { index = stls.Count; }

            BindData();
        }

        protected void QuitButton_Click(object sender, EventArgs e)
        {
            //Response.Redirect("OrderList.aspx");
            Response.Redirect("ShowScore.aspx");
        }

        protected void PreButton_Click(object sender, EventArgs e)
        {
            index--;
            if (index <= 1)
            { index = 1; }
            BindData();
        }
    }
}