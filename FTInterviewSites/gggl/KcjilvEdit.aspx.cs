using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.gggl
{
    public partial class Kcjv : System.Web.UI.Page
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
            SystemManage sm = FTInterviewBLL.SystemManageManage.GetSystemManage();
            myEditor.InnerHtml = sm.KaochangJilv;
        }
        //saves
        protected void Button1_Click(object sender, EventArgs e)
        {
            string kcjvstr =  Server.HtmlDecode(myEditor.InnerHtml);
            FTInterviewBLL.SystemManageManage.UpdateKaochangjilv(kcjvstr);
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('更新成功')</script>");
        }
    }
}