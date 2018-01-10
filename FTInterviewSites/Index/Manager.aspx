<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="FTInterviewSites.Index.Manager" %>

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
                Width="47px" ForeColor="Red" onclick="Button1_Click" />
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
                        部门管理</div>
                </li>
                <li class="nav-item">
                    <div class="nav-item-inner nav-order">
                        招聘管理</div>
                </li>
                <li class="nav-item">
                    <div id="leaveManager" runat="Server" class="nav-item-inner nav-inventory">
                        试题管理</div>
                </li>
                <li class="nav-item">
                    <div id="systemmanager" runat="Server" class="nav-item-inner nav-supplier">
                        系统管理</div>
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
        {
            text: '首页',
            items: [
            {
                id: 'code', text: '考场纪律', href: '../gggl/KcjilvEdit.aspx', closeable: false
            }
            ]
        }
        ,
        {
            text: '账户管理',
            items: [
            {
                id: 'code2', text: '修改密码', href: '../Account/ChangePWD.aspx'
            }
            ]
        }
        ]
    }
     ,
    {
        id: 'form',
        homePage: 'code3',
        menu: [
        {
            text: '部门管理',
            items: [
            {
                id: 'code6', text: '添加部门', href: '../bmgl/AddBm.aspx'
            },
            {
                id: 'code3', text: '部门查询', href: '../bmgl/SearchBm.aspx', closeable: false
            }
            ]
        }
        ]
    },
    {
        id: 'search',
        homePage: 'code7',
        menu: [
        {
            text: '招聘管理',
            items: [
            {
                id: 'code8', text: '发布招聘', href: '../zpgwgl/AddZpitem.aspx'
            },
            {
                id: 'code7', text: '招聘查询', href: '../zpgwgl/zpitmindex.aspx', closeable: false
            }
            ]
        },
        {
            text: '应聘者管理',
            items: [
            {
                id: 'code12', text: '添加应聘人员', href: '../ypzgl/AddYpz0.aspx'
            },
            {
                id: 'code11', text: '应聘者查询', href: '../ypzgl/Zpitmindex.aspx'
            }
            ]
        },
        {
            text: '考官管理',
            items: [
            {
                id: 'code10', text: '添加考官', href: '../msggl/AddMsg.aspx'
            },
            {
                id: 'code9', text: '考官查询', href: '../msggl/SearchMsg.aspx'
            }
            ]
        },
         {
             text: '面试管理',
             items: [
            {
                id: 'code14', text: '面试安排', href: '../msap/AddMsap00.aspx'
            },
            {
                id: 'code13', text: '面试查询', href: '../msap/SearchMsap0.aspx'
            }
            ]
        }
         ,
         {
             text: '面试结果',
             items: [
            {
                id: 'code15', text: '面试结果查询', href: '../msjggl/MsjgIndex.aspx'
            }
            ]
         }
        ]
    },
    {
        id: 'search1',
        homePage: 'code19',
        menu: [
        {
            text: '考题管理',
            items: [
            {
                id: 'code20', text: '添加考题', href: '../mstgl/Add_s1.aspx'
            },
            {
                id: 'code19', text: '考题查询', href: '../mstgl/SearchMst.aspx', closeable: false
            } ,
            {
                id: 'code21', text: '评分管理', href: '../mstgl/Pingfengl.aspx'
            }
            ]
        },
         {
             text: '题库密码管理',
             items: [
            {
                id: 'code22', text: '修改题库密码', href: '../mstgl/ChangetikuPwd.aspx'
            }
            ]
         }
        ]
    }
    ,
    {
        id: 'detail2',
        homePage: 'code23',
        menu: [
        {
            text: '系统管理',
            items: [
            {
                id: 'code23', text: '历史结果查询', href: '../systemmanage/historyindex.aspx', closeable: false
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
