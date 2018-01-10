<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FTRailway.login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <style type="text/css">
        BODY
        {
            font-size: 12px;
            color: #ffffff;
            font-family: 宋体;
        }
        TD
        {
            font-size: 12px;
            color: #ffffff;
            font-family: 宋体;
        }
    </style>
    
</head>
<body>
    <form id="form1" name="form1" action="login.aspx" runat="Server">
    <div id="UpdatePanel1">
        <div id="div1" style="left: 0px; position: absolute; top: 0px; background-color: #0066ff">
        </div>
        <div id="div2" style="left: 0px; position: absolute; top: 0px; background-color: #0066ff">
        </div>
        <div>
            &nbsp;&nbsp;
        </div>
        <div>
            <table cellspacing="0" cellpadding="0" width="900" align="center" border="0">
                <tbody>
                    <tr>
                        <td style="height: 105px">
                            <img src="res/login/login_1.gif" border="0">
                        </td>
                    </tr>
                    <tr>
                        <td background="res/login/login_2.jpg" height="300">
                            <table height="300" cellpadding="0" width="900" border="0">
                                <tbody>
                                    <tr>
                                        <td colspan="2" height="35">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="360">
                                        </td>
                                        <td>
                                            <table cellspacing="0" cellpadding="2" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 28px" width="80">
                                                            登 录 名：
                                                        </td>
                                                        <td style="height: 28px" width="150">
                                                            <input id="txtName" style="width: 130px" name="txtName" runat="Server">
                                                        </td>
                                                        <td style="height: 28px" width="370">
                                                            <span id="RequiredFieldValidator3" style="font-weight: bold; visibility: hidden;
                                                                color: white">请输入登录名</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 28px">
                                                            登录密码：
                                                        </td>
                                                        <td style="height: 28px">
                                                            <input id="txtPwd" style="width: 130px" type="password" name="txtPwd" runat="Server">
                                                        </td>
                                                        <td style="height: 28px">
                                                            <span id="RequiredFieldValidator4" style="font-weight: bold; visibility: hidden;
                                                                color: white">请输入密码</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 18px">
                                                        </td>
                                                        <td style="height: 18px">
                                                        </td>
                                                        <td style="height: 18px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        <%--    <input id="btn" runat="Server" style="border-top-width: 0px; border-left-width: 0px;
                                                                border-bottom-width: 0px; border-right-width: 0px" onclick="btn_onclick" type="image"
                                                                src="res/login/login_button.gif" name="btn">--%>
                                                              <%--  <input type="button" onclick="btn_onclick" runat="Server" value="ok" />--%>

                                                            <asp:Button ID="Button1" runat="server" Text="登录" onclick="btn_onclick" 
                                                                Width="104px" />


                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="res/login/login_3.jpg" border="0">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
