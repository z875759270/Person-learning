<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-2.2.4.min.js"></script>
    <style>
        .main {
            width: 600px;
            height: 400px;
            background-color: indianred;
            top: 100px;
            left: 100px;
            padding: 20px 30px 20px 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <input class="hide" type="button" value="隐藏" />
        <div class="main">
            <p>skrrrrrrrrrrrrrrrrrrr</p>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".hide").click(function () {
                $(".main").hide("fast");
                $(this).attr({
                    "class":"show"
                });
                $(this).val("显示");
            })
        })
    </script>
</body>
</html>
