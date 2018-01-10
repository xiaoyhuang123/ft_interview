<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMsap0.aspx.cs" Inherits="FTInterviewSites.msap.AddMsap0" %>
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
                alert("请先选择岗位！");
                return false;
            }
            else {
                if (confirm("该操作会删除该岗位所有信息，您确认要删除吗？")) {
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

            <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>

            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        招聘部门：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
                        AutoPostBack="True"  onselectedindexchanged="department_SelectedIndexChanged"
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
               
              <div style="align:center">
                  <asp:Button ID="StuffSearch" runat="server" Text="搜索" 
                      class="button button-primary" onclick="StuffSearch_Click"/>
                </div>
            </div>
         <hr width="100%" size="1" color="#5151A2" align="center"> 
          
          
        
          <asp:GridView ID="ZpgwGridview" runat="server" AllowPaging="True" 
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
                  <asp:TemplateField HeaderText="招聘部门">
                      <ItemTemplate>
                          <asp:Label ID="ZpBm" runat="server" Text='<%# Bind("Zpbm") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="招聘岗位">
                      <ItemTemplate>
                          <asp:Label ID="ZpGw" runat="server" Text='<%# Bind("Zppos") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="招聘人数">
                      <ItemTemplate>
                          <asp:Label ID="ZpSum" runat="server" Text='<%# Bind("ZpSums") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                  <asp:HyperLinkField DataNavigateUrlFormatString="AddMsap.aspx?zpfb_id={0}" Text="面试安排"
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
                    onpagechanging="AspNetPagerAskAnswer_PageChanging" Font-Size="Large"> 
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
