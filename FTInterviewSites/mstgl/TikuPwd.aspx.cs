using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTInterviewSites.Account
{
    public partial class TikuPWD : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void ConfirmChange_Click(object sender, EventArgs e)
        {
            string tkpwd_input = psd.Value;
           // if(tkpwd_input !="")
            {
                if (FTInterviewBLL.SystemManageManage.GetSystemManage().TikuPwd == tkpwd_input)
                {
                   // Session["tkpwd"] = tkpwd_input;// "123456";
                    String url = "";

                    HttpCookie cok = Request.Cookies["ftcook"];
                    if (cok != null)
                    {
                        url=cok["url"].ToString();
                        cok.Values.Remove("tkpwd");
                        cok.Values.Add("tkpwd", tkpwd_input);
                        cok.Expires = DateTime.Now.AddDays(1);
                        Response.AppendCookie(cok);
                    }

                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('题库登陆成功！');self.location='" + url + "'; </script>");  
                }
                else
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('题库密码错误！'); </script>");  
                }
            }

        }

        protected void ResetChange_Click(object sender, EventArgs e)
        {
            psd.Value = "";
        }
    }
}