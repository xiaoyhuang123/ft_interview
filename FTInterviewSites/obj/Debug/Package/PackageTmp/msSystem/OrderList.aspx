<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="FTInterviewSites.msSystem.OrderList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../assets/js/bui-min.js"></script>
    <script type="text/javascript" src="../assets/js/config-min.js"></script>
    <script src="../Scripts/javascript/popup.js" type="text/javascript"></script>
    <script src="../Scripts/javascript/common.js" type="text/javascript"></script> 
</head>
<body>
    <div style=" text-align:center">
    <br/>
    <br/>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="面试顺序"></asp:Label>
    </div>
    <div style=" text-align:right">
        <asp:Label ID="XuantiState" runat="server" Font-Size="Medium" Text="选题状态：">
         <asp:Label ID="XuanTi" runat="server" Font-Size="Medium" Text=""></asp:Label>
        </asp:Label>&nbsp;&nbsp;&nbsp;
    </div>
     <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
        </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
          <asp:GridView ID="MsOrderGridview" runat="server" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static"
                                CaptionAlign="Top">
              <Columns>
                  <asp:TemplateField HeaderText="编号" Visible="false">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="姓名">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("YpzName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="面试顺序">
                        <ItemTemplate>
                           <asp:Label ID="ZpGw" runat="server" Text='<%# Eval("Index_temp").ToString()=="32767"?" ":Eval("Index_temp").ToString()  %>'>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                   <asp:HyperLinkField DataNavigateUrlFormatString="Question.aspx?ms_id={0}" Text="开始面试"
                   ControlStyle-Font-Size="Smaller" ControlStyle-ForeColor="Red" ControlStyle-Font-Underline="true"
                        DataNavigateUrlFields="Id"  />
                 
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />
              <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
                  PreviousPageText="" Visible="False" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" 
                  Font-Size="Medium" />

              <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="center" 
                  Font-Size="Medium" Height="50px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br/>
         </ContentTemplate>
           </asp:UpdatePanel>
           <div style=" text-align:center;">
            <input type="button" id="btn_add_stuff"  class="button button-primary" value="考场纪律" onclick="javascript:location.href='kcjl.aspx'"/>&nbsp;
             <asp:Button ID="Start" runat="server" class="button button-primary" Text="抽选考题" 
                    OnClientClick="ShowIframe('SelectMst.aspx',900,400,'面试套题选择'); return false" />
                     <input type="button" id="Button1"  class="button button-primary" value="返回主页" onclick="javascript:location.href='index0.aspx'"/>&nbsp;
           </div>
         <br/><br />
           <div id="ResultID" runat="server" style=" text-align:center;">
          <asp:Label ID="Label2" runat="server" Font-Size="30px" Text="已抽选试题编号："></asp:Label>
          <asp:Label ID="LabelRes" runat="server" Font-Size="50px" Text=""></asp:Label>
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
