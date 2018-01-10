<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BmInfo.aspx.cs" Inherits="FTInterviewSites.bmgl.BmInfo" %>

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
         <form id="J_Form" runat="server">
      <h3>基本信息</h3>

       <div class="row">
        <div class="control-group span12">
          <label class="control-label"><s>*</s>部门名称：</label>
          <div class="controls">
            <input name="Dname" id="Dname" type="text" class="control-text"  runat="server">
          </div>
        </div>
       </div> 

         <div class="row">
        <div class="control-group span12">
          <label class="control-label">简介：</label>
         <div class="controls control-row4">
            <textarea name="Dinfo" id="Dinfo" class="span8 span-width" runat="Server">
            </textarea>
          </div>
        </div>
      </div>
      <hr/>
      
      <div class="row">
        <div class="form-actions offset3">
             <asp:Button ID="SaveID" class="button button-primary" runat="server" Text="保存" 
                onclick="Save_Click" />
        </div>
      </div>
         </form>

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
