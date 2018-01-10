<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionScore.aspx.cs" Inherits="FTInterviewSites.msg.QuestionScore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript" >
      /*  function toFull() {
            if (window.name == "fullscreen") return;
            var a = window.open("", "fullscreen", "fullscreen=yes")
            a.location = window.location.href
            window.opener = null
            window.close()
        }*/
        function auto_submit() {
            //alert("hhy");
            document.getElementById("SaveButton").click();
        }
    </script>
</head>
<body onload="toFull()">
    <div class="container">
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        <h3>试题信息</h3>
          <asp:GridView ID="GridView1" runat="server" 
                 AutoGenerateColumns="False" 
                  Width="100%" HorizontalAlign="Center" DataKeyNames="Id" 
            ShowHeaderWhenEmpty="True" CellPadding="4" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                 <Columns>
                  <asp:TemplateField HeaderText="题号" ItemStyle-Width="5%">
                      <ItemTemplate>
                          <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="试题内容" ItemStyle-HorizontalAlign="Left">
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server" 
                             ToolTip='<%# Bind("Question") %>'
                             Text='<%# Eval("Question").ToString() %>' ></asp:Label>
                         </ItemTemplate>

                   <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:TemplateField>
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle Height="30px" BackColor="#003399" Font-Bold="True" 
                     ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle HorizontalAlign="center" Font-Size="15px" 
                     BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>

        <h3>评分信息</h3>
           <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
        </div>
           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
         <asp:GridView ID="ScoreDetail" Width="100%" runat="server"
             AllowPaging="True" ShowHeader="false"
              BackColor="White" BorderColor="#3366CC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="4" ClientIDMode="Static"  >
              
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />

              <RowStyle BackColor="White" HorizontalAlign="center" ForeColor="#003399" 
               Font-Size="15px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>
            </ContentTemplate>
       </asp:UpdatePanel>
        <hr />
      <div style=" text-align:center">
             <asp:Button ID="submitButton"  class="button button-primary" runat="Server" 
                 Text="提交" onclick="SubmitButton_Click"  ></asp:Button>

              <asp:Button ID="BackButton"  class="button button-primary" runat="Server" 
                 Text="返回" onclick="BackButton_Click"  ></asp:Button>

                  <asp:Button ID="SaveButton"  class="button button-primary" runat="Server" style="display: none"
                 Text="保存" onclick="SaveButton_Click"  ></asp:Button>
           
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
