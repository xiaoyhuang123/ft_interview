<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchMsap0.aspx.cs" Inherits="FTInterviewSites.msap.SearchMsap0" %>
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
</head>
<body>
    <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          <h3>基本信息</h3>
            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        招聘名称：</label>
                    <div class="controls">
                      <input id="ZpitemName"   name="ZpitemName"  type="text" class=" control-text"  runat="Server"/>
                    </div>
                </div>
                <asp:Button ID="SearchButton" runat="server" class="button button-primary" 
                    Text="搜索" onclick="SearchButton_Click" />  
            </div>
            <h3>招聘列表</h3>
             <div class="row"  align="right">
                 <asp:HiddenField ID="hdfWPBH" runat="server" />
            </div>
          <asp:GridView ID="ZpitmGridview" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static" 
                                ShowHeaderWhenEmpty="True">
              <Columns>
                  <asp:TemplateField HeaderText="编号" ItemStyle-Width="10%">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="招聘名称" ItemStyle-Width="50%">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="发布时间" ItemStyle-Width="30%">
                      <ItemTemplate>
                          <asp:Label ID="ZpBm" runat="server" Text='<%# Bind("PubTime") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   
                  <asp:HyperLinkField DataNavigateUrlFormatString="SearchMsap.aspx?zpitmid={0}" Text="进入"
                    ItemStyle-Width="8%"
                  ControlStyle-Font-Size="Smaller" ControlStyle-ForeColor="Gray" ControlStyle-Font-Underline="true"
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
                  Font-Size="Medium" Height="30px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br/>
           <webdiyer:AspNetPager ID="AspNetPagerAskAnswer" runat="server"  CenterCurrentPageButton="True"
                    PageSize="15"
                    AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                    HorizontalAlign="Center" 
                    onpagechanging="AspNetPagerAskAnswer_PageChanging" Font-Size="Medium"> 
            </webdiyer:AspNetPager> 
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
