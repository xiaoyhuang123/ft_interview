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

namespace FTInterviewSites.zpgwgl
{
    public partial class SearchZpgw : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        public string itmid_str = "";

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
            itmid_str = zpitmid + "";
        }

        protected void BindData(int bmid=-1)
        {
            DataProcess.DepartmentBind(department);
            if(zpitmid !=-1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);

                ItemTitle.Text = zim.Title;
                if (bmid != -1)
                {
                    department.SelectedValue = bmid + "";
                }
                string gn = gwName.Value;

                //DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(bmid, gn);
                DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(bmid, gn,zpitmid);

                ZpgwGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                ZpgwGridview.DataBind();
            }
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
            int bm =Convert.ToInt32(department.SelectedValue);
            string gn = gwName.Value;

            if(bm !=-1)
            {
                //DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(bm, gn);
                DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(bm, gn,zpitmid);

                ZpgwGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                ZpgwGridview.DataBind();
            }
            else
            {
                //DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFb(-1, gwName.Value);
                DataTable dt = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinFbInItem(-1, gn, zpitmid);

                ZpgwGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Rows.Count;
                ZpgwGridview.DataBind();
            }
        }

        //delete
        protected void DeleteStuff_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_z = Convert.ToInt32(res[i]);
                FTInterviewBLL.ZhaopinFbManage.DeleteZhaopinFb(id_z);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }

    }
}