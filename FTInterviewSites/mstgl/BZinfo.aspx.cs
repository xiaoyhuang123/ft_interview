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
    public partial class BZinfo : System.Web.UI.Page
    {
        private static int bzid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bzid"] != null)
            {
                bzid = Convert.ToInt32(Request.Params["bzid"].ToString());
            }
            else
            {
                bzid = -1;
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            if (bzid != -1)
            {
                Pingjiabiaozhun pjz = FTInterviewBLL.PingjiabiaozhunManage.GetPXBZbyId(bzid);
                myEditor.Value = pjz.Content;
            }
           
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Pingjiabiaozhun pbz = new Pingjiabiaozhun();
            pbz.Content = myEditor.Value;
            pbz.PjxdID = 1;
            pbz.CkScore = 100;
            if (bzid != -1)
            {
               // if (ScoreValue.Value != null && ScoreValue.Value != "")
                {
                    try
                    {
                        pbz.Id = bzid;
                        FTInterviewBLL.PingjiabiaozhunManage.Update(pbz);
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('更新成功！')</script>");
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('输入不合法！')</script>");
                    }
                }
            }
            else
            {
               
               // if (ScoreValue.Value != null && ScoreValue.Value != "")
               {
                    try
                    {
                        FTInterviewBLL.PingjiabiaozhunManage.Add(pbz);
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('添加成功！')</script>");
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('输入不合法！')</script>");
                    }
                }
                
            }
        }
    }
}