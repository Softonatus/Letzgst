var actionType = "I";
var fileDetails = "";
var _handlerUrl = "";

$(function () {

    $('.chosen-select-deselect').chosen({
        width: "100%",
        allow_single_deselect: true,
        include_group_label_in_selected: true
    });

});

$.validator.addMethod("regx", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Password must contain atleast 1 numeric and 1 alphanumeric charater.");

$.validator.addMethod("Adhar", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid Adhar Number.");

$.validator.addMethod("_gstno", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid GST Number.");

$(document).ready(function () {
    //highliht the menu
    var $target = $('#sidebar-wrapper');
    $target.find("ul li a").each(function () {
        if($(this).hasClass("active"))
        {
            $(this).removeClass("active");
        }

        $("#profile").addClass("active");
    });
    
    var CType = getUrlVars()["usertype"];
    if (CType != null && CType !== "" && CType != undefined) {
        $("#selectprofile").val(4);
       // $("#selectprofile").trigger("change");
        $("#selectprofile").prop("disabled", true);
    }

    if (($("#hdn_FirstTime").val()) == "1")
    {
        actionType = "U";
        _handlerUrl = generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/Profile.ashx');
        var reqUserId = { "UserId": 0 }
        $.ajax({
            type: "POST",
            url: _handlerUrl,
            data: JSON.stringify(reqUserId),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                //var respCode = parseInt(data.ResponseCode);
                $("#companyname").val(data.Name);
                $("#profileemail").val(data.EmailId);
                $("#contactno").val(data.ContactNo);
                $("#adhaar").val(data.AadharNo);
                $("#fileUrl").val(data.LogoUrl);
                //"LogoUrl": null,
                $("#address1").val(data.AddressLine1);
                $("#address2").val(data.AddressLine2);
                $("#address3").val();
                $("#state").val(data.State);
                $("#city").val(data.City);
                $("#pin").val(data.PinCode);
                $("#panno").val(data.PanNo);
                $("#cin").val(data.CinNo);
                $("#servicetax").val(data.ServiceTaxNo);
                $("#vattin").val(data.Vat_TinNo);
                $("#gstnno").val(data.GstinNo);
                $("#tan").val(data.TanNo);
                $("#website").val(data.WebsiteUrl);
                $("#camembership").val(data.MembershipId);
                $("#selectprofile").val(data.UserType);
                $("#country").val(data.Country);
                $("#selectprofile").trigger("change");
                $("#selectprofile").prop("disabled", true);
                $("#btnUpdate").focus();

                $(".chosen-select-deselect").trigger("chosen:updated");

            },
            error: function (data, success, error) {
                alert("Eror " + error);
            }
        });
    }
    
    /*-----profile settings page------*/
    $("#profileform").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: ":hidden",
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
                required: true,
                regx: /^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$/
            },
            gstnno: {
                required: true,
                _gstno: /^[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Z]{1}Z[0-9a-zA-Z]{1}$/
            },
            camembership: {
                required: "#camembership:visible"
            },
            adhaar: {
                required: true,
                Adhar : /^[0-9]{12}$/
            },
            ////tan: {
            ////    regex: /^[0-9]{12}$/
            ////},
            //servicetax: {
            //    regex: /^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[a-zA-Z]{2}[0-9]{3}$/
            //},
            //cin: {
            //    regex: /^[luLU]{1}[0-9]{5}[a-zA-Z]{2}[0-9]{4}[a-zA-Z]{3}[0-9]{6}$/
            //},
            //vattin: {
            //    regex: /^[0-9]{11}$/
            //}
        },
        messages: {
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
                required: "Please enter PAN number",
                regx: "Please provide a valid Pan number"
            },
            gstnno: {
                required: "Please enter GSTN number",
                _gstno: "Please provide a valid GSTN number"
            },
            camembership: {
                required: "Please enter CA Membership number"
            },
            adhaar: {
                required: "Please enter Adhaar number",
                Adhar : "Please provide valid Adhaar Number"
            },

            //servicetax: {
            //    regex: "Please provide valid Service Tax"
            //},
            //cin: {
            //    regex: "Please provide valid CIN"
            //},
            //vattin: {
            //    regex: "Please provide valid TIN"
            //}
        },
        submitHandler: function (form) {
            var $form = $(form);
            var $inputs = $form.find("input, select, button");
            _handlerUrl = generateHandlerUrl.getUrl( '../HandlerFiles/Dashboard/Profile.ashx?action='+actionType);
            //var serializedData = $form.serializeArray();
            //console.log(serializedData);
            var UserType = $("#selectprofile option:selected").val();
            var Qtype = getUrlVars()["usertype"];
            if (Qtype != null && Qtype !== "" && Qtype != undefined) {
                UserType = 4;
            }
            var reqProfile = new Object();
            reqProfile = {
                "Name": $("#companyname").val(),
                "AadharNo": $("#adhaar").val(),
                "EmailId": $("#profileemail").val(),
                "ContactNo": $("#contactno").val(),
                "LogoUrl": $("#fileUrl").val(),
                "AddressLine1": $("#address1").val(),
                "AddressLine2": $("#address2").val(),
                "AddressLine3": $("#address3").val(),
                "State": $("#state option:selected").val(),
                "City": $("#city").val(),
                "PinCode": $("#pin").val(),
                "PanNo": $("#panno").val(),
                "CinNo": $("#cin").val(),
                "ServiceTaxNo": $("#servicetax").val(),
                "Vat_TinNo": $("#vattin").val(),
                "GstinNo": $("#gstnno").val(),
                "TanNo": $("#tan").val(),
                "WebsiteUrl": $("#website").val(),
                "MembershipId": $("#camembership").val(),
                "Country": $("#country").val(),
                "UserType": $("#selectprofile option:selected").val()
            }
            $.ajax({
                type: "POST",
                url: _handlerUrl,
                data: JSON.stringify(reqProfile),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var respCode = parseInt(data.ResponseCode);
                    UserId = data.UserId;
                    if (respCode == 0) {
                        actionType = "U";
                        AlertSuc.alertsuccess("success", data.ResponseMessage);
                        $('#sidebar-wrapper').removeClass("firstlogin");
                    }
                    else {
                        AlertSuc.alertsuccess("success", data.ResponseMessage);
                        $('#sidebar-wrapper').removeClass("firstlogin");
                        $('#sidebar-wrapper a').click(function () { return true });
                    }
                },
                error: function (data, success, error) {
                    AlertSuc.alertsuccess("error", error);
                }
            });
        }

    });
    // grab your file object from a file input
    $('#companylogo').change(function () {
        sendFile(this.files[0]);
    });

    $("#btnCancel").click(function () {
        var url = window.location.href;
        var arr = url.split("/");
        window.location.href = generateHandlerUrl.getUrl(arr[0] + "//" + arr[2] + "/" + "Dashboard/Dashboard.aspx");
    });

    $("#btnUpdate").click(function () {
        $("#profileform").trigger("submit");
       // submitForm($("#profileform"));
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





$('#selectprofile').change(function () {
    $('.hideme').hide();
    $('.hidemember').hide();
    if ($(this).val() == '1') {
        $('.hidemember').show();
    } else if ($(this).val() == 'consultant') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == 'individual') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == '2') {
        $('.hideme, .hidemember').hide();
    } else {
        $('.hideme').show();
    }
});

//------------------file Upload-----------------
function sendFile(file) {
    var fileDetails = new FormData();
    fileDetails.append(file.name, file);
    $.ajax({
        type: 'post',
        url: generateHandlerUrl.getUrl('../HandlerFiles/FileUploader.ashx?type=Logo&FileName=' + file.name),
        data: fileDetails,
        success: function (result) {
            fileDetails = result;
            $("#fileUrl").val(fileDetails);
            var fileNameUrl = fileDetails;
            if (fileNameUrl.indexOf("http://") == -1) {
                fileNameUrl = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + fileNameUrl.replace('~', '');
            }
            $("#cmp_LogoImg").attr("src", fileNameUrl).css("height", "110px;");
            AlertSuc.alertsuccess("success", "File uploaded successfully !!");
        },
        processData: false,
        //contentType: file.type
        contentType: false
    });
}




