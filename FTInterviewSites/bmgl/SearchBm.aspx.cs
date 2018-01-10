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

namespace FTInterviewSites.bmgl
{
    public partial class SearchBm : System.Web.UI.Page
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
            List<Department> res = FTInterviewBLL.DepartmentManage.GetAllDepartment();
            //List<Department> res = FTInterviewBLL.DepartmentManage.GetDepartmentByName(bmName);
            BmGridview.DataSource = res;
            AspNetPagerAskAnswer.RecordCount = res.Count;
            BmGridview.DataBind();
        }

        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            BmGridview.PageIndex = e.NewPageIndex - 1;
            BindData();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int did=Convert.ToInt32(BmGridview.DataKeys[e.RowIndex].Value.ToString());
            //did 部门id
            FTInterviewBLL.DepartmentManage.Delete(did);
            BindData();
        }

        //search
        protected void Button1_Click(object sender, EventArgs e)
        {
            string bmName = Dname.Value;
            List<Department> res = FTInterviewBLL.DepartmentManage.GetDepartmentByName(bmName);
            BmGridview.DataSource = res;
            AspNetPagerAskAnswer.RecordCount = res.Count;
            BmGridview.DataBind();
        }
    }
}