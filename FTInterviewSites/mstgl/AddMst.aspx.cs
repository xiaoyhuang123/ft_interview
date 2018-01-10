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
    public partial class AddMst : System.Web.UI.Page
    {
        private static  int gwId=-1;
        private static int ktid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ktid"] != null)
           {
               ktid = Convert.ToInt32(Request["ktid"].ToString());
           }
            if (Request.QueryString["gwid"] != null)
            {
                gwId = Convert.ToInt32(Request["gwid"].ToString());
            }
            if (!Page.IsPostBack)
            {
                BindData(false);
            }
           
        }

        //delete
        protected void Deletesgiti_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_shiti = Convert.ToInt32(res[i]);
                FTInterviewBLL.PingfenManage.DeleteByShitiid(id_shiti);
                FTInterviewBLL.ShitiManage.DeleteByID(id_shiti);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }

        protected void BindData(bool isfirst=true)
        {
            DataProcess.DepartmentBind(department);
           
            if (gwId != -1)
            {
                DataProcess.KaotiBind(Sumti, gwId);
                ZhaopinGw zg = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwByid(gwId);

                DataProcess.PositionBind(Position,zg.ZpDepart);
                department.SelectedValue = zg.ZpDepart + "";
                Position.SelectedValue = zg.ZpPosition;
                department.Enabled = false;
                Position.Enabled = false;

                int t_temp = Convert.ToInt32(Sumti.SelectedValue);

             
                    List<Shiti> ls;
                    if (t_temp != -1)
                    {
                        ls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(t_temp);
                    }
                    else
                    {
                        ls = new List<Shiti>();
                    }
                    MsttGridview.DataSource = ls;
                    AspNetPagerAskAnswer.RecordCount = ls.Count;
                    MsttGridview.DataBind();
                    int sum_test = 0;
                 if (isfirst)
                 {
                    foreach (Shiti sstt in ls)
                    {
                        sum_test += sstt.Weight;
                    }
                    if (sum_test < 100)
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('权重和不为1！')</script>");
                    }
                    if (sum_test > 100)
                    {
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('权重大于1，请合理分配！')</script>");
                    }
                }
             
            }
            else
            {
                if(ktid !=-1)
                {
                    Kaoti kt = FTInterviewBLL.KaotiManage.GetKaotiByID(ktid);
                    DataProcess.KaotiBind(Sumti, kt.ZpgwId);
                    ZhaopinGw zg = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwByid(kt.ZpgwId);

                    department.SelectedValue = zg.ZpDepart + "";

                    DataProcess.PositionBind(Position, Convert.ToInt32(department.SelectedValue));
                    Position.SelectedValue = zg.ZpPosition;
                    Sumti.SelectedValue = kt.Id + "";

                    TTime.Value = kt.CreateTime;
                    department.Enabled = false;
                    Position.Enabled = false;
                    Sumti.Enabled = false;

                    int t_temp = kt.Id;

                   
                        List<Shiti> ls;
                        if (t_temp != -1)
                        {
                            ls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(t_temp);
                        }
                        else
                        {
                            ls = new List<Shiti>();
                        }

                        MsttGridview.DataSource = ls;
                        AspNetPagerAskAnswer.RecordCount = ls.Count;
                        MsttGridview.DataBind();
                        Sumti_SelectedIndexChanged();
                     if (isfirst)
                    {
                        int sum_test = 0;
                        foreach (Shiti sstt in ls)
                        {
                            sum_test += sstt.Weight;
                        }
                        if (sum_test < 100)
                        {
                            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                            Response.Write("<script language=javascript>alert('权重和不为1！')</script>");
                        }
                        if (sum_test > 100)
                        {
                            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                            Response.Write("<script language=javascript>alert('权重大于1，请合理分配！')</script>");
                        }
                    }
                  
                }
                else
                {
                    DataProcess.KaotiBind(Sumti, -2);
                    List<Shiti> ls = new List<Shiti>();
                    AspNetPagerAskAnswer.RecordCount = ls.Count;
                    MsttGridview.DataBind();
                }
              
            }
        }
       
        protected void AspNetPagerAskAnswer_PageChanging(object src, PageChangingEventArgs e)
        {
            MsttGridview.PageIndex = e.NewPageIndex - 1;
            BindData();

            AspNetPagerAskAnswer.CurrentPageIndex = e.NewPageIndex - 1;
        }

        protected void MsttGridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MsttGridview.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void MsttGridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MsttGridview.EditIndex = -1;
            BindData();
        }

        protected void MsttGridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id =Convert.ToInt32(MsttGridview.DataKeys[e.RowIndex].Value.ToString());
            int ktid = Convert.ToInt32(Sumti.SelectedValue);
            if ( ktid !=-1)
            {
                int weisum = FTInterviewBLL.ShitiManage.getShitiWeightsInkaoti(ktid,id);
              
                int new_time = Convert.ToInt32(((TextBox)(MsttGridview.Rows[e.RowIndex].Cells[3].FindControl("TextTime"))).Text.ToString().Trim());
                int new_weight = Convert.ToInt32(((TextBox)(MsttGridview.Rows[e.RowIndex].Cells[4].FindControl("TextBox1"))).Text.ToString().Trim());

                FTInterviewBLL.ShitiManage.UpdateWeight_Time(id, new_weight, new_time);
                if (weisum + new_weight <= 100)
                {
                    FTInterviewBLL.ShitiManage.UpdateWeight_Time(id, new_weight, new_time);

                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
                else
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('超出范围，请合理分配权值！')</script>");
                }
            }
            BindData();
        }

        protected void Sumti_SelectedIndexChanged()
        {
            int t_temp=Convert.ToInt32(Sumti.SelectedValue);
            if(t_temp != -1)
            {
                Session["ktid"] = t_temp;

                Kaoti kt_t = FTInterviewBLL.KaotiManage.GetKaotiByID(t_temp);
                TTime.Value = kt_t.CreateTime;

                List<Shiti> ls = FTInterviewBLL.ShitiManage.GetAllShitiByKaotiId(t_temp);
                MsttGridview.DataSource = ls;
                AspNetPagerAskAnswer.RecordCount = ls.Count;
                MsttGridview.DataBind();
            }
        }

        protected void Confirm_Button_Click(object sender, EventArgs e)
        {
            Sumti_SelectedIndexChanged();
        }

    }
}