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
