$(function ShowOrHideAddress() {
    var hej = ('.UseShipToAddress');
    $('.UseShipToAddress').change(function () {
        var checked = $(this).is(':checked');

        $('.BillingAddress').toggle(checked);
    });
});

$(function() {
    $(".orderListTable tr:nth-child(odd)").addClass("grayBackground");
});