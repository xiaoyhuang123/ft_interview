<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectMst.aspx.cs" Inherits="FTInterviewSites.mstgl.SelectMst" %>

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
         }

     </script>


</head>
<body style=" width:100%; margin-left:auto; margin-right:auto; ">
   <div class="container">
       
        <form id="J_Form" class="form-horizontal" action="Selectmst.aspx" runat="Server">
        <h3>抽签结果</h3>
            
       <!--div class="row">
                <label class="control-label">
                     抽签结果：</label>
        </div-->
       <div style=" height:280px; width:400px; background-color:Gray; text-align:center;  margin-left: 30%;">
         <br/>
         <br />
           <asp:HiddenField ID="HiddenField2" runat="server" />
           <asp:Label ID="Result" runat="server" Width="100%" ForeColor="black" 
               Font-Size="200px"  Height="100%" Text="" style="margin-top: 100px"></asp:Label>   
         </div>
         <br/>
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
          <div style=" text-align:center;">
         
         <asp:Button ID="Start" runat="server" class="button button-primary"  
                    Text="抽签开始" OnClientClick="GetStart()"/>&nbsp;
                 <asp:Button ID="Stop" runat="server" class="button button-primary"  
               Text="停  止" OnClientClick="GetStop()" />
                <asp:Button ID="SaveButton"  class="button button-primary" runat="Server" 
                    Text="保存" OnClientClick="alert('保存成功！');" onclick="SaveButton_Click" >
                </asp:Button>
        </div>
             </ContentTemplate>
           </asp:UpdatePanel>

        <hr />
        <asp:HiddenField ID="HiddenField1" runat="server" />
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
