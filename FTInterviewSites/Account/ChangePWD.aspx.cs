using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTInterviewSites.Account
{
    public partial class ChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
        }

        protected void ConfirmChange_Click(object sender, EventArgs e)
        {
            if(Session["kgname"]!=null)//面试官
            {
                if(Session["kgid"]!=null)
                {
                    if (psd.Value.Trim()!=Session["paswd"].ToString())
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('原始密码不正确！')</script>");
                    }
                    else
                    {
                        if (psd1.Value!=null && psd2.Value!=null)
                        {
                            if (psd1.Value != psd2.Value)
                            {
                                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                                Response.Write("<script language=javascript>alert('新密码不一致！')</script>");
                            }
                            else
                            {
                                 FTInterviewBLL.KaoguanManage.UpdataPassword(Convert.ToInt32(Session["kgid"]), psd1.Value);
                                Session["paswd"] = psd1.Value;
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
            }
            else if (Session["name"] != null && Session["name"].ToString() == "管理员")//管理员
            {
                if (Session["name"].ToString() == "管理员")
                {
                    if (psd.Value.Trim() != Session["paswd"].ToString())
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
                                FTInterviewBLL.UserInfoManage.UpdatePassword(Session["name"].ToString(), psd1.Value);
                                Session["paswd"] = psd1.Value;
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
            }
        }
    }
}