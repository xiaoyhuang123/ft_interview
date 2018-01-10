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

namespace FTInterviewSites.msap
{
    public partial class AddMsap0 : System.Web.UI.Page
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


        protected void BindData(int bmid = -1)
        {
            DataProcess.DepartmentBind(department);

            string str = "";
            if (Position.Items.Count > 0 && Position.SelectedItem.Text!="请选择")
            {
                str=Position.SelectedItem.Text;
            }
            //DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(bmid, "");
            DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(bmid, str,zpitmid);

            ZpgwGridview.DataSource = dt;
            AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
            ZpgwGridview.DataBind();
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            ZpgwGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        //search
        protected void StuffSearch_Click(object sender, EventArgs e)
        {
            int bmid = Convert.ToInt32(department.SelectedValue);
            string gn = "";
            if (Position.Items.Count > 0 && Position.SelectedItem.Text != "请选择")
            {
                gn=Position.SelectedItem.Text;
            }
            DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(bmid, gn, zpitmid);

            ZpgwGridview.DataSource = dt;
            AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
            ZpgwGridview.DataBind();
            /*
            if (bmid != -1)
            {
               // DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(bm, gn);
                DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(bmid, gn, zpitmid);

                ZpgwGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                ZpgwGridview.DataBind();
            }
            else
            {
                DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(-1, gn);

                ZpgwGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                ZpgwGridview.DataBind();
            }*/
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