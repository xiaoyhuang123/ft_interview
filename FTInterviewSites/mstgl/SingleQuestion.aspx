<%@ Page Language="C#"  ValidateRequest="false"  AutoEventWireup="true" CodeBehind="SingleQuestion.aspx.cs" Inherits="FTInterviewSites.mstgl.SingleQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>丰台机务段公开招聘面试管理系统</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
     <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
     <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" /> 

      <script type="text/javascript" charset="utf-8" src="../ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../ueditor/ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="../ueditor/lang/zh-cn/zh-cn.js"></script>
</head>
<body style="width:100%; margin-right:auto; margin-left:auto;">
     <div class="container">
         <form id="J_Form" class="form-horizontal" action="SingleQuestion.aspx" runat="server">
      <h3>基本信息</h3>
      <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        答题时间:</label>
                    <div class="controls">
                          <input id="AnsTime" name="AnsTime" type="text" runat="Server" class="control-text" /> 分钟
                    </div>
                </div>
                <div class="control-group span12">
                    <label class="control-label">
                        权重比例:</label>
                    <div class="controls">
                         <input id="StWeight" name="StWeight" type="text" runat="Server" class="control-text" /> %
                    </div>
                </div>    
            </div>
      <h3>题干信息</h3>
       <div align="center" style="z-index:99999; height:100%;">
                   <textarea id="myEditor" name="myEditor" 
                    style=" height:220px; width:100%; "
                   runat="server" onblur="setUeditor()"></textarea>
                  <!--  <script type="text/javascript">
                        var editor = new baidu.editor.ui.Editor();
                        editor.render("myEditor");
                    </script>-->
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
