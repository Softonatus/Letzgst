$.fn.clearValidation = function () { var v = $(this).validate(); $('[name]', this).each(function () { v.successList.push(this); v.showErrors(); }); v.resetForm(); v.reset(); };

$.validator.addMethod("regx", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Password must contain atleast 1 numeric and 1 alphanumeric charater.");

//$.validator.addMethod("notEqual", function (value, element) {
//    return $('#oldPwd').val() != $('#newpwd').val()
//}, "New password cannot be same as current password");

$(document).ready(function () {

    var $target = $('#sidebar-wrapper');
    $target.find("ul li a").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }

        $("#cPwd").addClass("active");
    });

    $("#submitbtn").click(function (e) {        
        e.preventDefault();
        if($("#pwdvalid").valid() === true)
        {
            var params = { "Password": $("#newpwd").val() };
            $.ajax({
                type: "POST",
                url: generateHandlerUrl.getUrl('../HandlerFiles/ResetPassword.ashx?type=change'),
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (PWDChangeResponse) {
                    $("#newpwd").val("");
                    $("#newcpwd").val("");
                    var OTPrespCode = parseInt(PWDChangeResponse.ResponseCode);
                    if (OTPrespCode == 1) {
                        AlertSuc.alertsuccess("success", PWDChangeResponse.ResponseMessage);
                    }
                },
                error: function (OTPresponse, success, error) {
                    AlertSuc.alertsuccess("error", error);
                }
            });
        }
    });

    $("#pwdvalid").validate({
        rules: {
            newpwd: {
                required: true,
                //notEqual: true,
                minlength: 5,
                regx: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$/
            },
            newcpwd: {
                required: true,
                minlength: 5,
                equalTo: "#newpwd"
            }
        },
        messages: {
            newpwd: {
                required: "Please provide a password",
                // notEqual: "New password cannot be same as current password",
                minlength: "Your password must be at least 5 characters long",
                regx: "Please enter a strong password"
            },
            newcpwd: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long",
                equalTo: "Please enter the same password as new password"
            }
        }
    });


});