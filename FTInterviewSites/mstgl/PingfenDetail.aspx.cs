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
    public partial class PingfenDetail : System.Web.UI.Page
    {
        private static int xdnum = 0;
        private static int bznum = 0;
        private static List<Xiangdianbiaozhun> xdbzls=new List<Xiangdianbiaozhun>();

        private static List<Pingjiaxiangdian> xdls = new List<Pingjiaxiangdian>();
        private static List<Pingjiabiaozhun> bzls = new List<Pingjiabiaozhun>();

        //private static Dictionary<int, Dictionary<int, string>> conlist = new Dictionary<int, Dictionary<int, string>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
           /* List<Pingjiaxiangdian>*/ xdls = FTInterviewBLL.PingjiaxiangdianManage.GetAll();
           /* List<Pingjiabiaozhun>*/ bzls = FTInterviewBLL.PingjiabiaozhunManage.GetAll();
            xdnum = xdls.Count;
            bznum = bzls.Count;
            xdbzls = FTInterviewBLL.XiangdianBiaozhunManage.GetAll();


            DataTable dt = new DataTable("xdbz");
            dt.Columns.Add("pjxd", typeof(string));
            for (int i = 1; i <= bzls.Count; i++)
            {
                dt.Columns.Add("bz" + i, typeof(string));
            }
          

            DataRow dr = dt.NewRow();
            dr["pjxd"] = "项点";
            for (int i = 1; i <= bzls.Count; i++)
            {
                dr["bz" + i] = bzls[i - 1].Content;
            }
            dt.Rows.Add(dr);

            for (int i = 1; i <= xdls.Count; i++)
            {
                dr = dt.NewRow();
                dr["pjxd"] = xdls[i-1].Content;
                dt.Rows.Add(dr);
            }

            DetailGridview.DataSource = dt;
            DetailGridview.DataBind();

            double w=1/bzls.Count;
            for (int i = 0; i <= bzls.Count; i++)
            {
                DetailGridview.Rows[0].Cells[i].Width = Unit.Percentage(w);
            }
             

           // int ide = 0;
            for (int ri = 1; ri <= xdls.Count; ri++)
            {
                for (int ci = 1; ci <= bzls.Count; ci++)
                {
                    TextBox tb = new TextBox();
                    tb.Width = Unit.Percentage(90);
                    tb.Height = Unit.Percentage(90);
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.Wrap = true;
                    
                    //tb.Text = xdbzls[ide].MyContent;//concdd[ide]; 
                    foreach(Xiangdianbiaozhun xdbzz in xdbzls)
                    {
                        if (xdbzz.PjxdID == xdls[ri-1].Id && xdbzz.PjbzID == bzls[ci-1].Id)
                        {
                            tb.Text = xdbzz.MyContent;
                            break;
                        }
                    }

                   // ide++;
                    DetailGridview.Rows[ri].Cells[ci].Controls.Add(tb);
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int idex = 0;
            for (int ri = 1; ri <= xdnum; ri++)
            {
                for (int ci = 1; ci <= bznum; ci++)
                {
                    TextBox dl = (TextBox)DetailGridview.Rows[ri].Cells[ci].Controls[0];
                    string context = dl.Text;

                    foreach (Xiangdianbiaozhun xdbzz in xdbzls)
                    {
                        if (xdbzz.PjxdID == xdls[ri - 1].Id && xdbzz.PjbzID == bzls[ci - 1].Id)
                        {
                            xdbzz.MyContent = context;
                            FTInterviewBLL.XiangdianBiaozhunManage.Update(xdbzz);
                            break;
                        }
                    }
                }
            }
            Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            Response.Write("<script language=javascript>alert('保存成功！')</script>");  

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pingfengl.aspx");
        }

    }
}