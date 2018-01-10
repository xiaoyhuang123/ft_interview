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

namespace FTInterviewSites.msjggl
{
    public partial class MsResult : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid=Convert.ToInt32(Request["zpitmid"].ToString());
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            DataProcess.PositionBind(Position, Convert.ToInt32(department.SelectedValue));

            ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
            if(zim != null)
            {
                ItemTitle.Text = zim.Title;
            }
            //List<Zhaopin> zpls=FTInterviewBLL.ZhaopinManage.GetAllZhaopinListByparameters();
            List<Zhaopin> zpls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid);

            MslbGridview.DataSource = zpls;
            AspNetPagerAskAnswer.RecordCount = zpls.Count;
            MslbGridview.DataBind();
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MslbGridview.PageIndex = e.NewPageIndex - 1;
            BindData();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }


        //search button
        protected void Button1_Click(object sender, EventArgs e)
        {
            int depid = Convert.ToInt32(department.SelectedValue);
            string posname = "";// Position.SelectedItem.Text;
            if (Position.Items.Count > 0 && Position.SelectedItem.Text!="请选择")
            {
                posname = Position.SelectedItem.Text;
            }
            string st = startDate.Value;
            string et = startDate.Value;

            List<Zhaopin> zpls =  FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid,depid,posname,st,et);
            MslbGridview.DataSource = zpls;
            AspNetPagerAskAnswer.RecordCount = zpls.Count;
            MslbGridview.DataBind();

           /* int zpgwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(depid, posname);

            if (zpgwid != -1)
            {
                string stime = startDate.Value;
                string etime = endDate.Value;
                List<Zhaopin> zpls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListByparameters(depid,posname,stime,etime);

                MslbGridview.DataSource = zpls;
                AspNetPagerAskAnswer.RecordCount = zpls.Count;
                MslbGridview.DataBind();
            }
            else
            {
                List<Zhaopin> zpls = new List<Zhaopin>();
                MslbGridview.DataSource = zpls;
                AspNetPagerAskAnswer.RecordCount = zpls.Count;
                MslbGridview.DataBind();
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