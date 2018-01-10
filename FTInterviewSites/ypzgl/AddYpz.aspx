<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddYpz.aspx.cs" Inherits="FTInterviewSites.ypzgl.AddYpz" %>

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
<body>
     <div class="container">
        <form id="J_Form" class="form-horizontal" action="AddYpz.aspx" runat="Server">
        <h3>基本信息</h3>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>姓名：</label>
                <div class="controls">
                    <input id="name" name="name" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>性别：</label>
                <div class="controls">
                     <asp:DropDownList ID = "SexDP" name="SexDP" runat="Server">
                     <asp:ListItem Value="男">男</asp:ListItem>
                     <asp:ListItem Value="女">女</asp:ListItem>
                   </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
             <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>出生日期：</label>
                <div class="controls">
                   <input id="Birthday" runat="Server"  onchange="SetRestParameter()" name="join_time" style="width:140px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen',maxDate:'%y-%M-%d'})"/>
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>参工时间：</label>
                <div class="controls">
                     <input id="join_time" runat="Server"  onchange="SetRestParameter()" name="join_time" style="width:140px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen',maxDate:'%y-%M-%d'})"/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>部门：</label>
                <div class="controls">
                     <asp:DropDownList ID = "department" name="department" runat="Server" 
                        DataTextField="Name" DataValueField="Id" >
                   </asp:DropDownList>
                </div>
            </div>

             <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>职务：</label>
               <div class="controls">
                     <input id="Duty" name="company" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                </div>
                 
            </div>
        </div>
        <div class="row">
         <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>学历：</label>
                <div class="controls">
                   <!-- <input id="Degree" name="Degree" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                   -->
                   <asp:DropDownList ID = "XueliDP" name="XueliDP" runat="Server" 
                        DataTextField="XueliName" DataValueField="Id"  >
                   </asp:DropDownList>
                </div>
            </div>
            <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>政治面貌：</label>
                <div class="controls">
                    <!--<input id="ZZMM" name="ZZMM" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                     -->
                       <asp:DropDownList ID = "PolDP" name="PolDP" runat="Server" 
                        DataTextField="PoliticName" DataValueField="Id"  >
                   </asp:DropDownList>
                </div>
            </div>
        </div>
        <hr />
        <h3>应聘信息</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>应聘部门-岗位：</label>
                <div class="controls">
                     <asp:DropDownList ID = "YpFbList" name="YpFbList" runat="Server" AutoPostBack="True"
                        DataTextField="ZpBmName" DataValueField="Id" >
                   </asp:DropDownList>
                </div>
            </div>
        </div>
         </ContentTemplate>
           </asp:UpdatePanel>
        
        <hr />
        <div style=" width:100%; text-align:center;">
                <asp:Button ID="SaveButton"  class="button button-primary" runat="Server" Text="保存" 
                    onclick="Add_btnClick">
                </asp:Button>
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
