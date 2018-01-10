<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsjgDetails.aspx.cs" Inherits="FTInterviewSites.msjggl.MsjgDetails" %>

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
     <form id="J_Form" name="J_Form" class="form-horizontal" runat="Server">
      <h3>招聘结果汇总表</h3>
      <div style="height:20px;">
      </div>
     <hr />
       <div align="right">
          <asp:Button ID="Button2" runat="server" Text="导出报表" onclick="Button2_Click" />
     </div>
     <div align="center">
         <asp:Label ID="title_f" runat="server" Font-Size="24px" Text=""></asp:Label>
         <div style="height:5px">
         </div>
     </div>
     <div id="Div1" class="row" runat="Server">
         <asp:GridView ID="MsjgGridview" runat="Server" AutoGenerateColumns="False" 
          ShowHeaderWhenEmpty="true"
             HorizontalAlign="Center" Width="100%" BorderStyle="Solid">
             <Columns>
                 <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# (Container.DataItemIndex+1).ToString()%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:TemplateField>
                 <asp:TemplateField HeaderText="姓名">
                     <ItemTemplate>
                         <asp:Label ID="Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="部门-职务">
                     <ItemTemplate>
                         <asp:Label ID="Bm" runat="server" Text='<%# Bind("bm_duty") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="应聘部门-应聘岗位">
                     <ItemTemplate>
                         <asp:Label ID="Duty" runat="server" Text='<%# Bind("ypdep_pos") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="应聘岗位" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="Position" runat="server" Text='<%# Bind("yppos") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="面试成绩">
                     <ItemTemplate>
                         <asp:Label ID="Score" runat="server" ForeColor="red" Text='<%# Bind("score") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="备注">
                     <ItemTemplate>
                         <asp:Label ID="Comments" runat="server" Text='<%# Bind("info") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <HeaderStyle Font-Size="20px" Height="30px" />
             <PagerStyle  Font-Size="Medium" />
             <RowStyle HorizontalAlign="center" Height="40px" Font-Size="Medium"/>
         </asp:GridView>
    </div>
     <asp:HiddenField ID="hdfWBSH" runat="server" />
    </form>
    </div>
    <div style="height:100px;">
    </div>
</body>
</html>
