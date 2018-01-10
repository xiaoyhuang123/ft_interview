<%@ Page Language="C#" validateRequest="false"  AutoEventWireup="true" CodeBehind="KcjilvEdit.aspx.cs" Inherits="FTInterviewSites.gggl.Kcjv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
<body>
     <div class="container">
         <form id="J_Form" runat="server">
      <h3>考场纪律</h3>

            <table style="width: 100%;">
             <tr>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
             <tr>
                 <td>
                    内容：
                 </td>
                 <td>
                      <div align="center" style="z-index:99999; height:100%;">
                   <textarea id="myEditor" name="myEditor" 
                    style=" height:300px; width:100%;"
                   runat="server" onblur="setUeditor()"></textarea>
                    <script type="text/javascript">
                        var editor = new baidu.editor.ui.Editor();
                        editor.render("myEditor");
                    </script>
                    </div>
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
         </table>
      <hr/>
      <div class="row">
        <div align="center">
            <asp:Button ID="Button1" class="button button-primary" runat="server" Text="保存" 
                onclick="Button1_Click" />
            <asp:LinkButton ID="LinkButton1"  runat="server" PostBackUrl="ShowKcjl.aspx" class="button button-primary">预览</asp:LinkButton>  
        </div>
      </div>
         </form>
         <div style=" height:100px;">
         </div>
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
