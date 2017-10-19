$(function () {

    $(".chosen-select").chosen({
        width: "100%"
    });
    $('.chosen-select-deselect').chosen({
        width: "100%",
        allow_single_deselect: true,
        include_group_label_in_selected: true
    });
    $('.chosen-select-deselect').chosen({ parser_config: { copy_data_attributes: true } });

});

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
$('.chosen-select').chosen({ width: "100%" });

var addSerialNumber = function (id) {
    var i = 1
    $('#' + id + ' tr').each(function (index) {
        $(this).find('td:nth-child(1)').html(index + 1);
    });
};

function convertDate(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}

var responseDetails = {
    getVendordetils :function(data)
    {
        var RespCode = parseInt(data.ResponseCode);
        if(RespCode == 0)
        {
            if (data.resVendor != null) {
                var myTemplate = $.templates("#tblVendorDropdown");
                var html = myTemplate.render(data.resVendor);
                $("#purchaseorderto").append(html);
                $("#purchaseorderto").trigger("chosen:updated");

            }
        }
        else
        {

        }
    },
    insertVendordetils: function(data)
    {
        if(parseInt(data.ResponseCode) == 0)
        {
            var Venid = data.Id;
            $('#poorderto').modal('hide');
            if ($("#hdnVendorId").val() != "")
            {
                Venid = $("#hdnVendorId").val();
                $("#hdnVendorId").val("");
            }
            var option = '<option value="' + Venid + '"> ' + $("#companyname").val() + ' </option>'
            $('#purchaseorderto').append(option);
            $('#purchaseorderto').val(Venid);
            $(".chosen-select-deselect").trigger("chosen:updated");
        }
    },
    getExpensedetils: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resExpenseList != null) {
                var myTemplate = $.templates("#tblexpenseDropdown");
                var html = myTemplate.render(data.resExpenseList);
                $("#addnewexp").append(html);
                $("#addnewexp").trigger("chosen:updated");

            }
        }
    },
    insertExpenseDetails: function (data) {
        if(parseInt(data.ResponseCode) == 0)
        {
            var option = '<option value="' + data.Id + '"> ' + $("#newexpense").val() + ' </option>'
            $('#addnewexp').append(option);
            $('#addnewexp').val(data.Id);
            $("#addnewexp").trigger("chosen:updated");
            $("#newexpense").val("");
            $('#newexpenses').modal('hide');
        }
    },
    searchHsnHscdetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            var html_hsc = ""; var html_hsn;
            $("#userCodes").html("");
            var selCode = $("#crrole option:selected").val();
            if (selCode == "hsc") {
                var InsertHSCTemplate = $.templates("#userHsc");
                html_hsc = InsertHSCTemplate.render(data.resHsnCodeGoods);

            }
            if (selCode == "hsn") {
                var InsertHSNTemplate = $.templates("#userHsn");
                html_hsn = InsertHSNTemplate.render(data.resHsnCodeGoods);
            }
            var html = html_hsc + html_hsn
            $("#userCodes").html(html);
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
    insertPaymentTerms: function(data)
    {
        if(parseInt(data.ResponseCode) == 0)
        {
            var option = '<option value="' + data.Id + '"> ' + $("#newpyterm").val() + ' </option>'
            $('#paymentterms').append(option);
            $('#paymentterms').val(data.Id);
            $("#paymentterms").trigger("chosen:updated");
            $("#newpyterm").val("");
            $('#addpayments').modal('hide');
        }
    },
    retriveLastPOId: function (data) {
        if(parseInt(data.ResponseCode) == 0)
        {
            $("#billno").val(data.PoIdCount).attr("disabled", "disabled");
        }
    },
    getHsnHscdetails: function (data) {
        if(parseInt(data.ResponseCode) == 0)
        {
            var html_hsc = ""; var html_hsn;
            $("#userCodes").html("");
            if (data.reqUserHscList != null) {
                var InsertHSCTemplate = $.templates("#userHsc");
                html_hsc = InsertHSCTemplate.render(data.reqUserHscList);

            }
            if (data.reqUserHsnList != null) {
                var InsertHSNTemplate = $.templates("#userHsn");
                html_hsn = InsertHSNTemplate.render(data.reqUserHsnList);
            }

            var html = html_hsc + html_hsn
            $("#userCodes").html(html);
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
    insertItemDetils: function(data){
        if(parseInt(data.ResponseCode) == 0)
        {
            var selectedId = $("#hdnRowId").val();
            var option = '<option value="' + data.Id + '"> ' + $("#txtItemName").val() + ' </option>'
            $('#additems_' + selectedId).append(option);
            $('#additems_' + selectedId).val(data.Id);
            $('#additems_' + selectedId).trigger("chosen:updated");

            $("#desc_" + selectedId).val($("#TA_desc").val());
            $("#price_" + selectedId).val($("#txtprice").val());
            var tax = $("#taxdetails option:selected").val();
            $('#tax_' + selectedId).val(tax);
            $(".chosen-select-deselect").trigger("chosen:updated");

            $('.itemsadd').modal('hide');
        }
    },
    getPODetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            if (data.reqPurchaseList != null) {
                var myTemplate = $.templates("#tblPOdetailsList");
                var html = myTemplate.render(data.reqPurchaseList);
                $("#tblPOdetails").html(html);
                addSerialNumber("tblPOdetails");
                $('#exptable').DataTable({
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
                //$("#exptable").DataTable();
                //$("#exptable").trigger("update");
            }
            else {
                var noRecords = "<tr><td> No records found</td></tr>";
            }
        }
        else
        {
            AlertSuc.alertsuccess("error", data.ResponseMessage);
        }
        
    },
    editVendorDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $modal = $('#poorderto');
            $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
            var sez = false;
            $("#companyname").val(data.VendorName);
            $("#profileemail").val(data.EmailId);
            $("#gstnno").val(data.GstinNo);
            $("#vattin").val(data.TinVat);
            $("#panno").val(data.PanCardNo);
            $("#contactno").val(data.PhoneNo);
            $("#ContactPerson").val(data.PrimaryContactPerson);
            $("#servicetax").val(data.ServiceTaxNo);
           // $("#tdsrate").val(data.TdsRate);
            $("#address1").val(data.AddressLine1);
            $("#address2").val(data.AddressLine2);
            $("#city").val(data.City);
            $("#pin").val(data.PinCode);
            $("#state").val(data.State);
            $("#bankacname").val(data.AccountHolderName);
            $("#bankacno").val(data.AccountNo);
            $("#ifsc").val(data.IfscCode);

            $(".chosen-select-deselect").trigger("chosen:updated");

            $modal.modal('show', { backdrop: 'static', keyboard: false });
        }
    },
    insertPODetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $("#hdnPurchaseId").val("");
            window.location.reload(true);
        }
    },
    deletePO: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            AlertSuc.alertsuccess("success", data.ResponseMessage);
            window.location.reload(true);
        }
    },
    getPOdetailsbyPOId: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            if (data.resPurchase != null)
            {
                $('#purchaseorderto').val(data.resPurchase.PurchaseVendorId);
                $("#billno").val(data.resPurchase.PoId);
                $("#podate").val(convertDate(data.resPurchase.PoDate.split(" ")[0]));
                $("#duedate").val(convertDate(data.resPurchase.DueDate.split(" ")[0]));
                $('#addnewexp').val(data.resPurchase.ExpenseType);
                $("#refno").val(data.resPurchase.RefId);
                $("#paymentterms").val(data.resPurchase.PaymentTerm);
                $("#disount").val(data.resPurchase.Discount);

                $("#invoicetype").val(data.resPurchase.InvoiceType);
                $("#transactioncode").val(data.resPurchase.TransactionCode);
                $("#transmode").val(data.resPurchase.TransportMode);
                $("#freight").val(data.resPurchase.Freight);
                $("#labourCharge").val(data.resPurchase.LabourCharge);
                $("#InsuranceAmt").val(data.resPurchase.InsuranceAmount);
                $("#otherCharges").val(data.resPurchase.OtherCharge);

                $("#disount").val(data.resPurchase.Discount);
                if (data.resPurchaseItemList.length > 0) {
                    $("#tblItemDetails").find("tr:gt(0)").remove();
                    if (data.resPurchaseItemList.length > 1) {
                        $("#add_1").attr('class', 'del');
                    }
                    else {
                        $("#add_1").attr('class', 'add');
                    }

                    for (var b = 1; b <= (data.resPurchaseItemList.length) ; b++) {
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
                            if (b < data.resPurchaseItemList.length) {
                                $("#add_" + b).attr('class', 'del');
                            }
                            else {
                                $("#add_" + b).attr('class', 'add');
                            }

                            addSerialNumber("tblItemDetails");
                            $('.chosen-container').css("width", "100%");
                        }
                    }
                    var json = data.resPurchaseItemList;
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
                $("#TA_notes").val(data.resPurchase.Notes);
                $("#TandC").val(data.resPurchase.TermCondition);
                $("#PayDet").val(data.resPurchase.InvoicePaymentDetail);
                $(".chosen-select-deselect").trigger("chosen:updated");

                $("#expensetable").hide(800);
                $("#addexpense").show(800);

                TotalAmount();
            }
            
        }
    }
}

