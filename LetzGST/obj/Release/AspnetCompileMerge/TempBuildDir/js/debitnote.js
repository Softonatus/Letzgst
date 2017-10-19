

var ItemDetailsObj = new Object();
var UTList = ["Andaman and Nicobar Islands", "Dadra and Nagar Haveli", "Lakshadweep", "Puducherry", "Chandigarh", "Daman and Diu", "New Delhi"];
var clone = $("table tr.data-wrapper:first").clone(true);

//validatiopn details
$.validator.addMethod("valueNotEquals", function (value, element, arg) {
    return arg !== value;
}, "Value must not equal arg.");

$.validator.addMethod("Adhar", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid Adhar Number.");

$.validator.addMethod("_gstno", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid GST Number.");

$.validator.addMethod("tan", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid TAN Number.");

$.validator.addMethod("tan", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Invalid TAN Number.");

//Vendor List
function getVendorList() {
    var req = { "userId": "" };
    var getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getVendorListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getVendordetils;
    doAjax(params);
}

function getItemList() {
    var req = { "userId": "" };
    var getitemListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/ItemDetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getitemListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getItemDetails;
    doAjax(params);
}

function getPaymentTerms() {
    var req = { "userId": "" };
    var getPaymentTermsurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PaymentTerms.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getPaymentTermsurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getPaymentTermsDetails;
    doAjax(params);
}

function getTDSList() {
    var req = { "userId": "" };
    var getTDSListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetTDSDetails.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getTDSListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getTDSDeatilsResp;
    doAjax(params);
}

function getLastBillId() {
    var req = { "userId": "" };
    var getLastBillIdUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetLastInsertedDebitNoteId.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getLastBillIdUrl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.retriveLastPOId;
    doAjax(params);
}

function getDebitNoteList() {
    var req = { "userId": "" };
    var getDebitListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/DebitNoteDetails.ashx?opertype=get");
   
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getDebitListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getDebitNoteDetails;
    doAjax(params);
}

function TotalAmount() {
    var totalAmt = 0;
    $(".amtdetails").each(function () {
        if (parseFloat($(this).val()) > 0) {
            totalAmt = totalAmt + parseFloat($(this).val());
        }

    });
    var CSGT = 0; var SGST = 0; var IGST = 0; var UTGST = 0;
    $("#totalcgst").text(0);
    $("#totalsgst").text(0);
    $("#totaligst").text(0);
    $("#totalugst").text(0);

    $(".cgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            CSGT = CSGT + parseFloat($(this).text());
            $("#totalcgst").text(CSGT);
        }

    });
    $(".sgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            SGST = SGST + parseFloat($(this).text());
            $("#totalsgst").text(SGST);
        }

    });
    $(".igstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            IGST = IGST + parseFloat($(this).text());
            $("#totaligst").text(IGST);
        }

    });
    $(".utgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            UTGST = UTGST + parseFloat($(this).text());
            $("#totalugst").text(UTGST);
        }

    });
    var tds = $("#TdsOption").val();
    if (parseInt(tds) > 0) {
        totalAmt = totalAmt - tds;
    }

    var freight = 0;
    if (parseFloat($("#freight").val()) > 0) {
        freight = parseFloat($("#freight").val());
    }
    var labourCharge = 0;
    if (parseFloat($("#labourCharge").val()) > 0) {
        labourCharge = parseFloat($("#labourCharge").val());
    }
    var InsuranceAmt = 0;
    if (parseFloat($("#InsuranceAmt").val()) > 0) {
        InsuranceAmt = parseFloat($("#InsuranceAmt").val());
    }
    var otherCharges = 0;
    if (parseFloat($("#otherCharges").val()) > 0) {
        otherCharges = parseFloat($("#otherCharges").val());
    }
    var cess = 0;
    if (parseFloat($("#cess").val()) > 0) {
        cess = parseFloat($("#cess").val());
    }
    var NetTotal = parseFloat(parseFloat(totalAmt.toFixed(2)) + parseFloat(freight) + parseFloat(labourCharge) + parseFloat(InsuranceAmt) + parseFloat(otherCharges) + parseFloat(cess));
    var RoundOffValue = 0;
    var roundVal = parseFloat(Math.round(NetTotal.toFixed(2)) + ".00");
    var Mod = roundVal % 10;
    if (Mod > 0 && Mod < 5) {
        RoundOffValue = parseFloat(parseFloat(Math.round(NetTotal.toFixed(2)) + ".00") - parseInt(Mod))
    }
    else if (Mod >= 5 && Mod <= 9) {
        RoundOffValue = parseFloat(parseFloat(parseFloat(Math.round(NetTotal.toFixed(2)) + ".00") - parseInt(Mod)) + 10);
    }

    $("#totalamt").text(totalAmt.toFixed(2));
    $("#roundamt").text(Math.round(RoundOffValue) + ".00");
    $("#nettotal").text(NetTotal.toFixed(2));
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57)))
        return false;
    return true;
}

