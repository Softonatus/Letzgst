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

var BillresponseDetails = {
    getVendordetils: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resVendor != null) {
                var myTemplate = $.templates("#tblVendorDropdown");
                var html = myTemplate.render(data.resVendor);
                $("#purchaseorderto").append(html);
                $("#purchaseorderto").trigger("chosen:updated");
            }
        }
    },
    insertVendordetils: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            var Venid = data.Id;
            $('#poorderto').modal('hide');
            if ($("#hdnVendorId").val() != "") {
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
        if (parseInt(data.ResponseCode) == 0) {
            var option = '<option value="' + data.Id + '"> ' + $("#newexpense").val() + ' </option>'
            $('#addnewexp').append(option);
            $('#addnewexp').val(data.Id);
            $("#addnewexp").trigger("chosen:updated");
            $("#newexpense").val("");
            $('#newexpenses').modal('hide');
        }
    },
    
    retriveLastPOId: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $("#billno").val(data.BillNoCount).attr("disabled", "disabled");
        }
    },
    getHsnHscdetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
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
    getItemDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            ItemDetailsObj = data.resUserItemsList;
            if (ItemDetailsObj != null)
            {
                var myTemplate = $.templates("#tblItemsDropdown");
                var html = myTemplate.render(ItemDetailsObj);
                $("#additems_1").append(html);
                $("#additems_1").trigger("chosen:updated");

                var BillID = getUrlVars()["billId"];
                var typedet = getUrlVars()["usertype"];
                var cmpIddet = getUrlVars()["cmp_id"];

                if (BillID != null && BillID !== "" && BillID != undefined) {
                    setTimeout(function () {
                        var reqId = { "Id": BillID }
                        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/PODetails.ashx?opertype=getPODetails");
                        var params = $.extend({}, doAjax_params_default);
                        params['url'] = getPObyIdurl;
                        params['data'] = JSON.stringify(reqId);
                        params['requestType'] = "POST";
                        params['successCallbackFunction'] = BillresponseDetails.getPOdetailsbyPOId;
                        doAjax(params);
                    }, 1000);
                }
            }
            

        }
    },
    insertItemDetils: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
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
    getTDSDeatilsResp: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            var myTemplate = $.templates("#tblTdsDropdown");
            var html = myTemplate.render(data.resTdsList);
            $("#TdsOption").append(html);
            $("#TdsOption").trigger("chosen:updated");

        }
    },
    getBillDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            if (data.reqBillList != null) {
                var myTemplate = $.templates("#tblBilldetailsList");
                var html = myTemplate.render(data.reqBillList);
                $("#billDetail").html(html);
                addSerialNumber("billDetail");
                $('#pobills').DataTable({
                    responsive: true
                });
            }
            else {
                var noRecords = "<tr><td> No records found</td></tr>";
            }
        }
    },

    insertPODetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            AlertSuc.alertsuccess("success", data.ResponseMessage);
            $("#hdnPurchaseId").val("")
            var BillID = getUrlVars()["billId"];
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
     getPOdetailsbyPOId: function (data) {
         if (parseInt(data.ResponseCode) == 0) {
             if (data.resPurchase != null) {
                 getLastBillId();
                 $('#purchaseorderto').val(data.resPurchase.PurchaseVendorId);
                 $("#billno").val(data.resPurchase.PoId);
                 $("#podate").val(convertDate(data.resPurchase.PoDate.split(" ")[0]));
                 $("#duedate").val(convertDate(data.resPurchase.DueDate.split(" ")[0]));
                 $('#addnewexp').val(data.resPurchase.ExpenseType);
                 $("#refno").val(data.resPurchase.RefId);                 
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
                 $(".chosen-select-deselect").trigger("chosen:updated");

                 $("#expensetable").hide(800);
                 $("#addexpense").show(800);

                 TotalAmount();
             }
          }
     },
     deleteBill: function (data) {
         if (parseInt(data.ResponseCode) == 0) {
             AlertSuc.alertsuccess("success", data.ResponseMessage);
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
     getBilldetailsbyBillId: function (data) {
         if (parseInt(data.ResponseCode) == 0) {
             $('#purchaseorderto').val(data.BillVendorId);
             $("#billno").val(data.BillNo);
             $("#podate").val(convertDate(data.BillDate.split(" ")[0]));
             $("#duedate").val(convertDate(data.DueDate.split(" ")[0]));
             $("#poenddate").val(convertDate((data.EndDate.split(" ")[0])));
             $('#addnewexp').val(data.ExpenseTypeId);
             $("#refno").val(data.RefId);
             $("#paymentterms").val(data.PaymentTerm);
             $("#paymentmethod").val(data.PaymentMethod);
             $("#disount").val(data.Discount);
             $("#TA_notes").val(data.Notes);
             $("#TdsOption").val(data.Tds);

             if (data.reqBillItemList.length > 0) {
                 $("#tblItemDetails").find("tr:gt(0)").remove();
                 if (data.reqBillItemList.length > 1) {
                     $("#add_1").attr('class', 'del');
                 }
                 else {
                     $("#add_1").attr('class', 'add');
                 }

                 for (var b = 1; b <= (data.reqBillItemList.length) ; b++) {
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
                         if (b < data.reqBillItemList.length) {
                             $("#add_" + b).attr('class', 'del');
                         }
                         else {
                             $("#add_" + b).attr('class', 'add');
                         }

                         addSerialNumber("tblItemDetails");
                         $('.chosen-container').css("width", "100%");
                     }
                 }
                 var json = data.reqBillItemList;
                 for (var key in json) {
                     if (json.hasOwnProperty(key)) {
                         var a = parseInt(key) + 1;
                         $("#additems_" + a).val(json[key].ItemId);
                         $("#desc_" + a).val(json[key].Description);
                         $("#price_" + a).val(json[key].Price);
                         $("#unt_" + a).val(json[key].Quantity);
                         $("#unit_" + a).val(json[key].Unit);
                         $("#tax_" + a).val(json[key].Tax);
                         $("#purchase_" + a).val(json[key].PurchaseType);
                         performCalculation(a);
                     }
                 }
             }
             $("#TA_notes").val(data.Notes);
             $(".chosen-select-deselect").trigger("chosen:updated");

             $("#expensetable").hide(800);
             $("#addexpense").show(800);

             TotalAmount();
         }
     }
}

