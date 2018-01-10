using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites
{
    public partial class AddZpitem : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["zpitmid"]!=null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"]);
                }
                BindData();
            }
        }

        protected void BindData()
        {
            if(zpitmid !=-1)
            {
                ZhaopinItem zm = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ZPitemName.Value = zm.Title;
            }
            else
            {
                ZPitemName.Value = "";
            }

        }
        protected void SaveID_Click(object sender, EventArgs e)
        {
            if (zpitmid != -1)
            {
                if (ZPitemName.Value != "")
                {
                    FTInterviewBLL.ZhaopinItemManage.UpdateZhaopinItemTitle(zpitmid, ZPitemName.Value);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
            }
            else
            {
                if(ZPitemName.Value !="")
                {
                    ZhaopinItem zm = new ZhaopinItem();
                    zm.Title = ZPitemName.Value;
                    zm.PubTime = DateTime.Now.ToString();
                    zm.ZpitemState = 1;
                    FTInterviewBLL.ZhaopinItemManage.Add(zm);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('添加成功！')</script>");
                }
            }
        }
    }
}