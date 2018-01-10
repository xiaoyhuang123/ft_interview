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
using MySql.Data.MySqlClient;

using FTRailwayModel;

namespace FTRailway
{
public partial class tab : System.Web.UI.Page
{
    protected void Page_Load ( object sender, EventArgs e )
    {
        if ( !IsPostBack )
        {
            Bind();
        }
    }

    protected void Bind()
    {
        GridView_Stuff.DataSource = FTRailwayBLL.StuffManage.GetAllStuff();
        GridView_Stuff.DataBind();

    }


    protected void Add_Stuff ( object sender, EventArgs e )
    {
//             Stuff stuff = new Stuff();
//             stuff.Name = txtName.Value;
//             stuff.Sex = txtSex.Value;
//             stuff.Work_id = txtWorkId.Value;
//             //stuff.Dep_id =
//             int nResult = FTRailwayBLL.StuffManage.Add(stuff);
//             if (nResult > 0)
//             {
//                 Response.Redirect(Request.Url.ToString());
//             }
    }


    protected DataTable dt;
    protected MySqlConnection conn;

    protected void GridView_Stuff_RowEditing ( object sender, GridViewEditEventArgs e )
    {

    }

    protected void GridView_Stuff_RowDeleting ( object sender, GridViewDeleteEventArgs e )
    {

    }

    protected void GridView_Stuff_RowUpdating ( object sender, GridViewUpdateEventArgs e )
    {

    }

}
}