function performCalculation(id) {
    var stateMatches = false;
    var isUnionteritory = false;

    var options = $("#debitnoteto option:selected");
    var VendorState = "";
    if ($("#shippingState").val() != "" && $("#shippingState").val() != "undefined" && $("#shippingState").val() != undefined) {
        VendorState = $("#shippingState").val();
    }
    else {
        for (var i = 0; i < options.length; i++) {
            VendorState = $(options[i]).attr('state');
        }
    }
    if (VendorState == $("#hdn_uCountry").val()) {
        stateMatches = true;
    }
    if ($.inArray(VendorState, UTList) !== -1) {
        isUnionteritory = true;
    }
    //alert(VendorState);
    var Price = parseInt($("#price_" + id).val());
    var Quantity = parseInt($("#unt_" + id).val());
    //calculate the tax on the items
    var gross = (Price * Quantity);
    var discount = parseInt($("#disount").val());

    if (parseInt(discount) > 0) {
        var disountAmt = gross * (parseFloat(parseInt(discount) / 100));
        gross = gross - disountAmt;
    }
    var tax = 0
    if (parseInt($("#tax_" + id).val()) > 0) {

        tax = gross * (parseFloat(parseInt($("#tax_" + id).val()) / 100));
    }
    if (stateMatches && !isUnionteritory) {
        $("#taxseperation_" + id).find(".cgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".cgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".cgst-sep").show();

        $("#taxseperation_" + id).find(".sgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".sgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".sgst-sep").show();

        $("#taxseperation_" + id).find(".igst").text("0");
        $("#taxseperation_" + id).find(".igstAmt").text("0");
        $("#taxseperation_" + id).find(".utgst").text("0");
        $("#taxseperation_" + id).find(".utgstAmt").text("0");
        $("#taxseperation_" + id).find(".igst-sep").hide();
        $("#taxseperation_" + id).find(".utgst-sep").hide();
    }
    else if (!stateMatches) {
        $("#taxseperation_" + id).find(".igst").text(parseFloat(parseInt($("#tax_" + id).val())));
        $("#taxseperation_" + id).find(".igstAmt").text(parseFloat(parseInt(tax)));
        $("#taxseperation_" + id).find(".igst-sep").show();

        $("#taxseperation_" + id).find(".sgst").text("0");
        $("#taxseperation_" + id).find(".sgstAmt").text("0");
        $("#taxseperation_" + id).find(".sgst-sep").hide();
        $("#taxseperation_" + id).find(".cgst").text("0");
        $("#taxseperation_" + id).find(".cgstAmt").text("0");
        $("#taxseperation_" + id).find(".cgst-sep").hide();
        $("#taxseperation_" + id).find(".cgst").text("0");
        $("#taxseperation_" + id).find(".utgstAmt").text("0");
        $("#taxseperation_" + id).find(".utgst-sep").hide();
        $("#taxseperation_" + id).find(".utgst-sep").hide();

    }
    else if (stateMatches && isUnionteritory) {
        $("#taxseperation_" + id).find(".cgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".cgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".cgst-sep").show();

        $("#taxseperation_" + id).find(".utgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".utgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".utgst-sep").show();

        $("#taxseperation_" + id).find(".igst").text("0");
        $("#taxseperation_" + id).find(".igstAmt").text("0");
        $("#taxseperation_" + id).find(".igst-sep").hide();
        $("#taxseperation_" + id).find(".sgst").text("0");
        $("#taxseperation_" + id).find(".sgstAmt").text("0");
        $("#taxseperation_" + id).find(".sgst-sep").hide();
    }
    //calculate the amount including TAX
    var Amount = (gross + tax).toFixed(2);
    $("#Amount_" + id).val(Amount);
    TotalAmount();

}

