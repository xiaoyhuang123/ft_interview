using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;
using System.Data;

namespace FTInterviewSites.msggl
{
    public partial class AddMsg : System.Web.UI.Page
    {
        private static int msgid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["msg_id"] != null)
                {
                    msgid = Convert.ToInt32(Request["msg_id"]);
                }
                else
                {
                    msgid=-1;
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            if (msgid != -1)
            {
                Kaoguan kg = FTInterviewBLL.KaoguanManage.GetKaoguanByID(msgid);
                work_id.Value = kg.WorkID;
                name.Value = kg.Name;
                department.SelectedValue= kg.DepID+"";
                Duty.Value = kg.PositionName;
                Pwsd.Attributes.Add("value", kg.Pwd);//重点
            }
            else
            {
                Pwsd.Attributes.Add("value", "123456");
            }
        }

        //save
        protected void Add_btnClick(object sender, EventArgs e)
        {
            Kaoguan kg = new Kaoguan();
            kg.WorkID=work_id.Value;
            kg.Name = name.Value ;
            kg.DepID = Convert.ToInt32(department.SelectedValue);
            kg.PositionName=Duty.Value;
            kg.Pwd = Pwsd.Text;

            kg.Company = "北京铁路局丰台机务段";

//             if (Convert.ToInt32(department.SelectedValue)==-1)
//             {
//                 Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
//                 Response.Write("<script language=javascript>alert('请选择部门！')</script>");
//             }
//             else
            {
                if (msgid != -1)
                {
                    kg.Id = msgid;
                    FTInterviewBLL.KaoguanManage.UpdateKaoguan(kg);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
                else
                {
                    FTInterviewBLL.KaoguanManage.Add(kg);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('添加成功！')</script>");
                }
            }
            BindData();
        }

        //reset
        protected void Reset_btnClick(object sender, EventArgs e)
        {
            if (msgid == -1)
            {
                work_id.Value = "";
                name.Value = "";
             
                Duty.Value = "";
                Pwsd.Text = "";
            }
        }

        //password rest
        protected void Reset_Click(object sender, EventArgs e)
        {
           if(msgid != -1)
           {
               FTInterviewBLL.KaoguanManage.UpdataPassword(msgid,"123456");
               BindData();
               Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
               Response.Write("<script language=javascript>alert('密码重置成功！')</script>");
           }
        }
    }
}