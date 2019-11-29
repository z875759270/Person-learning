$(document).ready(function () {
    var color = ["gold", "green", "red", "grey", "dark", "pink", "blue"];

    alert(navigator.appName);

    $("#getwh").click(function () {
        $("#width").append($("#divwh").width());
        $("#height").append($("#divwh").height());
    });

    $(".getparent-btn").click(function () {
        $(this).parent().css({
            "background-color": color[randomFrom(0, 6)]
        });
    });
    
    $("#loadData").click(function () {
        $(this).next().load("../TextFile.txt", function (res, status, xhr) {
            if (status == "success")
                alert("加载成功！");
            if (status == "error")
                alert("Error:" + xhr.status + ":" + xhr.status);
        });
    });

    //范围内生成随机数
    function randomFrom(lowerValue, upperValue) {
        return Math.floor(Math.random() * (upperValue - lowerValue + 1) + lowerValue);
    }
})