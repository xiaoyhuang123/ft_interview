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
    public partial class index : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie cok = Request.Cookies["ftcook"];
               
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"].ToString());
                    if (cok != null)
                    {
                        cok.Expires = DateTime.Now.AddDays(1);
                        cok.Values.Remove("zpitmid");
                        cok.Values.Add("zpitmid", "" + zpitmid);
                        Response.AppendCookie(cok);
                    }
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            DataProcess.PositionBind(Position, -1);

            HttpCookie cok = Request.Cookies["ftcook"];
            if(cok!=null){
                zpitmid = Convert.ToInt32(cok["zpitmid"]);
            }

            if (zpitmid != -1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);
                ItemTitle.Text = zim.Title;

                List<Zhaopin> ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid);

                MslbGridview.DataSource = ls;
                AspNetPagerAskAnswer.RecordCount = ls.Count;
                MslbGridview.DataBind();
            }
        }
       
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MslbGridview.PageIndex = e.NewPageIndex - 1;
            DataBind();
            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            int did = Convert.ToInt32(department.SelectedValue);
            string gwname = "";
            if (Position.Items.Count >= 1 && Position.SelectedItem.Text != "请选择")
            {
                gwname = Position.SelectedItem.Text;
            }

            List<Zhaopin> ls = FTInterviewBLL.ZhaopinManage.GetAllZhaopinListInZpItemId(zpitmid,did, gwname);

            MslbGridview.DataSource = ls;
            AspNetPagerAskAnswer.RecordCount = ls.Count;
            MslbGridview.DataBind();
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定应聘岗位
            int bid = Convert.ToInt32(department.SelectedValue);
            //if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
        }
    }
}