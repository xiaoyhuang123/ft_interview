<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsDetails.aspx.cs" Inherits="FTInterviewSites.msSystem.MsDetails" %>

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
</head>
<body>
     <div class="container">
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        <h3>招聘信息</h3>
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
        <hr />
      <h3>应聘者信息</h3>
      
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
           

       <div class="row">
         <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>应聘人数：</label>
                    <div class="controls">
                        <asp:Label ID="YpSum" Font-Size="Medium" runat="server" Text=""> </asp:Label>
                    </div>
            </div>

     </div>
      <h3>抽签结果</h3>
      <div style="text-align:right;height:40px;">
      <asp:Button ID="ResetButton" runat="server" class="button" Text="重置抽签结果" onclick="ResetButton_Click"/>  
      </div>
         <asp:GridView ID="MsOrderGridview" runat="server" AllowPaging="false"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                Width="100%" DataKeyNames="Id"  PageSize="15" ClientIDMode="Static"
                                CaptionAlign="Top" ShowHeaderWhenEmpty="True">
              <Columns>
                  <asp:TemplateField HeaderText="编号" Visible="false">
                      <ItemTemplate>
                         <%# (Container.DataItemIndex+1).ToString()%>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="姓名">
                      <ItemTemplate>
                          <asp:Label ID="TiName" runat="server" Text='<%# Bind("YpzName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="面试顺序">
                        <ItemTemplate>
                           <asp:Label ID="ZpGw" runat="server" Text='<%# Eval("Index_temp").ToString()=="32767"?" ":Eval("Index_temp").ToString()  %>'>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="" ShowHeader="False">
                        <ItemTemplate>
                         <a href='#' onclick="ShowIframe('SelectOrder.aspx?ypzid=<%# Eval("Id") %>',900,500,'面试抽签选择');">
                             <asp:Label ID="Label1" Font-Size="Smaller" Font-Underline="true" ForeColor="Red" runat="server" Text="抽签"></asp:Label>
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
                  Font-Size="Medium" Height="35px" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
      <!-- <div style=" height:300px; width:300px; background-color:Gray; text-align:center;  margin-left: 40%;">
         <br/>
         <br />
           <asp:Label ID="Result" runat="server" Width="100%" ForeColor="black" 
               Font-Size="200px"  Height="100%" Text="" style="margin-top: 110px;"></asp:Label>   
         </div>-->
             </ContentTemplate>
           </asp:UpdatePanel>
         <div style="height:50px;width:100%"> </div>

          <div style="text-align:center">
           <asp:Button ID="JumpButton" runat="server" class="button button-primary" 
                  Text="跳过"/> 
            <asp:Button ID="NextButton" runat="server" class="button button-primary" 
                  Text="下一步" onclick="NextButton_Click"/>  
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
