<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowScore.aspx.cs" Inherits="FTInterviewSites.msSystem.ShowScore" %>

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
        <form id="J_Form" class="form-horizontal" runat="Server">
        <h1>应聘者</h1>
        <div style=" text-align:center;">
            <asp:Label ID="YpzName" Font-Size="50px" runat="server" Text=""> </asp:Label>
        </div>
        <h1>面试得分</h1>
        <div style=" width:100%; height:260px; text-align:center;">
        
               <div style=" height:260px; width:600px; background-color:Gray; text-align:center; margin:auto;">
                 <br/><br />
                   <asp:Label ID="ResultScore" runat="server" Width="100%" ForeColor="Black" 
                       Font-Size="200px"  Height="100%" style="margin-top: 100px" ></asp:Label>   
                 </div>
        </div>

          
         <br/>
          <div style=" text-align:center;">
          <asp:Button ID="Button1" runat="server" class="button button-primary"   
                  Text="刷 新" onclick="Button1_Click" />
              <asp:Button ID="SaveButton" runat="server" class="button button-primary"   
                  Text="返 回" onclick="SaveButton_Click" />
         </div>
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
