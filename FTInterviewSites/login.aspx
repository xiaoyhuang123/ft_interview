<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FTInterviewSites.Account.login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <style type="text/css">
        BODY
        {
            font-size: 12px;
            color: #000000;
            font-family: 宋体;
        }
        TD
        {
            font-size: 12px;
            color: #000000;
            font-family: 宋体;
        }
        .style1
        {
            width: 271px;
        }
        .style2
        {
            height: 42px;
            width: 81px;
        }
        .style3
        {
            height: 18px;
            width: 81px;
        }
        .style4
        {
        }
        .style5
        {
            height: 58px;
        }
        .style6
        {
            height: 49px;
            width: 81px;
        }
        .style8
        {
            height: 42px;
        }
        .style9
        {
            height: 49px;
        }
    </style>
    
</head>
<body style="background-attachment:fixed; background-position:center; background-repeat:no-repeat">
    <form id="form1" name="form1" action="login.aspx" runat="Server">
    <div id="UpdatePanel1">
        <div id="div1" style="left: 0px; position: absolute; top: 0px;">
        </div>
        <div id="div2" style="left: 0px; position: absolute; top: 0px;" >
        </div>
        <div>
            &nbsp;&nbsp;
        </div>
        <div>
           <table cellspacing="0" cellpadding="0" width="900" align="center" border="0" 
                background="../Imgs/login.png" style="height: 560px">
                <tbody>
                    <tr>
                        <td style="height: 105px">
                           
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <table cellpadding="0" width="900" border="0" 
                                style="height: 179px; margin-bottom: 146px">
                                <tbody>
                                    <tr>
                                        <td colspan="2" class="style5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                        </td>
                                        <td>
                                            <table cellspacing="0" cellpadding="2" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="style6">
                                                            用户名：
                                                        </td>
                                                        <td  width="370" class="style9">
                                                            <asp:DropDownList ID = "UserName" name="UserName" runat="Server"  Width="179px"
                                                            DataTextField="Name" DataValueField="Id" Height="28px" >
                                                            <asp:ListItem Text="请选择" Selected="True" Value="-1"></asp:ListItem>
                                                            <asp:ListItem Text="管理员" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="电脑操作员" Value="1"></asp:ListItem>
                                                             </asp:DropDownList>
                                                        </td>
                                                        <td width="370" class="style9">
                                                            <span id="RequiredFieldValidator3" style="font-weight: bold; visibility: hidden;
                                                                color: white">请输入登录名</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style2">
                                                            密 码：
                                                        </td>
                                                        <td class="style8">
                                                            <input id="txtPwd" style="width: 177px; height:28px;background-color:#ADD8E6;" data-tip="{text:'请输入密码'}" type="password" name="txtPwd" 
                                                                runat="Server">
                                                        </td>
                                                        <td class="style8">
                                                            <span id="RequiredFieldValidator4" style="font-weight: bold; visibility: hidden;
                                                                color: white">请输入密码</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                        </td>
                                                        <td style="height: 18px">
                                                        </td>
                                                        <td style="height: 18px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style4" align="center" colspan="2">
                                                      
                                                            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button_Click"
                                                                Width="105px" Height="28px" style="margin-right: 131px" />


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
