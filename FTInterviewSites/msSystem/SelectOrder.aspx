<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectOrder.aspx.cs" Inherits="FTInterviewSites.mstgl.SelectOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
     <script type="text/javascript">
         var id;
         var len;
         var para
         function GetStart() {
             para = document.getElementById("<%=HiddenField1.ClientID%>").value;
             para = para.split(',');
             len = para.length;
             id = setInterval(getRTime, 100);
             var ui = document.getElementById("Button1");
             ui.style.visibility = "hidden";
             var ui = document.getElementById("Button2");
             ui.style.visibility = "visible";
         }

         function getRTime() {
             var ran = parseInt(Math.random() * len % len);
            // alert(ran);
             document.getElementById("<%=Result.ClientID%>").innerHTML = para[ran];
         }
         function GetStop() {
             var ran = parseInt(Math.random() * len % len);
             document.getElementById("<%=Result.ClientID%>").innerHTML = para[ran];
             document.getElementById("<%=HiddenField2.ClientID%>").value = para[ran];
             clearInterval(id);
             var ui = document.getElementById("Button1");
             ui.style.visibility = "visible";
             var ui = document.getElementById("Button2");
             ui.style.visibility = "hidden";
         }
     </script>
</head>
<body style=" width:100%; margin-left:auto; margin-right:auto; ">
   <div class="container">
        <form id="J_Form" class="form-horizontal" runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
          <h3>面试抽签</h3>
        <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        应聘者：</label>
                    <div class="controls">
                        <asp:Label ID="YpzName" Font-Size="Medium" runat="server" Text="张三"> </asp:Label>
                    </div>
                </div>
        </div>
        <div style=" width:100%; height:260px; text-align:center;">
               <div style=" height:260px; width:600px; background-color:Gray; text-align:center; margin:auto;">
                 <br/>
                 <br />
                   <asp:Label ID="Result" runat="server" Width="100%" ForeColor="Black" 
                       Font-Size="200px"  Height="100%" style="margin-top: 100px" 
                       ClientIDMode="Static"></asp:Label>   
                   <asp:HiddenField ID="HiddenField2" runat="server" />
                 </div>
        </div>

          
         <br/>
          <div style=" text-align:center;">
              <input id="Button1" type="button" class="button button-primary"   value="开 始" onclick="GetStart()"/>&nbsp;
              <input id="Button2" type="button" class="button button-primary"   value="停 止" onclick="GetStop()"/>&nbsp;
              <asp:Button ID="SaveButton" runat="server" class="button button-primary"   Text="保  存" OnClientClick="alert('保存成功');" onclick="SaveButton_Click" />
         </div>
       </ContentTemplate>
           </asp:UpdatePanel>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        </form>
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
