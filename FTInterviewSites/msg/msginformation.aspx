<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msginformation.aspx.cs" Inherits="FTInterviewSites.msg.msginformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/jcombox/jquery.combobox.css" rel="stylesheet" />
    <script type="text/javascript" src="../assets/jcombox/jquery.js"></script>
    <script type="text/javascript" src="../assets/jcombox/jquery.combobox.min.js"></script>
</head>
<body>
    <div class="container">
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        <asp:HiddenField ID="Dutylist" runat="server" />
          <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

        <h3>基本信息</h3>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">工号：</label>
                <div class="controls">
                    <input id="work_id" name="work_id" type="text" class="control-text"
                       runat="Server" />
                </div>
            </div>
            <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>姓名：</label>
                <div class="controls">
                    <input id="name" name="name" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                </div>
            </div>
        </div>
        <hr />
        <h3>工作信息</h3>
     
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
           </ContentTemplate>
           </asp:UpdatePanel>
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
