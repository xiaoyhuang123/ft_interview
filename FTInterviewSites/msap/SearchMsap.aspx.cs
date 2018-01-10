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
    public partial class SearchMsap : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            DataProcess.PositionBind(Position, -1);

            if (zpitmid != -1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ItemTitle.Text = zim.Title;

                List<Zhaopin> ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid);

                MslbGridview.DataSource = ls;
                AspNetPagerAskAnswer.RecordCount = ls.Count;
                MslbGridview.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int zpbmid=Convert.ToInt32(department.SelectedValue);
            string zpgwname="";
            if(Position.Items.Count>0 && Position.SelectedItem.Text !="请选择")
            {
                zpgwname = Position.SelectedValue;
            }
            string stime=startDate.Value;
            string etime=endDate.Value;
            if(stime !="")
            {
                stime += " 00:00:00";
            }
            if(etime !="")
            {
                etime += " 23:59:59";
            }

           // List<Zhaopin> ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListByparameters(zpbmid, zpgwname, stime, etime);
            List<Zhaopin> ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid,zpbmid, zpgwname, stime, etime);

            MslbGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            MslbGridview.DataBind();
        }
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MslbGridview.PageIndex = e.NewPageIndex - 1;
            BindData();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        //delete
        protected void DeleteStuff_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id = Convert.ToInt32(res[i]);
                FTInterviewBLL.ZhaopinManage.DeleteZhaopinByID(id);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
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