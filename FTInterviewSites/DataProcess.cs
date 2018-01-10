using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;


namespace FTInterviewSites
{
    public class DataProcess 
    {
        //bind department
        public static void DepartmentBind(DropDownList ddlist,int id=-1)
        {
            List<Department> delist = FTInterviewBLL.DepartmentManage.GetAllDepartment();
            ddlist.DataSource = delist;
            ddlist.DataBind();
            ddlist.Items.Insert(0, new ListItem("请选择", "-1"));
            if(id != -1)
            {
               ddlist.SelectedValue = Convert.ToString(id);
            }
          
        }

        //bind position
        public static void PositionBind(DropDownList ddlist,int depid=-1,int id=-1)
        {
            DataTable dt = FTInterviewBLL.ZhaopinGwManage.GetAllZhaopinGw(depid);
            if(depid ==-1)
            {
                dt.Clear();
            }
            ddlist.DataSource = dt;
            ddlist.DataBind();
            ddlist.Items.Insert(0, new ListItem("请选择", "请选择"));
            if (id != -1)
            {
                // ddlist.SelectedIndex = id;
            }
        }

        //bind politic
        public static void PoliticBind(DropDownList ddlist,int id=-1)
        {
            List<Politic> delist = FTInterviewBLL.PoliticManage.GetAllPolitic();
            ddlist.DataSource = delist;
            ddlist.DataBind();
            ddlist.Items.Insert(0, new ListItem("请选择", "-1"));
            if (id != -1)
            {
                 ddlist.SelectedValue = id+"";
            }
        }

        //bind politic
        public static void XueliBind(DropDownList ddlist, int id = -1)
        {
            List<Xueli> delist = FTInterviewBLL.XueliManage.GetAll();
            ddlist.DataSource = delist;
            ddlist.DataBind();
            ddlist.Items.Insert(0, new ListItem("请选择", "-1"));
            if (id != -1)
            {
                ddlist.SelectedValue = id + "";
            }
        }


        //bind ypgw将部门bmid内的招聘岗位绑定到dropdownlist
        public static void YpgwBind(DropDownList ddlist,int bmid = -1)
        {
          if(bmid !=-1)
          {
            //  List<Zhaopin> zplist = FTInterviewBLL.ZhaopinManage;
          }
        }

        //bind 套题
        public static void KaotiBind(DropDownList ddlist,int zpgwid, int s_index = -1)
        {

            List<Kaoti> ktls = FTInterviewBLL.KaotiManage.GetKaotiByZpgwID(zpgwid);

            int size_kaoti = ktls.Count;

            ddlist.Items.Insert(0, new ListItem("请选择","-1"));
            for (int i = 1; i <= size_kaoti; i++)
            {
                ListItem itemAll = new ListItem();
                //itemAll.Text = Convert.ToString(i+'A');
                itemAll.Text = ((char)((i - 1) + 'A')).ToString(); 
                itemAll.Value = Convert.ToString(ktls[i-1].Id);
                ddlist.Items.Insert(i, itemAll);
            }
            if (s_index != -1)
            {
                ddlist.SelectedValue = s_index+"";
            }
        }




        //bind score
        public static void ScoreBind(DropDownList ddlist, int score,int s_index=-1)
        {
            ddlist.Items.Insert(0,new ListItem("请选择", "-1"));
            for (int i = 1; i <= score+1; i++)
            {
                ListItem itemAll = new ListItem();
                itemAll.Text = Convert.ToString(i-1);
                itemAll.Value = Convert.ToString(i-1);
                ddlist.Items.Insert(i, itemAll);
            }
            if (s_index !=-1)
            {
                ddlist.SelectedValue = s_index+"";
            }
            else
            {
                ddlist.SelectedIndex = 0;
            }
        }

        public static void UserInfoBind(DropDownList ddlist)
        {
            List<Kaoguan> delist = FTInterviewBLL.KaoguanManage.GetAll();
            int i = 0;
            foreach(Kaoguan kg in delist)
            {
                ddlist.Items.Insert(3 + i, new ListItem(kg.Name, kg.Name));
                i++;
            }
        }
    }
}