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
    public partial class zpitmindex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            List<ZhaopinItem> ls = FTInterviewBLL.ZhaopinItemManage.GetAllZhaopinItemList();
            ZpitmGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            ZpitmGridview.DataBind();
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string _name = ZpitemName.Value;
            if (_name != "")
            {
                List<ZhaopinItem> ls = FTInterviewBLL.ZhaopinItemManage.GetAllZhaopinItemListByTitle(_name);
                ZpitmGridview.DataSource = ls;
                AspNetPagerAskAnswer.RecordCount = ls.Count;
                ZpitmGridview.DataBind();
            }
            else
            {
                BindData();
            }
        }

        protected void DeleteZpitm_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_zpitm = Convert.ToInt32(res[i]);
                FTInterviewBLL.ZhaopinItemManage.DeleteZhaopinByID(id_zpitm);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            ZpitmGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }
    }
}