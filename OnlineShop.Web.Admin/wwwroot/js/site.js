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
    }
    $("#Search").keyup(function () {
        var searchText = $("#Search").val().toLowerCase();
        $(".Search").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });
    });
});

//$("#txtsearch").on("keyup", function () {
//    var txtenter = $(this).val();
//    $("table tbody tr").each(function (results) {
//        if (results !== 0) {
//            var id = $(this).find("td:nth-child(2)").text();
//            if (id.indexOf(txtenter) !== 0 && id.toLowerCase().indexOf(txtenter.toLowerCase()) < 0) {
//                $(this).hide();
//            }
//            else {
//                $(this).show();
//            }
//        }
//    });
//});
