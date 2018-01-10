using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTInterviewSites.Index
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                if (cok.Expires.CompareTo(new DateTime()) < 0)
                {
                    TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                    cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在

                    Response.Redirect("~/login.aspx");
                }
            }


            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
          
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                NameNick.Text = Server.UrlDecode(cok["name"]);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Response.Redirect("../Login.aspx");
        } 
        
    }
}