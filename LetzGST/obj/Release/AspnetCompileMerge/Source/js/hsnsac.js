$.validator.addMethod("valueNotEquals", function (value, element, arg) {
    return arg !== value;
}, "Value must not equal arg.");


function loadDetails()
{
    $.ajax({
        type: "GET",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/GetUserHsnMapping.ashx'),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);

            if (respCode == 0) {
                if (data.reqUserHscList != null) {
                    var InsertTemplate = $.templates("#hscdata");
                    var html = InsertTemplate.render(data.reqUserHscList);
                   // alert(html);
                    $("#hscdetails").html(html);
                    addSerialNumber("hscdetails");
                }
                else {
                    $("#dvSAC").hide();
                }
                if (data.reqUserHsnList != null) {
                    var hsnTemp = $.templates("#hsndata");
                    var htmlhsn = hsnTemp.render(data.reqUserHsnList);
                    $("#hsnDetails").html(htmlhsn);
                    //alert(htmlhsn);
                    addSerialNumber("hsnDetails");
                }
                else {
                    $("#dvHSN").hide();
                }
                setTimeout(function () {
                    $('#hsncodes').DataTable({
                        "destroy": true,
                        responsive: true,
                        columnDefs: [
                            {
                                width: 10,
                                targets: 0
                            }
                        ],
                        fixedColumns: true,
                        autoWidth: false
                    });

                    $("#saccodes").DataTable({
                        "destroy": true,
                        responsive: true,
                        columnDefs: [
                            {
                                width: 10,
                                targets: 0
                            }
                        ],
                        fixedColumns: true,
                        autoWidth: false
                    });
                }, 5000);
            }
            else {
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
}

var addSerialNumber = function (id) {
    var i = 1
    $('#' + id + ' tr').each(function (index) {
        $(this).find('td:nth-child(1)').html(index + 1);
    });
};
$(document).ready(function () {
    var $target = $('#sidebar-wrapper');
    $target.find("ul li ul").each(function () {
        $(this).removeClass("show");
    });
    $target.find("ul li a").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
        $("#settingsmenu").addClass("show");
        $("#mnu_hsnhsc").addClass("active");
    });
    loadDetails();    
});

$("#sethsncode").submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        crrole: {
                valueNotEquals: "-1"
            },
    },
    messages: {
        crrole: { valueNotEquals: "Please select an item type!" }
    },
    submitHandler: function (form) {
        var selCode = $("#crrole option:selected").val();
        var searchReq = new Object();
        searchReq.HsnOrHsc = selCode;
        searchReq.HsnDetail = $("#txtSearch").val();

        $.ajax({
            type: "POST",
            url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacSearchResults.ashx'),
            data: JSON.stringify(searchReq),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                var respCode = parseInt(data.ResponseCode);

                if (respCode == 0) {
                    var InsertTemplate = $.templates("#dvChkbox");
                    var htmlsrch = InsertTemplate.render(data.resHsnCodeGoods);
                    $("#dvHSNCodes").html(htmlsrch);
                }
                else {
                    AlertSuc.alertsuccess("error", data.ResponseMessage);
                }
                $("#txtSearch").val("");

            },
            error: function (data, success, error) {
                AlertSuc.alertsuccess("error", error);
            }
        });
    }
});

$("body").on("click", ".actions-btn", function () {

    var reqUserHsn = { "HsnOrHsc": $(this).attr("type"), "Id": $(this).attr("hsnid"), UserId: $("#hdn_Main").val() };
    $.ajax({
        type: "POST",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacUserMapping.ashx?action=D'),
        data: JSON.stringify(reqUserHsn),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);
            if (respCode == 0) {
                AlertSuc.alertsuccess("success", data.ResponseMessage);
                window.location.reload(true);
            }
            else {
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
});

$("#savehsnCode").submit(function (e) {
    e.preventDefault();
}).validate({    
    submitHandler: function (form) {
        var reqUserHsnListObj = [];
        var id = 0;

        $(form).find('input:checkbox:checked').each(function () {
            var obj =  { "Id": $(this).attr("id"), UserId: $("#hdn_Main").val() };
            reqUserHsnListObj.push(obj);
            $(this).prop("checked", false);
        });

        var reqInsertUserHsn = { "HsnOrHsc": $("#crrole option:selected").val(), reqUserHsnList: reqUserHsnListObj };

        $.ajax({
            type: "POST",
            url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacUserMapping.ashx?action=I'),
            data: JSON.stringify(reqInsertUserHsn),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                var respCode = parseInt(data.ResponseCode);
                if (respCode == 0) {
                    AlertSuc.alertsuccess("success", data.ResponseMessage);
                    window.location.reload(true);
                }
                else {

                    AlertSuc.alertsuccess("error",data.ResponseMessage);
                }
                $("#txtSearch").val("");
            },
            error: function (data, success, error) {
                AlertSuc.alertsuccess("error", error);
            }
        });
    }
});