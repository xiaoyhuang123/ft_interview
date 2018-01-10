<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tab.aspx.cs" Inherits="FTRailway.tab" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/prettify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="assets/js/bui-min.js"></script>
    <script type="text/javascript" src="assets/js/config-min.js"></script>
    <title>无标题文档</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE1 {font-size: 12px}
.STYLE3 {font-size: 12px; font-weight: bold; }
.STYLE4 {
	color: #03515d;
	font-size: 12px;
}
-->
</style>
    <style type="text/css">
<!--
#stuff_info {
display:none;
position:absolute;
z-index:1000;
width:80%;
height:auto;
background-color:#FFFFFF;
width:80%;
border: 1px solid #CAD9EA;
padding: 5px;
font-size: 12px;
color: #000000;
line-height:26px;
text-align: center; 
}
-->
</style>

    <!-- 20121107加入，目的是在点击右下角弹窗弹出登录窗口，共两部分。这是第一部分。第一部分开始 -->
    <script type="text/javascript">

        //弹出式登录
        function ShowNo()                        //隐藏两个层 
        {
            document.getElementById( "doing" ).style.display = "none";
            document.getElementById( "stuff_info" ).style.display = "none";
        }
        function $( id )
        {
            return ( document.getElementById ) ? document.getElementById( id ) : document.all[id];
        }
        function showFloat()                    //根据屏幕的大小显示两个层 
        {
            var range = getRange();
            $( 'doing' ).style.width = range.width + "px";
            $( 'doing' ).style.height = range.height + "px";
            $( 'doing' ).style.display = "block";
            var window_height = document.body.clientHeight;
            var window_width = document.body.clientWidth;
            //        var width = $('stuff_info').style.width /2;
            //        var height = $('stuff_info').style.height / 2;
            //不知道为什么这两个都是0
            $( 'stuff_info' ).style.top = ( window_height / 4 ) + "px";
            $( 'stuff_info' ).style.left = ( window_width / 4 ) + "px";
            $( 'stuff_info' ).style.display = "block";
        }
        function getRange()                      //得到屏幕的大小 
        {
            var top = document.body.scrollTop;
            var left = document.body.scrollLeft;
            var height = document.body.clientHeight;
            var width = document.body.clientWidth;

            if ( top == 0 && left == 0 && height == 0 && width == 0 )
            {
                top = document.documentElement.scrollTop;
                left = document.documentElement.scrollLeft;
                height = document.documentElement.clientHeight;
                width = document.documentElement.clientWidth;
            }
            return { top: top, left: left, height: height, width: width };
        }
    </script>
    <!-- 20121107加入，目的是在点击右下角弹窗弹出登录窗口，共两部分。这是第一部分。第一部分完。 -->
