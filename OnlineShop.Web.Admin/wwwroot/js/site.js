$(function () {
    $(".callPartialRenderBody").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("url");
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#partialRenderBody').html(data);
            }
        });
    });
});