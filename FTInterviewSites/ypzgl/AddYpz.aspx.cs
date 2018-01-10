using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FTInterviewBLL;
using FTInterviewModel;

namespace FTInterviewSites.ypzgl
{
    public partial class AddYpz : System.Web.UI.Page
    {
        private static int ypzid = -1;
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["ypz_id"] != null)
                {
                    ypzid = Convert.ToInt32(Request["ypz_id"]);
                }
                else
                {
                    ypzid=-1;
                }
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"]);
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataProcess.DepartmentBind(department);
            DataProcess.PoliticBind(PolDP);
            DataProcess.XueliBind(XueliDP);

            if (zpitmid!=-1)
            {
              YpFbList.DataSource = FTInterviewBLL.ZhaopinFbManage.GetAllZhaopinItem(zpitmid);
              YpFbList.DataBind();
            }
            YpFbList.Items.Insert(0, new ListItem("请选择", "-1"));

            if(ypzid !=-1)
            {
                Yingpinzhe ypz = FTInterviewBLL.YingpinzheManage.GetYingpinzheById(ypzid);
                name.Value = ypz.Name;
                SexDP.SelectedValue = ypz.Sex;
                Birthday.Value = ypz.Birthday;
                department.SelectedValue = ypz.DepartId+"";
                Duty.Value = ypz.PositionName;
                XueliDP.SelectedValue = ypz.XueliId + "";
                join_time.Value = ypz.JoinTime;
                PolDP.SelectedValue = ypz.PoliticId + "";

                //ZhaopinGw zg = FTInterviewBLL.ZhaopinGwManage.GetZhaopinGwByid(ypz.ZpfbId);
                YpFbList.SelectedValue = ypz.ZpfbId + "";
            }
           
        }
        //save
        protected void Add_btnClick(object sender, EventArgs e)
        {
            List<string> msg=new List<string>();

            string ypzname = name.Value;
            string sex = SexDP.SelectedItem.Text;
            string birth = Birthday.Value;
            string bm = department.SelectedValue;
            string dutyname = Duty.Value;
            string xueli = XueliDP.SelectedValue;
            string jointime = join_time.Value;
            string polic = PolDP.SelectedValue;
            string zpfbstr = YpFbList.SelectedValue;

            if(Convert.ToInt32(bm)==-1)
            {
                msg.Add("请选择所在部门！");
            }
            if (Convert.ToInt32(xueli) == -1)
            {
                msg.Add("请选择学历！");
            }
            if (Convert.ToInt32(polic) == -1)
            {
                msg.Add("请选择政治面貌！");
            }
            if (Convert.ToInt32(zpfbstr) == -1)
            {
                msg.Add("请选择应聘岗位与部门！");
            }

            if(msg.Count>0)
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('"+msg[0]+"')</script>");
            }
            else
            {
                Yingpinzhe ypz = new Yingpinzhe();
                ypz.Name = ypzname;
                ypz.Sex = sex;
                ypz.Birthday = birth;
                ypz.JoinTime = jointime;
                ypz.DepartId = Convert.ToInt32(bm);
                ypz.PositionName = dutyname;
                ypz.XueliId = Convert.ToInt32(xueli);
                ypz.PoliticId = Convert.ToInt32(polic);
                ypz.Company = "北京铁路局丰台机务段";

                ypz.ZpfbId = Convert.ToInt32(zpfbstr);
                
                if (ypzid != -1)
                {
                    ypz.ID = ypzid;
                    FTInterviewBLL.YingpinzheManage.Update(ypz);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");
                }
                else
                {
                    FTInterviewBLL.YingpinzheManage.Add(ypz);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('添加成功！')</script>");

                }
            }
        }
    }
}