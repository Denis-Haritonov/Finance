$(function() {
    $(".remove-payment").click(function() {
        $(".remove-link").val($(this).data("url"));
    });
    $(".code-button").click(function() {
        if ($(".code-input").val().trim() !== '' &&  $(".code-value").val() == $(".code-input").val()) {
            window.location = $(".remove-link").val();
        } else {
            $(".message").text("Неверный код подтверждения");
        }
    });

})
