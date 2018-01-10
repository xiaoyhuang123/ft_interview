<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMsap.aspx.cs" Inherits="FTInterviewSites.msap.AddMsap" %>
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
                     document.getElementById("HiddenField1").value = AuditVal;
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

         function SubMitConfirm() {
             var tb = document.getElementById('<%=MsgGridview.ClientID %>');
         if (tb) {
             var rows = tb.rows.length-1;
             if(rows <5)
             {
                 if(confirm("考官人数不足5人，是否继续？"))
                 {
                  return true;
                 }
                 else{
                 return false;
                 }
             }
             return true;
         }

         }


     </script>
</head>
<body>
      <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          <h3>基本信息</h3>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <div class="row">
                <div class="control-group span12">
                    <label class="control-label">
                        招聘部门：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
                        DataTextField="Name" DataValueField="Id" Width="150px" AutoPostBack="True"
                            onselectedindexchanged="department_SelectedIndexChanged" >
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
                       </ContentTemplate>
        </asp:UpdatePanel>
            <div class="row">
               <div class="control-group span12">
                    <label class="control-label">
                        面试时间：</label>
                 <div class="controls">
                        <input id="MsTime"  name="MsTime" runat="Server" style="width:140px;" 
                        class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"/>
                 </div>
           </div>
               <div class="control-group span12">
                    <label class="control-label">
                        及格分数：</label>
                 <div class="controls">
                        <input id="HegeScore"  name="HegeScore" runat="Server" data-rules="{required:true,number:true}" style="width:140px;"/>
                        百分制
                 </div>
           </div>
                <asp:Button ID="Button4" runat="server" Text="保存" class="button button-primary"
                 onclick="Button4_Click" />
          </div>
           <div runat="Server" id="Step2Part">
          <h3>考官</h3>
          <hr/>
         
          
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
            <input type="button" id="add_kg"  class="button" value="添加考官"
              onclick="ShowIframe('MsgList.aspx?zpid=<%=zpidstr%>',900,400,'考官选择'); return false"/>
             <asp:Button ID="DeleteKaoguan" runat="Server" CssClass="button" Text="移除考官"  
                ToolTip="点此完成删除移除考官" OnClientClick="return batchAudit(this)"
                onclick="DeleteMsg_Click" />  
          <br/><br/>
        </div>
         
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>       
          <asp:GridView ID="MsgGridview" runat="server" AllowPaging="false" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static" 
                                onrowcancelingedit="MsgGridview_RowCancelingEdit" 
                                onrowediting="MsgGridview_RowEditing" 
                                onrowupdating="MsgGridview_RowUpdating" ShowHeaderWhenEmpty="True">
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
                  <asp:TemplateField HeaderText="序号" ItemStyle-Width="60px">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="姓名">
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("KgName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="部门">
                      <ItemTemplate>
                          <asp:Label ID="Label4" runat="server" Text='<%# Bind("KgDepName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="职务">
                      <ItemTemplate>
                          <asp:Label ID="duty" runat="server" Text='<%# Bind("KgPosName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="权重%" ItemStyle-Width="8%" ItemStyle-Height="25px" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" Height="100%" Width="50px" Text='<%# Bind("Weight") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Height="100%" Width="50px" Text='<%# Bind("Weight") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="False" ItemStyle-Width="120px">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" Font-Size="Smaller" ForeColor=" Gray" Font-Underline="true"
                            CommandName="Update" Text="更新"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"
                            CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"  Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"
                            CommandName="Edit" Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                  <asp:HyperLinkField Visible="false" DataNavigateUrlFormatString="MsgInfo.aspx?msg_id={0}" Text="详情"
                        DataNavigateUrlFields="Id"  />
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="40px" />
              <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
                  PreviousPageText="" Visible="False" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" 
                  Font-Size="Medium" />

              <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="center" VerticalAlign="Middle"
                  Font-Size="Medium" Height="38px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br/>
          </ContentTemplate>
           </asp:UpdatePanel>
          <h3>应聘者</h3>
          <hr/>

             <div class="row"  align="right">
            <asp:HiddenField ID="HiddenField1" runat="server" />
               <input type="button" id="Button2"  class="button" value="添加应聘者" 
              onclick="ShowIframe('YpzList.aspx?zpid=<%=zpidstr %>',900,400,'应聘者选择'); return false"/>
             <asp:Button ID="Button3" runat="Server" CssClass="button" Text="移除应聘者"  
                ToolTip="点此完成删除移除应聘者" OnClientClick="return batchAudit1(this)"
                onclick="DeleteYpz_Click" >
                 </asp:Button>    
          <br/><br/>
        </div>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>    
          <asp:GridView ID="YpzGridview" runat="server" AllowPaging="False" 
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
                  <asp:HyperLinkField Visible="false" DataNavigateUrlFormatString="YpzInfo.aspx?ypz_id={0}" Text="详情"
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
          </ContentTemplate>
           </asp:UpdatePanel>
          <div style=" text-align:center;">
            <asp:Button ID="Button1" class="button button-primary" runat="server" Text="保存" 
                 OnClientClick="return SubMitConfirm()" onclick="Button1_Click" />
          </div>
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
