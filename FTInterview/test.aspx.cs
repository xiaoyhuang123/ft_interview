using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;

namespace FTRailway
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initData();
        }

        protected void initData()
        {

            String conn_str = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            conn = new MySqlConnection(conn_str);
            conn.Open();


            String getData = "insert into stuff values(,'lognwind',100,1,'employee',1,10,'scholl','2014-10-13','男')";
            // String dep = Session["dep"].ToString();
            int dep_id = 1;
            MySqlCommand cmd = new MySqlCommand(getData, conn);
            cmd.ExecuteNonQuery();

         
        }
       
        protected MySqlConnection conn;
    }
}