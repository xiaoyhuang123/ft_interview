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
    public partial class index1 : System.Web.UI.Page
    {
        private static int msgid = -1;
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                msgid = Convert.ToInt32(cok["kgid"]);
            }
            if(!IsPostBack)
            {
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"]);
                    cok.Values.Remove("zpitmid");
                    cok.Values.Add("zpitmid",zpitmid+"");
                    cok.Expires = DateTime.Now.AddDays(1);
                    Response.AppendCookie(cok);
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);

            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                zpitmid = Convert.ToInt32(cok["zpitmid"].ToString());
            }

            if (zpitmid != -1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ItemTitle.Text = zim.Title;

                DataTable dt = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInItemIdByKaoguan(zpitmid, msgid);

                MslbGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                MslbGridview.DataBind();
            }
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MslbGridview.PageIndex = e.NewPageIndex - 1;
            DataBind();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
        }


        //search
        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            int bid = Convert.ToInt32(department.SelectedValue);
             string pos="";

             if (Position.Items.Count > 0 && Position.SelectedItem.Text != "请选择")
             {
                 pos = Position.SelectedValue;
             }

             HttpCookie cok = Request.Cookies["ftcook"];
             if (cok != null)
             {
                 zpitmid = Convert.ToInt32(cok["zpitmid"].ToString());
                 msgid = Convert.ToInt32(cok["kgid"]);
             }

             DataTable ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInItemIdByKaoguan(zpitmid,msgid, bid, pos);
           
            MslbGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Rows.Count;
            MslbGridview.DataBind();
        }
    }
}