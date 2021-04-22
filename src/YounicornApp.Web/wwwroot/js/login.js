$(document).ready(function () {
    $("#p-Msg").hide();

    $('.login').on('click', 'a.sign-in', function (e) {
        var uname = $('#txtusername').val();
        var pwd = $('#txtpwd').val();
        window.localStorage.setItem("youusername", uname);
        $.ajax({
            type: "Post",
            url: "/User/ValidateCredentials",
            data: { userName: uname, password: pwd },
            success: function (data) {
                var d = data;
                if (d != null) {
                    if (d.id != null && d.id != 0) {
                        window.localStorage.setItem("userid", d.id);
                        window.location.href = "../Dashboard/Index";
                    }
                }
            },
            error: function () {
                $("#p-Msg").show();
                $("#p-Msg").text('Invalid username or password ! Please try again.');
                $("#p-Msg").focus();
            }
        })
    })
})
