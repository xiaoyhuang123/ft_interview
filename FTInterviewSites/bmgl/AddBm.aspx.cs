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
    public partial class AddBm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //save
        protected void Save_Click(object sender, EventArgs e)
        {
            string departname = Dname.Value;
            string departinfo = Dinfo.Value;

            Department temp = new Department();
            temp.Id = -1;
            temp.Name = departname;
            temp.Info = departinfo;
            FTInterviewBLL.DepartmentManage.Add(temp);

            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('添加成功！'); </script>");  
        }
    }
}