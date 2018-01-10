<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmInfo.aspx.cs" Inherits="FTInterviewSites.msg.ConfirmInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
</head>
<body style=" margin-left:5%; margin-right:5%;">
    <div class="container">
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        <h3>基本信息</h3>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    考官姓名：</label>
                <div class="controls">
                    <asp:Label ID="KGName" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    应聘者姓名：</label>
                <div class="controls">
                 <asp:Label ID="yName" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    出生日期：</label>
                <div class="controls">
                 <asp:Label ID="BirthDay" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!-- <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>身份证号：</label>
                <div class="controls">
                    <input id="CardID" name="CardID" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                </div>
            </div>-->
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    学历：</label>
                <div class="controls">
                    <asp:Label ID="yDegree" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    参工时间：</label>
                <div class="controls">
                     <asp:Label ID="yJoinTime" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
             <div class="control-group span12">
                <label class="control-label">
                    应聘部门：</label>
                <div class="controls">
                     <asp:Label ID="yDepart" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group12 span12">
                <label class="control-label">
                    应聘岗位：</label>
                     <div class="controls">
                     <asp:Label ID="yPosition" runat="server" Text=""></asp:Label>
                     </div>
            </div>
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    政治面貌：</label>
                <div class="controls">
                    <asp:Label ID="yPolitic" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

      <div style=" text-align:center">
             <asp:Button ID="PreButton"  class="button button-primary" runat="Server" 
                 Text="确定" onclick="ConfirmButton_Click"  ></asp:Button>
                 <asp:Button ID="BackButton"  class="button button-primary" runat="Server" 
                 Text="返回" onclick="BackButton_Click" ></asp:Button>
        </div>
        </form>
    </div>
    <div style="height:100px;width:100%">
    </div>
    <script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../assets/js/bui-min.js"></script>
    <script type="text/javascript" src="../assets/js/config-min.js"></script>
    <script type="text/javascript">
        BUI.use('common/page');
    </script>
    <script type="text/javascript">
        BUI.use('bui/form', function (Form) {
            var form = new Form.HForm({
                srcNode: '#J_Form'
            }).render();
        });
        </script>
</body>
</html>
