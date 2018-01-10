using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FTInterviewSites.Index
{
    public partial class Msg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            HttpCookie cok = Request.Cookies["ftcook"];
            if (cok != null)
            {
                NameNick.Text = Server.UrlDecode(cok["kgname"]);
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

    }
}