using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
//using MySQLDriverCS;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace FTRailway
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_onclick(object sender, EventArgs e)
        {

            String conn_str = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            MySqlConnection conn = new MySqlConnection(conn_str);
            conn.Open();

            string uname = this.txtName.Value;
            string upwd = this.txtPwd.Value;

           

            string strSql = "select * from authority where username= @username  and password= @pwd";

            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            cmd.Parameters.Add(new MySqlParameter("username",uname));
            cmd.Parameters.Add(new MySqlParameter("pwd", upwd));
         
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                //Response.Redirect("STManager/ManagerLogin.aspx");
                if (sdr.Read())
                {
                    Session["username"] = sdr["username"];
                    Session["level"] = sdr["auth_lev"];
                   // Session["STNoAdmin"] = sdr["STNoAdmin"];
                    if (Session["level"].ToString() == "0")
                    {
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }

            }
            sdr.Close();
            conn.Close();
            //if (Session["level"].ToString() == "0")
            //{
            //    Response.Redirect("STUser/UserLogin.aspx");
            //}
            //else
            //{
            //    Response.Redirect("STManager/ManagerLogin.aspx");
            //}
            
        }
    }
}