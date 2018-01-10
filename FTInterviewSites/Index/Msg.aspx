<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Msg.aspx.cs" Inherits="FTInterviewSites.Index.Msg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>丰台机务段公开招聘面试管理系统</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <!--meta http-equiv="refresh" content="600"-->
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/main-min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div1" runat="Server" style="height: 65px;">
        <img src="../Imgs/header.png" style="width:100%;height:65px;position:absolute;z-index:-10;">
        <div class="dl-log" style="margin-top:25px">
           <asp:Label ID="Label_welcome" runat="server" Text="欢迎您，" ForeColor="red"> </asp:Label><span class="dl-log-user">
                <asp:Label ID="NameNick" runat="server" Text="visitor" ForeColor="red"></asp:Label>
            </span>
            <a id="A1" href="###" title="退出系统" runat="Server" onclick="Logout" class="dl-log-quit" ></a>
            <asp:Button ID="Button1" runat="server" Text="[退出] " BackColor="#CCCCCC" 
                BorderStyle="None" style="background-color:transparent;" Height="19px" 
                Width="47px" ForeColor="Red" onclick="Button1_Click"  />
            &nbsp;</div>
    </div>
    <div class="content">
        <div class="dl-main-nav">
          
            <ul id="J_Nav" class="nav-list ks-clear">
                <li class="nav-item dl-selected">
                    <div class="nav-item-inner nav-home">
                        首页</div>
                </li>
                <li class="nav-item">
                    <div class="nav-item-inner nav-order">
                        面试管理</div>
                </li>
            </ul>
        </div>
        <ul id="J_NavContent" class="dl-tab-conten">
        </ul>
    </div>
    <script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../assets/js/bui.js"></script>
    <script type="text/javascript" src="../assets/js/config.js"></script>
    <script type="text/javascript">
        BUI.use('common/main', function () {
            var config = [
    {
        id: 'menu',
        homePage: 'code',
        menu: [
       /* {
            text: '首页',
            items: [
            {
                id: 'code', text: '面试公告', href: '../gggl/SearchGg.aspx', closeable: false
            }
            ]
        },*/
         {
         text: '考场信息',
         items: [
            {
                id: 'code', text: '考场纪律', href: '../msSystem/kcjl.aspx', closeable: false
            }
            ]
        },
        {
        text: '基本信息',
        items: [
            {
                id: 'code1', text: '个人信息', href: '../msg/msginformation.aspx'
            },
            {
                id: 'code2', text: '修改密码', href: '../Account/ChangePWD.aspx'
            }
            ]
        }
        /*,
        {
            text: '账户管理',
            items: [
            {
                id: 'code2', text: '修改密码', href: '../Account/ChangePWD.aspx'
            }
            ]
        }*/
        ]
    }
    ,
    {
        id: 'form',
        homePage: 'code3',
        menu: [
        {
            text: '面试管理',
            items: [
            {
                id: 'code3', text: '查询面试安排', href: '../msg/index0.aspx', closeable: false
            }
            ]
        }
        ]
    }
    ];
            new PageUtil.MainPage(
    {
        modulesConfig: config
    }
    );
        }
);
    </script>
    </form>
</body>
</html>