function getLastPOId() {
    var req = { "userId": "" };
    var getLastPOIdUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetLastPO.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getLastPOIdUrl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.retriveLastPOId;
    doAjax(params);
}

function getVendorList() {
    var req = { "userId": "" };
    var getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getVendorListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getVendordetils;
    doAjax(params);
}

function getExpenseList() {
    var req = { "userId": "" };
    var getExpenseListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/expenseDetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getExpenseListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getExpensedetils;
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

function getPOList() {
    var req = { "userId": "" };
    var getPOListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getPOListurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getPODetails;
    doAjax(params);
}

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
    if (Mod >= 0 && Mod < 5) {
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

function performCalculation(id)
{
    var stateMatches = false;
    var isUnionteritory = false;

    var options = $("#purchaseorderto option:selected");
    var VendorState = "";
    for (var i = 0; i < options.length; i++) {
        VendorState = $(options[i]).attr('state');
    }
    if (VendorState == $("#hdn_uCountry").val())
    {
        stateMatches = true;
    }
    if ($.inArray(VendorState, UTList) !== -1)
    {
        isUnionteritory = true;
    }
    //alert(VendorState);
    var Price = parseInt($("#price_" + id).val());
    var Quantity = parseInt($("#unt_" + id).val());
    //calculate the tax on the items
    var gross = (Price * Quantity);
    var discount = parseInt($("#disount").val());
    
    if (parseFloat(discount) > 0)
    {
        var disountAmt = gross * (parseFloat(parseInt(discount) / 100));
        gross = gross - disountAmt;
    }
    var tax = 0
    if (parseFloat($("#tax_" + id).val()) > 0)
    {
        
        tax = gross * (parseFloat(parseInt($("#tax_" + id).val()) / 100));
    }
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
    var Amount = (gross + tax).toFixed(2);
    $("#Amount_" + id).val(Amount);
    //calculate the amount including TAX
    var Amount = (gross + tax).toFixed(2);
    $("#Amount_" + id).val(Amount);
    TotalAmount();
    
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

function getHsnHsc() {
    var req = { "userId": "" };
    var getHsnHscTermsurl = generateHandlerUrl.getUrl("../HandlerFiles/Dashboard/GetUserHsnMapping.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getHsnHscTermsurl;
    params['data'] = req;
    params['successCallbackFunction'] = responseDetails.getHsnHscdetails;
    doAjax(params);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57)))
        return false;
    return true;
}

$(document).ready(function () {
    $("#country").val("India")
    $("#preloader").show();
    $("#billno").attr("disabled", "disabled");
    var $target = $('#sidebar-wrapper');
    $target.find("ul li ul").each(function () {
        $(this).removeClass("show");
    });
    $target.find("ul li a").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
        $("#managemenus").addClass("show");
        $("#expense").addClass("active");
    });

    getPOList();
    getVendorList();
    getExpenseList();
    getPaymentTerms();
    getHsnHsc();
    getItemList();


    $('#potable').DataTable({
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
    $('#addpobtn').click(function () {
        $("#expensetable").hide(800);
        $("#addexpense").show(800);

        $('#purchaseorderto').val("");
        $("#billno").val("");
        $("#podate").val("");
        $("#duedate").val("");
        $('#addnewexp').val("");
        $("#refno").val("");
        $("#paymentterms").val("");
        $("#tblItemDetails").find("tr:gt(0)").remove();
        $("#additems_1").val("");
        $("#desc_1").val("");
        $("#price_1").val("");
        $("#unt_1").val("");
        $("#unit_1").val("");
        $("#tax_1").val("");
        $("#Amount_1").val("");
        $("#totalamt").text("00.00");
        $("#roundamt").text("00.00");
        $("#nettotal").text("00.00");
        $("#TA_notes").val("");
        $("#add_1").attr('class', 'add');
        $(".chosen-select-deselect").trigger("chosen:updated");

        getLastPOId();

    });

    $('#backtopo').click(function () {
        $("#addexpense").hide(800);
        $("#expensetable").show(800);

    });

    $('#podate').datepicker({
        todayBtn: 1,
        autoclose: true,
        todayHighlight: true,
        //startDate: today
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#duedate').datepicker('setStartDate', minDate);
    });

    $('#duedate').datepicker({
        autoclose: true,
        todayHighlight: true
    }).on('changeDate', function (selected) {
        var maxDate = new Date(selected.date.valueOf());
        $('#podate').datepicker('setEndDate', maxDate);
    }); /**/

    $("#search").click(function () {
        var selCode = $("#crrole option:selected").val();
        var searchReq = new Object();
        searchReq.HsnOrHsc = selCode;
        searchReq.HsnDetail = $("#txtSearch").val();

        var searchurl = generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacSearchResults.ashx');
        var params = $.extend({}, doAjax_params_default);
        params['url'] = searchurl;
        params['data'] = JSON.stringify(searchReq);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.searchHsnHscdetails;
        doAjax(params);
    });

    $(document).on('click', '.del', function () {
        var index = $(this).closest('tr').index();
        $(this).parent().parent().remove();
        for (var i = index; i < $('table tbody tr').children().length; i++) {
            $('table tbody tr:nth-child(' + i + ') td:first-child').text(i);
        }
        TotalAmount();
    });

    $(document).on('click', '.add', function () {
        var ParentRow = $("table tr.data-wrapper").last();
        var newId = "";
        clone.find('td').each(function () {
            var el = $(this).find(':first-child');
            var id = el.attr('id') || null;
            if (id) {
                var i = id.substr(id.length - 1);
                if (newId == "")
                {
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

    $("#saveExpense").click(function () {
        if ($("#expenseDetails").valid()) {
            var expenseProfile = new Object();
            expenseProfile = { "ExpenseType": $("#newexpense").val() };
            var expenseProfileurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/expenseDetails.ashx?opertype=insert");
            var params = $.extend({}, doAjax_params_default);
            params['url'] = expenseProfileurl;
            params['data'] = JSON.stringify(expenseProfile);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertExpenseDetails;
            doAjax(params);
        }
    });

    $("#savePaymentTerm").click(function () {
        if ($("#frm_addPayment").valid()) {
            var termProfile = new Object();
            termProfile = { "Term": $("#newpyterm").val() };
            var termProfileurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PaymentTerms.ashx?opertype=insert");
            var params = $.extend({}, doAjax_params_default);
            params['url'] = termProfileurl;
            params['data'] = JSON.stringify(termProfile);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertPaymentTerms;
            doAjax(params);
        }
    });
    $.validator.setDefaults({ ignore: ":hidden:not(.chosen-select-deselect)" });
    $("#vendordetails").validate({
        rules: {
            companyname: {
                required: true
            },
            contactno: {
                required: true,
                minlength: 10,
                number: true
            },
            profileemail: {
                required: true,
                email: true
            },
            state: {
                valueNotEquals: ""
            },
        },
        contactno: {
            contactno:"valid no"
        },
        companyname: {
            companyname:"Please provide a company name"
        },
        profileemail: {

            email: "Please enter a valid email address"
        },
        messages: {
            state: { valueNotEquals: "Please select a state" }
        },
        errorPlacement: function (error, element) {
            if (element.attr("name") == "state") {
                $("#stateErr").html(error[0]);
            }
            else
            {
                $("#err_" + element.attr("name")).html(error[0]);
            }
        }
        
    });

    $("#addExpenseDetails").validate({
        rules: {
            podate: { required: true },
            duedate:{required : true },
            purchaseorderto: { valueNotEquals: "" },
            addnewexp: { valueNotEquals: "" },
            paymentterms: { valueNotEquals: "" },
        },
        messages: {
            purchaseorderto: { valueNotEquals: "Please select a Vendor" },
            addnewexp: { valueNotEquals: "Please select a Expense Type" },
            paymentterms: { valueNotEquals: "Please select a Payment Term" }
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);
        }
    });

    $("#expenseDetails").validate({
        rules: {
            newexpense: {
                required: true
            }
        },
        newexpense: {
            newexpense: "Please enter a expense details"
        },
        errorPlacement: function (error, element) {
                $("#err_" + element.attr("name")).html(error[0]);
            
        }
    });

    $("#frm_addPayment").validate({
        rules: {
            newpyterm: {
                required: true
            }
        },
        newpyterm: {
            newpyterm: "Please enter a expense details"
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);

        }
    });

    $("#frm_additem").validate({
        rules: {
            txtItemName: {
                required: true
            },
            txt_hsnhsc: {
                required: true
            },
            txtprice: {
                required: true
            },
            taxdetails: {
                valueNotEquals: "-1"
            },
            dd_Unit: {
                valueNotEquals: "-1"
            },
        },
        txtItemName: {
            txtItemName: "Please enter Item name"
        },
        txt_hsnhsc: {
            txt_hsnhsc: "Please enter Item HSN/HSC details"
        },
        txtprice: {
            txtprice: "Please enter Item price"
        },
        messages: {
            taxdetails: { valueNotEquals: "Please select a tax rate" },
            dd_Unit: { valueNotEquals: "Please select a unit" }
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);

        }
    });

    $("#saveVendor").click(function () {
        
        if ($("#vendordetails").valid())
        {
            $("#hdn_uCountry").val($("#state option:selected").val());
            var vendorProfile = new Object();
            vendorProfile = {
                "VendorId": $("#hdnVendorId").val(),
                "VendorName": $("#companyname").val(),
                "PrimaryContactPerson": $("#ContactPerson").val(),
                "EmailId": $("#profileemail").val(),
                "PhoneNo": $("#profileemail").val(),
                "AddressLine1": $("#address1").val(),
                "AddressLine2": $("#address2").val() + " " + $("#address3").val(),
                "City": $("#city").val(),
                "State": $("#state option:selected").val(),
                "PinCode": $("#pin").val(),
                "PanCardNo": $("#panno").val(),
                "ServiceTaxNo": $("#servicetax").val(),
                "TinVat": $("#vattin").val(),
                "GstinNo": $("#gstnno").val(),
                "AccountNo": $("#bankacno").val(),
                "IfscCode": $("#ifsc").val(),
                "AccountHoderName": $("#bankacname").val(),
                "Note": "",
                "IsReverseCharge": false,
                "IsCompositionVendor": false
            }

            var getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=insert");
            if ($("#hdnVendorId").val() != "")
            {
                getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = getVendorListurl;
            params['data'] = JSON.stringify(vendorProfile);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertVendordetils;
            doAjax(params);
    }
    });

    $("#btnSaveItem").click(function () {
        if ($("#frm_additem").valid()) {
            var ItemRequest = new Object();
            ItemRequest = {
                "ItemName": $("#txtItemName").val(),
                "HsnCodeId": $("#txt_hsnhsc").val(),
                "ItemDescription": $("#TA_desc").val(),
                "Price": $("#txtprice").val(),
                "Tax": $("#taxdetails option:selected").val(),
                "UnitOfMeasures": $("#dd_Unit option:selected").val()
            }
            var saveItemListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/ItemDetails.ashx?opertype=insert");
            var params = $.extend({}, doAjax_params_default);
            params['url'] = saveItemListurl;
            params['data'] = JSON.stringify(ItemRequest);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertItemDetils;
            doAjax(params);

        }
    });

    $("#btnSaveHsnCode").click(function () {
        var hsnCode = $('input[name=rd_HSNHSC]:checked').attr("code");
        var rate = $('input[name=rd_HSNHSC]:checked').attr("rate");
        
        if (rate == "Nil" || rate == "Nill")
        {
            rate = "0";
        }
        $("#txt_hsnhsc").val(hsnCode);
        $("#taxdetails").val(rate);
        $('#codesmodal').modal('hide');
    });

        $("#search").click(function () {
        var selCode = $("#crrole option:selected").val();
        var searchReq = new Object();
        searchReq.HsnOrHsc = selCode;
        searchReq.HsnDetail = $("#txtSearch").val();

        var searchurl = generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacSearchResults.ashx');
        var params = $.extend({}, doAjax_params_default);
        params['url'] = searchurl;
        params['data'] = JSON.stringify(searchReq);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = BillresponseDetails.searchHsnHscdetails;
        doAjax(params);
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

    $("#btn_SubmitPO").click(function () {
        if($("#addExpenseDetails").valid()){
            var PurchaseItemList = [];
            var i = 1;
            $("#tblItemDetails tr").each(function () {
                var Obj = {
                    "PoId": $("#billno").val(),
                    "ItemId": $("#additems_" + i).val(),
                    "Description": $("#desc_" + i).val(),
                    "Price": $("#price_" + i).val(),
                    "Quantity": $("#unt_" + i).val(),
                    "Unit": $("#unit_" + i).val(),
                    "Tax": $("#tax_" + i).val(),
                    "Amount": $("#Amount_" + i).val(),
                    "Discount": $("#disount").val(),
                    "Igst": $("#taxseperation_" + i).find(".igstAmt").text(),
                    "Cgst": $("#taxseperation_" + i).find(".cgstAmt").text(),
                    "Sgst": $("#taxseperation_" + i).find(".sgstAmt").text(),
                    "Utgst": $("#taxseperation_" + i).find(".utgstAmt").text(),
                    "Cess": $("#cess_" + i).val()
                }
                PurchaseItemList.push(Obj);
                i++;
            });

            var POObject = new Object();
            POObject = {            
                "PurchaseId": $("#hdnPurchaseId").val(),
                "PurchaseVendorId": $("#purchaseorderto").val(),
                "PoId": $("#billno").val(),
                "PoDate": $("#podate").val(),
                "DueDate": $("#duedate").val(),
                "PaymentTerm": $("#paymentterms").val(),
                "ExpenseType": $("#addnewexp").val(),
                "RefId": $("#refno").val(),
                "AttachmentUrl": null,
                "Notes": $("#TA_notes").val(),
                "TotalAmount": $("#nettotal").text(),
                "Discount": $("#disount").val(),
                "PurchaseType": $("#purchaseType").val(),
                "PurchaseCode": $("#purchaseCode").val(),
                "PurchaseCreditType": $("#purchasecreditType").val(), 
                "Freight": $("#freight").val(),
                "LabourCharge": $("#labourCharge").val(),
                "InsuranceAmount": $("#InsuranceAmt").val(),
                "OtherCharge": $("#otherCharges").val(),
                "TermCondition": $("#TandC").val(),
                "InvoicePaymentDetail": $("#PayDet").val(),
                "PurchaseItemList": PurchaseItemList
            }
            var savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=insert");
            if ($("#hdnPurchaseId").val() != "")
            {
                savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = savePOurl;
            params['data'] = JSON.stringify(POObject);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = responseDetails.insertPODetails;
            doAjax(params);
    }

    });

    $(".edits").on("click", function () {
        var CustRequest = new Object();
        $("#hdnVendorId").val($("#purchaseorderto").val());
        CustRequest = {
            "Id": $("#purchaseorderto").val(),
        }
        var getCustDetailurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=getVendorDetail");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getCustDetailurl;
        params['data'] = JSON.stringify(CustRequest);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.editVendorDetails;
        doAjax(params);
    });

    $(document).on("click", ".bill", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var url = window.location.href;
        var arr = url.split("/");
        var type = getUrlVars()["usertype"];
        var cmpId = getUrlVars()["cmp_id"];
        var querystring = "billId=" + EditPOId;
        if (type != null && type !== "" && type != undefined) {
            querystring = querystring + '&usertype=company&cmp_id=' + cmpId;
        }
        var hrefval = arr[0] + "//" + arr[2] + "/" + "Manage/Bills.aspx";
        window.location.href = hrefval + (hrefval.match(/\?/) ? '&' : '?') + querystring;
        //
    });

    $(document).on("click", ".delete", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getdeletePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=delete");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getdeletePOurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.deletePO;
        doAjax(params);
    });
    
    $(document).on("click", ".edit", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=getPODetails");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getPObyIdurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = responseDetails.getPOdetailsbyPOId;
        doAjax(params);
    });

    $(document).on('keyup change', '.calculate', function () {
        var Id = $(this).attr("id").split("_")[1];
            performCalculation(Id);
    });

    $(document).on('keyup change', '#disount, #purchaseorderto, #shippingState, #freight, #labourCharge, #InsuranceAmt, #otherCharges, #cess', function () {
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




