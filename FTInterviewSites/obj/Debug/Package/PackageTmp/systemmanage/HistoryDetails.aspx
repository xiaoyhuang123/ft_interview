<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryDetails.aspx.cs" Inherits="FTInterviewSites.systemmanage.HistoryDetails" %>

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
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        <h3>基本信息</h3>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    应聘者姓名：</label>
                <div class="controls">
                 <asp:Label ID="yName" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    出生日期：</label>
                <div class="controls">
                 <asp:Label ID="BirthDay" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    学历：</label>
                <div class="controls">
                    <asp:Label ID="yDegree" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group span12">
                <label class="control-label">
                    参工时间：</label>
                <div class="controls">
                     <asp:Label ID="yJoinTime" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
             <div class="control-group span12">
                <label class="control-label">
                    应聘部门：</label>
                <div class="controls">
                     <asp:Label ID="yDepart" runat="server" Text=""></asp:Label>
                </div>
            </div>
             <div class="control-group12 span12">
                <label class="control-label">
                    应聘岗位：</label>
                     <div class="controls">
                     <asp:Label ID="yPosition" runat="server" Text=""></asp:Label>
                     </div>
            </div>
        </div>
        <div class="row">
            <div class="control-group span12">
                <label class="control-label">
                    政治面貌：</label>
                <div class="controls">
                    <asp:Label ID="yPolitic" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <hr />
        <h3>面试结果汇总</h3>
        <br/>
           <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
        </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <asp:GridView ID="ScoreDetailAll" Width="100%" runat="server"
             AllowPaging="False" ShowHeader="false"
              BackColor="White" BorderColor="#3366CC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="4"  >

              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />

              <RowStyle BackColor="White" HorizontalAlign="center" 
                  Font-Size="Medium" Height="40px" ForeColor="#3366FF" Font-Bold="True" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
             </asp:GridView>
         </ContentTemplate>
           </asp:UpdatePanel>
        <hr />
          <h3>面试结果详情</h3>
        <br/>
           <div class="row"  align="right">
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
             <asp:GridView ID="ScoreDetailEach" Width="100%" runat="server"
             AllowPaging="False" ShowHeader="false"
              BackColor="White" BorderColor="#3366CC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="4"  >

              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />

              <RowStyle BackColor="White" HorizontalAlign="center" 
                  Font-Size="Medium" Height="40px" ForeColor="#3366FF" Font-Bold="True" />
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
          <asp:LinkButton ID="LinkButton1" CssClass=" button button-primary" PostBackUrl="Historylist.aspx" runat="server">返回</asp:LinkButton>
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
