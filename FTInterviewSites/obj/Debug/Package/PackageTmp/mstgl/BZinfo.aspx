<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BZinfo.aspx.cs" Inherits="FTInterviewSites.mstgl.BZinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>丰台机务段公开招聘面试管理系统</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
     <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
     <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <div class="container">
         <form id="J_Form" class="form-horizontal" action="" runat="server">
          
      <h3>标准内容</h3>
       <div align="center" style="z-index:99999; height:100%;">
                   <textarea id="myEditor" name="myEditor" 
                    style=" height:220px; width:100%; "
                   runat="server" onblur="setUeditor()"></textarea>
                    <!--script type="text/javascript">
                        var editor = new baidu.editor.ui.Editor();
                        editor.render("myEditor");
                    </script-->
       </div>
      <div style=" text-align:center">
        <br/>
             <asp:Button ID="SaveID" class="button button-primary" runat="server" Text="保存" 
                onclick="Save_Click" />
                <br/>
                <br/>
      </div>
      
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
