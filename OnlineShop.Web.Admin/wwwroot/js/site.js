$(function () {
    $(".callPartialRenderBody").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
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

$(function () {
    var partialRenderBody = $('#partialRenderBody');
    $('button[data-toggle="modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            partialRenderBody.html(data);
            partialRenderBody.find('.modal').modal('show');
        })
    })
});