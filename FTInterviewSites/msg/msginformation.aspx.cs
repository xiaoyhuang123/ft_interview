using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewModel;
using FTInterviewBLL;

namespace FTInterviewSites.msg
{
    public partial class msginformation : System.Web.UI.Page
    {
        private static int msgid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cok = Request.Cookies["ftcook"];
                if (cok != null)
                {
                    msgid = Convert.ToInt32(cok["kgid"]);
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
                department.SelectedValue = kg.DepID + "";
                Duty.Value = kg.PositionName;
            }
        }

        //save
        protected void Add_btnClick(object sender, EventArgs e)
        {
            if (msgid != -1)
            {
                Kaoguan kg = FTInterviewBLL.KaoguanManage.GetKaoguanByID(msgid);
                kg.Id = msgid;
                kg.WorkID = work_id.Value;
                kg.Name = name.Value;
                kg.DepID = Convert.ToInt32(department.SelectedValue);
                kg.PositionName = Duty.Value;

                FTInterviewBLL.KaoguanManage.UpdateKaoguan(kg);
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('更新成功！')</script>");
            }
//             else
//             {
//                 FTInterviewBLL.KaoguanManage.Add(kg);
//                 Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
//                 Response.Write("<script language=javascript>alert('添加成功！')</script>");
//             }
            BindData();
        }
    }
}