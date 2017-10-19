var ItemDetailsObj = new Object();
var UTList = ["Andaman and Nicobar Islands", "Dadra and Nagar Haveli", "Lakshadweep", "Puducherry", "Chandigarh", "Daman and Diu", "New Delhi"];

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

var clone = $("table tr.data-wrapper:first").clone(true);
var P_clone_Pdf = "";

function TotalAmount() {
    var totalAmt = 0;
    $(".amtdetails").each(function () {
        if (parseFloat($(this).val()) > 0) {
            totalAmt = totalAmt + parseFloat($(this).val());
        }

    });
    var CSGT = 0; var SGST = 0; var IGST = 0; var UTGST = 0; var CessTotal = 0
    $("#totalcgst").text(0);
    $("#totalsgst").text(0);
    $("#totaligst").text(0);
    $("#totalugst").text(0);
    $(".cessAmtFull").each(function () {
        if (parseFloat($(this).text()) > 0) {
            CessTotal = CessTotal + parseFloat($(this).text());
            $("#cess").val(CessTotal.toFixed(2));
            $("#P_TotCess").text(CessTotal.toFixed(2));
        }

    });
    $(".cgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            CSGT = CSGT + parseFloat($(this).text());
            $("#totalcgst").text(CSGT);
            $("#P_CGSTAMT").text(CSGT);
        }

    });
    $(".sgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            SGST = SGST + parseFloat($(this).text());
            $("#totalsgst").text(SGST);
            $("#P_SGSTAMT").text(SGST);
        }

    });
    $(".igstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            IGST = IGST + parseFloat($(this).text());
            $("#totaligst").text(IGST);
            $("#P_IGSTAMT").text(IGST);
        }

    });
    $(".utgstAmt").each(function () {
        if (parseFloat($(this).text()) > 0) {
            UTGST = UTGST + parseFloat($(this).text());
            $("#totalugst").text(UTGST);
            $("#P_UTGSTAMT").text(UTGST);
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
    $("#P_TotalAMT").text(totalAmt.toFixed(2));
    $("#roundamt").text(Math.round(RoundOffValue) + ".00");
    $("#nettotal").text(NetTotal.toFixed(2));
    $("#P_nettotal").text(NetTotal.toFixed(2));
    $("#AmtWords").text(AlertSuc.number2text(NetTotal.toFixed(2)));

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

    var options = $("#creditnoteto option:selected");
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
    if (parseFloat($("#tax_" + id).val()) > 0) {

        tax = gross * (parseFloat(parseInt($("#tax_" + id).val()) / 100));
    }
    var cess = 0
    if (parseFloat($("#cess_" + id).val()) > 0) {
        cess = gross * (parseFloat(parseFloat($("#cess_" + id).val()) / 100));
    }
    $("#cess_" + id).parent().find(".cessAmt").text(cess.toFixed(2));
    $("#P_CESS_AMT_" + id).text(cess.toFixed(2));

    if (stateMatches && !isUnionteritory) {
        $("#taxseperation_" + id).find(".cgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".cgstAmt").text(parseFloat(parseInt(tax) / 2));

        $("#P_CGSTRate_" + id).text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#P_CGSTAmount_" + id).text(parseFloat(parseInt(tax) / 2));

        $("#taxseperation_" + id).find(".cgst-sep").show();

        $("#taxseperation_" + id).find(".sgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".sgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".sgst-sep").show();

        $("#P_SGSTRate_" + id).text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#P_SGSTAmount_" + id).text(parseFloat(parseInt(tax) / 2));

        $("#taxseperation_" + id).find(".igst").text("0");
        $("#taxseperation_" + id).find(".igstAmt").text("0");
        $("#taxseperation_" + id).find(".utgst").text("0");
        $("#taxseperation_" + id).find(".utgstAmt").text("0");
        $("#taxseperation_" + id).find(".igst-sep").hide();
        $("#taxseperation_" + id).find(".utgst-sep").hide();

        $("#P_IGSTRate_" + id).text("0");
        $("#P_IGSTAmount_" + id).text("0");
        $("#P_UTGSTRate_" + id).text("0");
        $("#P_UTGSTAmount_" + id).text("0");
    }
    else if (!stateMatches) {
        $("#taxseperation_" + id).find(".igst").text(parseFloat(parseInt($("#tax_" + id).val())));
        $("#taxseperation_" + id).find(".igstAmt").text(parseFloat(parseInt(tax)));
        $("#taxseperation_" + id).find(".igst-sep").show();

        $("#P_IGSTRate_" + id).text(parseFloat(parseInt($("#tax_" + id).val())));
        $("#P_IGSTAmount_" + id).text(parseFloat(parseInt(tax)));

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

        $("#P_CGSTRate_" + id).text("0");
        $("#P_CGSTAmount_" + id).text("0");
        $("#P_SGSTRate_" + id).text("0");
        $("#P_SGSTAmount_" + id).text("0");
        $("#P_UTGSTRate_" + id).text("0");
        $("#P_UTGSTAmount_" + id).text("0");

    }
    else if (stateMatches && isUnionteritory) {
        $("#taxseperation_" + id).find(".cgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".cgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".cgst-sep").show();

        $("#P_CGSTRate_" + id).text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#P_CGSTAmount_" + id).text(parseFloat(parseInt(tax) / 2));

        $("#taxseperation_" + id).find(".utgst").text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#taxseperation_" + id).find(".utgstAmt").text(parseFloat(parseInt(tax) / 2));
        $("#taxseperation_" + id).find(".utgst-sep").show();

        $("#P_UTGSTRate_" + id).text(parseFloat(parseInt($("#tax_" + id).val()) / 2));
        $("#P_UTGSTAmount_" + id).text(parseFloat(parseInt(tax) / 2));

        $("#taxseperation_" + id).find(".igst").text("0");
        $("#taxseperation_" + id).find(".igstAmt").text("0");
        $("#taxseperation_" + id).find(".igst-sep").hide();
        $("#taxseperation_" + id).find(".sgst").text("0");
        $("#taxseperation_" + id).find(".sgstAmt").text("0");
        $("#taxseperation_" + id).find(".sgst-sep").hide();

        $("#P_IGSTRate_" + id).text("0");
        $("#P_IGSTAmount_" + id).text("0");
        $("#P_SGSTRate_" + id).text("0");
        $("#P_SGSTAmount_" + id).text("0");
    }
    //calculate the amount including TAX
    var Amount = (gross + tax + cess).toFixed(2);
    $("#Amount_" + id).val(Amount);
    $("#P_TotalAmount_" + id).text(Amount);
    TotalAmount();

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

//Customer List
function getCustomerList() {
    var req = { "userId": "" };
    var getCustomerListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getCustomerListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getCustomerdetails;
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

function getLastAdvanceId() {
    var req = { "userId": "" };
    var getLastBillIdUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetLastInsertedAdvance.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getLastBillIdUrl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.retriveLastAdvanceId;
    doAjax(params);
}
function getInvoiceNODetails() {
    var req = { "userId": "" };
    var getBillNODetailsUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillRefList.ashx?opertype=invoice");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getBillNODetailsUrl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.GetInvoiceNoDetails;
    doAjax(params);
}
function getAdvanceDetails() {
    var req = { "userId": "" };
    var getDebitListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/AdvanceDetails.ashx?opertype=get");

    var params = $.extend({}, doAjax_params_default);
    params['url'] = getDebitListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getCreditNoteDetails;
    doAjax(params);
}

function getUserProfileDetails() {
    // actionType = "U";
    var _handlerUrl = generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/Profile.ashx');
    var reqUserId = { "UserId": 0 }
    $.ajax({
        type: "POST",
        url: _handlerUrl,
        data: JSON.stringify(reqUserId),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            //var respCode = parseInt(data.ResponseCode);
            $("#P_contactDet").text(data.Name);
            $("#P_Email").text(data.EmailId);
            $("#P_contact").text(data.ContactNo);
            //"LogoUrl": null,
            $("#P_Add1").text(data.AddressLine1);
            $("#P_Add2").text(data.AddressLine2);
            $("#P_State").text(data.State);
            $("#P_city").text(data.City);
            $("#P_Country").text("India");
            $("#P_pin").text(data.PinCode);
            $("#P_Pan").text(data.PanNo);
            $("#vattin").text(data.Vat_TinNo);
            $("#P_Gstn").text(data.GstinNo);
            $("#P_website").text(data.WebsiteUrl);

            $(".chosen-select-deselect").trigger("chosen:updated");

        },
        error: function (data, success, error) {
            alert("Eror " + error);
        }
    });
}

var responseDetails = {
    getCustomerdetails: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resCustomer != null) {
                var myTemplate = $.templates("#tblCustomerDropdown");
                var html = myTemplate.render(data.resCustomer);
                $("#advanceto").append(html);
                $("#advanceto").trigger("chosen:updated");

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
    retriveLastAdvanceId: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $("#billno").val(data.Count).attr("disabled", "disabled");
        }
    },
    insertAdvance: function (data) {
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
    getCreditNoteDetails: function (data) {
        // if (parseInt(data.resEstimateGetList.ResponseCode) == 0) {
        if (data.resAdvanceGetList != null) {
            var myTemplate = $.templates("#tblAdvanceDetails");
            var html = myTemplate.render(data.resAdvanceGetList);
            $("#advanceDetails").html(html);
            addSerialNumber("advanceDetails");
            $('#advancetbl').DataTable({
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
    deleteAdvance: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            AlertSuc.alertsuccess("success", data.ResponseMessage);
            window.location.reload(true);
        }
    },
    GetInvoiceNoDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            var myTemplate = $.templates("#BillIDDetails");
            var html = myTemplate.render(data.resrefIdList);
            $("#invrefno").append(html);
            $("#invrefno").trigger("chosen:updated");
        }
    },
    getAdvanceDetailsbyId: function (data) {
        if (data.resAdvanceGetList != null) {
            $('#advanceto').val(data.resAdvanceGetList[0].CustomerId);
            $("#billno").val(data.resAdvanceGetList[0].AdvanceNo).attr("disabled", "disabled");
            $("#podate").val(convertDate(data.resAdvanceGetList[0].AdvanceDate.split("T")[0]));
            $("#paymentmetod").val(data.resAdvanceGetList[0].PaymentTerm);
            $("#refno").val(data.resAdvanceGetList[0].RefNo);
            $("#shipaddress1").val(data.resAdvanceGetList[0].ShippingAddress1);
            $("#shipaddress2").val(data.resAdvanceGetList[0].ShippingAddress2);
            $("#shipcity").val(data.resAdvanceGetList[0].City);
            $("#pincode").val(data.resAdvanceGetList[0].PinCode);
            $("#shippingState").val(data.resAdvanceGetList[0].State);
            if (data.resAdvanceGetList[0].Cess != null && data.resAdvanceGetList[0].Cess != undefined) {
                $("#cess").val(data.resAdvanceGetList[0].Cess);
            }
            $("#freight").val(data.resAdvanceGetList[0].Frieght);
            $("#labourCharge").val(data.resAdvanceGetList[0].LabourCharge);
            $("#InsuranceAmt").val(data.resAdvanceGetList[0].InsuranceAmount);
            $("#otherCharges").val(data.resAdvanceGetList[0].OtherCharge);
            $("#TandC").val(data.resAdvanceGetList[0].TermCondition);
            $("#invrefno").val(data.resAdvanceGetList[0].InvoiceRefNo);
            $("#INVPayDet").val(data.resAdvanceGetList[0].InvoicePaymentDetail);
            $("#disount").val(data.resAdvanceGetList[0].Discount);
            if (data.resAdvanceGetList[0].ResAdvanceItemList != null) {
                if (data.resAdvanceGetList[0].ResAdvanceItemList.length > 0) {
                    $("#tblItemDetails").find("tr:gt(0)").remove();
                    if (data.resAdvanceGetList[0].ResAdvanceItemList.length > 1) {
                        $("#add_1").attr('class', 'del');
                    }
                    else {
                        $("#add_1").attr('class', 'add');
                    }
                    P_clone_Pdf = $("#P_ItemDetails tr.itemdetailsPDF:first").clone(true);

                    for (var b = 1; b <= (data.resAdvanceGetList[0].ResAdvanceItemList.length) ; b++) {
                        if (b > 1) {
                            var ParentRow = $("table tr.data-wrapper").last();
                            var P_ParentRow = $("#P_ItemDetails tr.itemdetailsPDF").last();
                            var newId = ""; var P_newId = "";

                            // for PDF
                            P_clone_Pdf.find('td').each(function () {
                                var elpfd = $(this).find(':first-child');
                                var idpdf = elpfd.attr('id') || null;
                                if (idpdf) {
                                    //var i = id.substr(id.length - 1);
                                    var i_pdf = b;
                                    if (P_newId == "") {
                                        P_newId = b;
                                    }
                                    var prefix = idpdf.substr(0, (idpdf.length - 1));
                                    elpfd.attr('id', prefix + (+i_pdf));
                                    elpfd.attr('name', prefix + (+i_pdf));
                                }
                            });
                            P_clone_Pdf.find('span').text('');

                            P_clone_Pdf.clone(true).insertAfter(P_ParentRow);

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

                            if (b < data.resAdvanceGetList[0].ResAdvanceItemList.length) {
                                $("#add_" + b).attr('class', 'del');
                            }
                            else {
                                $("#add_" + b).attr('class', 'add');
                            }

                            addSerialNumber("tblItemDetails");
                            $('.chosen-container').css("width", "100%");
                        }
                    }
                    var json = data.resAdvanceGetList[0].ResAdvanceItemList;
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            var a = parseInt(key) + 1;
                            $("#additems_" + a).val(json[key].ItemId);
                            $("#desc_" + a).val(json[key].Description);
                            $("#price_" + a).val(json[key].Price);
                            $("#unt_" + a).val(json[key].Quantity);
                            $("#unit_" + a).val(json[key].Unit);
                            $("#tax_" + a).val(json[key].Tax);
                            if (json[key].Cess) {
                                $("#cess").val(json[key].Cess);
                                $("#P_CESS_" + a).text(json[key].Cess);
                            }
                            $("#P_hsnId_" + a).text(json[key].ItemId);
                            $("#P_Price_" + a).text(json[key].Price);
                            $("#P_Qty_" + a).text(json[key].Quantity);
                            $("#P_Unit_" + a).text(json[key].Unit);
                            $("#P_tax_" + a).text(json[key].Tax);
                            //$("#P_CESS_" + a).text(json[key].Cess);
                            $("#P_Discount_" + a).text(data.resAdvanceGetList[0].Discount);

                            performCalculation(a);
                        }
                    }
                }

            }
            $("#TA_notes").val(data.resAdvanceGetList[0].Note);

            //for PDF code
            $('#P_invoiceto').text(data.resAdvanceGetList[0].CustomerId);
            $("#P_billno").text(data.resAdvanceGetList[0].InvoiceNo).attr("disabled", "disabled");
            $("#P_invNO").text(data.resAdvanceGetList[0].InvoiceNo);
            $("#P_podate").text(convertDate(data.resAdvanceGetList[0].AdvanceDate.split("T")[0]));
            //$("#P_duedate").text(convertDate(data.resAdvanceGetList[0].DueDate.split("T")[0]));
            $("#P_refno").text(data.resAdvanceGetList[0].RefNo);
            $("#P_shipadd1").text(data.resAdvanceGetList[0].ShippingAddress1);
            $("#P_shipadd2").text(data.resAdvanceGetList[0].ShippingAddress2);
            $("#P_city").text(data.resAdvanceGetList[0].City);
            $("#P_pincode").text(data.resAdvanceGetList[0].PinCode);
            $("#P_billingstate").text(data.resAdvanceGetList[0].State);
            $("#P_freight").text(data.resAdvanceGetList[0].Frieght);
            $("#P_labourCharge").text(data.resAdvanceGetList[0].LabourCharge);
            $("#P_InsuranceAmt").text(data.resAdvanceGetList[0].InsuranceAmount);
            $("#P_otherCharges").text(data.resAdvanceGetList[0].OtherCharge);
            $("#P_disount").text(data.resAdvanceGetList[0].Discount);
            $("#P_TandC").text(data.resAdvanceGetList[0].TermCondition);
            $("#P_INVPayDet").text(data.resAdvanceGetList[0].InvoicePaymentDetail);

            $(".chosen-select-deselect").trigger("chosen:updated");

            $("#advancetable").hide(800);
            $("#advancedetails").show(800);

            TotalAmount();
        }
        else {
            AlertSuc.alertsuccess("error", "Couldn't fetch records")
        }
    },
    P_editCustDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {

            var EmailBody = "HEREWITH ENCLOSED THE ADVANCE RAISED AGAINST INVOICE REF NO-" + $("#invrefno").val() + "  FOR YOUR REVIEW.";
            $("#EmailBody").val(EmailBody)
            $("#EmailSubject").val("Advance Details against Invoice Ref No-" + $("#invrefno").val());

            var sez = false;
            $("#P_C_Gstn").val(data.GstinNo);
            $("#P_S_Gstn").val(data.GstinNo);
            $("#P_C_contact").val(data.PhoneNo);
            $("#senderEmailId").val(data.EmailId);
            //$("#P_S_contact").val(data.PhoneNo);
            //$("#ContactPerson").val(data.PrimaryContactPerson);
            //$("#servicetax").val(data.ServiceTaxNo);

            if (data.BillingAddress1 != "" || data.BillingAddress1 != "undefined" || data.BillingAddress1 == null) {
                $("#P_C_Add1").text(data.BillingAddress1);
            }
            if (data.BillingAddress2 != "" || data.BillingAddress2 != "undefined" || data.BillingAddress2 == null) {
                $("#P_C_Add2").text(data.BillingAddress2);
            }
            if (data.BillingCity != "" || data.BillingCity != "undefined" || data.BillingCity == null) {
                $("#P_C_city").text(data.BillingCity);
            }
            if (data.BillingState != "" || data.BillingState != "undefined" || data.BillingState == null) {
                $("#P_C_State").text(data.BillingState);
            }
            if (data.BillingPinCode != "" || data.BillingPinCode != "undefined" || data.BillingPinCode == null) {
                $("#P_C_pin").text(data.BillingPinCode);
            }

            if (data.ShippingAddress1 != "" || data.ShippingAddress1 != "undefined" || data.ShippingAddress1 == null) {
                $("#P_S_Add1").text(data.ShippingAddress1);
            }
            if (data.ShippingAddress2 != "" || data.ShippingAddress2 != "undefined" || data.ShippingAddress2 == null) {
                $("#P_S_Add2").text(data.ShippingAddress2);
            }
            if (data.ShippingCity != "" || data.ShippingCity != "undefined" || data.ShippingCity == null) {
                $("#P_S_city").text(data.ShippingCity);
            }
            if (data.ShippingState != "" || data.ShippingState != "undefined" || data.ShippingState == null) {
                $("#P_S_State").text(data.ShippingState);
            }
            if (data.ShippingPinCode != "" || data.ShippingPinCode != "undefined" || data.ShippingPinCode == null) {
                $("#P_S_pin").text(data.ShippingPinCode);
            }
            $("#P_C_Country").text("India");
            $("#P_S_Country").text("India");

        }
    },
}


