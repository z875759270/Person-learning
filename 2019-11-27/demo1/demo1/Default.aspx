<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAjax" runat="server" Text="Button" />
            <asp:Label ID="lblShow" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
    <script src="js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript">
        $("#btnAjax").click(function () {
            $.ajax({
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Default.aspx/GetData",
                data: "{'str1':'辣','str2':'是真滴牛嗷'}",
                success: function (data) {
                    $("#lblShow").append(data.d);
                },
                error: function () {
                    alert("不牛批了")
                }
            });
            return false;
        });
    </script>
</body>
</html>
