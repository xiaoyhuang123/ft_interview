using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTInterviewSites.mstgl
{
    public partial class ChangetikuPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ConfirmChange_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null && cok["tkpwd"] != null)
            {
                cok.Values.Remove("url");
                cok.Values.Add("url", "Add_s1.aspx");
                cok.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(cok);

                Response.Redirect("TikuPwd.aspx");
            }
               // if (Session["tkpwd"] != null)
            if (cok != null && cok["tkpwd"] != null)
                {
                    if (psd.Value.Trim() != cok["tkpwd"].ToString())
                       // if (psd.Value.Trim() != Session["tkpwd"].ToString())
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('原始密码不正确！')</script>");
                    }
                    else
                    {
                        if (psd1.Value != null && psd2.Value != null)
                        {
                            if (psd1.Value != psd2.Value)
                            {
                                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                                Response.Write("<script language=javascript>alert('新密码不一致！')</script>");
                            }
                            else
                            {
                                FTInterviewBLL.SystemManageManage.UpdateTikuPassword( psd1.Value);
                                Session["tkpwd"] = FTInterviewBLL.SystemManageManage.GetSystemManage().TikuPwd;
                                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                                Response.Write("<script language=javascript>alert('密码更新成功！')</script>");
                            }

                        }
                        else
                        {
                            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                            Response.Write("<script language=javascript>alert('密码不能为空！')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('请先登录题库！')</script>");
                }

        }
    }
}