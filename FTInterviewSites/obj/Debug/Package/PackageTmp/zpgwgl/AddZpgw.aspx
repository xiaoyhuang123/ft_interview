<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddZpgw.aspx.cs" Inherits="FTInterviewSites.zpgwgl.AddZpgw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>丰台机务段公开招聘面试管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/page-min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script> 
</head>
<body>
     <div class="container">
        <form id="J_Form" class="form-horizontal" action="AddZpgw.aspx" runat="Server">
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
             <div class="controls">
                <label class="control-label">
                    <s>*</s>招聘岗位：</label>
                    <input id="ZpgwName"   name="ZpgwName"  type="text" data-rules="{required:true}" class=" control-text" onchange="SetRestParameterstd()"  runat="Server"/>
            </div>
        </div>
       <div class="row">
         <!--   <div class="control-group12 span12">
                <label class="control-label">
                    <s>*</s>面试日期：</label>
                <div class="controls">
                    <input id="PubTime" runat="Server"  onchange="SetRestParameter()" data-rules="{required:true}" name="join_time" style="width:140px;" class="Wdate" type="text" onfocus="WdatePicker({skin:'whyGreen'})"/>
                </div>
            </div>-->
        <div class="control-group span12">
                <label class="control-label">
                    <s>*</s>招聘人数：</label>
                     <div class="controls">
                    <input id="ZpSum"  name="ZpSum"  type="text" class=" control-text" data-rules="{required:true}"  runat="Server"/>
            </div>
            </div>
        </div>
        
        <hr />
        <div style=" width:100%; text-align:center;">
            
                <asp:Button ID="SaveButton"  class="button button-primary" runat="Server" Text="保存" 
                    onclick="Add_btnClick">
                    </asp:Button>
               <asp:Button ID="BackButton"  class="button button-primary" runat="Server" 
                    Text="返回" onclick="BackButton_Click" >
                    </asp:Button>
                    <!-- <asp:HyperLink ID="HyperLink1"   class="button button-primary" NavigateUrl="SearchZpgw.aspx"  runat="server">返回</asp:HyperLink>-->
                 
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
