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

namespace FTInterviewSites.ypzgl
{
    public partial class SearchYpz : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["zpitmid"]!=null)
                {
                    zpitmid=Convert.ToInt32(Request["zpitmid"].ToString());
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            List<Yingpinzhe> ls = new List<Yingpinzhe>();
            if(zpitmid !=-1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ItemTitle.Text = zim.Title;
                //ls = FTInterviewBLL.YingpinzheManage.GetAllYingpinzhe();
                ls = FTInterviewBLL.YingpinzheManage.GetAllYingpinzheInZpItem(zpitmid);
            }

            YpzGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            YpzGridview.DataBind();
        }
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            YpzGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        //search
        protected void StuffSearch_Click(object sender, EventArgs e)
        {
            string ypzname = YpzName.Value;
            int bmid = Convert.ToInt32(department.SelectedValue);
            //List<Yingpinzhe> ls = FTInterviewBLL.YingpinzheManage.GetYingpinzheByParameters(ypzname, bmid);
            List<Yingpinzhe> ls = FTInterviewBLL.YingpinzheManage.GetYingpinzheInZpItemByParameters(zpitmid,ypzname, bmid);

            YpzGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            YpzGridview.DataBind();
        }

        //delete
        protected void DeleteYpz_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_ypz = Convert.ToInt32(res[i]);
                FTInterviewBLL.YingpinzheManage.DeleteYingpinzheByID(id_ypz);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }
    }
}