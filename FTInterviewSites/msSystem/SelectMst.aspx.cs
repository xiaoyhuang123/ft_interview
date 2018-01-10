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
    public partial class SelectMst : System.Web.UI.Page
    {
        private static int zpid = -1;
        private static Dictionary<char, int> myres = new Dictionary<char, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                zpid = Convert.ToInt32(cok["zpid"].ToString());
            }
            else
            {
                
                Response.Redirect("../login.aspx");
            }

            if(!IsPostBack)
            {
                myres.Clear();
                BindData();
            }
        }

        protected void BindData()
        {
            if (zpid !=-1)
            {
                string res = "";
                List<Kaoti> ls = FTInterviewBLL.KaotiManage.GetKaotiByZpID(zpid);
                if(ls.Count >0)
                {
                    for (int i = 0; i < ls.Count; i++)
                    {
                        char ch = Convert.ToChar('A' + i);
                        myres.Add(ch, ls[i].Id);
                        res += ch + ",";
                    }
                    if (res.Length > 1)
                    {
                        res = res.Substring(0, res.Length - 1);
                        HiddenField1.Value = res;
                    }
                }
                else
                {

                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('当前岗位无考题，请退出！'); </script>");
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                zpid = Convert.ToInt32(cok["zpid"].ToString());
            }

            if (zpid != -1)
            {
                char t = Convert.ToChar(HiddenField2.Value);
                if ( t != ' ')
                {
                    int mstindex = myres[t];

                    FTInterviewBLL.ZhaopinManage.UpdateKaotiIndex(zpid, mstindex);

                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('选题成功！'); </script>");
                }
            }
        }


        protected void Stop_Click(object sender, EventArgs e)
        {
           // Timer1.Enabled = false;
           
        }
    }
}