function getLastBillId() {
    var req = { "userId": "" };
    var getLastBillIdUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetLastBillId.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getLastBillIdUrl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.retriveLastPOId;
    doAjax(params);
}

function getVendorList() {
    var req = { "userId": "" };
    var getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getVendorListurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getVendordetils;
    doAjax(params);
}

function getExpenseList() {
    var req = { "userId": "" };
    var getExpenseListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/expenseDetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getExpenseListurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getExpensedetils;
    doAjax(params);
}

function getItemList() {
    var req = { "userId": "" };
    var getitemListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/ItemDetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getitemListurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getItemDetails;
    doAjax(params);
}
function getTDSList() {
    var req = { "userId": "" };
    var getTDSListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetTDSDetails.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getTDSListurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getTDSDeatilsResp;
    doAjax(params);
}

function getBillList() {
    var req = { "userId": "" };
    var getBillListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillDetails.ashx?opertype=get");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getBillListurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getBillDetails;
    doAjax(params);
}

function TotalAmount() {
    var totalAmt = 0;
    $(".amtdetails").each(function () {
        if (parseFloat($(this).val()) > 0) {
            totalAmt = totalAmt + parseFloat($(this).val());
        }

    });
    var tds = $("#TdsOption").val();
    if (parseInt(tds) > 0) {
        totalAmt = totalAmt - tds;
    }
    $("#totalamt").text(totalAmt.toFixed(2));
    $("#roundamt").text(Math.round(totalAmt.toFixed(2)) + ".00");
    $("#nettotal").text(totalAmt.toFixed(2));
}

function performCalculation(id) {
    var stateMatches = false;
    var isUnionteritory = false;

    var options = $("#purchaseorderto option:selected");
    var VendorState = "";
    for (var i = 0; i < options.length; i++) {
        VendorState = $(options[i]).attr('state');
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

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57)))
        return false;
    return true;
}

