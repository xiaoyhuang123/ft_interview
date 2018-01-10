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

namespace FTInterviewSites.mstgl
{
    public partial class SearchMst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok == null || cok["tkpwd"] == null)
            {
                cok.Values.Remove("url");
                cok.Values.Add("url", "SearchMst.aspx");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);

                Response.Redirect("TikuPwd.aspx");
            }

            /*
            if(Session["tkpwd"] ==null)
            {
                Session["url"] = "SearchMst.aspx";
                Response.Redirect("TikuPwd.aspx");
            }*/
            if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            //绑定应聘岗位
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
            else
            {
                DataProcess.PositionBind(Position, -2);

                List<Kaoti> dt = new List<Kaoti>();//FTInterviewBLL.KaotiManage.GetAllKaoti();

                MsttGridview.DataSource = dt;
                AspNetPagerAskAnswer.RecordCount = dt.Count;
                MsttGridview.DataBind();
            }


        }
        //search
        protected void MsttSearch_Click(object sender, EventArgs e)
        {
            int depid = Convert.ToInt32(department.SelectedValue);
            string zposname = "";
            if (Position.Items.Count>0)
            {
                zposname = Position.SelectedItem.Text;
                zposname = (zposname == "请选择" || zposname == "" || zposname == null) ? "" : zposname;
            }
            if (depid != -1 && zposname!="")
            {
                   List<Kaoti> ktls = FTInterviewBLL.KaotiManage.GetKaotiByParameters(depid,zposname);
                   MsttGridview.DataSource = ktls;
                   AspNetPagerAskAnswer.RecordCount = ktls.Count;
                   MsttGridview.DataBind();
            }
            else
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('请选择部门和岗位！')</script>");
            }
         

        }

        //delete
        protected void DeleteStuff_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_ypz = Convert.ToInt32(res[i]);
                FTInterviewBLL.KaotiManage.DeleteKaoti(id_ypz);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MsttGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
        }
    }
}