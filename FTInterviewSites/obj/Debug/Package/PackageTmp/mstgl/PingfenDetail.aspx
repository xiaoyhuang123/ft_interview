<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PingfenDetail.aspx.cs" Inherits="FTInterviewSites.mstgl.PingfenDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
     <script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../assets/js/bui-min.js"></script>
    <script type="text/javascript" src="../assets/js/config-min.js"></script>
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
                 alert("请先选择！");
                 return false;
             }
             else {
                 if (confirm("该操作会移除该条信息，您确认要移除吗？")) {
                     document.getElementById("hdfWPBH").value = AuditVal;
                     return true;
                 }
                 else
                     return false;
             }
         }
         function batchAudit1(id) {
             var AuditVal = "";
             var bid = document.getElementsByName("BoxId");
             for (var i = 0; i < bid.length; i++) {
                 if (bid[i].checked == true) {
                     AuditVal = AuditVal + bid[i].value + ",";
                 }
             }
             if (AuditVal.length <= 0) {
                 alert("请先选择！");
                 return false;
             }
             else {
                 if (confirm("该操作会移除该条信息，您确认要移除吗？")) {
                     document.getElementById("hdfWPBH1").value = AuditVal;
                     return true;
                 }
                 else
                     return false;
             }
         }
         function GetYpzList() {

             //   var url = "YpzList.aspx?id=" + dep + "&c_time=" + tme;
             ShowIframe("YpzList.aspx", 900, 400, "用户列表");
             return false;
         }
     </script>
</head>
<body>
      <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          <h3>评价详细</h3>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>

          <asp:GridView ID="DetailGridview" runat="server" AllowPaging="false" 
                   BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowHeader="false"
                Width="100%"  PageSize="15" ClientIDMode="Static">
             
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />
              <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
                  PreviousPageText="" Visible="False" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" 
                  Font-Size="Medium" />

              <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="center" 
                 Height="80px"  Font-Size="Medium"  />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br/>
         </ContentTemplate>
           </asp:UpdatePanel>

          <div style=" text-align:center;">
            <asp:Button ID="SaveButton" class="button button-primary" runat="server" Text="保存" 
                onclick="SaveButton_Click" />
            <asp:Button ID="BackButton" class="button button-primary" runat="server" Text="返回" 
                onclick="BackButton_Click" />
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
