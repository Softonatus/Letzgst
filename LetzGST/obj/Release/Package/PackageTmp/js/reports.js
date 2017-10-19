$(document).ready(function () {
    $('#rptexptbl').DataTable({
        responsive: false,
        paging: true,
        ordering: true,
        info: false,
        searching: false,
        autoWidth: false,
        fixedHeader: {
            header: true,
        },

        dom: 'Bfrtip',
        buttons: [

            {
                extend: 'print',
                orientation: 'landscape',
                pageSize: 'A3',
                footer: true,
            },
            {
                extend: 'pdfHtml5',
                orientation: 'landscape',
                pageSize: 'A3',
                footer: true,
            },
            {
                extend: 'csv',
                footer: true,
            },
            {
                extend: 'excel',
                footer: true,
            },

        ],
        order: [[0, 'asc']],
        footer: true,

    });
});
/*$(document).ready(function () {
    $('#rptexptbl').DataTable({
        responsive: false,
        paging: false,
        ordering: true,
        info: false,
        searching: false,
        autoWidth: false,
        fixedHeader: {
            header: true,
        },

        dom: 'Bfrtip',
        buttons: [

            {
                extend: 'csv',
                footer: true,
                exportOptions: {
                    stripHtml: false
                }
           },
            {
                extend: 'excel',
                footer: true,
                exportOptions: {
                    stripHtml: false
                }
           },
            {
                extend: 'pdf',
                footer: true,
                extend: 'pdfHtml5',
                orientation: 'landscape',
                pageSize: 'LEGAL',
                exportOptions: {
                    stripHtml: false
                }
           },
            {
                extend: 'print',
                footer: true,
                exportOptions: {
                    stripHtml: false
                }
           },

        ],
        order: [[1, 'asc']],
        footer: true,
    });
});*/



$(document).ready(function () {

    $('#rptfromdt').datepicker({
        autoclose: true,
        todayHighlight: true,
        endDate: '+0d',
    });
    $('#rpttodt').datepicker({
        startDate: '+0d',
        autoclose: true,
        todayHighlight: true
    });

    $('#rptok').on("click", function () {
        getReportList();
    });
    //getVendorList();

});

var responseDetails = {
    getVendordetils: function (data) {

        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resVendor != null) {
                var myTemplate = $.templates("#tblVendorCustomerDropdown");
                var html = myTemplate.render(data.resVendor);
                $("#drpVendorCustomerlist").append(html);
                $("#drpVendorCustomerlist").trigger("chosen:updated");
            

            }
        }
        else {

        }

    }
}

//function getVendorList() {
//    var req = { "userId": "" };
//    var getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=get");
//    var params = $.extend({}, doAjax_params_default);
//    params['url'] = getVendorListurl;
//    params['data'] = req;
//    params['successCallbackFunction'] = responseDetails.getVendordetils;
//    doAjax(params);
//}

function getReportList() {
    var req = new Object();
    req.UserId = null,
    req.tableName = $('#drpTypelist').find(":selected").text().trim();
    req.StartDate = getDate($('#rptfromdt').val());
    req.EndDate = getDate($('#rpttodt').val());
    isBrsInsert = null;

    $.ajax({
        type: "POST",
        url: generateHandlerUrl.getUrl('../Reports/GetReports.ashx'),
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(req),
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);
            console.log(data);
            if (respCode == 0) {
                if (data.resReportsList != null) {

                    //Change column name
                    $("#trReportHead").html("");
                    var selectedReportFor = req.tableName;
                    var reportHeader = "<th>Sr.no</th><th>Ref.no</th><th>" + selectedReportFor + " no</th><th>" + selectedReportFor + " Date</th><th>Vendor / Company</th><th>GSTN</th><th>PAN</th><th>Contact Name &amp; No</th><th>Net Amt</th><th>SGST</th><th>CGST</th><th>UTGST</th><th>IGST</th><th>Status</th>";
                    $("#trReportHead").html(reportHeader);
                    var myTemplate = $.templates("#tblReportListDetails");
                    var html = myTemplate.render(data.resReportsList);
                    $("#tbReport").html("");
                    $("#tbReport").html(html);

                }
            }
            else {
                $("#tbReport").html("");
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
}

function getDate(date) {
    var newDate = null;
    if (date != null && date != "") {
        var splitDate = date.split("/");
        var day = splitDate[0];
        var month = splitDate[1];
        var year = splitDate[2];

        newDate = year + "-" + month + "-" + day + " 00:00:00.000";
    }
    return newDate;

}
