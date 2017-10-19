$(document).ready(function () {

    $('#brstoptbl').DataTable({

        responsive: true,

        paging: false,

        ordering: true,

        info: false,

        searching: true,

        autoWidth: false,

        fixedHeader: {

            header: true,

        },

        columnDefs: [{

            orderable: false,

            className: 'select-checkbox',

            targets: 0

        }],

        select: {

            style: 'os',

            selector: 'td:first-child'

        },

        order: [[1, 'asc']]

    });

});

$(document).ready(function () {
    $('#invoicetbl').DataTable({
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
});


$(document).ready(function () {
    $('#brsbottomtbl').DataTable({
        responsive: true,
        paging: false,
        ordering: false,
        info: false,
        searching: false,
        autoWidth: false,
        columnDefs: [{
            orderable: false,
            targets: [1, 2, 3, 4]
        }]

    });
    //----accordian tabs

    $('#btnReconcile').click(function () {
        getBRSList();
    });

    $('#btnSubmit').click(function () {

        //check total amount is not greater then pending amount
         var totalPendingAmount = 0; 
        $('#brbottomtbl > tbody  > tr').each(function () {
            
            var amount = $(this).find("[name='BrsPayAmount']").val();
            totalPendingAmount = totalPendingAmount + parseInt(amount);
        });
        if (totalPendingAmount <= parseInt(selectedBrsPendingAmount)) {
            insertBRSPaymentList();
        }
        else
        {
            AlertSuc.alertsuccess("error", "Total amount exceeded pending amount");
        }
    });

    //---------
    $('#addinvoice').click(function () {
        $("#invoicetable").hide(800);
        $("#addinvoicedetails").show(800);

    });

    $('#backtoinvoice').click(function () {
        $("#addinvoicedetails").hide(800);
        $("#invoicetable").show(800);

    });
    //---
    $('.brspydate').datepicker({
        autoclose: true,
        todayHighlight: true
    });

});

$(document).ready(function () {
    $('.btn-edit').on("click", function () {
        $(this).closest('tr').find('input,textarea,select').prop('disabled', false);
    });
});

$(document).ready(function () {

    var todaysDate = new Date();
    var todaysMonth = todaysDate.getMonth() + 1;
    $("#ddMonth").val(todaysMonth + "");
    
});

$(document).ready(function () {

    $(document).on('click', '.del', function () {
        var index = $(this).closest('#brbottomtbl tr').index();
        $(this).parent().parent().remove();
        for (var i = index; i < $('#brbottomtbl tbody tr').children().length; i++) {
            $('#brbottomtbl tbody tr:nth-child(' + i + ') td:first-child').text(i);
        }
    });

    $(document).on('click', '.add', function () {
        $('.chosen_select').chosen('destroy');
        $(this).val('');
        $(this).attr('title', 'Delete Item');
        $(this).attr('class', 'del');
        var appendTxt = "<tr> <td>" + (parseInt($(this).closest('tr').find('td:first-child').text()) + 1) + "</td> <td><input type='text' name='BrsPayAmount' class='form-control'></td> <td><textarea name='BrsPayDescription' class='form-control'></textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'> <option selected></option> <option value='cash'> Cash </option> <option value='cheque'> Cheque</option> <option value='banktransfer'> Bank Transfer</option> <option value='creditcard'>Credit Card</option> <option value='debitcard'>Debit Card</option> <option value='online'>Online</option> <option value='others'>Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
        $("tr:last").after(appendTxt);
        $('.chosen-select').chosen({
            width: "100%"
        });
        $('.brspydate').datepicker({
            autoclose: true,
            todayHighlight: true
        });
    });
});

function getBRSList() {
    var req = new Object();
    req.UserId = null,
    req.tableName = $('#ddReconcile').find(":selected").text();
    req.Month = $('#ddMonth').val();
    isBrsInsert = null;

    $.ajax({
        type: "POST",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Manage/GetBRSList.ashx'),
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(req),
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);
            
            if (respCode == 0) {
                if (data.resBrsList != null)
                {
                    var myTemplate = $.templates("#tblBrsListDetails");
                    var html = myTemplate.render(data.resBrsList);
                    $("#tbBrsList").html("");
                    $("#tbBrsList").html(html);

                    $('input:radio[name="rd_BRS"]').change(
                        function () {
                            $("#tbBrsPaymentList").html("");

                            var status = $(this).attr("data-status");
                            var Pid = $(this).attr("id");
                            var arrPid = Pid.split("_");
                            selectedPid = arrPid[1];
                            selectedTid = $(this).attr("data-TId");
                            selectedBrsPendingAmount = $(this).attr("data-PendingAmount");
                            if (status == "") {
                                $("#dvBrsPayment").hide();
                            }
                            else if (status.trim().toLowerCase() == "pending") {
                                isBrsInsert = true;
                                $("#dvBrsPayment").show();
                                var appendTxt = "<tr> <td>" + 1 + "</td> <td><input type='text' name='BrsPayAmount' class='form-control'></td> <td><textarea name='BrsPayDescription' class='form-control'></textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'> <option selected></option> <option value='cash'> Cash </option> <option value='cheque'> Cheque</option> <option value='banktransfer'> Bank Transfer</option> <option value='creditcard'>Credit Card</option> <option value='debitcard'>Debit Card</option> <option value='online'>Online</option> <option value='others'>Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
                                $("#tbBrsPaymentList").html(appendTxt);
                                $('.chosen-select').chosen({
                                    width: "100%"
                                });
                                $('.brspydate').datepicker({
                                    autoclose: true,
                                    todayHighlight: true
                                });
                                $("html, body").animate({ scrollTop: $(document).height() }, 1000);
                            }
                            else if (status.trim().toLowerCase() == "partial payment") {
                                isBrsInsert = false;
                                getBrsPaymentList();
                            }
                        });
                }
                else
                {
                    $("#tbBrsList").html("");
                }
            }
            else {
                $("#tbBrsList").html("");
                AlertSuc.alertsuccess("error", data.ResponseMessage);
            }
        },
        error: function (data, success, error) {
            AlertSuc.alertsuccess("error", error);
        }
    });
}

