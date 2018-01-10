<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchMsg.aspx.cs" Inherits="FTInterviewSites.msggl.SearchMsg" %>
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
    <script type="text/javascript">
        function selAll() {
            var selobj = document.getElementsByName("BoxId");
            for (var i = 0; i < selobj.length; i++) {
                if (!selobj[i].disabled) {
                    selobj[i].checked = true;
                    selobj[i].parentNode.parentNode.style.backgroundColor = '#CCCCCC';
                }
            }
        }

        function removeAll() {
            var selobj = document.getElementsByName("BoxId");
            for (var i = 0; i < selobj.length; i++) {
                selobj[i].checked = false;
                selobj[i].parentNode.parentNode.style.backgroundColor = '';
            }
        }

        function onclicksel() {
            var chkobj = document.getElementById("BoxIdAll");
            if (chkobj.checked == true) {
                selAll();
            }
            else {
                removeAll();
            }
        }
        function onclicksingle(cb) {
            var row = cb.parentNode.parentNode;
            if (cb.checked) {
                row.style.backgroundColor = '#CCCCCC';
            }
            else {
                row.style.backgroundColor = '';
            }
        }

        function batchAudit(id) {
            var AuditVal = "";
            var bid = document.getElementsByName("BoxId");
            for (var i = 0; i < bid.length; i++) {
                if (bid[i].checked == true) {
                    AuditVal = AuditVal + bid[i].value + ",";
                }
            }
            if (AuditVal.length <= 0) {
                alert("请先选择考官！");
                return false;
            }
            else {
                if (confirm("该操作会删除该考官所有信息，您确认要删除吗？")) {
                    document.getElementById("hdfWPBH").value = AuditVal;
                    return true;
                }
                else
                    return false;
            }
        }
</script>
</head>
<body>
   <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        部门名称：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
                        DataTextField="Name" DataValueField="Id" >
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div>
           
              <div class="control-group span12">
                    <label class="control-label">
                        姓 名：</label>
                    <div class="controls">
                        <input id="wName" name="wName" type="text" runat="Server" class="control-text" />
                    </div>
                </div>   
               

                  <asp:Button ID="StuffSearch" runat="server" Text="搜索" 
                      class="button button-primary" onclick="StuffSearch_Click"/>
            </div>
         <hr width="100%" size="1" color="#5151A2" align="center"> 
        <div class="row">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
            <div style="  text-align:center"><label style=" font-size:medium; color:Red">局属单位干部管理规定，面试小组一般不少于5人</label></div>
            <div style=" float:right">
            <input type="button" id="btn_add_stuff"  class="button" value="添加考官" onclick="javascript:location.href='AddMsg.aspx'"/>
             <asp:Button ID="DeleteStuff" runat="Server" CssClass="button" Text="删除考官"  
                ToolTip="点此完成删除考官" OnClientClick="return batchAudit(this)"
                onclick="DeleteStuff_Click" />  
                </div>
          <br/><br/>

        </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>


          <asp:GridView ID="MsgGridview" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static" 
                                ShowHeaderWhenEmpty="True">
              <Columns>
               <asp:TemplateField HeaderText="选择" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                      <HeaderTemplate>
                                <input type="checkbox" name="BoxIdAll" id="BoxIdAll" ToolTip="全选" onclick="onclicksel()" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <input id="BoxId" name="BoxId" value='<%#(Convert.ToString(Eval("Id")))%>' type="checkbox" onclick="onclicksingle(this)"/>
                    </ItemTemplate>
                                       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="序号">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="工号" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Bind("WorkID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="姓名">
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="部门">
                      <ItemTemplate>
                          <asp:Label ID="Label4" runat="server" Text='<%# Bind("DepName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="职务">
                      <ItemTemplate>
                          <asp:Label ID="duty" runat="server" Text='<%# Bind("PositionName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:HyperLinkField DataNavigateUrlFormatString="AddMsg.aspx?msg_id={0}" Text="详情"
                   ControlStyle-Font-Size="Smaller" ControlStyle-ForeColor="Gray" ControlStyle-Font-Underline="true"
                        DataNavigateUrlFields="Id"  >
                  <ControlStyle Font-Size="Smaller" Font-Underline="True" ForeColor="Gray" />
                  </asp:HyperLinkField>
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
