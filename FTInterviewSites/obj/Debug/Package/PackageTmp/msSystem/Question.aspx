<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="FTInterviewSites.msSystem.Question" %>

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
        var t ;//= document.getElementById("<%=HiddenField1.ClientID%>").value;
        var id; //= setInterval(getRTime, 1000);
        var init = 0;
        function getRTime() {
       
            var h = Math.floor(t / 60 / 60);
            var m = Math.floor(t / 60 % 60);
            var s = Math.floor(t % 60);
            if (m < 1) {
                document.getElementById("t_h").style.color = "Red";
                document.getElementById("t_m").style.color = "Red";
                document.getElementById("t_s").style.color = "Red";
            }

            document.getElementById("t_h").innerHTML = h + "时";
            document.getElementById("t_m").innerHTML = m + "分";
            document.getElementById("t_s").innerHTML = s + "秒";
            t--;
            if (t < 0) {
                clearInterval(id);
            }
        }
        function StartTime() {
            if (init == 0) {
                t = document.getElementById("<%=HiddenField1.ClientID%>").value;
                t = Number(t) * 60-1;
                init = 1;
            }
            id = setInterval(getRTime, 1000);
    }
    function PauseTime() {
        clearInterval(id);
    }
    function RestTime() {
        clearInterval(id);
        t = document.getElementById("<%=HiddenField1.ClientID%>").value;
        t = Number(t) * 60;
        document.getElementById("t_h").style.color = "Black";
        document.getElementById("t_m").style.color = "Black";
        document.getElementById("t_s").style.color = "Black";
        getRTime();
        init = 0;
    }
    function StopAndRest() {
        clearInterval(id);
        t = document.getElementById("<%=HiddenField1.ClientID%>").value;
        t = Number(t) * 60;
        document.getElementById("t_h").style.color = "Black";
        document.getElementById("t_m").style.color = "Black";
        document.getElementById("t_s").style.color = "Black";
        getRTime();
        init = 0;
    }

    </script>
</head>
<body>
<div id="CountMsg" class="HotDate" style=" width:100%; text-align:center; margin-top:30px;"> 
<span id="t_h" style="font-size:xx-large">0时</span> 
<span id="t_m" style="font-size:xx-large">0分</span> 
<span id="t_s" style="font-size:xx-large">0秒</span> 
</div> 
    <div class="container">
        <form id="J_Form" class="form-horizontal" action="" runat="Server">
        
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
             <asp:HiddenField ID="HiddenField1" runat="server" />
         <hr/>
        <div style=" width:90%; height:300px; ">
        
            <asp:Label ID="QuestionID" Font-Size="X-Large" Font-Bold="true" runat="server" Text=""></asp:Label>、
         <asp:Label ID="QuestionName" Font-Size="X-Large" runat="server"   style="line-height:150%;" Text=""></asp:Label>

        </div>
               <br/><br/>
         <div style=" text-align:right">
         <asp:Label ID="TimeLabel"  Font-Size="Large" Visible="false" runat="server" Text="00:00:00"></asp:Label>
         <asp:Label ID="Label3" Font-Size="Large" runat="server" Text=" 当前第"></asp:Label>
         <asp:Label ID="CurrentID" Font-Size="Large" runat="server" Text="1"></asp:Label>
         <asp:Label ID="Label4" Font-Size="Large" runat="server" Text="题"></asp:Label>

         <asp:Label ID="Label5" Font-Size="Large" runat="server" Text="共"></asp:Label>
         <asp:Label ID="Totals" Font-Size="Large" runat="server" Text="10"></asp:Label>
         <asp:Label ID="Label7" Font-Size="Large" runat="server" Text="题"></asp:Label>
         </div>

         
       <hr/>
        <div style=" text-align:center">
            <asp:Button ID="Button1" runat="server" Text="开始答题" OnClientClick="StartTime()" class="button button-primary" />
            <asp:Button ID="Button2" runat="server" Text="暂 停" OnClientClick="PauseTime()" class="button button-primary" />
            <asp:Button ID="Button3" runat="server" Text="重 置" OnClientClick="RestTime()" class="button button-primary" />
        </div>
        <hr />
        <div style=" text-align:center">
         <asp:Button ID="PreButton" runat="server" Text="上一题" class="button button-primary"
          OnClientClick="StopAndRest()"   onclick="PreButton_Click" />
            <asp:Button ID="NextButton" runat="server" Text="下一题" class="button button-primary"
             OnClientClick="StopAndRest()"     onclick="NextButton_Click" />
            <asp:Button ID="QuitButton" runat="server" Text="退 出" class="button button-primary"
                onclick="QuitButton_Click" />
        </div>
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
