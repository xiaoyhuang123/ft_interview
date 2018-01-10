using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FTInterviewBLL;
using FTInterviewModel;
using System.Text.RegularExpressions;

namespace FTInterviewSites.mstgl
{
    public partial class SingleQuestion : System.Web.UI.Page
    {
        private static int t_id = -1;
        private static int kt_id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["stid"] != null)
                {
                    string temp = Request["stid"].ToString();
                    t_id = Convert.ToInt32(temp);
                }
                else
                {
                    t_id = -1;
                }
                if (Request.QueryString["ktid"] != null)
                {
                    string temp = Request["ktid"].ToString();
                    kt_id = Convert.ToInt32(temp);
                }
                else
                {
                      HttpCookie cok = Request.Cookies["ftcook"];
                      if (cok != null && cok["tkpwd"] != null)
                      {
                          kt_id = Convert.ToInt32(cok["ktid"].ToString());
                      }
                   /* if (Session["ktid"] != null)
                    {
                        kt_id = Convert.ToInt32(Session["ktid"]);
                    }*/
                    else
                    {
                        kt_id = -1;
                    }
                }

                DataBind(t_id);
            }
        }

        protected void DataBind(int tid=-1)
        {
            if (tid != -1)//chuan zhi
            {
                Shiti st = FTInterviewBLL.ShitiManage.GetShitiById(tid);
                AnsTime.Value = st.StTime+"";
                StWeight.Value = st.Weight + "";
                myEditor.Value = st.Question;
            }
        }

        //save
        protected void Save_Click(object sender, EventArgs e)
        {
            List<string> msg = new List<string>();
            int ans_t=0, wei_t=0;
            //if(AnsTime.Value.Trim()=="" || )
            {
               try
               {
                    ans_t = Convert.ToInt32(AnsTime.Value);
                }
               catch (System.Exception ex)
               {
                       msg.Add("请输入合法时间值！");
               }
                
            }
            //if (StWeight.Value.Trim() == "")
            {
                try
                {
                     wei_t = Convert.ToInt32(StWeight.Value);
                }
                catch (System.Exception ex)
                {
                    msg.Add("请输入合法权重比例！");
                }
            }
            if(msg.Count>0)
            {
                Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                Response.Write("<script language=javascript>alert('" + msg[0] + "')</script>");
            }
            else
            {
                if (t_id != -1)
                {
                    Shiti st = new Shiti();
                    st.StTime = ans_t;
                    st.Weight = wei_t;
                    st.Question = myEditor.Value;//myEditor.InnerHtml;

                    st.Id = t_id;
                    FTInterviewBLL.ShitiManage.Update(st);
                    Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                    Response.Write("<script language=javascript>alert('更新成功！')</script>");

                }
                else
                {
                    if (kt_id !=-1)
                    {
                        Shiti st = new Shiti();
                        st.StTime = ans_t;
                        st.Weight = wei_t;
                        st.Question = myEditor.Value;//myEditor.InnerHtml;
                        st.KaotiID = kt_id;

                        FTInterviewBLL.ShitiManage.Add(st);
                        Response.Write("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                        Response.Write("<script language=javascript>alert('添加成功！')</script>");
                    }
                }
            }
        }
    }
}