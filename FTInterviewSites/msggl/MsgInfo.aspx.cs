using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTInterviewSites.msggl
{
    public partial class MsgInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["msg_id"] != null)
            {
                msgID = Convert.ToInt32(Request["msg_id"].ToString());
            }
           
            if(!IsPostBack)
            {
                BindData(msgID);
            }
        }

        protected void BindData(int msgID = -1)
        {
            work_id.Value = "1001";
            name.Value = "张三";
            company.Value = "1001";
            work_id.Value = "1001";

            //department
           // department.DataSource = DepartmentManage.GetAllDepartment();
            department.DataBind();
            department.Items.Insert(0, new ListItem("请选择", "-1"));
            department.Items.Insert(1, new ListItem("劳动人事科", "0"));
            department.Items.Insert(2, new ListItem("安全科", "1"));
            department.Items.Insert(3, new ListItem("设备科", "2"));
            department.Items.Insert(4, new ListItem("职工教育科", "3"));
            department.Items.Insert(5, new ListItem("丰台西运用车间", "4"));
            department.SelectedIndex = 2;

            //duty
            //duty.DataSource = DepartmentManage.GetAllDepartment();
//             duty.DataBind();
//             duty.Items.Insert(0, new ListItem("请选择", "-1"));
//             duty.Items.Insert(1, new ListItem("科长", "0"));
//             duty.Items.Insert(2, new ListItem("副科长", "1"));
//             duty.Items.Insert(3, new ListItem("党委书记", "2"));
//             duty.Items.Insert(4, new ListItem("一般干事", "3"));
//             duty.Items.Insert(5, new ListItem("职工", "4"));
//             duty.SelectedIndex = 1;

            psd1.Value = "123456";
        }

        //save
        protected void Add_btnClick(object sender, EventArgs e)
        {

        }

        private static int msgID = -1;

       

        protected void Reset_btnClick(object sender, EventArgs e)
        {

        }
    }
}