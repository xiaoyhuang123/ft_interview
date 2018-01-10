<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangetikuPwd.aspx.cs" Inherits="FTInterviewSites.mstgl.ChangetikuPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title></title>
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />   <!-- 下面的样式，仅是为了显示代码，而不应该在项目中使用-->
   <link href="../assets/css/prettify.css" rel="stylesheet" type="text/css" />

   <style type="text/css">
    code {
      padding: 0px 4px;
      color: #d14;
      background-color: #f7f7f9;
      border: 1px solid #e1e1e8;
    }
   </style>
   <script type="text/javascript">

       function checkPass() {
           var pwd1 = document.getElementById("<%=psd1.ClientID%>").value
           var pwd2 = document.getElementById("<%=psd2.ClientID%>").value
           if (pwd1 != pwd2) {
               document.getElementById("errorpwd").style.display = "inline";
               // return false;
           }
           else {
               document.getElementById("errorpwd").style.display = "none";
           }
       }
       function ClearInput() {
           document.getElementById("<%=psd.ClientID%>").value = "";
           document.getElementById("<%=psd1.ClientID%>").value = "";
           document.getElementById("<%=psd2.ClientID%>").value = "";
       }

   </script>
</head>
<body>
    <div class="container" >
    <div class="row" >
      <form id="J_Form" class="form-horizontal span24" runat="Server">
      
      <div class="row" >
          <div class="control-group span12">
            <label class="control-label"><s>*</s>原始密码：</label>
            <div class="controls">
              <input id="psd" name="psd" type="password" runat="Server" data-rules="{required:true}" class="input-normal control-text">
            </div>
          </div>
        </div>
        <div class="row">
          <div class="control-group span12">
            <label class="control-label"><s>*</s>新密码：</label>
            <div class="controls">
              <input id ="psd1" name="psd1" runat="Server" type="password"  data-rules="{required:true}" class="input-normal control-text">
            </div>
          </div>
        </div>
		<div class="row">
          <div class="control-group span12">
            <label class="control-label"><s>*</s>确  认：</label>
            <div class="controls">
              <input id="psd2" name="psd2" type="password" runat="Server" onblur="return checkPass();" data-rules="{required:true}" class="input-normal control-text">
              <asp:Label ID="errorpwd" runat="server" style="display:none;" Text="两次输入密码不一致" ForeColor="Red"></asp:Label>
                
            </div>
          </div>
        </div>
        <div class="row ">
            <div class="span13 offset3 ">
        <asp:Button ID="ConfirmChange" class="button button-primary" runat="server" Text="确定" 
                    onclick="ConfirmChange_Click" />
        <asp:Button ID="ResetChange" class="button button-primary" runat="server" Text="清空" OnClientClick="ClearInput();" />
            </div>
        </div>
      </form>
    </div>
  </div>
</body>
</html>
