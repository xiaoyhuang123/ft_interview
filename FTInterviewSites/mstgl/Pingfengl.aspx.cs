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
    public partial class Pingfenmanager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<Pingjiaxiangdian> xdls = FTInterviewBLL.PingjiaxiangdianManage.GetAll();

            XdGridview.DataSource = xdls;
            XdGridview.DataBind();

            if(FTInterviewBLL.PingjiaxiangdianManage.GetPingjiaxiangdianScoreSum()!=100)
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('项点和不等于100！')</script>");
            }

            List<Pingjiabiaozhun> bzls = FTInterviewBLL.PingjiabiaozhunManage.GetAll();
            BZGridview.DataSource = bzls;
            BZGridview.DataBind();

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void RestButton_Click(object sender, EventArgs e)
        {

        }

//         protected void AddXD_Click(object sender, EventArgs e)
//         {
//             
//         }

        protected void DeleteXD_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_xd = Convert.ToInt32(res[i]);

                FTInterviewBLL.PingfenManage.DeleteByXdid(id_xd);
                FTInterviewBLL.XiangdianBiaozhunManage.DeleteByXDID(id_xd);
                FTInterviewBLL.PingjiaxiangdianManage.DeleteByID(id_xd);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }

        protected void DeleteBZ_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH1.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id_ypz = Convert.ToInt32(res[i]);
                FTInterviewBLL.XiangdianBiaozhunManage.DeleteByBZID(id_ypz);
                FTInterviewBLL.PingjiabiaozhunManage.DeleteByID(id_ypz);
            }

            BindData();
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('删除成功！')</script>");
        }

        protected void XdGridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            XdGridview.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void XdGridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(XdGridview.DataKeys[e.RowIndex].Value.ToString());
            {
                int val_score = Convert.ToInt32(((TextBox)(XdGridview.Rows[e.RowIndex].Cells[3].FindControl("TextBox1"))).Text.ToString().Trim());
               
                FTInterviewBLL.PingjiaxiangdianManage.UpdateScore(id, val_score);
                if (FTInterviewBLL.PingjiaxiangdianManage.GetPingjiaxiangdianScoreSum() != 100)
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('项点分值和不等于100！')</script>");
                }
                else
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
            }
            BindData();
        }

        protected void XdGridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            XdGridview.EditIndex = -1;
            BindData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Pingjiaxiangdian> xdls = FTInterviewBLL.PingjiaxiangdianManage.GetAll();
            List<Pingjiabiaozhun> bzls = FTInterviewBLL.PingjiabiaozhunManage.GetAll();
            List<Xiangdianbiaozhun> xdbzls = FTInterviewBLL.XiangdianBiaozhunManage.GetAll();
            
            for (int i = 0; i < xdls.Count; i++)
            {
                for (int j = 0; j < bzls.Count; j++)
                {
                    bool flag = false;
                    for (int k = 0; k < xdbzls.Count;k++ )
                    {
                        Xiangdianbiaozhun te=xdbzls[k];
                        if (te.PjxdID == xdls[i].Id && te.PjbzID == bzls[j].Id)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Xiangdianbiaozhun new_temp = new Xiangdianbiaozhun();
                        new_temp.PjxdID = xdls[i].Id;
                        new_temp.PjbzID = bzls[j].Id;
                        new_temp.MyContent = "";
                        FTInterviewBLL.XiangdianBiaozhunManage.Add(new_temp);
                    }

                }
            }
            Response.Redirect("PingfenDetail.aspx");
        }
    }
}