function insertBRSPaymentList() {

    var req = new Object();
    req.reqBrsPaymentList = [];
    req.Type = $('#ddReconcile').find(":selected").text();
    $('#brbottomtbl > tbody  > tr').each(function () {
        var brsPayment = {
            "Amount": null,
            "Memo": null,
            "PaymentMode": null,
            "PaidDate": null,
            "ModeNo": null,
            "RealizationDate": null,
            "Id":null
        };
        brsPayment.Amount = $(this).find("[name='BrsPayAmount']").val();
        brsPayment.Memo = $(this).find("[name='BrsPayDescription']").val();
        brsPayment.RealizationDate = getDate($(this).find("[name='BrsPayRealDate']").val());
        brsPayment.PaidDate = getDate($(this).find("[name='BrsPayPaidDate']").val());
        brsPayment.PaymentMode = $(this).find("[name='BrsPayMethod']").val();
        brsPayment.Id = selectedPid;
        brsPayment.ModeNo = selectedTid;
        req.reqBrsPaymentList.push(brsPayment);
    });
    console.log(req);
    var url;
    if (isBrsInsert)
    {
        url = generateHandlerUrl.getUrl('../HandlerFiles/Manage/InsertBrsPayment.ashx?insertType=insert')
    }
    else
    {
        url = generateHandlerUrl.getUrl('../HandlerFiles/Manage/InsertBrsPayment.ashx?insertType=update')
    }
    
    
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(req),
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);

            if (respCode == 0) {
                
                AlertSuc.alertsuccess("success", data.ResponseMessage);
                $("#dvBrsPayment").hide();
                $("#tbBrsPaymentList").html("");
                var appendTxt = "<tr> <td>" + (parseInt($("#tbBrsPaymentList").closest('tr').find('td:first-child').text()) + 1) + "</td> <td><input type='text' name='BrsPayAmount' class='form-control'></td> <td><textarea name='BrsPayDescription' class='form-control'></textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'> <option selected></option> <option value='cash'> Cash </option> <option value='cheque'> Cheque</option> <option value='banktransfer'> Bank Transfer</option> <option value='creditcard'>Credit Card</option> <option value='debitcard'>Debit Card</option> <option value='online'>Online</option> <option value='others'>Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
                $("#tbBrsPaymentList").html(appendTxt);
                getBRSList();
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

function getBrsPaymentList() {
    var req = new Object();
    req.Type = $('#ddReconcile').find(":selected").text();
    req.Id = selectedPid;

    $.ajax({
        type: "POST",
        url: generateHandlerUrl.getUrl('../HandlerFiles/Manage/GetBrsPayment.ashx'),
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(req),
        dataType: 'json',
        success: function (data) {
            var respCode = parseInt(data.ResponseCode);

            if (respCode == 0) {
                console.log(data);
                $("#dvBrsPayment").show();
                
                $.each(data.reqBrsPaymentList, function (i, l) {
                    var selectedCash = "";
                    var selectedCheque = "";
                    var selectedBank = "";
                    var selectedCredit = "";
                    var selectedDebit = "";
                    var selectedOnline = "";
                    var selectedOthers = "";
                    if (l.PaymentMode == "cash")
                        selectedCash = "selected";
                    if (l.PaymentMode == "cheque")
                        selectedCheque = "selected";
                    if (l.PaymentMode == "debitcard")
                        selectedDebit = "selected";
                    if (l.PaymentMode == "creditcard")
                        selectedCredit = "selected";
                    if (l.PaymentMode == "banktransfer")
                        selectedBank = "selected";
                    if (l.PaymentMode == "online")
                        selectedOnline = "selected";
                    if (l.PaymentMode == "others")
                        selectedOthers = "selected";
                    if (i == 0)
                    {
                        var appendTxt = "<tr> <td>" + 1 + "</td> <td><input type='text' name='BrsPayAmount' disabled class='form-control' value='" + l.Amount + "'></td> <td><textarea name='BrsPayDescription' disabled class='form-control'>" + l.Memo + "</textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' disabled class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' disabled class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' disabled data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'>  <option value='cash'" + selectedCash + "> Cash </option> <option value='cheque' " + selectedCheque + "> Cheque</option> <option value='banktransfer' " + selectedBank + "> Bank Transfer</option> <option value='creditcard' " + selectedCredit + ">Credit Card</option> <option value='debitcard' " + selectedDebit + ">Debit Card</option> <option value='online' " + selectedOnline + ">Online</option> <option value='others' " + selectedOthers + ">Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit' data-id='" + l.Id + "'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
                        $("#tbBrsPaymentList").html(appendTxt);
                        

                    }
                    else
                    {
                        var appendTxt = "<tr> <td>" + (parseInt(i) + 1) + "</td> <td><input type='text' name='BrsPayAmount' disabled class='form-control' value='" + l.Amount + "'></td> <td><textarea name='BrsPayDescription' disabled class='form-control'>" + l.Memo + "</textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' disabled class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' disabled class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' disabled data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'> <option selected></option> <option value='cash' " + selectedCash + "> Cash </option> <option value='cheque' " + selectedCheque + "> Cheque</option> <option value='banktransfer' " + selectedBank + "> Bank Transfer</option> <option value='creditcard' " + selectedCredit + ">Credit Card</option> <option value='debitcard' " + selectedDebit + ">Debit Card</option> <option value='online' " + selectedOnline + ">Online</option> <option value='others' " + selectedCash + ">Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit' data-id='" + l.Id + "'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
                        $("tr:last").after(appendTxt);
                    }
                    if (l.RealizationDate != null && l.RealizationDate != "") {
                        $("tr:last").find("[name='BrsPayRealDate']").datepicker("setDate", getDateForDatePicker(l.RealizationDate));
                    }
                    if (l.PaidDate != null && l.PaidDate != "") {
                        $("tr:last").find("[name='BrsPayPaidDate']").datepicker("setDate", getDateForDatePicker(l.PaidDate));
                    }
                    $('.btn-edit').on("click", function () {
                        $(this).closest('tr').find('input,textarea,select').prop('disabled', false);
                    });
                    
                });
                //var appendTxt = "<tr> <td>" + 1 + "</td> <td><input type='text' name='BrsPayAmount' class='form-control'></td> <td><textarea name='BrsPayDescription' class='form-control'></textarea></td> <td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayRealDate' class='form-control pull-right brspydate' id='duedate'> </div> </td><td> <div class='input-group date'> <div class='input-group-addon'> <i class='icon ico-calendar'></i> </div> <input type='text' name='BrsPayPaidDate' class='form-control pull-right brspydate' id='duedate'> </div> </td> <td> <select id='brspaymentmethod' name='BrsPayMethod' data-placeholder='Payment Terms' name='brspaymentmethod' class='form-control' required='required'> <option selected></option> <option value='cash'> Cash </option> <option value='cheque'> Cheque</option> <option value='banktransfer'> Bank Transfer</option> <option value='creditcard'>Credit Card</option> <option value='debitcard'>Debit Card</option> <option value='online'>Online</option> <option value='others'>Others</option> </select> </td> <td> <input type='button' class='add tbl-btn' value='' title='Add More Items' /><a class='actions-btn btn-edit' id='edit-brspayment' title='Edit'><span class='icon ico-edit ico-2x'></span></a> </td> </tr>";
                //$("#tbBrsPaymentList").html(appendTxt);
                $('.chosen-select').chosen({
                    width: "100%"
                });
                $('.brspydate').datepicker({
                    autoclose: true,
                    todayHighlight: true
                });
                $("html, body").animate({ scrollTop: $(document).height() }, 1000);
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


function getDateForDatePicker(date) {
    var newDate = null;
    if (date != null && date != "") {
        var splitDate = date.split(" ");
        var datePart = splitDate[0];

        var splitDatePart = datePart.split("/");
        var day = splitDatePart[1];
        var month = splitDatePart[0];
        var year = splitDatePart[2];

        newDate = year + "-" + month + "-" + day + " 00:00:00.000";
    }
    return (new Date(newDate));

}

function brsRadioButtonChanged() {
    
}

