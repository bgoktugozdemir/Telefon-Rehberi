function Modal(url, baslik, genislik) {
    $("#myModal").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
    });
    $('#myModal').modal({
        backdrop: 'static',
        keyboard: false
    });
    $('#myModalTitle').html(baslik);

    $('.modal-dialog').css('width', genislik + '%');
    $('#myModalBody').html("<img src=\"/areas/yonetim/assets/img/page-loader1.gif\"  />");


    $('#myModalBody').load(url);
    $('#myModal').modal('show');
}

$(document).ready(function ($) {
    $(".clickable").click(function () {
        console.alert(this);
        window.document.location = $(this).data("href");
    });
});
