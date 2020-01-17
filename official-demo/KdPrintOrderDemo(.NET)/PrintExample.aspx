<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintExample.aspx.cs" Inherits="KdniaoWebsite.WebUI.External.PrintExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            form1.submit();
        };
    </script>
</head>
<body>
    <form id="form1" action="http://www.kdniao.com/External/PrintOrder.aspx" method="post" target="_self">
    <div style="width:600px;margin:0 auto">
       <div ><input  type="text" runat="server" id="RequestData" name="RequestData"/></div><br /><br />
        <div ><input type="text" runat="server" id="EBusinessID" name="EBusinessID"/></div><br /><br />
        <div ><input  type="text" runat="server" id="DataSign" name="DataSign"/></div><br /><br />
        <div ><input  type="text" runat="server" id="IsPreview" name="IsPreview"/></div><br /><br />
    
    </div>
    </form>
</body>
    
</html>
