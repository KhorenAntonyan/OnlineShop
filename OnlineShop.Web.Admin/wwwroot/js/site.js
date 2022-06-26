$(function () {
    var partialModal = $('#Modal');
    $(".addModal").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        $.get(url).done(function (data) {
            partialModal.html(data);
            partialModal.find('.modal').modal('show');
        });
    });
});

$(function () {
    var partialModal = $('#Modal');
    $(".deleteModal").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        var hiddenId = $(this).data("id");
        $.get(url).done(function (data) {
            partialModal.html(data);
            partialModal.find('.modal').modal('show');
            $(".modal-body .hiddenId").val(hiddenId);
        });
    });
});

$(document).ready(function () {
    function Contains(text_one, text_two) {
        if (text_one.indexOf(text_two) != -1)
            return true;
    };
    $("#Search").keyup(function () {
        var searchText = $("#Search").val().toLowerCase();
        $(".tableTbody").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });
    });
});

$(function () {
    $(".dropdown-item").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        $.get(url, null, function (data) {
            $(".listPartial").html(data);
        });
    });
});
