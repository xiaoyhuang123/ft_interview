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

namespace FTInterviewSites.systemmanage
{
    public partial class Historylist : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"].ToString());
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);

            DataProcess.PositionBind(Position, Convert.ToInt32(department.SelectedValue));

            if (zpitmid != -1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ItemTitle.Text = zim.Title;

                DataTable dt = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheResultInzhaopinItemId(zpitmid);
                MslbGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                MslbGridview.DataBind();
            }
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MslbGridview.PageIndex = e.NewPageIndex - 1;
            BindData();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            int depid = Convert.ToInt32(department.SelectedValue);
            string posname = "";
            if (Position.Items.Count>0 && Position.SelectedItem.Text!="请选择")
            {
                posname = Position.SelectedItem.Text;
            }
            {
                 string stime = startDate.Value;
                string etime = endDate.Value;
               // DataTable dt = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheResultInzhaopinID(zpgwid, stime, etime);
                DataTable dt = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheResultInzhaopinItemId(zpitmid,depid,posname,stime,etime);

                MslbGridview.PageIndex = 1;
                AspNetPagerAskAnswer.CurrentPageIndex = 1;

                MslbGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                MslbGridview.DataBind();
            }
//             else
//             {
//                 DataTable dt = new DataTable();
//                 MslbGridview.DataSource = dt;
//                 AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
//                 MslbGridview.DataBind();
//             }
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定应聘岗位
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
        }

    }
}