function getBillNODetails() {
    var req = { "userId": "" };
    var getBillNODetailsUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillRefList.ashx?opertype=bill");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getBillNODetailsUrl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.GetBillNoDetails;
    doAjax(params);
}
function convertDate(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}

var addSerialNumber = function (id) {
    var i = 1
    $('#' + id + ' tr').each(function (index) {
        $(this).find('td:nth-child(1)').html(index + 1);
    });
};

var responseDetails = {
    getVendordetils: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resVendor != null) {
                var myTemplate = $.templates("#tblVendorDropdown");
                var html = myTemplate.render(data.resVendor);
                $("#debitnoteto").append(html);
                $("#debitnoteto").trigger("chosen:updated");

            }
        }
        else {

        }
    },
    getItemDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            ItemDetailsObj = data.resUserItemsList;
            if (ItemDetailsObj != null) {
                var myTemplate = $.templates("#tblItemsDropdown");
                var html = myTemplate.render(ItemDetailsObj);
                $("#additems_1").append(html);
                $("#additems_1").trigger("chosen:updated");

            }
        }
    },
    getPaymentTermsDetails: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resGetPaymentTermList != null) {
                var myTemplate = $.templates("#tblpaymentTermsDropdown");
                var html = myTemplate.render(data.resGetPaymentTermList);
                $("#paymentterms").append(html);
                $("#paymentterms").trigger("chosen:updated");

            }
        }
    },
    getTDSDeatilsResp: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            var myTemplate = $.templates("#tblTdsDropdown");
            var html = myTemplate.render(data.resTdsList);
            $("#debittds").append(html);
            $("#debittds").trigger("chosen:updated");

        }
    },
    retriveLastPOId: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $("#billno").val(data.Count).attr("disabled", "disabled");
        }
    },
    GetBillNoDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            var myTemplate = $.templates("#BillIDDetails");
            var html = myTemplate.render(data.resrefIdList);
            $("#invrefno").append(html);
            $("#invrefno").trigger("chosen:updated");
        }
    },
    insertDebitNote: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            AlertSuc.alertsuccess("success", data.ResponseMessage);
            $("#hdnPurchaseId").val("");
            var typedet = getUrlVars()["usertype"];
            var cmpIddet = getUrlVars()["cmp_id"];
            //url rewrite start
            var querystring = "";
            if (typedet != null && typedet !== "" && typedet != undefined) {
                querystring = querystring + '&usertype=company&cmp_id=' + cmpIddet;
            }
            var newURL = location.href.split("?")[0];
            if (querystring != "") {
                newURL = newURL + (newURL.match(/\?/) ? '&' : '?') + querystring;
            }
            window.location.href = newURL;

        }
    },
    getDebitNoteDetails: function (data) {
        // if (parseInt(data.resEstimateGetList.ResponseCode) == 0) {
        if (data.resDebitNoteGet != null) {
            var myTemplate = $.templates("#tblDebitNoteDetails");
            var html = myTemplate.render(data.resDebitNoteGet);
            $("#DebitDetails").html(html);
            addSerialNumber("DebitDetails");
            $('#debitlisttbl').DataTable({
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
        }
        else {
            var noRecords = "<tr><td> No records found</td></tr>";
        }
    },
    deleteDebitNotes: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            AlertSuc.alertsuccess("success", data.ResponseMessage);
            window.location.reload(true);
        }
    },
    getDebitDetailsbyId: function (data) {
        if (data.resDebitNoteGet != null) {
            $('#debitnoteto').val(data.resDebitNoteGet[0].VendorId);
            $("#billno").val(data.resDebitNoteGet[0].DebitNo).attr("disabled", "disabled");
            $("#debitdate").val(convertDate(data.resDebitNoteGet[0].DebitDate.split("T")[0]));
            if (data.resDebitNoteGet[0].DueDate != null) {                
                $("#debitduedate").val(convertDate(data.resDebitNoteGet[0].DueDate.split("T")[0]));
            }
            $("#invrefno").val(data.resDebitNoteGet[0].InvoiceRefNo);
            $("#paymentterms").val(data.resDebitNoteGet[0].PaymentTerm);
            $("#refno").val(data.resDebitNoteGet[0].RefNo);
            $("#shipaddress1").val(data.resDebitNoteGet[0].ShippingAddress1);
            $("#shipaddress2").val(data.resDebitNoteGet[0].ShippingAddress2);
            $("#shipcity").val(data.resDebitNoteGet[0].City);
            $("#pincode").val(data.resDebitNoteGet[0].PinCode);
            $("#shippingState").val(data.resDebitNoteGet[0].State);
            $("#freight").val(data.resDebitNoteGet[0].Frieght);
            $("#labourCharge").val(data.resDebitNoteGet[0].LabourCharge);
            $("#InsuranceAmt").val(data.resDebitNoteGet[0].InsuranceAmount);
            $("#otherCharges").val(data.resDebitNoteGet[0].OtherCharge);
            $("#TandC").val(data.resDebitNoteGet[0].TermCondition);
            $("#INVPayDet").val(data.resDebitNoteGet[0].InvoicePaymentDetail);
            $("#cess").val(data.resDebitNoteGet[0].Cess);
            $("#disount").val(data.resDebitNoteGet[0].Discount);

            if (data.resDebitNoteGet[0].ResDebitItemList.length > 0) {
                $("#tblItemDetails").find("tr:gt(0)").remove();
                if (data.resDebitNoteGet[0].ResDebitItemList.length > 1) {
                    $("#add_1").attr('class', 'del');
                }
                else {
                    $("#add_1").attr('class', 'add');
                }

                for (var b = 1; b <= (data.resDebitNoteGet[0].ResDebitItemList.length) ; b++) {
                    if (b > 1) {
                        var ParentRow = $("table tr.data-wrapper").last();
                        var newId = "";
                        clone.find('td').each(function () {
                            var el = $(this).find(':first-child');
                            var id = el.attr('id') || null;
                            if (id) {
                                //var i = id.substr(id.length - 1);
                                var i = b;
                                if (newId == "") {
                                    newId = b;
                                }
                                var prefix = id.substr(0, (id.length - 1));
                                el.attr('id', prefix + (+i));
                                el.attr('name', prefix + (+i));
                            }
                        });
                        clone.find('input:text').val('');

                        clone.clone(true).insertAfter(ParentRow);
                        var myTemplate = $.templates("#tblItemsDropdown");
                        var html = myTemplate.render(ItemDetailsObj);
                        $("#additems_" + newId).append(html);

                        $('tr.data-wrapper:last select').chosen();
                        newId = "";

                        if (b < data.resDebitNoteGet[0].ResDebitItemList.length) {
                            $("#add_" + b).attr('class', 'del');
                        }
                        else {
                            $("#add_" + b).attr('class', 'add');
                        }

                        addSerialNumber("tblItemDetails");
                        $('.chosen-container').css("width", "100%");
                    }
                }
                var json = data.resDebitNoteGet[0].ResDebitItemList;
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        var a = parseInt(key) + 1;
                        $("#additems_" + a).val(json[key].ItemId);
                        $("#desc_" + a).val(json[key].Description);
                        $("#price_" + a).val(json[key].Price);
                        $("#unt_" + a).val(json[key].Quantity);
                        $("#unit_" + a).val(json[key].Unit);
                        $("#tax_" + a).val(json[key].Tax);
                        performCalculation(a);
                    }
                }
            }
            $("#TA_notes").val(data.resDebitNoteGet[0].Note);
            $(".chosen-select-deselect").trigger("chosen:updated");

            $("#debitnotetable").hide(800);
            $("#debitnote").show(800);

            TotalAmount();
        }
        else {
            AlertSuc.alertsuccess("error", "Couldn't fetch records")
        }
    }
}


