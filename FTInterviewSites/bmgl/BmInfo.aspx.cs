using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.bmgl
{
    public partial class BmInfo : System.Web.UI.Page
    {
        private static int bmId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["dep_id"] != null)
            {
                bmId = Convert.ToInt32(Request["dep_id"].ToString());
            }

            if(!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData(int bmID=-1)
        {
            if (bmId !=-1)
            {
                Department temp = FTInterviewBLL.DepartmentManage.GetDepartmentByID(bmId);
                Dname.Value = temp.Name;
                Dinfo.Value = temp.Info;
            }
        }
        //save
        protected void Save_Click(object sender, EventArgs e)
        {
            if (bmId != -1)
            {
                Department temp = new Department();
                temp.Id = bmId;
                temp.Name = Dname.Value;
                temp.Info = Dinfo.Value;
                FTInterviewBLL.DepartmentManage.UpdateDepartment(temp);

                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('更新成功！'); </script>");  
            }
        }
    }
}