</head>
<body>
    <form id="stuff_form" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30" background="tab_images/tab_05.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="30">
                            <img src="tab_images/tab_03.gif" width="12" height="30" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="46%" valign="middle">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="5%">
                                                    <div align="center">
                                                        <img src="tab_images/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <td width="95%" class="STYLE1">
                                                    <span class="STYLE3">你当前的位置</span>：[业务中心]-[我的邮件]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="60">
                                                    <table width="87%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <input type="checkbox" name="checkbox62" value="checkbox" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    全选</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="60">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="tab_images/22.gif" width="14" height="14" onclick="showFloat();" style="cursor: pointer" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    新增</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="60">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="tab_images/33.gif" width="14" height="14" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    修改</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="52">
                                                    <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="tab_images/11.gif" width="14" height="14" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    删除</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="16">
                            <img src="tab_images/tab_07.gif" width="16" height="30" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table runat="Server" id="tb_stuff" width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="8" background="tab_images/tab_12.gif">
                            &nbsp;
                        </td>
                        <td>
                            <asp:GridView ID="GridView_Stuff" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                BackColor="#B5D6E6" BorderStyle="None" CellPadding="0" Height="91px" Width="100%"
                                DataKeyNames="id" BackImageUrl="~/tab_images/bg.gif" CellSpacing="1" CssClass="STYLE1"
                                OnRowDeleting="GridView_Stuff_RowDeleting" OnRowEditing="GridView_Stuff_RowEditing"
                                OnRowUpdating="GridView_Stuff_RowUpdating">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbx_name" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbx_sex" runat="server" Text='<%# Bind("sex") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sex" runat="server" Text='<%# Bind("sex") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="编号">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbx_workId" runat="server" Text='<%# Bind("work_id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_workId" runat="server" Text='<%# Bind("work_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="更新"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="取消"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="编辑"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select"
                                                Text="选择"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="删除"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="White" Height="22px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <RowStyle BackColor="White" Height="22px" VerticalAlign="Middle" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                        <td width="8" background="tab_images/tab_15.gif">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="35" background="tab_images/tab_19.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12" height="35">
                            <img src="tab_images/tab_18.gif" width="12" height="35" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="STYLE4">
                                        &nbsp;&nbsp;共有 120 条记录，当前第 1/10 页
                                    </td>
                                    <td>
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="40">
                                                    <img src="tab_images/first.gif" width="37" height="15" />
                                                </td>
                                                <td width="45">
                                                    <img src="tab_images/back.gif" width="43" height="15" />
                                                </td>
                                                <td width="45">
                                                    <img src="tab_images/next.gif" width="43" height="15" />
                                                </td>
                                                <td width="40">
                                                    <img src="tab_images/last.gif" width="37" height="15" />
                                                </td>
                                                <td width="100">
                                                    <div align="center">
                                                        <span class="STYLE1">转到第
                                                            <input name="textfield" type="text" size="4" style="height: 12px; width: 20px; border: 1px solid #999999;" />
                                                            页 </span>
                                                    </div>
                                                </td>
                                                <td width="40">
                                                    <img src="tab_images/go.gif" width="37" height="15" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="16">
                            <img src="tab_images/tab_20.gif" width="16" height="35" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--加一个半透明层-->
    <div id="doing" style="filter: alpha(opacity=30); -moz-opacity: 0.3; opacity: 0.3;
        background-color: #000; width: 100%; height: 100%; z-index: 999; position: absolute;
        left: 0; top: 0; display: none; overflow: hidden;">
    </div>
    <!--加一个添加员工层-->
    <div id="stuff_info">
        <div class="container">
            <form id="J_Form" class="form-horizontal" action="success.html">
            <h3>
                基本信息</h3>
            <div class="row">
                <div class="control-group span12">
                    <label class="control-label">
                        <s>*</s>学生姓名：</label>
                    <div class="controls">
                        <input name="sname" type="text" class="control-text" data-rules="{required:true}">
                    </div>
                </div>
                <div class="control-group span12">
                    <label class="control-label">
                        <s>*</s>学生编号：</label>
                    <div class="controls">
                        <input name="sid" type="text" class="control-text" data-rules="{required:true}">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="control-group span12">
                    <label class="control-label">
                        性别：</label>
                    <div class="controls">
                        <select name="sex">
                            <option value="0">男</option>
                            <option value="1">女</option>
                        </select>
                    </div>
                </div>
                <div class="control-group12 span12">
                    <label class="control-label">
                        <s>*</s>出生日期：</label>
                    <div class="controls">
                        <input name="birthday" type="text" class="calendar" data-rules="{required:true}">
                    </div>
                </div>
            </div>

            <hr />
            <div class="row">
                <div class="span21 offset3 control-row-auto">
                    <div id="grid">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-actions offset3">
                    <button type="submit" class="button button-primary">
                        保存</button>
                    <button type="reset" class="button">
                        重置</button>
                    <button type="reset" class="button" onclick="ShowNo">
                        取消</button>
                </div>
            </div>
            </form>
        </div>
        <!-- 20121107加入，目的是在点击右下角弹窗弹出登录窗口，共两部分。这是第二部分。第二部分完。 -->
 
    <script type="text/javascript">
        BUI.use( 'common/page' );
    </script>
    <script type="text/javascript">
        BUI.use( 'bui/form', function ( Form )
        {
            var form = new Form.HForm( {
                srcNode: '#J_Form'
            } ).render();
        } );
    </script>
       </form>
</body>
</html>
