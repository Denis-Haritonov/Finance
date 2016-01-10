$('#currency-btn').click(function () {
    var res = parseInt($('#currency-1').val()) * parseInt($('#currency-1-name').val()) / parseInt($('#currency-2-name').val());
    $('#currency-2').val(res);
});