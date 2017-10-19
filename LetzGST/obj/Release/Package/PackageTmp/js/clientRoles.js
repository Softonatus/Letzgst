var UserId;
var SelUserId = "0";

$(document).ready(function () {

    document.title = "letzGST:: Create Client";

    //highliht the menu
    var $target = $('#sidebar-wrapper');
    $target.find("ul li ul").each(function () {
        $(this).removeClass("show");
    });
    $target.find("ul li a").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
        $("#createmenu").addClass("show");
        $("#client").addClass("active");
    });

    $.ajax({
        type: "GET",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/GetClientDetails.ashx'),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            
            var respCode = parseInt(data.ResponseCode);
            if (respCode == 0) {
                var myTemplate = $.templates("#tbltemplate");
                var html = myTemplate.render(data.resCompany_CA);
                $("#bodyContent").html(html);
                $('#usersroles').DataTable();
            }
            else {
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });


    $("body").on("click", ".actions-btn", function () {
        var type = $(this).attr("title");
        var trDetails = $(this).closest('tr');
        SelUserId = $(trDetails).children('td:eq(0)').text();
        if (type == "View")
        {
            getCompanyDetails(SelUserId);
        }
        if (type == "Edit") {
            fillUsers(trDetails);
        }
        else if (type == "Delete") {
            var reqUserId = { "UserId": SelUserId }
            $.ajax({
                type: "POST",
                url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/CreateUser.ashx?type=delete&page=CR'),
                data: JSON.stringify(reqUserId),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var respCode = parseInt(data.ResponseCode);
                    trDetails.remove();

                    AlertSuc.alertsuccess("success", data.ResponseMessage);
                    SelUserId = "";

                    $('#usersroles').DataTable();
                },
                error: function (data, success, error) {
                    AlertSuc.alertsuccess("error", error);
                }
            });
        }

    });
});

function performOperations(type) {

    var ReqRegistration = new Object();
    if (parseInt(SelUserId) > 0) {
        type = "update";
        ReqRegistration.UserId = parseInt(SelUserId);
    }
    ReqRegistration.Name = $("#crname").val();
    ReqRegistration.EmailId = $("#cremail").val();
    ReqRegistration.ContactNo = $("#crmobile").val();
    ReqRegistration.UserRoleAuth = $("#crmobile option:selected").val();

    $.ajax({
        type: "POST",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/CreateUser.ashx?type=' + type + '&page=CR'),
        data: JSON.stringify(ReqRegistration),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);

            if (respCode == 1 && type == "insert") {
                UserId = data.UserId;
                var companyDetail = [
                    {
                        UserId: data.UserId,
                        Name: ReqRegistration.Name,
                        EmailId: ReqRegistration.EmailId,
                        ContactNo: ReqRegistration.ContactNo
                    }
                ]

                var InsertTemplate = $.templates("#tbltemplate");
                var html = InsertTemplate.render(companyDetail);
                $("#bodyContent").append(html);
                AlertSuc.alertsuccess("success", data.ResponseMessage);
            }
            else if (respCode == 0 && type == "update") {
                var trdetails = $("#bodyContent").find("tr[id='" + SelUserId + "']");
                $(trdetails).children('td:eq(1)').text($("#crname").val());
                $(trdetails).children('td:eq(2)').text($("#cremail").val());
                $(trdetails).children('td:eq(3)').text($("#crmobile").val())
                AlertSuc.alertsuccess("success", data.ResponseMessage);
            }
            else {
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
            clearAll();
            $('#usersroles').DataTable();
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
}

function clearAll() {
    $("#crname").val("");
    $("#cremail").val("");
    $("#crmobile").val("");
    SelUserId = "";
}

function getCompanyDetails(userId) {

    var Windowname = "CompanyDetails_" + userId;
    //document.title = Windowname;
    var specs = "location=no,directories=no,titlebar=no,toolbar=no,scrollbars=yes,resizable=no,width=1280,height=600";

    var win = window.open('', Windowname, specs);
    
    window.oldOpen = window.open;
    window.open = function (url) { // reassignment function
        
        win.location = url;
        window.open = oldOpen;
        win.focus();
        win.title = Windowname;
    }

    $.ajax({
        type: "POST",
        url: '../HandlerFiles/Dashboard/CreateCompanySession.ashx?userId=' + userId,
        //data: JSON.stringify(reqProfile),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);
            // UserId = data.UserId;
            if (respCode == 0) {
                var url = window.location.href;
                var arr = url.split("/");
                var redirectionUrl = "";
                if (data.ResponseMessage == "dashboard")
                {
                    redirectionUrl = arr[0] + "//" + arr[2] + "/" + "Dashboard/Dashboard.aspx?usertype=company&cmp_id=" + userId;
                }
                else
                {
                    redirectionUrl = arr[0] + "//" + arr[2] + "/" + "Dashboard/Profile.aspx?usertype=company&cmp_id=" + userId;
                }
                
                window.open(redirectionUrl);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
   
}

function fillUsers(trDetails) {
    $("#crname").val($(trDetails).children('td:eq(1)').text());
    $("#cremail").val($(trDetails).children('td:eq(2)').text());
    $("#crmobile").val($(trDetails).children('td:eq(3)').text());
    // $("#crmobile option:selected").val("1");

}

$("#createusers").submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        crmobile: {
            required: true,
            minlength: 10,
            number: true
        },
        cremail: {
            required: true,
            email: true
        }
    },
    cremail: {
        email: "Please enter a valid email address"
    },
    crmobile: {
        mobile: "Please enter mobile number"
    },
    submitHandler: function (form) {
        var $form = $(form);
        var $inputs = $form.find("input, button");
        var serializedData = $form.serialize();
        performOperations("insert");
    }
});