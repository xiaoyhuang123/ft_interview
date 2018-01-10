using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;
using System.Data;

namespace FTInterviewSites.zpgwgl
{
    public partial class AddZpgw : System.Web.UI.Page
    {
        private static int zpfbid = -1;
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["zpfbid"] != null)
                {
                    zpfbid = Convert.ToInt32(Request["zpfbid"].ToString());
                }
                else
                {
                    zpfbid = -1;
                }
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"].ToString());
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            if (zpfbid != -1)
            {
                ZhaopinFb zf = FTInterviewBLL.ZhaopinFbManage.GetZhaopinFbByid(zpfbid);
                if(zf !=null)
                {
                    zpitmid = zf.ZpitmId;
                    department.SelectedValue = zf.FbBmId + "";
                    ZpgwName.Value = zf.ZpPosName;
                    ZpSum.Value = Convert.ToString(zf.ZpSums);
                }
            }
        }
        //save
        protected void Add_btnClick(object sender, EventArgs e)
        {
            if (zpfbid == -1)//add new 
            {
                int tid = Convert.ToInt32(department.SelectedValue.ToString());
                if (tid == -1)
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('请选择部门！')</script>");
                }
                else
                {
                    int bmid= tid;//Convert.ToInt32(department.SelectedValue);
                    string zpgw = ZpgwName.Value;
                    int num = Convert.ToInt32(ZpSum.Value);


                    int zpgwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(tid, zpgw);
                    if(zpgwid ==-1)
                    {
                        ZhaopinGw zg = new ZhaopinGw();
                        zg.ZpDepart = tid;
                        zg.ZpPosition = zpgw;
                        FTInterviewBLL.ZhaopinGwManage.Add(zg);
                        zpgwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(tid, zpgw);
                    }

                    if(zpgwid !=-1)
                    {
                        ZhaopinFb zf = new ZhaopinFb();
                        zf.ZpGwID = zpgwid;
                        zf.ZpSums = num;
                        zf.ZpFbTime = DateTime.Now.ToString();
                        zf.FbState = 1;
                        zf.ZpitmId = zpitmid;
                        FTInterviewBLL.ZhaopinFbManage.Add(zf);

                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('添加成功！')</script>");
                    }
                    else
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('添加失败！')</script>");
                    }
                  
                }
            }
            else
            {
                int tid = Convert.ToInt32(department.SelectedValue.ToString());
                if (tid == -1)
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('请选择部门！')</script>");
                }
                else
                {
                    string zpgw = ZpgwName.Value;
                    int num = Convert.ToInt32(ZpSum.Value);

                    int zpgwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(tid, zpgw);
                    if (zpgwid == -1)
                    {
                        ZhaopinGw zg = new ZhaopinGw();
                        zg.ZpDepart = tid;
                        zg.ZpPosition = zpgw;
                        FTInterviewBLL.ZhaopinGwManage.Add(zg);
                        zpgwid = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwID(tid, zpgw);
                    }

                    if (zpgwid != -1)
                    {
                        ZhaopinFb zf = new ZhaopinFb();
                        zf.Id = zpfbid;
                        zf.ZpGwID = zpgwid;
                        zf.ZpSums = num;
                        zf.ZpFbTime = DateTime.Now.ToString();
                        zf.FbState = 1;
                        zf.ZpitmId = zpitmid;
                        FTInterviewBLL.ZhaopinFbManage.Update(zf);

                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('更新成功！')</script>");
                    }
                    else
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('更新失败！')</script>");
                    }
                }
            }
           
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchZpgw.aspx?zpitmid=" + zpitmid);
        }
    }
}