<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="FTRailway.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ޱ����ĵ�</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE1 {font-size: 12px}
.STYLE3 {font-size: 12px; font-weight: bold; }
.STYLE4 {
	color: #03515d;
	font-size: 12px;
}
-->
</style>
    <script>
        var highlightcolor = '#c1ebff';
        //�˴�clickcolorֻ����winϵͳ��ɫ������ܳɹ�,�����#xxxxxx�Ĵ���Ͳ���,��û�����Ϊʲô:(
        var clickcolor = '#51b2f6';
        function changeto()
        {
            source = event.srcElement;
            if ( source.tagName == "TR" || source.tagName == "TABLE" )
                return;
            while ( source.tagName != "TD" )
                source = source.parentElement;
            source = source.parentElement;
            cs = source.children;
            //alert(cs.length);
            if ( cs[1].style.backgroundColor != highlightcolor && source.id != "nc" && cs[1].style.backgroundColor != clickcolor )
                for ( i = 0; i < cs.length; i++ )
                {
                    cs[i].style.backgroundColor = highlightcolor;
                }
        }

        function changeback()
        {
            if ( event.fromElement.contains( event.toElement ) || source.contains( event.toElement ) || source.id == "nc" )
                return
            if ( event.toElement != source && cs[1].style.backgroundColor != clickcolor )
            //source.style.backgroundColor=originalcolor
                for ( i = 0; i < cs.length; i++ )
                {
                    cs[i].style.backgroundColor = "";
                }
        }

        function clickto()
        {
            source = event.srcElement;
            if ( source.tagName == "TR" || source.tagName == "TABLE" )
                return;
            while ( source.tagName != "TD" )
                source = source.parentElement;
            source = source.parentElement;
            cs = source.children;
            //alert(cs.length);
            if ( cs[1].style.backgroundColor != clickcolor && source.id != "nc" )
                for ( i = 0; i < cs.length; i++ )
                {
                    cs[i].style.backgroundColor = clickcolor;
                }
            else
                for ( i = 0; i < cs.length; i++ )
                {
                    cs[i].style.backgroundColor = "";
                }
        }
    </script>
</head>
<body>
   aa
</body>
</html>
