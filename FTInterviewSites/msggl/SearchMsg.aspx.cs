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

namespace FTInterviewSites.msggl
{
    public partial class SearchMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);

            List<Kaoguan> ls = FTInterviewBLL.KaoguanManage.GetAll();

            MsgGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            MsgGridview.DataBind();
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MsgGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        //search
        protected void StuffSearch_Click(object sender, EventArgs e)
        {

            int bmid = Convert.ToInt32(department.SelectedValue);
            string kgname = wName.Value;

            List<Kaoguan> ls = FTInterviewBLL.KaoguanManage.GetKaoguanByParameters(bmid, kgname);

            MsgGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            MsgGridview.DataBind();
        }

        //delete
        protected void DeleteStuff_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id = Convert.ToInt32(res[i]);
                FTInterviewBLL.KaoguanManage.DeleteKaoguan(id);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }
    }
}