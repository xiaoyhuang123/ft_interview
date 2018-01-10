using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msSystem
{
    public partial class kcjl : System.Web.UI.Page
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
            SystemManage sm = FTInterviewBLL.SystemManageManage.GetSystemManage();
            ContentID.InnerHtml = sm.KaochangJilv;
        }
    }
}