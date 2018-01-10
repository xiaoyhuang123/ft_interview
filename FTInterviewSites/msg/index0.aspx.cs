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
    public partial class index0 : System.Web.UI.Page
    {
        private static int msgid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                msgid = Convert.ToInt32(cok["kgid"]);
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            //List<ZhaopinItem> ls = FTInterviewBLL.ZhaopinItemManage.GetAllZhaopinItemList();
            List<ZhaopinItem> ls = FTInterviewBLL.ZhaopinItemManage.GetAllZhaopinItemListWithKgaoguan(msgid);
            ZpitmGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            ZpitmGridview.DataBind();
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                msgid = Convert.ToInt32(cok["kgid"]);
            }

            string _name = ZpitemName.Value;
            List<ZhaopinItem> ls = FTInterviewBLL.ZhaopinItemManage.GetAllZhaopinItemListWithKgaoguan(msgid,_name);
            ZpitmGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            ZpitmGridview.DataBind();
        }
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            ZpitmGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }
    }
}