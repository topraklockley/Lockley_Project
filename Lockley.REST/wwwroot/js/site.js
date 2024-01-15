function GetData() {
    $.ajax({
        type: "GET",
        url: "http://localhost:5218/api/home",
        success: function (data) {
            $(".apiData").empty();
            $(".apiData").append("<ul class='list-group'>");
            $.each(data, function (i, v) {
                $(".apiData ul").append("<li class='list-group-item'>" + v.name + "</li>")
            });
            $(".apiData").append("</ul>");
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}