$(document).ready(function () {
    $("#country").val("India")
    $("#preloader").show();
    $("#billno").attr("disabled", "disabled");
    $.validator.setDefaults({ ignore: ":hidden:not(.chosen-select-deselect)" });
    $("#frm_debit").validate({
        rules: {
            debitdate: { required: true },
            debitduedate: { required: true },
            debitnoteto: { valueNotEquals: "" },
            invrefno: { valueNotEquals: "" },
            paymentterms: { valueNotEquals: "" },
        },
        messages: {
            debitnoteto: { valueNotEquals: "Please select a Debit Note Vendor" },
            addnewexp: { valueNotEquals: "Please select a Expense Type" },
            paymentterms: { valueNotEquals: "Please select a Payment Term" }
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);
        }
    });

    $("#btn_SaveDebitNote").click(function () {
        if ($("#frm_debit").valid()) {
            var PurchaseItemList = [];
            var i = 1;
            $("#tblItemDetails tr").each(function () {
                var Obj = {
                    "DebitId": $("#hdnPurchaseId").val(),
                    "DebitNo": $("#billno").val(),
                    "ItemId": $("#additems_" + i).val(),
                    "Description": $("#desc_" + i).val(),
                    "Price": $("#price_" + i).val(),
                    "Quantity": $("#unt_" + i).val(),
                    "Unit": $("#unit_" + i).val(),
                    "Tax": $("#tax_" + i).val(),
                    "Amount": $("#Amount_" + i).val(),
                    "Igst": $("#taxseperation_" + i).find(".igstAmt").text(),
                    "Cgst": $("#taxseperation_" + i).find(".cgstAmt").text(),
                    "Sgst": $("#taxseperation_" + i).find(".sgstAmt").text(),
                    "Utgst": $("#taxseperation_" + i).find(".utgstAmt").text(),
                    "Cess": $("#cess").val()

                }
                PurchaseItemList.push(Obj);
                i++;
            });
            var BillObject = new Object();
            BillObject = {
                "DebitId": $("#hdnPurchaseId").val(),
                "CustomerId": $("#debitnoteto").val(),
                "DebitNo": $("#billno").val(),
                "DebitDate": $("#debitdate").val(),
                "DueDate": $("#debitduedate").val(),
                "InvoiceRefNo": $("#invrefno").val(),
                "PaymentTerm": $("#paymentterms").val(),
                "ShippingAddress1": $("#shipaddress1").val(),
                "ShippingAddress2": $("#shipaddress2").val(),
                "City": $("#shipcity").val(),
                "State": $("#shippingState").val(),
                "PinCode": $("#pincode").val(),
                "Country": "India",
                "RefNo": $("#refno").val(),
                "AttachmentUrl": null,
                "Note": $("#TA_notes").val(),
                "Discount": $("#disount").val(),
                "TotalAmount": $("#nettotal").text(),
                "Frieght": $("#freight").val(),
                "LabourCharge": $("#labourCharge").val(),
                "InsuranceAmount": $("#InsuranceAmt").val(),
                "OtherCharge": $("#otherCharges").val(),
                "TermCondition": $("#TandC").val(),
                "InvoicePaymentDetail": $("#INVPayDet").val(),
                //"IsTaxInclusive": $('#Inclusive').is(':checked') ? true : false,
                "Advance": null,
                "ReqDebitItemList": PurchaseItemList
            }
            var savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/DebitNoteDetails.ashx?opertype=insert");
            if ($("#hdnPurchaseId").val() != "") {
                savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/DebitNoteDetails.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = savePOurl;
            params['data'] = JSON.stringify(BillObject);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertDebitNote;
            doAjax(params);

        }
    });

    $('#recenttable').DataTable({
        responsive: true,
        paging: false,
        ordering: true,
        info: false,
        searching: false,
        autoWidth: false,
        fixedHeader: {
            header: true,
        }
    });



    $('#debitdetailstbl').DataTable({
        responsive: true,
        paging: false,
        ordering: false,
        info: false,
        searching: false,
        autoWidth: false,
        columnDefs: [{
            orderable: false,
            targets: [1, 2, 3, 4, 5, 6, 7, 8]
        }]

    });
    //----accordian tabs

    //---------
    $('#adddebitnote').click(function () {
        getLastBillId();
        $("#debitnotetable").hide(800);
        $("#debitnote").show(800);

    });

    $('#backtodebit').click(function () {
        AlertSuc.clear_form_elements("frm_debit");
        $("#frm_debit").find('select').each(function () {
            $(this).val("");
        });
        $(".chosen-select-deselect").trigger("chosen:updated");

        $("#debitnote").hide(800);
        $("#debitnotetable").show(800);

    });
    //---
    $('#debitdate').datepicker({
        todayBtn: 1,
        autoclose: true,
        todayHighlight: true,
        //startDate: today
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#debitduedate').datepicker('setStartDate', minDate);
    });
    $('#debitduedate').datepicker({
        autoclose: true,
        todayHighlight: true
    }).on('changeDate', function (selected) {
        var maxDate = new Date(selected.date.valueOf());
        $('#debitdate').datepicker('setEndDate', maxDate);
    }); /**/



    $(document).on('click', '.del', function () {
        var index = $(this).closest('tr').index();
        $(this).parent().parent().remove();
        for (var i = index; i < $('table tbody tr').children().length; i++) {
            $('table tbody tr:nth-child(' + i + ') td:first-child').text(i);
        }
    });

    $(document).on('click', '.add', function () {
        var ParentRow = $("table tr.data-wrapper").last();
        var newId = "";
        clone.find('td').each(function () {
            var el = $(this).find(':first-child');
            var id = el.attr('id') || null;
            if (id) {
                var i = id.substr(id.length - 1);
                if (newId == "") {
                    newId = parseInt(i) + 1;
                }
                var prefix = id.substr(0, (id.length - 1));
                el.attr('id', prefix + (+i + 1));
                el.attr('name', prefix + (+i + 1));
            }
        });
        clone.find('input:text').val('');

        clone.clone(true).insertAfter(ParentRow);
        var myTemplate = $.templates("#tblItemsDropdown");
        var html = myTemplate.render(ItemDetailsObj);
        $("#additems_" + newId).append(html);

        $('tr.data-wrapper:last select').chosen();
        newId = "";
        $(this).val('');
        $(this).attr('class', 'del');
        $('.chosen-container').css("width", "100%");
        addSerialNumber("tblItemDetails");
    });

    $(document).on('change', '.userItemDetails', function (e) {
        // triggers when whole value changed
        var selectedId = $(this).attr("id").split("_")[1];
        $("#desc_" + selectedId).val($('option:selected', this).attr("ItemDescription"));
        $("#price_" + selectedId).val($('option:selected', this).attr("Price"));
        // var tax = $("#taxdetails option:selected").val();
        $('#tax_' + selectedId).val($('option:selected', this).attr("Tax"));
        $(".chosen-select-deselect").trigger("chosen:updated");

    });

    $(document).on("click", ".delete", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getdeletePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/DebitNoteDetails.ashx?opertype=delete");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getdeletePOurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.deleteDebitNotes;
        doAjax(params);
    });

    $(document).on("click", ".edit", function () {
        //$("#invoiceto").find('option').not(':first').remove();
        //getCustomerList();
        getUserProfileDetails();
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/DebitNoteDetails.ashx?opertype=getdebitNoteDetails");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getPObyIdurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.getDebitDetailsbyId;
        setTimeout(function () { doAjax(params); }, 10);
    });

    //Call Vendor List
    getVendorList();
    //CallItemList
    getItemList();
    //Call Payment Term
    getPaymentTerms();
    //Call TDS
    getTDSList();
    getLastBillId();
    //get Bill NO 
    getBillNODetails();
    // Get debit details
    getDebitNoteList();

    $(document).on('keyup change', '.calculate', function () {
        var Id = $(this).attr("id").split("_")[1];
        performCalculation(Id);
    });

    $(document).on('keyup change', '#disount, #debitnoteto, #shippingState, #freight, #labourCharge, #InsuranceAmt, #otherCharges, #cess', function () {
        $("#tblItemDetails tr").each(function () {
            var Id = $(this).find("td:nth-child(2) select").attr("id").split("_")[1];
            performCalculation(Id);
        });

    });
    $("#chkRound").change(function () {
        if (this.checked) {
            $("#nettotal").text($("#roundamt").text());
        }
        else {
            $("#nettotal").text($("#totalamt").text());
        }
    });
});