function getHsnHsc() {
    var req = { "userId": "" };
    var getHsnHscTermsurl = generateHandlerUrl.getUrl("../HandlerFiles/Dashboard/GetUserHsnMapping.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getHsnHscTermsurl;
    params['data'] = req;
    params['successCallbackFunction'] = BillresponseDetails.getHsnHscdetails;
    doAjax(params);
}



$(document).ready(function () {
    $("#preloader").show();
    var BillID = getUrlVars()["billId"];
    if (BillID == null || BillID == "" || BillID == undefined) {
        getBillList();
    }

    getVendorList();
    getExpenseList();
    getHsnHsc();
    getItemList();
    getTDSList();
    $("#billno").attr("disabled", "disabled");


    $('#potable').DataTable({
        responsive: true,
        paging: false,
        ordering: false,
        info: false,
        searching: false,
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
        $("#paymentmethod").val("");
        $("#poenddate").val("");
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
        $("#disount").val("");
        $(".chosen-select-deselect").trigger("chosen:updated");

        getLastBillId();

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
            contactno: "valid no"
        },
        companyname: {
            companyname: "Please provide a company name"
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
            else {
                $("#err_" + element.attr("name")).html(error[0]);
            }
        }

    });

    $("#addBillDetails").validate({
        rules: {
            podate: { required: true },
            duedate: { required: true },
            purchaseorderto: { valueNotEquals: "" },
            addnewexp: { valueNotEquals: "" },
            paymentmethod: { valueNotEquals: "" },
        },
        messages: {
            purchaseorderto: { valueNotEquals: "Please select a Vendor" },
            addnewexp: { valueNotEquals: "Please select a Expense Type" },
            paymentmethod: { valueNotEquals: "Please select a Payment Term" }
        },
        errorPlacement: function (error, element) {
            //var chosenId = "#" + (element.attr("id")) + "_chosen";
            //$(chosenId).css("border", "1px solid red")
            $("#err_" + element.attr("name")).html(error[0]);
        },
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
            params['successCallbackFunction'] = BillresponseDetails.insertItemDetils;
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
        params['successCallbackFunction'] = BillresponseDetails.editVendorDetails;
        doAjax(params);
    });

    $(document).on("click", ".delete", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getdeletePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillDetails.ashx?opertype=delete");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getdeletePOurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = BillresponseDetails.deleteBill;
        doAjax(params);
    });

    $(document).on("click", ".edit", function () {
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillDetails.ashx?opertype=getPODetails&act=edit");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getPObyIdurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = BillresponseDetails.getBilldetailsbyBillId;
        doAjax(params);
    });

    $("#btn_SubmitBill").click(function () {
        if ($("#addBillDetails").valid()) {
            var PurchaseItemList = [];
            var i = 1;
            $("#tblItemDetails tr").each(function () {
                var Obj = {
                    "BillNo": $("#billno").val(),
                    "ItemId": $("#additems_" + i).val(),
                    "Description": $("#desc_" + i).val(),
                    "Price": $("#price_" + i).val(),
                    "Quantity": $("#unt_" + i).val(),
                    "Unit": $("#unit_" + i).val(),
                    "Tax": $("#tax_" + i).val(),
                    "Amount": $("#Amount_" + i).val(),
                    "PurchaseType": $("#purchase_" + i).val()
                }
                PurchaseItemList.push(Obj);
                i++;
            });

            var BillObject = new Object();
            BillObject = {
                "BillId": $("#hdnPurchaseId").val(),
                "BillVendorId": $("#purchaseorderto").val(),
                "BillNo": $("#billno").val(),
                "BillDate": $("#podate").val(),
                "DueDate": $("#duedate").val(),
                "EndDate": $("#poenddate").val(),
                "PaymentTerm": $("#paymentterms").val(),
                "ExpenseTypeId": $("#addnewexp").val(),
                "RefId": $("#refno").val(),
                "AttachmentUrl": null,
                "Notes": $("#TA_notes").val(),
                "Discount": $("#disount").val(),
                "TotalAmount": $("#nettotal").text(),
                "IsreverseChargeBill": false,
                "IsRecurring": false,
                "IsDeleted": false,
                "RecurringFrequency": 0,
                "Cess": 0,
                "PaymentMethod": $("#paymentmethod").val(),
                "Tds": $("#TdsOption").val(),
                "reqBillItemList": PurchaseItemList
            }
            var savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillDetails.ashx?opertype=insert");
            if ($("#hdnPurchaseId").val() != "") {
                savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/BillDetails.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = savePOurl;
            params['data'] = JSON.stringify(BillObject);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = BillresponseDetails.insertPODetails;
            doAjax(params);
        }

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

    $("#saveVendor").click(function () {
        if ($("#vendordetails").valid()) {
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
                if ($("#hdnVendorId").val() != "") {
                    getVendorListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/InsertVendor.ashx?opertype=update");
                }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = getVendorListurl;
            params['data'] = JSON.stringify(vendorProfile);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = BillresponseDetails.insertVendordetils;
            doAjax(params);
        }
    });

    $('#backtopo').click(function () {
        $("#addexpense").hide(800);
        $("#expensetable").show(800);
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

    });
    //---
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

    $('#poenddate').datepicker({
        autoclose: true,
        todayHighlight: true
    });
    //$('#payrecord').datepicker({
    //    autoclose: true,
    //    todayHighlight: true
    //});

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

    $(document).on('change', '.userItemDetails', function (e) {
        // triggers when whole value changed
        var selectedId = $(this).attr("id").split("_")[1];
        $("#desc_" + selectedId).val($('option:selected', this).attr("ItemDescription"));
        $("#price_" + selectedId).val($('option:selected', this).attr("Price"));
        // var tax = $("#taxdetails option:selected").val();
        $('#tax_' + selectedId).val($('option:selected', this).attr("Tax"));
        $(".chosen-select-deselect").trigger("chosen:updated");

    });

    $("#btnSaveHsnCode").click(function () {
        var hsnCode = $('input[name=rd_HSNHSC]:checked').attr("code");
        var rate = $('input[name=rd_HSNHSC]:checked').attr("rate");
        if (rate == "Nil" || rate == "Nill") {
            rate = "0";
        }
        $("#txt_hsnhsc").val(hsnCode);
        $("#taxdetails").val(rate);
        $('#codesmodal').modal('hide');
    });

    $("#search").click(function () {
        var selCode = $("#crrole option:selected").val();
        if (selCode != "" && selCode != "-1")
        {            
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



    $("#purchaseorderto").on("change", function () {
        $modal = $('#poorderto');
        if ($(this).val() === 'addnewpoto') {
            $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
            $modal.modal('show', { backdrop: 'static', keyboard: false });
            $(this).val("");
        }
        if ($("#purchaseorderto option:selected").val() !== "addnewpoto") {
            $('.edits').show();
        }
    });

    $("#addnewexp").on("change", function () {
        $modal = $('#newexpenses');
        if ($(this).val() === 'newexpense') {
            $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
            $modal.modal('show', { backdrop: 'static', keyboard: false });
            $(this).val("");
        }
    });

    $(document).on({
        change: function () {
            $modal = $('.itemsadd');
            if ($(this).val() === 'addnewitem') {
                $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
                var dd_Id = $(this).parent().parent().find("select").attr("id").split("_")[1];
                $("#hdnRowId").val(dd_Id);
                $modal.modal('show', { backdrop: 'static', keyboard: false });
                $(this).val("");
            }
        }
    }, '.data-wrapper select');

    $("#chkRound").change(function () {
        if (this.checked) {
            $("#nettotal").text($("#roundamt").text());
        }
        else {
            $("#nettotal").text($("#totalamt").text());
        }
    });

    $(document).on('keyup change', '.calculate', function () {
        var Id = $(this).attr("id").split("_")[1];
        performCalculation(Id);
    });

    $(document).on('keyup change', '#disount', function () {
        $("#tblItemDetails tr").each(function () {
            var Id = $(this).find("td:nth-child(2) select").attr("id").split("_")[1];
            performCalculation(Id);
        });

    });

});

//// This script block should be placed after jQuery, jQuery Validate and jQuery Validate
//// Unobtrusive plugins have been loaded.
//$(function () {
//    // retrieves the current jQuery validator for the form
//    var $validator = $("form").validate();
//    // We're going to override the default highlight method from jQuery when applying
//    // our css class for an error
//    $validator.settings.highlight = function (element, errorClass, validClass) {
//        var $element = $(element);
//        if ($element.hasClass("chosen-select-deselect")) {
//            // It's a chosen element so move to the next element in the DOM 
//            // which should be your container for chosen.  Add the error class to 
//            // that instead of the hidden select
//            $element.next().addClass(errorClass).removeClass(validClass);
//        }
//        else if (element.type === "radio") {
//            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
//        } else {
//            $element.addClass(errorClass).removeClass(validClass);
//        }
//    };
//    // We're going to override the default unhighlight method from jQuery when removing
//    // our css class for an error
//    $validator.settings.unhighlight = function (element, errorClass, validClass) {
//        var $element = $(element);
//        if ($element.hasClass("chosen-select-deselect")) {
//            // It's a chosen element so move to the next element in the DOM 
//            // which should be your container for chosen.  Add the error class to 
//            // that instead of the hidden select
//            $element.next().removeClass(errorClass).addClass(validClass);
//        }
//        else if (element.type === "radio") {
//            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
//        } else {
//            $element.removeClass(errorClass).addClass(validClass);
//        }
//    };
//});
//-------open modal for poorder to
