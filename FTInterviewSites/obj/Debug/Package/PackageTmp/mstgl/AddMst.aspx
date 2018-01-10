<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="AddMst.aspx.cs" Inherits="FTInterviewSites.mstgl.AddMst" %>
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
                    alert("请先选择考题！");
                    return false;
                }
                else {
                    if (confirm("该操作会删除该考题及其相关信息，您确认要删除吗？")) {
                        document.getElementById("hdfWPBH").value = AuditVal;
                        return true;
                    }
                    else
                        return false;
                }
            }
            function GetsingleQue() {
                var ddl = document.getElementById("Sumti")
                var index = ddl.selectedIndex;

                var Value = ddl.options[index].value;
                var Text = ddl.options[index].text;
                if (Text != "请选择") {
                    var url = "SingleQuestion.aspx";
                    ShowIframe(url, 1100, 450, "添加考题");
                }
                else{alert("请选择实试题！");}
                return false;
            }
        </script>
</head>
<body>
       <div class="container">
          <form id="J_Form" class="form-horizontal" runat="Server">
          
          <h3>基本信息</h3>
           <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        套题选择：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "Sumti" name="Sumti" runat="Server" 
                        DataTextField="Name" DataValueField="Id" Width="150px"  >
                         </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group span12">
                    <label class="control-label">
                        创建时间：</label>
                    <div class="controls">
                         <input id="TTime"  name="TTime" runat="Server" style="width:140px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"/>
                    </div>
                </div>    
            </div>
            <div class="row">
             <div class="control-group span12">
                    <label class="control-label">
                        招聘部门：</label>
                    <div class="controls">
                        <asp:DropDownList ID = "department" name="department" runat="Server" 
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
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div> 
                  <asp:Button ID="Confirm_Button" runat="Server" CssClass="button button-primary" Text="确定"  
                onclick="Confirm_Button_Click" />  
            </div>
            
            
            <h3>试题列表</h3>
             <div class="row"  align="right">
            <asp:HiddenField ID="hdfWPBH" runat="server" />
             <asp:Button ID="AddQue"  ToolTip="点此添加" class="button" 
                        runat="Server" Text="添加"  
                        OnClientClick="return GetsingleQue();">
             </asp:Button>
             <asp:Button ID="DeleteStuff" runat="Server" CssClass="button" Text="删除"  
                ToolTip="点此完成删除" OnClientClick="return batchAudit(this)"
                onclick="Deletesgiti_Click" />  
          <br/>
        </div>
         <hr width="100%" size="1" color="#5151A2" align="center"> 
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>       
          <asp:GridView ID="MsttGridview" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowHeaderWhenEmpty="True"
                Width="100%" DataKeyNames="Id" ClientIDMode="Static" 
                 onrowediting="MsttGridview_RowEditing" 
                 onrowcancelingedit="MsttGridview_RowCancelingEdit" 
                 onrowupdating="MsttGridview_RowUpdating">
              <Columns>
               <asp:TemplateField  HeaderText="选择" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                      <HeaderTemplate>
                                <input type="checkbox" name="BoxIdAll" id="BoxIdAll" ToolTip="全选" onclick="onclicksel()" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <input id="BoxId" name="BoxId" value='<%#(Convert.ToString(Eval("Id")))%>' type="checkbox" onclick="onclicksingle(this)"/>
                    </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="编号" HeaderStyle-Width="5%">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>

                <HeaderStyle Width="5%"></HeaderStyle>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="题干">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("Question") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="时限" ItemStyle-Width="8%" ItemStyle-Height="30px">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextTime" Height="100%" Width="50px" Text='<%# Bind("StTime") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelTime" Height="100%" Width="50px" Text='<%# Bind("StTime") %>' runat="server"></asp:Label>
                    </ItemTemplate>

                <ItemStyle Height="30px" Width="8%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="权重%" ItemStyle-Width="8%" ItemStyle-Height="30px">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" Height="100%" Width="50px" Text='<%# Bind("Weight") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Height="100%" Width="50px" Text='<%# Bind("Weight") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="30px" Width="8%"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="False"  ItemStyle-Width="120px">
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

<ItemStyle Width="120px"></ItemStyle>
                </asp:TemplateField>


                   <asp:TemplateField HeaderText="" HeaderStyle-Width="10%" ShowHeader="False">
                      <ItemTemplate>
                          <a href='#' onclick="ShowIframe('SingleQuestion.aspx?stid=<%# Eval("Id") %>',1100,450,'试题信息详情'); return false">
                              <asp:Label ID="Label2" runat="server" Font-Size="Smaller" ForeColor="Gray" Font-Underline="true"  Text="详细"></asp:Label>
                          </a>
                      </ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
                   </asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                  Font-Size="Medium" Height="33px" />
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
                    PageSize="10"
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
