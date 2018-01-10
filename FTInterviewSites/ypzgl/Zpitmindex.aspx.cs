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
    public partial class Zpitmindex : System.Web.UI.Page
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
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            ZpitmGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }
    }
}