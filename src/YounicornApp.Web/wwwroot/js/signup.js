$(document).ready(function () {
    $("#p-Msg").hide();

    $('.sign-up').on('click', 'button.get-internet', function (e) {
        var fname = $('#txtFirstName').val();
        var lname = $('#txtLastName').val();
        var email = $('#txtEmail').val();
        var phone = $('#txtPhone').val();
        var offerId = $('#hidOfferId').val();
        $.ajax({
            type: "Post",
            url: "/Home/CreateSignUp",
            data: { firstName: fname, lastName: lname, email: email, phone: phone, offerId: offerId },
            success: function (data) {
                var d = data;
                if (d != null) {
                    $("#p-Msg").show();
                    $('#spanOfferName').text(d.offerName);
                    $('#spanIspName').text(d.providerName);
                   // setTimeout(function () { window.location.href = "../Index" }, 4000);
                }
            },
            error: function () {
                $("#p-Msg").show();
                $("#p-Msg").text('Invalid username or password ! Please try again.');
                $("#p-Msg").focus();
            }
        })
        return false;
    });
});
