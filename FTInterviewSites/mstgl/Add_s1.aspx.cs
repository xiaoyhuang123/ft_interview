using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;
using System.Data;

namespace FTInterviewSites.mstgl
{
    public partial class Add_s1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok == null || cok["tkpwd"] == null)
            {
                cok.Values.Remove("url");
                cok.Values.Add("url", "Add_s1.aspx");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);

                Response.Redirect("TikuPwd.aspx");
            }
            /*

            if (Session["tkpwd"] == null)
            {
                Session["url"] = "Add_s1.aspx";
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
            DataProcess.PositionBind(Position, -2);
        }

        //next
        protected void SaveBm_Click(object sender, EventArgs e)
        {
            List<string> msg = new List<string>();
            int bmid = Convert.ToInt32(department.SelectedValue);
            int sums = Convert.ToInt32(Sumti.SelectedValue);
            if(bmid ==-1)
            {
                msg.Add("请选择部门！");
            }
            if(Position.Items.Count==0 || Position.SelectedItem.Text=="请选择")
            {
                msg.Add("请选择岗位！");
            }
            if(msg.Count>0)
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('" + msg[0] + "')</script>");
            }
            else
            {
                int gpgw = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(bmid, Position.SelectedItem.Text);
                int msum = FTInterviewBLL.KaotiManage.GetKaotiSumsInGw(gpgw);

                if (sums > msum)
                {
                    for (int i = msum + 1; i <= sums;i++ )
                    {
                        Kaoti kt = new Kaoti();
                        kt.Title = department.SelectedItem.Text + " " + Position.SelectedValue + " 招聘面试题";
                        kt.ZpgwId = gpgw;
                        kt.KtState = 1;
                        kt.CreateTime = DateTime.Now.ToShortDateString();
                        // int addktid = FTInterviewBLL.KaotiManage.Add(kt);
                        FTInterviewBLL.KaotiManage.Add(kt);
                    }
                  
                }

                if (gpgw != -1)
                {
                    string url = "AddMst.aspx?gwid=" + gpgw;
                    Response.Redirect(url);
                }
            }
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定应聘岗位
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
            else
            {
                DataProcess.PositionBind(Position, -2);
            }
        }

        protected void Position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Position.SelectedItem.Text !="请选择")
            {
                Title.Value = department.SelectedItem.Text + " " + Position.SelectedItem.Text + " 招聘面试题";

                 int bid = Convert.ToInt32(department.SelectedValue);
                 if (bid != -1)
                 {
                     int gwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(bid, Position.SelectedItem.Text);
                     int sums = FTInterviewBLL.KaotiManage.GetKaotiSumsInGw(gwid);
                     foreach (ListItem lt in Sumti.Items)
                     {
                         int m_s=Convert.ToInt32(lt.Value);
                         if(m_s<=sums && m_s !=-1)
                         {
                             lt.Attributes.Add("disabled", "disabled");
                         }
                     }
                 }
            }
        }
    }
}