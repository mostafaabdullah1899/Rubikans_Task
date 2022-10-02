$(function () {
    $(".print").click(function () {
        let left = ($(window).width() / 2) - (960 / 2);
        let top = ($(window).height() / 2) - (540 / 2);
        let invoiceId = $(this).attr('invoiceId');
            window.open(`/Print/SaleInvoice/${invoiceId}`, '_blank', `width=900, height=900, top= ${top}, left=${left}`);
        return false;
    });
});