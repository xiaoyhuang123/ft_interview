using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.Account
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cok = Request.Cookies["ftcook"];
            if(cok!=null){
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                Response.AppendCookie(cok);
            }
            if(!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            DataProcess.UserInfoBind(UserName);
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if(UserName.SelectedItem.Text !="请选择")
            {
                if (UserName.SelectedItem.Text == "管理员")
                {
                    if (FTInterviewBLL.UserInfoManage.FindUser(UserName.SelectedItem.Text, txtPwd.Value))
                    {
                        HttpCookie cookie = new HttpCookie("ftcook");//初使化并设置Cookie的名称
                        cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                        cookie.Values.Add("name",  Server.UrlEncode("管理员"));
                       
                        cookie.Values.Add("paswd", txtPwd.Value);
                        cookie.Values.Add("isExpired", "0");
                        Response.AppendCookie(cookie);

                        Response.Redirect("Index/Manager.aspx");
                    }
                }
                else if (UserName.SelectedItem.Text == "电脑操作员")
                {
                    HttpCookie cookie = new HttpCookie("ftcook");//初使化并设置Cookie的名称
                
                    cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                    cookie.Values.Add("paswd", txtPwd.Value);
                    cookie.Values.Add("isExpired", "0");
                    Response.AppendCookie(cookie);
                    Response.Redirect("msSystem/index0.aspx");
                }
                else
                {
                    Kaoguan kg = FTInterviewBLL.KaoguanManage.FindKaoGuan(UserName.SelectedItem.Text, txtPwd.Value);
                    if (kg !=null)
                    {
                    
                        HttpCookie cookie = new HttpCookie("ftcook");//初使化并设置Cookie的名称
                        cookie.Expires = DateTime.Now.AddDays(1);
                        cookie.Values.Add("kgid", ""+ kg.Id);
                        cookie.Values.Add("kgname", Server.UrlEncode(kg.Name ));
                        cookie.Values.Add("paswd", txtPwd.Value);
                        cookie.Values.Add("isExpired", "0");
                        Response.AppendCookie(cookie);

                        Response.Redirect("Index/msg.aspx");
                    }
                }
                
            }
            
        }
    }
}