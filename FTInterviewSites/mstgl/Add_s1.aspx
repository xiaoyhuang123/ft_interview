<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_s1.aspx.cs" Inherits="FTInterviewSites.mstgl.Add_s1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/javascript/popup.js" type="text/javascript"></script>
    <script src="../Scripts/javascript/common.js" type="text/javascript"></script> 
        <script type="text/javascript">
            function selAll() {
                var selobj = document.getElementsByName("BoxId");
                for (var i = 0; i < selobj.length; i++) {
                    if (!selobj[i].disabled) {
                        selobj[i].checked = true;
                        selobj[i].parentNode.parentNode.style.backgroundColor = '#CCCCCC';
                    }
                }
            }

            function removeAll() {
                var selobj = document.getElementsByName("BoxId");
                for (var i = 0; i < selobj.length; i++) {
                    selobj[i].checked = false;
                    selobj[i].parentNode.parentNode.style.backgroundColor = '';
                }
            }

            function onclicksel() {
                var chkobj = document.getElementById("BoxIdAll");
                if (chkobj.checked == true) {
                    selAll();
                }
                else {
                    removeAll();
                }
            }
            function onclicksingle(cb) {
                var row = cb.parentNode.parentNode;
                if (cb.checked) {
                    row.style.backgroundColor = '#CCCCCC';
                }
                else {
                    row.style.backgroundColor = '';
                }
            }

            function batchAudit(id) {
                var AuditVal = "";
                var bid = document.getElementsByName("BoxId");
                for (var i = 0; i < bid.length; i++) {
                    if (bid[i].checked == true) {
                        AuditVal = AuditVal + bid[i].value + ",";
                    }
                }
                if (AuditVal.length <= 0) {
                    alert("请先选择面试题！");
                    return false;
                }
                else {
                    if (confirm("该操作会删除该面试题及其相关信息，您确认要删除吗？")) {
                        document.getElementById("hdfWPBH").value = AuditVal;
                        return true;
                    }
                    else
                        return false;
                }
            }
            function GetsingleQue() {

                var url = "SingleQuestion.aspx";
                ShowIframe(url, 900, 400, "添加试题");
                return false;
            }
        </script>
</head>
<body>
      <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
          <h3>基本信息</h3>
            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        部门名称：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
                        DataTextField="Name" DataValueField="Id" Width="150px" AutoPostBack="true"
                            onselectedindexchanged="department_SelectedIndexChanged" >
                            
                         </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group span12">
                    <label class="control-label">
                        岗位名称：</label>
                    <div class="controls">
                         <asp:DropDownList ID = "Position" name="Position" runat="Server" 
                        DataTextField="Zppos" DataValueField="Zppos" Width="150px" 
                        AutoPostBack="true"
                             onselectedindexchanged="Position_SelectedIndexChanged" >
                           
                         </asp:DropDownList>
                    </div>
                </div> 
            </div>
            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">套数选择：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "Sumti" name="Sumti" runat="Server" 
                        DataTextField="Name" DataValueField="Id" Width="150px" >
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                            <asp:ListItem  Value="1">A(1)</asp:ListItem>
                            <asp:ListItem  Value="2">B(2)</asp:ListItem>
                            <asp:ListItem  Value="3">C(3)</asp:ListItem>
                            <asp:ListItem  Value="4">D(4)</asp:ListItem>
                            <asp:ListItem  Value="5">E(5)</asp:ListItem>
                            <asp:ListItem  Value="6">F(6)</asp:ListItem>
                            <asp:ListItem  Value="7">G(7)</asp:ListItem>
                            <asp:ListItem  Value="8">H(8)</asp:ListItem>
                            <asp:ListItem  Value="9">I(9)</asp:ListItem>
                            <asp:ListItem  Value="10">J(10)</asp:ListItem>
                            <asp:ListItem  Value="11">K(11)</asp:ListItem>
                            <asp:ListItem  Value="12">L(12)</asp:ListItem>
                            <asp:ListItem  Value="13">M(13)</asp:ListItem>
                            <asp:ListItem  Value="14">N(14)</asp:ListItem>
                            <asp:ListItem  Value="15">O(15)</asp:ListItem>
                            <asp:ListItem  Value="16">P(16)</asp:ListItem>
                            <asp:ListItem  Value="17">Q(17)</asp:ListItem>
                            <asp:ListItem  Value="18">R(18)</asp:ListItem>
                            <asp:ListItem  Value="19">S(19)</asp:ListItem>
                            <asp:ListItem  Value="20">T(20)</asp:ListItem>
                            <asp:ListItem  Value="21">U(21)</asp:ListItem>
                            <asp:ListItem  Value="22">V(22)</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div>
            </div>
           <!--  <div class="row">
                 <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>名 称：</label>
                <div class="controls">
                    <input id="Title" name="Title" style="Width:200px;" type="text" class="control-text" data-rules="{required:true}" runat="Server" >
                </div>
            </div>
            </div>-->
          </ContentTemplate>
           </asp:UpdatePanel>
            <div style=" text-align:center">
              <asp:Button ID="SaveBm" runat="Server" class="button button-primary" Text="下一步"  
                ToolTip="点此进行下一步"  onclick="SaveBm_Click" />    
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
