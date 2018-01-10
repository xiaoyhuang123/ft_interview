using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.msap
{
    public partial class AddMsap : System.Web.UI.Page
    {
        private static int id = -1;
        private static int zpfbid = -1;
        public string zpidstr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
                //Session["addaction"] = null;
                HttpCookie cok = Request.Cookies["ftcook"];
                if (cok != null)
                {
                    cok.Values.Remove("addaction");
                    //Response.AppendCookie(cok);
                }


                if (Request.QueryString["zpfb_id"] != null)
                {
                    zpfbid = Convert.ToInt32(Request["zpfb_id"].ToString());
                    id = -1;
                }
                else
                {
                    zpfbid = -1;
                }
               
                zpidstr = id + "";
            }
//             else
//             {
//                 zpidstr = id + "";
//             }
            zpidstr = id + "";
            BindData(id);
        }

        protected void BindData(int _id=-1)
        {
            DataProcess.DepartmentBind(department);
            List<KaoguanZhaopin> ls = new List<KaoguanZhaopin>();
            List<Yingpinzhe> ypzls = new List<Yingpinzhe>();

            if(id !=-1)
            {
                Step2Part.Visible = true;
                Zhaopin zp = FTInterviewBLL.ZhaopinManage.GetZhaopinById(id);
                zpfbid = zp.ZpfbId;
                
                ZhaopinFb zf = FTInterviewBLL.ZhaopinFbManage.GetZhaopinFbByid(zp.ZpfbId);

                //MsName.Value = zp.Title;       
                MsTime.Value = zp.InterviewTime;
                HegeScore.Value = zp.HegeLine + "";

                /////////////////////msg
                ls = FTInterviewBLL.KaoguanZhaopinManage.GetKgZPbyzpId(id);
                MsgGridview.DataSource = ls;
                MsgGridview.DataBind();
                /////////////////////ypz
                ypzls = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheInzhaopin(id);
                YpzGridview.DataSource = ypzls;
                YpzGridview.DataBind();
            }
            else
            {
                //HegeScore.Value = "60";
                Step2Part.Visible = false;
            }

            MsgGridview.DataSource = ls;
            MsgGridview.DataBind();
            YpzGridview.DataSource = ypzls;
            YpzGridview.DataBind();

            if(zpfbid !=-1)
            {
                ZhaopinFb zf = FTInterviewBLL.ZhaopinFbManage.GetZhaopinFbByid(zpfbid);
                department.SelectedValue = zf.FbBmId+"";
                DataProcess.PositionBind(Position, zf.FbBmId);
                Position.SelectedValue = zf.ZpPosName;
            }
            department.Enabled = false;
            Position.Enabled = false;
        }

        //save
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteMsg_Click(object sender, EventArgs e)
        {
            string[] res = hdfWPBH.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id = Convert.ToInt32(res[i]);

                FTInterviewBLL.KaoguanZhaopinManage.Delete(id);
            }
            BindData();
        }

        protected void DeleteYpz_Click(object sender, EventArgs e)
        {
            string[] res = HiddenField1.Value.Split(',');
            for (int i = 0; i < res.Length - 1; i++)
            {
                int id = Convert.ToInt32(res[i]);

                FTInterviewBLL.YingpinzheZhaopinManage.Delete(id);
            }
            BindData();
        }

        protected void AddYpz_Click(object sender, EventArgs e)
        {

        }

        protected void MsgGridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MsgGridview.EditIndex = -1;
            BindData();
        }

        protected void MsgGridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MsgGridview.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void MsgGridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int w=0;//=Convert.ToDouble(((TextBox)MsgGridview.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Trim());

            string te=((TextBox)MsgGridview.Rows[e.RowIndex].Cells[5].FindControl("TextBox1")).Text.ToString();
            
            if(te!="")
            {
                try
                {
                    w = Convert.ToInt32(te);
                    int sum=w;
                    for (int i = 0; i < MsgGridview.Rows.Count && i!=e.RowIndex;i++ )
                    {
                        string tem=((Label)MsgGridview.Rows[i].Cells[5].FindControl("Label1")).Text.ToString();
                        sum += Convert.ToInt32(tem);
                    }
                    if (sum > 100)
                   {
                       Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                       Response.Write("<script language=javascript>alert('权重大于1，请重新分配！')</script>");
                   }
                    else
                    {
                        int idd = Convert.ToInt32(MsgGridview.DataKeys[e.RowIndex].Value.ToString());
                        FTInterviewBLL.KaoguanZhaopinManage.UpdateWeight(idd, w);
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('更新成功！')</script>");
                    }
                }
                catch (System.Exception ex)
                {
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('输入不合理！')</script>");
                }
            }
           BindData();
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定应聘岗位
            int bid = Convert.ToInt32(department.SelectedValue);
            if (bid != -1)
            {
                DataProcess.PositionBind(Position, bid);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
          
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                Zhaopin zpt = new Zhaopin();
                zpt.Title = department.SelectedItem.Text + "-" + Position.SelectedItem.Text + "招聘";
                zpt.InterviewTime = MsTime.Value;
                zpt.KaotiID = -1;
                zpt.HegeLine = Convert.ToInt32(HegeScore.Value);
                zpt.ZpState = 1;
                zpt.ZpfbId = zpfbid;

                int zpid_new = FTInterviewBLL.ZhaopinManage.AddReturnID(zpt);
                id = zpid_new;
                zpidstr = id + "";
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('添加成功！')</script>");
            }
            else
            {
                HttpCookie cok = Request.Cookies["ftcook"];
              
                if (cok == null || cok["addaction"] ==null)
                //if( Session["addaction"] ==null)
                {
                    Zhaopin zpt = FTInterviewBLL.ZhaopinManage.GetZhaopinById(id);
                    zpt.InterviewTime = MsTime.Value;
                    zpt.HegeLine = Convert.ToInt32(HegeScore.Value);

                    zpidstr = id + "";

                    FTInterviewBLL.ZhaopinManage.Update(zpt);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
                else
                {
                    //Session["addaction"] = null;
                    //if (cok != null)
                    {
                        cok.Values.Remove("addaction");
                       // Response.AppendCookie(cok);
                    }
                }
             
                
            }
          

            BindData();

        }
    }
}