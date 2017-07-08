$(document).ready(function () {
    //highliht the menu
    var $target = $('#sidebar-wrapper');
    $target.find("ul li a").each(function () {
        if($(this).hasClass("active"))
        {
            $("this").removeClass("active");
            $("#profile").addClass(".active");
        }
    });
    
    $('.fp').click(function () {
        $('.login-translate-container').css("transform", "translateX(-240px)");
    });

    $('.bl').click(function () {
        $('.login-translate-container').css("transform", "translateX(0px)");
    });
    $('.sign').click(function () {
        $('.login-translate-container').css("transform", "translateX(-480px)");
    });
    
    /*-----profile settings page------*/
    $("#profileform").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {
            selectprofile: {
                required: true
            },

            profileemail: {
                required: true,
                email: true
            },
            contactno: {
                required: true
            },
            pin: {
                required: true
            },
            panno: {
                required: true
            },
            gstnno: {
                required: true
            },
            camembership: {
                required: true
            }
        },
        selectprofile: {
            required: "Please select type"
        },
        profileemail: {

            email: "Please enter a valid email address"
        },
        contactno: {
            required: "Please enter contact number"
        },
        pin: {
            required: "Please enter Pincode number"
        },
        panno: {
            required: "Please enter PAN number"
        },
        gstnno: {
            required: "Please enter GSTN number"
        },
        camembership: {
            required: "Please enter CA Membership number"
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, button");
            var serializedData = $form.serializeArray();
            console.log(serializedData);
            var reqProfile = new Object();
            reqProfile.Name = $("#companyname").val();
            reqProfile.Password = $("#signuppwd").val();
            reqProfile.ContactNo = $("#signupmob").val();
            //$.ajax({
            //    type: "POST",
            //    url: '../HandlerFiles/Registration.ashx',
            //    data: JSON.stringify(reqProfile),
            //    contentType: "application/json; charset=utf-8",
            //    dataType: 'json',
            //    success: function (data) {
            //        var respCode = parseInt(data.ResponseCode);
            //        UserId = data.UserId;
            //        if (respCode == 1) {
            //            alert(data.ResponseMessage);
            //        }
            //        else {
            //            alert(data.ResponseMessage);
            //        }
            //    },
            //    error: function (data, success, error) {
            //        alert("Eror " + error);
            //    }
            //});
        }

    });


});


$('input').each(function () {
    if ($(this).val() != '') {
        console.log('all inputs filled');
    } else {
        console.log('theres an empty input');
        return false
    }
});
//------------------dashboard-----------------


$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

$('ul.nav li.dropdown').hover(function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
}, function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
});


$('#selectprofile').change(function () {
    $('.hideme').hide();
    $('.hidemember').hide();
    if ($(this).val() == 'ca') {
        $('.hidemember').show();
    } else if ($(this).val() == 'consultant') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == 'individual') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == 'comp') {
        $('.hideme, .hidemember').hide();
    } else {
        $('.hideme').show();
    }
});