$(document).ready(function () {  


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

    

    $('#advancedetailstbl').DataTable({
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
    $('#addadvance').click(function () {
        getLastAdvanceId();
        $("#btnSendQuote").hide();
        $("#PrintPdf").hide();
        $("#advancetable").hide(800);
        $("#advancedetails").show(800);

    });

    $('#backtoadvance').click(function () {
        AlertSuc.clear_form_elements("frmAdvance");
        $("#frmAdvance").find('select').each(function () {
            $(this).val("");
        });
        $(".chosen-select-deselect").trigger("chosen:updated");
        $("#advancedetails").hide(800);
        $("#advancetable").show(800);

    });
    //---
    $('#podate').datepicker({
        autoclose: true,
        todayHighlight: true
    });
    $('#duedate').datepicker({
        autoclose: true,
        todayHighlight: true
    });
    //frmAdvance
    $.validator.setDefaults({ ignore: ":hidden:not(.chosen-select-deselect)" });
    $("#frmAdvance").validate({
        rules: {
            podate: { required: true },
            paymentmetod: { valueNotEquals: "" },
            advanceto: { valueNotEquals: "" },
            refno: { required: true }
        },
        messages: {
            advanceto: { valueNotEquals: "Please select a Customer" },
            paymentmetod: { valueNotEquals: "Please select a Payment Method" }
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);
        }
    });
    $("#btn_SaveAdvance").click(function () {
        if ($("#frmAdvance").valid()) {
            var PurchaseItemList = [];
            var i = 1;
            $("#tblItemDetails tr").each(function () {
                var Obj = {
                    "AdvanceId": $("#hdnPurchaseId").val(),
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
                "AdvanceId": $("#hdnPurchaseId").val(),
                "CustomerId": $("#advanceto").val(),
                "AdvanceNo": $("#billno").val(),
                "AdvanceDate": $("#podate").val(),
                "PaymentTerm": $("#paymentmetod").val(),
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
                "Cess": $("#cess").val(),
                "TermCondition": $("#TandC").val(),
                "InvoicePaymentDetail": $("#INVPayDet").val(),
                "InvoiceRefNo": $("#invrefno").val(),
                //"IsTaxInclusive": $('#Inclusive').is(':checked') ? true : false,
                "Advance": null,
                "ReqAdvanceItemList": PurchaseItemList
            }
            var savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/AdvanceDetails.ashx?opertype=insert");
            if ($("#hdnPurchaseId").val() != "") {
                savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/AdvanceDetails.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = savePOurl;
            params['data'] = JSON.stringify(BillObject);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertAdvance;
            doAjax(params);
        }
    });

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

    $(document).on("click", ".edit", function () {
        //$("#invoiceto").find('option').not(':first').remove();
        //getCustomerList();
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        $("#btnSendQuote").show();
        $("#PrintPdf").show();
        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/AdvanceDetails.ashx?opertype=getAdvanceDetails");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getPObyIdurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.getAdvanceDetailsbyId;
        setTimeout(function () { doAjax(params); }, 10);        
    });

    $(document).on("click", ".delete", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        swal({
            title: "Are you sure?",
            text: "Your will not be able to recover this data post deletion!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
       function () {
            var getdeletePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/AdvanceDetails.ashx?opertype=delete");
            var params = $.extend({}, doAjax_params_default);
            params['url'] = getdeletePOurl;
            params['data'] = JSON.stringify(reqId);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.deleteAdvance;
            doAjax(params);
       });
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

    //Call Customer List
    getCustomerList();
    //CallItemList
    getItemList();

    getLastAdvanceId();

    getAdvanceDetails();
    getInvoiceNODetails();

    $(document).on('keyup change', '.calculate', function () {
        var Id = $(this).attr("id").split("_")[1];
        performCalculation(Id);
    });

    $(document).on('keyup change', '#disount, #advanceto, #shippingState, #freight, #labourCharge, #InsuranceAmt, #otherCharges, #cess', function () {
        $("#tblItemDetails tr").each(function () {
            var Id = $(this).find("td:nth-child(2) select").attr("id").split("_")[1];
            performCalculation(Id);
        });

    });

    $("#btnSendQuote").click(function () {
        getUserProfileDetails();
        var CustRequest = new Object();
        $("#hdnCustomerId").val($("#advanceto").val());
        CustRequest = {
            "Id": $("#advanceto").val(),
        }
        var getCustDetailurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=getCustDetail");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getCustDetailurl;
        params['data'] = JSON.stringify(CustRequest);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.P_editCustDetails;
        doAjax(params);
    });

    $("#btn_Sendmail").click(function () {
        var pdfHtml = $("#my-container").html();
        $.ajax({
            type: 'POST',
            url: generateHandlerUrl.getUrl("../HandlerFiles/Manage/SendEmail.ashx"),
            data: {
                html: pdfHtml,
                emailId: $("#senderEmailId").val(),
                emailSubject: $("#EmailSubject").val(),
                content: $("#EmailBody").val(),
                HtmlType: "Advance",
            },
            success: function (data) {
                if (data.ResponseCode == 0) {
                    swal("Email Sent Successfully");
                    $('#sendquote').modal('hide');
                }
            },
            error: function (req, status, error) { }
        });
    });

});
