using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.mstgl
{
    public partial class XDinfo : System.Web.UI.Page
    {
        private static int xdid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["xdid"] != null)
            {
                xdid = Convert.ToInt32(Request.Params["xdid"].ToString());
            }
            else
            {
                xdid = -1;
            }

            if(!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            if (xdid != -1)
            {
                Pingjiaxiangdian pd = FTInterviewBLL.PingjiaxiangdianManage.GetPXXDbyId(xdid);
                myEditor.Value = pd.Content;
                ScoreValue.Value = pd.Score + "";
            }
          
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Pingjiaxiangdian pxd = new Pingjiaxiangdian();
            pxd.Content = myEditor.Value;
            pxd.Score = 0;
            if (xdid != -1)
            {
                if (ScoreValue.Value != null && ScoreValue.Value != "")
                {
                    try
                    {
                        int s = Convert.ToInt32(ScoreValue.Value);
                        pxd.Score = s;
                        pxd.Id = xdid;
                        FTInterviewBLL.PingjiaxiangdianManage.Update(pxd);
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
                if(ScoreValue.Value !=null && ScoreValue.Value!="")
                {
                    try
                    {
                        int s = Convert.ToInt32(ScoreValue.Value);
                        pxd.Score = s;
                        FTInterviewBLL.PingjiaxiangdianManage.Add(pxd);
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