<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pingfengl.aspx.cs" Inherits="FTInterviewSites.mstgl.Pingfenmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
     <script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../assets/js/bui-min.js"></script>
    <script type="text/javascript" src="../assets/js/config-min.js"></script>
    <script src="../Scripts/javascript/popup.js" type="text/javascript"></script>
    <script src="../Scripts/javascript/common.js" type="text/javascript"></script>
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
                 alert("请先选择！");
                 return false;
             }
             else {
                 if (confirm("该操作会移除该条信息，您确认要移除吗？")) {
                     document.getElementById("hdfWPBH").value = AuditVal;
                     return true;
                 }
                 else
                     return false;
             }
         }
         function batchAudit1(id) {
             var AuditVal = "";
             var bid = document.getElementsByName("BoxId");
             for (var i = 0; i < bid.length; i++) {
                 if (bid[i].checked == true) {
                     AuditVal = AuditVal + bid[i].value + ",";
                 }
             }
             if (AuditVal.length <= 0) {
                 alert("请先选择！");
                 return false;
             }
             else {
                 if (confirm("该操作会移除该条信息，您确认要移除吗？")) {
                     document.getElementById("hdfWPBH1").value = AuditVal;
                     return true;
                 }
                 else
                     return false;
             }
         }
         function GetYpzList() {

             //   var url = "YpzList.aspx?id=" + dep + "&c_time=" + tme;
             ShowIframe("YpzList.aspx", 900, 400, "用户列表");
             return false;
         }
     </script>
</head>
<body>
       <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          <h3>评价项点</h3>
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
                 <asp:Button ID="AddXD" runat="server" CssClass="button"  ToolTip="点此完成添加评价项点" Text="添加项点" 
                   OnClientClick="ShowIframe('XDinfo.aspx',900,450,'添加项点'); return false" />
             <asp:Button ID="DeleteStuff" runat="Server" CssClass="button" Text="移除项点"  
                ToolTip="点此完成删除评价项点" OnClientClick="return batchAudit(this)"
                onclick="DeleteXD_Click" />  
          <br/><br/>
        </div>

          <asp:GridView ID="XdGridview" runat="server" AllowPaging="false" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static" 
                 ShowHeaderWhenEmpty="true"
                                onrowcancelingedit="XdGridview_RowCancelingEdit" 
                                onrowediting="XdGridview_RowEditing" onrowupdating="XdGridview_RowUpdating">
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
                  <asp:TemplateField HeaderText="评价项点">
                      <ItemTemplate>
                          <asp:Label ID="pjxd" runat="server" Text='<%# Bind("Content") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="分值" ItemStyle-Width="30%">
                      <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" Height="100%" Width="50px" Text='<%# Bind("Score") %>' runat="server"></asp:TextBox>
                         <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" Font-Size="Smaller" ForeColor=" Gray" Font-Underline="true"
                            CommandName="Update" Text="更新"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"
                            CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Height="100%" Width="50px" Text='<%# Bind("Score") %>' runat="server"></asp:Label>
                          <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"  Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"
                            CommandName="Edit" Text="修改"></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="" ShowHeader="False">
                             <ItemTemplate>
                                <a href='#' onclick="ShowIframe('XDinfo.aspx?xdid=<%# Eval("Id") %>',900,450,'项点信息详情'); return false">
                                 <asp:Label ID="Label2" runat="server" Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"  Text="详细"></asp:Label>
                                </a>
                             </ItemTemplate>
                        </asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="30px" />
              <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
                  PreviousPageText="" Visible="False" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" 
                  Font-Size="Medium" />

              <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="center" VerticalAlign="Middle"
                  Font-Size="Medium" Height="30px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br/>
        

          <h3>评价标准</h3>
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH1" runat="server" />
              <asp:Button ID="AddBZ" runat="Server" CssClass="button" Text="添加标准"  
                ToolTip="点此完成添加评价标准" OnClientClick="ShowIframe('BZinfo.aspx',900,450,'添加标准'); return false" >
                  </asp:Button>    
             <asp:Button ID="DeleteBZ" runat="Server" CssClass="button" Text="移除标准"  
                ToolTip="点此完成删除评价标准" OnClientClick="return batchAudit1(this)"
                onclick="DeleteBZ_Click" >
                 </asp:Button>    
          <br/><br/>
        </div>
          
          <asp:GridView ID="BZGridview" runat="server" AllowPaging="False" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 ShowHeaderWhenEmpty="true"
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
                  <asp:TemplateField HeaderText="评价标准">
                      <ItemTemplate>
                          <asp:Label ID="pjbz" runat="server" Text='<%# Bind("Content") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ShowHeader="False">
                             <ItemTemplate>
                                <a href='#' onclick="ShowIframe('BZinfo.aspx?bzid=<%# Eval("Id") %>',900,450,'标准信息详情'); return false">
                                 <asp:Label ID="Label2" runat="server" Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"  Text="详细"></asp:Label>
                                </a>
                             </ItemTemplate>
                        </asp:TemplateField>
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
        
          <div style=" text-align:center;">
              <asp:Button ID="Button1" runat="server" class="button button-primary" Text="下一步" onclick="Button1_Click" />
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
