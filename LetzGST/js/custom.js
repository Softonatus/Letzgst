var OTPId = "";
var UserId = "";
$(document).ready(function () {
    $('.fp').click(function () {
        $('.login-translate-container').css("transform", "translateX(-240px)");
    });

    $('.bl').click(function () {
        $('.login-translate-container').css("transform", "translateX(0px)");
    });
    $('.sign').click(function () {
        $('.login-translate-container').css("transform", "translateX(-480px)");
    });
    //-----------login form-------------
    $("#loginform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            loginemail: {
                required: true,
                email: true
            },
            loginpwd: {
                required: true
            }
        },
        loginemail: {

            email: "Please enter a valid email address"
        },
        loginpwd: {
            required: "Please enter your password"
        },
        submitHandler: function (form) {
            var email = $("#loginemail").val();
            var password = $("#loginpwd").val();

            var loginParams = { "EmailId": email, "Password": password };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/Login.ashx',
                data: JSON.stringify(loginParams),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (loginResponse) {
                    var responseCode = parseInt(loginResponse.ResponseCode);
                    var url = window.location.href;
                    var arr = url.split("/");
                    if (responseCode == 0) { 
                        window.location.href = arr[0] + "//" + arr[2] + "/" + "Dashboard/Dashboard.aspx";
                    }
                    if (responseCode == 1) {
                        window.location.href = arr[0] + "//" + arr[2] + "/" + "Dashboard/Profile.aspx";
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
        }

    });
    //----------------forgot otp form----------
    $("#forgototp").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            forgototp: {
                required: true,
                minlength: 6,
                number: true
            }
        },
        forgototp: {

            minlength: "Please enter 6 digit otp",
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            var params = { "otpId": OTPId, "otpNo": $("#txtforgototp").val(), "UserId": UserId };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/OTPValidation.ashx',
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (OTPresponse) {
                    var OTPrespCode = parseInt(OTPresponse.ResponseCode);
                    if (OTPrespCode == 0) {
                        alert(OTPresponse.ResponseMessage);
                        $inputs.prop("disabled", true);
                        $('.login-translate-container').css("transform", "translateX(-1200px)");
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
        }
    });
    //-------------confirm otp form-----------------
    $("#confirmotpform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            confirmotp: {
                required: true,
                minlength: 6,
                number: true
            }
        },
        confirmotp: {

            minlength: "Please enter 6 digit otp",
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            //console.log(serializedData);
            var params = { "otpId": OTPId, "otpNo": $("#confirmotp").val(), "UserId": UserId };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/OTPValidation.ashx',
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (OTPresponse) {
                    var OTPrespCode = parseInt(OTPresponse.ResponseCode);
                    if (OTPrespCode == 0) {
                        alert(OTPresponse.ResponseMessage);
                        $inputs.prop("disabled", true);
                        $('.login-translate-container').css("transform", "translateX(0)");
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
        }
    });
    //-----------------------------reset password form--------------

    $("#forgotform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            forgotmob: {
                required: true,
                minlength: 10,
                number: true
            }
        },
        forgotmob: {

            mobile: "Please enter mobile number",
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            var params = { "mobileNo": $("#forgotmob").val() };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/GenerateOTP.ashx',
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (OTPresponse) {
                    var OTPrespCode = parseInt(OTPresponse.ResponseCode);
                    if (OTPrespCode == 0) {
                        OTPId = OTPresponse.OtpId;
                        UserId = OTPresponse.UserId;
                        $inputs.prop("disabled", true);
                        $('.login-translate-container').css("transform", "translateX(-960px)");
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
        }
    });

    $("#confirmotpform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            confirmotp: {
                required: true,
                minlength: 6,
                number: true
            }
        },
        confirmotp: {

            minlength: "Please enter 6 digit otp",
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            //console.log(serializedData);
            var params = { "otpId": OTPId, "otpNo": $("#confirmotp").val(), "UserId": UserId };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/OTPValidation.ashx',
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (OTPresponse) {
                    var OTPrespCode = parseInt(OTPresponse.ResponseCode);
                    if (OTPrespCode == 0) {
                        alert(OTPresponse.ResponseMessage);
                        $inputs.prop("disabled", true);
                        $('.login-translate-container').css("transform", "translateX(0)");
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
        }
    });

    //------------------------new password form-------
    $("#newpwdform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {

            newpwd: {
                required: true,
                minlength: 5
            },
            newcpwd: {
                required: true,
                minlength: 5,
                equalTo: "#newpwd"
            }
        },
        newpwd: {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long"
        },
        newcpwd: {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long",
            equalTo: "Please enter the same password as above"
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            var params = { "Password": $("#newpwd").val(), "UserId": UserId };
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/ResetPassword.ashx',
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (PWDChangeResponse) {
                    var OTPrespCode = parseInt(PWDChangeResponse.ResponseCode);
                    if (OTPrespCode == 1) {
                        alert(PWDChangeResponse.ResponseMessage);
                        $inputs.prop("disabled", true);
                        $('.login-translate-container').css("transform", "translateX(0)");
                    }
                },
                error: function (OTPresponse, success, error) {
                    alert("Eror " + error);
                }
            });
            
        }
    });
    //-----signup form-----------------------

    $("#signupform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {
            signupmob: {
                required: true,
                minlength: 10,
                number: true
            },
            signuppwd: {
                required: true,
                minlength: 5
            },
            signupcpwd: {
                required: true,
                minlength: 5,
                equalTo: "#signuppwd"
            },
            signupemail: {
                required: true,
                email: true
            }
        },
        signupmob: {
            mobile: "Please enter mobile number",

            email: "Please enter a valid email address"
        },
        password: {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long"
        },
        signupcpwd: {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long",
            equalTo: "Please enter the same password as above"
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serialize();
            //console.log(serializedData);
            var ReqRegistration = new Object();
            ReqRegistration.EmailId = $("#signupemail").val();
            ReqRegistration.Password = $("#signuppwd").val();
            ReqRegistration.ContactNo = $("#signupmob").val();
            $.ajax({
                type: "POST",
                url: '../HandlerFiles/Registration.ashx',
                data: JSON.stringify(ReqRegistration),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success : function (data)
                {
                    var respCode = parseInt(data.ResponseCode);
                    UserId = data.UserId;
                    if (respCode == 1)
                    {
                        var params = { "mobileNo": $("#signupmob").val() };
                        $.ajax({
                            type: "POST",
                            url: '../HandlerFiles/GenerateOTP.ashx',
                            data: JSON.stringify(params),
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success : function (OTPresponse)
                            {
                                var OTPrespCode = parseInt(OTPresponse.ResponseCode);
                                if (OTPrespCode == 0)
                                {
                                    OTPId =  OTPresponse.OtpId;
                                    $inputs.prop("disabled", true);
                                    $('.login-translate-container').css("transform", "translateX(-720px)");
                                }
                            },
                            error: function (OTPresponse, success, error) {
                                alert("Eror " + error);
                            }
                        });
                    }
                    else
                    {
                        alert(data.ResponseMessage);
                    }
                },
                error: function (data, success, error) {
                    alert("Eror " + error);
                }
            });
        }
    });





});




/*
$("#signupbtn").keypress(function() {
    if($(this).val().length > 1) {
        
    } 
     $('.login-translate-container').css("transform", "translateX(-720px)");
});


*/
$('input').each(function () {
    if ($(this).val() !== '') {
        console.log('all inputs filled');
    } else {
        console.log('theres an empty input');
        return false
    }
});
