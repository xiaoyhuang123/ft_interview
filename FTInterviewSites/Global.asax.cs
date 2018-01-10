using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FTInterviewSites
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }
		
        /*
        //获取cookie中的键值
		public static String getCookiesValues(String cookieName,String key)
		{
			HttpCookie cok = Request.Cookies[cookieName];
            if(cok!=null)
			{
			   if(cok[key]!=null)
			   {
				   return cok[key];
			   } 
            }
			else
			{
				//主页面跳转到login
			}
		}
		
		//设置Cookie值
		public static void SetCookiesValues(String cookieName,String key, String value)
		{
			HttpCookie cok = Request.Cookies[cookieName];
            if(cok!=null)
			{
				TimeSpan ts = new TimeSpan(0, 0, 0, 1);
				cok.Expires = DateTime.Now.Add(ts);
			   if(cok[key]!=null)
			   {
				   cok.Values.Remove(key);
			   }
			   cok.Values.put(key,value);
			   Response.AppendCookie(cok);
            }
			else
			{
				//主页面跳转到login
			}
		}
		
		//清空Cookie
		public static void clearCookies(String cookieName)
		{
			HttpCookie cok = Request.Cookies[cookieName];
            if(cok!=null)
			{
				TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
				cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
			   
				Response.AppendCookie(cok);
            }
			else
			{
				//主页面跳转到login
			}
		}
         * */

    }
}
