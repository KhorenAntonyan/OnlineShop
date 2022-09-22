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

$('#Modal').on('click', '[data-save="modal"]', function (event) {
    event.preventDefault();

    var form = $(this).parents('.modal').find('form');

    var actionUrl = form.attr('action');
    var formData = new FormData();

    formData.append("ProductName", $('#ProductName').val());
    formData.append("CategoryId", $('#CategoryId').val());
    formData.append("Price", $('#Price').val());
    formData.append("Quantity", $('#Quantity').val());
    formData.append("Description", $('#Description').val());
    formData.append("MainPhoto", $('#MainPhoto')[0].files[0]);
    for (var x = 0; x < document.getElementById('PhotoFiles').files.length; x++) {
        formData.append("PhotoFiles", document.getElementById('PhotoFiles').files[x]);
    }

    $.ajax({
        type: 'post',
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false
    }).done(function (data) {
        var newBody = $('.modal-body', data);
        $('#Modal').find('.modal-body').replaceWith(newBody);

        var isValid = newBody.find('[name="IsValid"]').val();
        if (isValid) {
            $('#Modal').find('.modal').modal('hide');
            $("#loading").show();
            $.get('/Product/ProductFilter', null, function (data) {
                $("#ListPartial").html(data);
                $("#loading").hide();
            });
        }
    });
});

$(function () {
    var partialModal = $('#Modal');
    $(document).on("click", ".deleteModal", function (e) {
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
        $("#loading").show();
        $.get(url, null, function (data) {
            $("#ListPartial").html(data);
            $("#loading").hide();
        });
    });
});

$(function () {
    $('#FilterBTN').on("click",function (e) {
        e.preventDefault();

        var formData = new FormData();

        formData.append("PriceRange", $('#PriceRange').val());
        formData.append("CategoryId", $('#CategoryId').val());
        formData.append("DateTimeFrom", $('#DateTimeFrom').val());
        formData.append("DateTimeTo", $('#DateTimeTo').val());

        //$.ajax({
        //    type: 'post',
        //    url: '/Product/ProductFilter',
        //    data: formData,
        //    processData: false,
        //    contentType: false,
        //    success: function (result) {
        //        $("#ListPartial").html(result);
        //    }
        //});
        //e.preventDefault();

        //return false;
        //var filterForm = $('#FilterForm').serialize();

        $.post('/Product/ProductFilter', $("#FilterForm").serialize, function (data) {
            $(".listPartial").html(data);
        });
    });
});