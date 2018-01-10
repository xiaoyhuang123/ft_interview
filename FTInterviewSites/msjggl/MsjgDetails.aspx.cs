using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using System.IO;
using System.Text;

using FTInterviewBLL;
using FTInterviewModel;


namespace FTInterviewSites.msjggl
{
    public partial class MsjgDetails : System.Web.UI.Page
    {
        private static int zpitmid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["zpitmid"] != null)
                {
                    zpitmid = Convert.ToInt32(Request["zpitmid"]);
                }
                BindData();
            }
        }

        protected void BindData()
        {
            if (zpitmid != -1)
            {
                ZhaopinItem zim = FTInterviewBLL.ZhaopinItemManage.GetZhaopinItemById(zpitmid);

                title_f.Text = zim.Title+"面试成绩";

                //List<YingpinzheZhaopin> ls = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheInzhaopinID(zpid);
                List<YingpinzheZhaopin> ls = FTInterviewBLL.YingpinzheZhaopinManage.GetAllYingpinzheInzhaopinItemID(zpitmid);

                DataTable dt = new DataTable("msg");
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("bm_duty", typeof(string));
                dt.Columns.Add("duty", typeof(string));
                dt.Columns.Add("ypdep_pos", typeof(string));
                dt.Columns.Add("yppos", typeof(string));
                dt.Columns.Add("score", typeof(string));
                dt.Columns.Add("info", typeof(string));

                for (int i = 0; i < ls.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    YingpinzheZhaopin t_ypzzp = ls[i];
                    dr["Id"] = t_ypzzp.ID;
                    dr["Name"] = t_ypzzp.YpzName;
                    dr["bm_duty"] = t_ypzzp.YpzDepName + "-" + t_ypzzp.YpzPosName;
                    dr["duty"] = t_ypzzp.YpzPosName;


                    dr["ypdep_pos"] = t_ypzzp.YpzYpDepName + "-" + t_ypzzp.YpzYpPosName;
                    dr["yppos"] = t_ypzzp.YpzYpPosName;
                    int sc = (int)FTInterviewBLL.PingfenManage.GetScoreSums(t_ypzzp.ID);
                    dr["score"] = sc + "";
                    if (sc < 60)
                    {
                        dr["info"] = "不及格";
                    }
                    else
                    {
                        dr["info"] = "";
                    }
                    dt.Rows.Add(dr);
                }
                MsjgGridview.DataSource = dt;
                MsjgGridview.DataBind();
            }
        }
        //search
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        //dao chu bao biao
        protected void Button2_Click(object sender, EventArgs e)
        {
            NPOI2Excel(MsjgGridview, title_f.Text);
        }

        protected void NPOI2Excel(Control ctrl, string filename)
        {
            //////////////////////////////////////////////////////////////////////////////////////
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            //Excel文件的摘要信息
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "ftjwd";
            hssfworkbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "Export Excel";
            hssfworkbook.SummaryInformation = si;

            //下面代码输出的Excel有三列(姓名、年龄、性别)
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            // sheet1.PrintSetup.PaperSize=9; 
            sheet1.PrintSetup.Landscape = true;

            sheet1.SetColumnWidth(0, 10 * 256);
            sheet1.SetColumnWidth(1, 18 * 256);//name
            sheet1.SetColumnWidth(2, 25 * 256);//department
            sheet1.SetColumnWidth(3, 18 * 256);//duty
            sheet1.SetColumnWidth(4, 18 * 256);//position
            sheet1.SetColumnWidth(5, 15 * 256);//score
            sheet1.SetColumnWidth(6, 18 * 256);//beizhu


            ////////////////////////////////////////////1     
            IRow row0 = sheet1.CreateRow(0);
            ICell cell00 = row0.CreateCell(0);
            ICellStyle cellstyle0 = hssfworkbook.CreateCellStyle();
            cellstyle0.Alignment = HorizontalAlignment.Center;
            IFont font0_ = hssfworkbook.CreateFont(); font0_.FontHeightInPoints = 18;
            cellstyle0.SetFont(font0_);
            cell00.CellStyle = cellstyle0;

            cell00.SetCellValue(filename);
            row0.Height = (short)2 * 256;
            sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 6));
            ///////////////////////////////////////////2
            IRow row1 = sheet1.CreateRow(1);
            ICell cell10 = row1.CreateCell(0);
            ICellStyle cellstyle1 = hssfworkbook.CreateCellStyle();
            cellstyle1.Alignment = HorizontalAlignment.Right;
            IFont font1_ = hssfworkbook.CreateFont(); font1_.FontHeightInPoints = 15;
            cellstyle1.SetFont(font1_);
            cellstyle1.VerticalAlignment = VerticalAlignment.Center;
            cell10.CellStyle = cellstyle1;

            cell10.SetCellValue("    年         月         日     ");
            row1.Height = (short)(2.3 * 256);
            sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 6));

            ////////////////////////////////////////////3    
            IRow row2 = sheet1.CreateRow(2);
            ICell cell20 = row2.CreateCell(0); cell20.SetCellValue("序号");
            ICell cell21 = row2.CreateCell(1); cell21.SetCellValue("姓名");
            ICell cell22 = row2.CreateCell(2); cell22.SetCellValue("部门");
            ICell cell23 = row2.CreateCell(3); cell23.SetCellValue("职务");
            ICell cell24 = row2.CreateCell(4); cell24.SetCellValue("应聘岗位");
            ICell cell25 = row2.CreateCell(5); cell25.SetCellValue("面试成绩");
            ICell cell26 = row2.CreateCell(6); cell26.SetCellValue("备注");

            ICellStyle cellstyle2 = hssfworkbook.CreateCellStyle();
            cellstyle2.Alignment = HorizontalAlignment.Center;
            cellstyle2.VerticalAlignment = VerticalAlignment.Center;
            cellstyle2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyle2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyle2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyle2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyle2.WrapText = true;

            IFont font2_ = hssfworkbook.CreateFont(); font2_.FontHeightInPoints = 14;
            cellstyle2.SetFont(font2_);
            cell20.CellStyle = cellstyle2;
            cell21.CellStyle = cellstyle2;
            cell22.CellStyle = cellstyle2;
            cell23.CellStyle = cellstyle2;
            cell24.CellStyle = cellstyle2;
            cell25.CellStyle = cellstyle2;
            cell26.CellStyle = cellstyle2;
            row2.Height = (short)4 * 256;


            int i = 3; int id = 1;
            foreach (GridViewRow dr in MsjgGridview.Rows)
            {
                int _bytes = -1;
                IRow row = sheet1.CreateRow(i);
                row.Height = (short)3 * 256;
                row.CreateCell(0).SetCellValue(id);
                row.Cells[0].CellStyle = cellstyle2;
                for (int j = 1; j < 7; j++)
                {
                    string cont = ((System.Web.UI.WebControls.Label)dr.Cells[j].Controls[1]).Text;
                    row.CreateCell(j).SetCellValue(cont);
                    row.Cells[j].CellStyle = cellstyle2;

                    byte[] sarr = System.Text.Encoding.Default.GetBytes(cont);
                    int len1 = sarr.Length;

                    if (_bytes <= (len1 / ((int)sheet1.GetColumnWidth(j) / 256)))
                    {
                        _bytes = (len1 / ((int)sheet1.GetColumnWidth(j) / 256)) + 1;
                    }
                }
                row.Height = (short)(row.Height * _bytes);
                i++;
                id++;
            }
            /////////////////////////////////////
            ///////////////////////////////////////////last
            IRow rown = sheet1.CreateRow(i);
            ICell celln0 = rown.CreateCell(0);
            ICellStyle cellstylen = hssfworkbook.CreateCellStyle();
            cellstylen.Alignment = HorizontalAlignment.Center;
            IFont fontn_ = hssfworkbook.CreateFont(); fontn_.FontHeightInPoints = 15;
            cellstylen.SetFont(fontn_);
            celln0.CellStyle = cellstylen;

            celln0.SetCellValue("考官签字：(手签字)");
            rown.Height = (short)(2.5 * 256);
            sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(i, i, 0, 6));



            MemoryStream ms = new MemoryStream();
            hssfworkbook.Write(ms);

            //asp.net输出的Excel文件名
            //如果文件名是中文的话，需要进行编码转换，否则浏览器看到的下载文件是乱码。
            string fileName = HttpUtility.UrlEncode(filename + ".xls");


            Response.ContentType = "application/vnd.ms-excel";
            //Response.ContentType = "application/download"; //也可以设置成download
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));

            Response.Buffer = true;
            Response.Clear();
            Response.BinaryWrite(ms.GetBuffer());
            Response.End();
        }
    }
}