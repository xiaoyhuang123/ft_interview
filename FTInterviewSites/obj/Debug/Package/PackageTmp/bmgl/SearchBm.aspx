<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBm.aspx.cs" Inherits="FTInterviewSites.bmgl.SearchBm" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" /> 
    <link href="../assets/css/prettify.css" rel="stylesheet" type="text/css">
   <style type="text/css">
    code {
      padding: 0px 4px;
      color: #d14;
      background-color: #f7f7f9;
      border: 1px solid #e1e1e8;
    }
     </style>
</head>
<body>
 <div class="container">
      <form id="J_Form" class="form-horizontal" runat="server">
        <div class="row">
          <div class="control-group span12">
            <label class="control-label">部门名称:</label>
            <div class="controls">
              <input id="Dname" name="Dname"  runat="server" type="text" class="control-text" />
            </div>
          </div>
          <div class="span3">
           
             <asp:Button ID="Button1" class="button button-primary" runat="server" Text="搜索" 
                  onclick="Button1_Click" />
          </div>
        </div>
        <h3/>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
       
         <asp:GridView ID="BmGridview" runat="server" BackColor="White" AllowPaging="true"
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 AutoGenerateColumns="False" Width="100%" DataKeyNames="Id" PageSize="10"
                 HeaderStyle-HorizontalAlign="Center"
                 HeaderStyle-VerticalAlign="Middle" ClientIDMode="Static"
                 onrowdeleting="GridView1_RowDeleting" >
              <Columns>
               <asp:TemplateField HeaderText="编号">
                      <ItemTemplate>
                          <%# (Container.DataItemIndex+1).ToString()%>
                </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="ID" Visible="false" HeaderText="部门编号" />
                  <asp:BoundField DataField="Name" ItemStyle-Width="80%" HeaderText="部门名称" >
                  </asp:BoundField>
                  <asp:BoundField DataField="Info" Visible="false"  HeaderText="部门简介" />
                  <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"  Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"
                              CommandName="Delete" Text="删除" OnClientClick="return confirm( '您确认要删除吗？')"></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:HyperLinkField DataNavigateUrlFormatString="BmInfo.aspx?dep_id={0}" Text="详情" 
                   ControlStyle-Font-Size="Smaller" ControlStyle-ForeColor="Gray" ControlStyle-Font-Underline="true"
                        DataNavigateUrlFields="Id"  />
                 
              </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />
              <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PreviousPageText="上一页" 
                  Visible="False" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" 
                  Width="10px" Font-Size="Medium" />
             <RowStyle BackColor="White" ForeColor="#003399" Height="30px" HorizontalAlign="Center"
                     Font-Size="Small"/>
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <br />
          <webdiyer:AspNetPager ID="AspNetPagerAskAnswer" runat="server"  CenterCurrentPageButton="True"
                    PageSize="10"
                    AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                    HorizontalAlign="Center" 
                    onpagechanging="AspNetPagerAskAnswer_PageChanging" Font-Size="Medium"> 
            </webdiyer:AspNetPager> 
   
        </ContentTemplate>
           </asp:UpdatePanel>
        
      </form>
    </div>
   <div style=" height:100px">
   </div>
</body>
</html>
