<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsInfo.aspx.cs" Inherits="FTInterviewSites.msg.MsInfo" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
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
                   alert("请先选择应聘者！");
                   return false;
               }
               else {
                   if (confirm("该操作会提交该应聘者面试信息，您确认要提交吗？")) {
                       document.getElementById("hdfWPBH").value = AuditVal;
                      // alert("提交成功！");
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
        <form id="J_Form" class="form-horizontal" action="MsInfo.aspx" runat="Server">

        <h3>招聘信息</h3>
        <div style=" text-align:center">
           
                    <asp:Label ID="MsTitle" Font-Size="Large" Width="100%" runat="server" Text=""></asp:Label>
               <hr/>
        </div>
        <div class="row">
             <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>招聘部门：</label>
                <div class="controls">
                     <asp:DropDownList ID = "department" name="department" runat="Server" 
                        DataTextField="Name" DataValueField="Id" >
                   </asp:DropDownList>
                </div>
            </div>
             <div class="control-group12 span12">
                <label class="control-label">
                    <s>*</s>招聘岗位：</label>
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
                    <s>*</s>招聘人数：</label>
                    <div class="controls">
                    <input id="ZpSum"  name="ZpSum"  type="text" class=" control-text"  runat="Server"/>
                    </div>
            </div>
          <div class="control-group12 span12">
                <label class="control-label">
                    <s>*</s>面试日期：</label>
                <div class="controls">
                    <input id="PubTime"  type="text" class=" control-text" runat="Server"  />
                </div>
            </div>
        </div>
       
     
          <div class="row"  align="right">
             <asp:Button ID="SubmitButton" runat="server" class="button" Width="100px"
                Text="提交" OnClientClick="return batchAudit(this)" onclick="SubmitButton_Click"/>  
          <br/><br/>
        </div>
         
        <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
        </div>
            
          <asp:GridView ID="MszGridview" runat="server" AllowPaging="True" 
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
                  <asp:TemplateField HeaderText="编号">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="应聘者姓名">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("YpzName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="所在部门" >
                        <ItemTemplate>
                           <asp:Label ID="BM" runat="server" Text='<%# Bind("DepName") %>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="职务" >
                        <ItemTemplate>
                           <asp:Label ID="Duty" runat="server" Text='<%# Bind("DutyName") %>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="得分">
                      <ItemTemplate>
                          <asp:Label ID="Chengji" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="提交状态">
                      <ItemTemplate>
                          <asp:Label ID="MsState" runat="server"
                           style=' <%# "color:" + (Eval("State").ToString() == "已提交" ? "#00FF00" : (Eval ("State").ToString() == "未提交") ? "red" : "" ) %> '
                           Text='<%# Bind("State") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:HyperLinkField DataNavigateUrlFormatString="ConfirmInfo.aspx?ypzzp_id={0}" Text="打分"
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

           <hr/>
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
