<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--获取元素宽高-->
        <div class="section">
            <input type="button" id="getwh" value="获取窗口宽高" />

            <div id="divwh" class="getwh">
                <label id="width">当前div宽度为：</label>
                <br />
                <label id="height">当前div高度为：</label>
            </div>
        </div>

        <!--祖先-->
        <div class="section">
            <div class="getparent-lg">
                <div class="getparent-nm">
                    <div class="getparent-sm">
                        <input type="button" value="儿子" id="son" class="getparent-btn" />
                    </div>
                    <input type="button" value="爸爸" id="father" class="getparent-btn" />
                </div>
                <input type="button" class="getparent-btn" value="爷爷" id="grandfather" />
            </div>
        </div>

        <!--Ajax-->
        <div class="section">
            <input type="button" value="ajax load" id="loadData"/>
            <p></p>
        </div>
    </form>
    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
