<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgList.aspx.cs" Inherits="FTInterviewSites.msap.MsgList" %>

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
                if (confirm("该操作会添加信息，您确认要执行吗？")) {
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
                        DataTextField="Name" DataValueField="Id" Width="200px" >
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
              <div class="control-group span12">
                    <label class="control-label">
                        姓 名：</label>
                    <div class="controls">
                        <input id="wName" name="wName" type="text" runat="Server" class="control-text" />
                    </div>
                </div>   
               
              <div style="align:center">
                  <asp:Button ID="StuffSearch" runat="server" Text="搜索" 
                      class="button button-primary" onclick="MsgSearch_Click"/>
                </div>
            </div>
         <hr width="100%" size="1" color="#5151A2" align="center"> 
        <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
             <asp:Button ID="DeleteYpz" runat="Server" CssClass="button" Text="添加"  
                    ToolTip="点此完成添加面试官进入面试" OnClientClick="return batchAudit(this)"
                    onclick="AddYpz_Click" />  
          <br/><br/>
        </div>


          <asp:GridView ID="MsgGridview" runat="server" AllowPaging="false" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowHeaderWhenEmpty="true"
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static">
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
                  <asp:HyperLinkField DataNavigateUrlFormatString="MsgInfo.aspx?msg_id={0}" Text="详情"
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
