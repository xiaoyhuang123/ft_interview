<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historylist.aspx.cs" Inherits="FTInterviewSites.systemmanage.Historylist" %>
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
     <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
</head>
<body>
    <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
          <h3>基本信息</h3>
            <div class="row">

             <div class="control-group span12">
                    <label class="control-label">
                        招聘部门：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
                        AutoPostBack="True" onselectedindexchanged="department_SelectedIndexChanged"
                        DataTextField="Name" DataValueField="Id" Width="150px" >
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div>
             <div class="control-group span12">
                    <label class="control-label">
                        招聘岗位：</label>
                    <div class="controls">
                         <asp:DropDownList ID = "Position" name="Position" runat="Server" 
                        DataTextField="Zppos" DataValueField="Zppos" Width="150px" >
                         </asp:DropDownList>
                    </div>
                </div> 
                
            </div>
               <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        面试时间：</label>
                    <div class="controls">
                        <input id="startDate"  name="startDate" runat="Server" style="width:80px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen'})"/>
                        <span> - </span>
                        <input id="endDate"  name="startDate" runat="Server" style="width:80px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'startDate\')}'})"/>
                    </div>
                </div>
                <div class="control-group span12">
                    <label class="control-label"> </label>
                    <div class="controls">
                        <asp:Button ID="SearchButton" runat="server" class="button button-primary" 
                    Text="搜索" onclick="SearchButton_Click1" />  
                    </div>
                </div>
               
            </div>
            <h3>面试列表</h3>
             <hr width="100%" size="1" color="#5151A2" align="center"> 
         <div class="row"  align="center">
          <h1><asp:Label ID="ItemTitle" Font-Size="Large" runat="server" Text=""></asp:Label></h1>
           </div>
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
             </div>

          <asp:GridView ID="MslbGridview" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%"   PageSize="15" ClientIDMode="Static" 
              ShowHeaderWhenEmpty="True">
              <Columns>
                  <asp:TemplateField HeaderText="编号">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="应聘者姓名">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="面试名称">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="应聘部门">
                      <ItemTemplate>
                          <asp:Label ID="ZpBm" runat="server" Text='<%# Bind("DepName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="应聘岗位" ShowHeader="False">
                        <ItemTemplate>
                           <asp:Label ID="ZpGw" runat="server" Text='<%# Bind("ZpPosName") %>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="面试时间">
                      <ItemTemplate>
                          <asp:Label ID="MsTime" runat="server" Text='<%# Bind("ViewTime") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFormatString="HistoryDetails.aspx?ypzzpid={0}" Text="详情"
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
       </ContentTemplate>
           </asp:UpdatePanel>

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
