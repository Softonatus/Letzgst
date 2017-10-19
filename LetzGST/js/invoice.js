$(function () {

    $(".chosen-select").chosen({
        width: "100%"
    });
    $('.chosen-select-deselect').chosen({
        width: "100%",
        allow_single_deselect: true,
        include_group_label_in_selected: true
    });

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
var P_clone_Pdf = "";


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

var invoiceResponse = {
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
            if (ItemDetailsObj != null) {
                var myTemplate = $.templates("#tblItemsDropdown");
                var html = myTemplate.render(ItemDetailsObj);
                $("#additems_1").append(html);
                $("#additems_1").trigger("chosen:updated");

                var BillID = getUrlVars()["EstId"];
                var typedet = getUrlVars()["usertype"];
                var cmpIddet = getUrlVars()["cmp_id"];

                if (BillID != null && BillID !== "" && BillID != undefined) {
                    //$("#invoiceto").find('option').not(':first').remove();
                    //getCustomerList();
                    setTimeout(function () {
                        var reqId = { "Id": BillID }
                        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Quotationdetails.ashx?opertype=getQuotationDetails");
                        var params = $.extend({}, doAjax_params_default);
                        params['url'] = getPObyIdurl;
                        params['data'] = JSON.stringify(reqId);
                        params['requestType'] = "POST";
                        params['successCallbackFunction'] = invoiceResponse.getQuotationDetailsbyId;
                        doAjax(params);
                    }, 2000);
                }
            }


        }
    },
    getQuotationDetailsbyId: function (data) {
        //if (parseInt(data.ResponseCode) == 0) {
        $("#btnSendQuote").hide();
        $("#PrintPdf").hide();
        if (data.resEstimateGetList[0] != null) {
            getLastInvoiceId();
            $('#invoiceto').val(data.resEstimateGetList[0].CustomerId);
            $("#billno").val(data.resEstimateGetList[0].InvoiceNo).attr("disabled", "disabled");
            $("#podate").val(convertDate(data.resEstimateGetList[0].EstimateDate.split("T")[0]));
            $("#duedate").val(convertDate(data.resEstimateGetList[0].ExpiryDate.split("T")[0]));
            $("#refno").val(data.resEstimateGetList[0].RefNo);
            $("#shipadd1").val(data.resEstimateGetList[0].ShippingAddress1);
            $("#shipadd2").val(data.resEstimateGetList[0].ShippingAddress2);
            $("#city").val(data.resEstimateGetList[0].City);
            $("#pincode").val(data.resEstimateGetList[0].PinCode);
            $("#billingstate").val(data.resEstimateGetList[0].State);
            if (data.resEstimateGetList[0].IsTaxInclusive) {
                $('#Exclusive').prop('checked', false);
                $('#Inclusive').prop('checked', true);
            }
            else {
                $('#Exclusive').prop('checked', true);
                $('#Inclusive').prop('checked', false);
            }
            $("#invoicetype").val(data.resEstimateGetList[0].InvoiceType);
            $("#transactioncode").val(data.resEstimateGetList[0].TransactionCode);
            $("#transmode").val(data.resEstimateGetList[0].TransportMode);
            $("#supplyplace").val(data.resEstimateGetList[0].PlaceOfSupply);
            if (data.resEstimateGetList[0].SupplyDate != null) {
                $("#supplydate").val(convertDate(data.resEstimateGetList[0].SupplyDate.split("T")[0]));
            }
            if (data.resEstimateGetList[0].IsReverseCharge) {
                $('#reversecharge').prop('checked', true);
            }
            else {
                $('#reversecharge').prop('checked', false);
            }
            if (data.resEstimateGetList[0].PortCode) {
                $("#portCode").val(data.resEstimateGetList[0].PortCode);
            }
            if (data.resEstimateGetList[0].Type_E_OE) {
                $("#transType").val(data.resEstimateGetList[0].Type_E_OE);
            }
            if (data.resEstimateGetList[0].ShippingBillNo) {
                $("#SBillNo").val(data.resEstimateGetList[0].ShippingBillNo);
            }
            $("#vehicleno").val(data.resEstimateGetList[0].VehicleNo);
            $("#freight").val(data.resEstimateGetList[0].Frieght);
            $("#labourCharge").val(data.resEstimateGetList[0].LabourCharge);
            $("#InsuranceAmt").val(data.resEstimateGetList[0].InsuranceAmount);
            $("#otherCharges").val(data.resEstimateGetList[0].OtherCharge);
            $("#disount").val(data.resEstimateGetList[0].Discount);

            if (data.resEstimateGetList[0].ResEstimateItemList.length > 0) {
                $("#tblItemDetails").find("tr:gt(0)").remove();
                if (data.resEstimateGetList[0].ResEstimateItemList.length > 1) {
                    $("#add_1").attr('class', 'del');
                }
                else {
                    $("#add_1").attr('class', 'add');
                }

                for (var b = 1; b <= (data.resEstimateGetList[0].ResEstimateItemList.length) ; b++) {
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

                        if (b < data.resEstimateGetList[0].ResEstimateItemList.length) {
                            $("#add_" + b).attr('class', 'del');
                        }
                        else {
                            $("#add_" + b).attr('class', 'add');
                        }

                        addSerialNumber("tblItemDetails");
                        $('.chosen-container').css("width", "100%");
                    }
                }
                var json = data.resEstimateGetList[0].ResEstimateItemList;
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

            $("#TandC").val(data.resEstimateGetList[0].TermCondition);
            $("#INVPayDet").val(data.resEstimateGetList[0].InvoicePaymentDetail);
            $("#TA_notes").val(data.resEstimateGetList[0].Notes);
            $(".chosen-select-deselect").trigger("chosen:updated");

            $("#invoicetable").hide(800);
            $("#addinvoicedetails").show(800);

            TotalAmount();
        }

        //}
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
    P_editCustDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            var EmailBody = "HEREWITH ENCLOSED THE INVOICE REF NO-" + $("#refno").val() + "  FOR YOUR REVIEW, THE TOTAL DUE AMOUNT OF Rs (" + $("#nettotal").text() + ") "+ $("#AmtWords").text();
            $("#EmailBody").val(EmailBody)
            $("#EmailSubject").val("Invice Details for Ref no-" + $("#refno").val());
            var sez = false;
            $("#P_C_Gstn").val(data.GstinNo);
            $("#P_S_Gstn").val(data.GstinNo);
            $("#P_C_contact").val(data.PhoneNo);
            $("#senderEmailId").val(data.EmailId);
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
    editCustDetails: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $modal = $('#poorderto');
            $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
            var sez = false;
            $("#companyname").val(data.CustomerName);
            $("#profileemail").val(data.EmailId);
            $("#gstnno").val(data.GstinNo);
            $("#panno").val(data.PanCardNo);
            $("#contactno").val(data.PhoneNo);
            $("#ContactPerson").val(data.PrimaryContactPerson);
            $("#servicetax").val(data.ServiceTaxNo);
            $("#tdsrate").val(data.TdsRate);
            if (data.Sez == "" || data.Sez == "undefined" || data.Sez == null)
            {
                sez = false;
            }
            else {
                sez = data.Sez
            }

            $("#sez").prop('checked', sez);
            $("#tdsSection").val(data.TdsSection);
            $("#vattin").val(data.TinVat);
            if (data.BillingAddress1 != "" || data.BillingAddress1 != "undefined" || data.BillingAddress1 == null) {
                $("#billingaddress1").val(data.BillingAddress1);
            }
            if (data.BillingAddress2 != "" || data.BillingAddress2 != "undefined" || data.BillingAddress2 == null) {
                $("#billingaddress2").val(data.BillingAddress2);
            }
            if (data.BillingCity != "" || data.BillingCity != "undefined" || data.BillingCity == null) {
                $("#billingcity").val(data.BillingCity);
            }
            if (data.BillingState != "" || data.BillingState != "undefined" || data.BillingState == null) {
                $("#bilingstate").val(data.BillingState);
            }
            if (data.BillingPinCode != "" || data.BillingPinCode != "undefined" || data.BillingPinCode == null) {
                $("#billingpin").val(data.BillingPinCode);
            }

            if (data.ShippingAddress1 != "" || data.ShippingAddress1 != "undefined" || data.ShippingAddress1 == null) {
                $("#shipaddress1").val(data.ShippingAddress1);
            }
            if (data.ShippingAddress2 != "" || data.ShippingAddress2 != "undefined" || data.ShippingAddress2 == null) {
                $("#shipaddress2").val(data.ShippingAddress2);
            }
            if (data.ShippingCity != "" || data.ShippingCity != "undefined" || data.ShippingCity == null) {
                $("#shipcity").val(data.ShippingCity);
            }
            if (data.ShippingState != "" || data.ShippingState != "undefined" || data.ShippingState == null) {
                $("#shippingstate").val(data.ShippingState);
            }
            if (data.ShippingPinCode != "" || data.ShippingPinCode != "undefined" || data.ShippingPinCode == null) {
                $("#shippin").val(data.ShippingPinCode);
            }

            $modal.modal('show', { backdrop: 'static', keyboard: false });
           
            
        }
    },
    retriveLastPOId: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $("#billno").val(data.Count).attr("disabled", "disabled");
        }
    },

    insertCustomerdetils: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            $('#poorderto').modal('hide');
            var option = '<option value="' + data.Id + '"> ' + $("#companyname").val() + ' </option>'
            $('#invoiceto').append(option);
            $('#invoiceto').val(data.Id);
            $(".chosen-select-deselect").trigger("chosen:updated");
            $("#hdnCustomerId").val("");
        }
    },
    getCustomerdetils: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            if (data.resCustomer != null) {
                var myTemplate = $.templates("#tblVendorDropdown");
                var html = myTemplate.render(data.resCustomer);
                $("#invoiceto").append(html);
                $("#invoiceto").trigger("chosen:updated");
            }
        }
    },
    insertQuotationDetails: function (data) {
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
    getTDSDeatilsResp: function (data) {
        var RespCode = parseInt(data.ResponseCode);
        if (RespCode == 0) {
            var myTemplate = $.templates("#tblTdsDropdown");
            var html = myTemplate.render(data.resTdsList);
            $("#invoicetds").append(html);
            $("#invoicetds").trigger("chosen:updated");

        }
    },
    getQuotationDetails: function (data) {
        // if (parseInt(data.resEstimateGetList.ResponseCode) == 0) {
        if (data.resInvoiceGetList != null) {
            var myTemplate = $.templates("#tblQuotationList");
            var html = myTemplate.render(data.resInvoiceGetList);
            $("#invoiceDetail").html(html);
            addSerialNumber("invoiceDetail");
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
        }
        else {
            var noRecords = "<tr><td> No records found</td></tr>";
        }
        //}
    },

    deleteQuotation: function (data) {
        if (parseInt(data.ResponseCode) == 0) {
            swal("Deleted!", "Record deleted successfully.", "success");
            //AlertSuc.alertsuccess("success", data.ResponseMessage);
            window.location.reload(true);
        }
    },
    getInvoiceDetailsbyId: function (data) {
        //if (parseInt(data.ResponseCode) == 0) {
        if (data.resInvoiceGetList != null) {
            $('#invoiceto').val(data.resInvoiceGetList[0].CustomerId);
            $("#billno").val(data.resInvoiceGetList[0].InvoiceNo).attr("disabled", "disabled");
            $("#invNO").text(data.resInvoiceGetList[0].InvoiceNo);3
            $("#podate").val(convertDate(data.resInvoiceGetList[0].InvoiceDate.split("T")[0]));
            $("#duedate").val(convertDate(data.resInvoiceGetList[0].DueDate.split("T")[0]));
            $("#refno").val(data.resInvoiceGetList[0].RefNo);
            $("#shipadd1").val(data.resInvoiceGetList[0].ShippingAddress1);
            $("#shipadd2").val(data.resInvoiceGetList[0].ShippingAddress2);
            $("#city").val(data.resInvoiceGetList[0].City);
            $("#pincode").val(data.resInvoiceGetList[0].PinCode);
            $("#billingstate").val(data.resInvoiceGetList[0].State);
            
            if (data.resInvoiceGetList[0].IsTaxInclusive) {
                $('#Exclusive').prop('checked', false);
                $('#Inclusive').prop('checked', true);
            }
            else {
                $('#Exclusive').prop('checked', true);
                $('#Inclusive').prop('checked', false);
            }

            $("#invoicetype").val(data.resInvoiceGetList[0].InvoiceType);
            $("#transactioncode").val(data.resInvoiceGetList[0].TransactionCode);
            $("#transmode").val(data.resInvoiceGetList[0].TransportMode);
            $("#supplyplace").val(data.resInvoiceGetList[0].PlaceOfSupply);
            if (data.resInvoiceGetList[0].SupplyDate != null) {
                $("#supplydate").val(convertDate(data.resInvoiceGetList[0].SupplyDate.split("T")[0]));
            }
            if (data.resInvoiceGetList[0].IsReverseCharge) {
                $('#reversecharge').prop('checked', true);
            }
            else
            {
                $('#reversecharge').prop('checked', false);
            }
            if (data.resInvoiceGetList[0].PortCode) {
                $("#portCode").val(data.resInvoiceGetList[0].PortCode);
            }
            if (data.resInvoiceGetList[0].Type_E_OE) {
                $("#transType").val(data.resInvoiceGetList[0].Type_E_OE);
            }
            if (data.resInvoiceGetList[0].ShippingBillNo) {
                $("#SBillNo").val(data.resInvoiceGetList[0].ShippingBillNo);
            }
            $("#vehicleno").val(data.resInvoiceGetList[0].VehicleNo);
            $("#freight").val(data.resInvoiceGetList[0].Frieght);
            $("#labourCharge").val(data.resInvoiceGetList[0].LabourCharge);
            $("#InsuranceAmt").val(data.resInvoiceGetList[0].InsuranceAmount);
            $("#otherCharges").val(data.resInvoiceGetList[0].OtherCharge);
            $("#disount").val(data.resInvoiceGetList[0].Discount);
            $("#TandC").val(data.resInvoiceGetList[0].TermCondition);
            $("#INVPayDet").val(data.resInvoiceGetList[0].InvoicePaymentDetail);
            $("#TA_notes").val(data.resInvoiceGetList[0].Note);
            if (data.resInvoiceGetList[0].ResInvoiceItemList.length > 0) {
                $("#tblItemDetails").find("tr:gt(0)").remove();
                if (data.resInvoiceGetList[0].ResInvoiceItemList.length > 1) {
                    $("#add_1").attr('class', 'del');
                }
                else {
                    $("#add_1").attr('class', 'add');
                }

                P_clone_Pdf = $("#P_ItemDetails tr.itemdetailsPDF:first").clone(true);

                for (var b = 1; b <= (data.resInvoiceGetList[0].ResInvoiceItemList.length) ; b++) {
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

                        if (b < data.resInvoiceGetList[0].ResInvoiceItemList.length) {
                            $("#add_" + b).attr('class', 'del');
                        }
                        else {
                            $("#add_" + b).attr('class', 'add');
                        }

                        addSerialNumber("tblItemDetails");
                        addSerialNumber("P_ItemDetails");
                        $('.chosen-container').css("width", "100%");
                    }
                }
                var json = data.resInvoiceGetList[0].ResInvoiceItemList;
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        var a = parseInt(key) + 1;
                        $("#additems_" + a).val(json[key].ItemId);
                        $("#desc_" + a).val(json[key].Description);
                        $("#price_" + a).val(json[key].Price);
                        $("#unt_" + a).val(json[key].Quantity);
                        $("#unit_" + a).val(json[key].Unit);
                        $("#tax_" + a).val(json[key].Tax);
                        $("#cess_"+ a).val(json[key].Cess);

                        $("#P_hsnId_" + a).text(json[key].ItemId);
                        $("#P_Price_" + a).text(json[key].Price);
                        $("#P_Qty_" + a).text(json[key].Quantity);
                        $("#P_Unit_" + a).text(json[key].Unit);
                        $("#P_tax_" + a).text(json[key].Tax);
                        $("#P_CESS_" + a).text(json[key].Cess);
                        $("#P_Discount_" + a).text(data.resInvoiceGetList[0].Discount);



                        performCalculation(a);
                    }
                }
            }
            $("#TA_notes").val(data.resInvoiceGetList[0].Notes);

            //for PDF code
            $('#P_invoiceto').text(data.resInvoiceGetList[0].CustomerId);
            $("#P_billno").text(data.resInvoiceGetList[0].InvoiceNo).attr("disabled", "disabled");
            $("#P_invNO").text(data.resInvoiceGetList[0].InvoiceNo); 
            $("#P_podate").text(convertDate(data.resInvoiceGetList[0].InvoiceDate.split("T")[0]));
            $("#P_duedate").text(convertDate(data.resInvoiceGetList[0].DueDate.split("T")[0]));
            $("#P_refno").text(data.resInvoiceGetList[0].RefNo);
            $("#P_shipadd1").text(data.resInvoiceGetList[0].ShippingAddress1);
            $("#P_shipadd2").text(data.resInvoiceGetList[0].ShippingAddress2);
            $("#P_city").text(data.resInvoiceGetList[0].City);
            $("#P_pincode").text(data.resInvoiceGetList[0].PinCode);
            $("#P_billingstate").text(data.resInvoiceGetList[0].State);
            $("#P_freight").text(data.resInvoiceGetList[0].Frieght);
            $("#P_labourCharge").text(data.resInvoiceGetList[0].LabourCharge);
            $("#P_InsuranceAmt").text(data.resInvoiceGetList[0].InsuranceAmount);
            $("#P_otherCharges").text(data.resInvoiceGetList[0].OtherCharge);
            $("#P_disount").text(data.resInvoiceGetList[0].Discount);
            $("#P_TandC").text(data.resInvoiceGetList[0].TermCondition);
            $("#P_INVPayDet").text(data.resInvoiceGetList[0].InvoicePaymentDetail);

            $(".chosen-select-deselect").trigger("chosen:updated");

            $("#invoicetable").hide(800);
            $("#addinvoicedetails").show(800);
            $(".chosen-select-deselect").trigger("chosen:updated");

            $("#invoicetable").hide(800);
            $("#addinvoicedetails").show(800);

            TotalAmount();
        }
        else
        {
            AlertSuc.alertsuccess("error", "Couldn't fetch records")
        }

        //}
    },
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
    if (parseFloat($("#freight").val()) > 0)
    {
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
    if (Mod > 0 && Mod < 5)
    {
        RoundOffValue = parseFloat(parseFloat(Math.round(NetTotal.toFixed(2)) + ".00") - parseInt(Mod))
    }
    else if (Mod >= 5 && Mod <=9 ) {
        RoundOffValue = parseFloat(parseFloat(parseFloat(Math.round(NetTotal.toFixed(2)) + ".00") - parseInt(Mod)) + 10);
    }
    $("#totalamt").text(totalAmt.toFixed(2));
    $("#P_TotalAMT").text(totalAmt.toFixed(2));
    $("#roundamt").text(Math.round(RoundOffValue) + ".00");
    $("#nettotal").text(NetTotal.toFixed(2));
    $("#P_nettotal").text(NetTotal.toFixed(2));
    $("#AmtWords").text(AlertSuc.number2text(NetTotal.toFixed(2)));

}

function performCalculation(id) {
    var stateMatches = false;
    var isUnionteritory = false;
   
    var options = $("#invoiceto option:selected");
   
    var VendorState = "";
    if ($("#billingstate").val() != "" && $("#billingstate").val() != "undefined" && $("#billingstate").val() != undefined)
    {
        VendorState = $("#billingstate").val();
    }
    else
    {
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

    if (parseFloat(discount) > 0) {
        var disountAmt = gross * (parseFloat(parseInt(discount) / 100));
        gross = gross - disountAmt;
    }
    var tax = 0
    if (parseFloat($("#tax_" + id).val()) > 0) {

        tax = gross * (parseFloat(parseFloat($("#tax_" + id).val()) / 100));
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
    params['successCallbackFunction'] = invoiceResponse.getHsnHscdetails;
    doAjax(params);
}

function getCustomerList() {
    var req = { "userId": "" };
    var getCustomerListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=get");
    console.log(getCustomerListurl);
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getCustomerListurl;
    params['data'] = req;
    params['successCallbackFunction'] = invoiceResponse.getCustomerdetils;
    doAjax(params);
}

function getItemList() {
    var req = { "userId": "" };
    var getitemListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/ItemDetails.ashx?opertype=get");
    console.log(getitemListurl);
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getitemListurl;
    params['data'] = req;
    params['successCallbackFunction'] = invoiceResponse.getItemDetails;
    doAjax(params);
}

function getTDSList() {
    var req = { "userId": "" };
    var getTDSListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/GetTDSDetails.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getTDSListurl;
    params['data'] = req;
    params['successCallbackFunction'] = invoiceResponse.getTDSDeatilsResp;
    doAjax(params);
}

function getLastInvoiceId() {
    var req = { "userId": "" };
    var getLastBillIdUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/getLastInvId.ashx");
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getLastBillIdUrl;
    params['data'] = req;
    params['successCallbackFunction'] = invoiceResponse.retriveLastPOId;
    doAjax(params);
}
function getInvoiceList() {
    var req = { "userId": "" };
    var getBillListurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Invoicedetails.ashx?opertype=get");
    console.log(getBillListurl);
    var params = $.extend({}, doAjax_params_default);
    params['url'] = getBillListurl;
    params['data'] = req;
    params['successCallbackFunction'] = invoiceResponse.getQuotationDetails;
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

$(document).ready(function () {

    getCustomerList();
    getHsnHsc();
    getItemList();
   // getTDSList();
    $.validator.setDefaults({ ignore: ":hidden:not(.chosen-select-deselect)" });
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
    $("#insertInvoice").validate({
        rules: {
            podate: { required: true },
            //duedate:{required : true },
            invoiceto: { valueNotEquals: "" },
            refno: { required: true }
        },
        messages: {
            invoiceto: { valueNotEquals: "Please select a Customer" }
        },
        errorPlacement: function (error, element) {
            $("#err_" + element.attr("name")).html(error[0]);
        }
    });

    var BillID = getUrlVars()["EstId"];
    if (BillID == null || BillID == "" || BillID == undefined) {
        getInvoiceList();
    }

    $("#chkBilling").click(function () {
        if ($(this).is(':checked')) {
            $("#shipaddress1").val($("#billingaddress1").val());
            $("#shipaddress2").val($("#billingaddress2").val());
            $("#shipaddress3").val($("#billingaddress3").val());
            $("#shipcity").val($("#billingcity").val());
            $("#shippin").val($("#billingpin").val());
            $("#shippingstate").val($("#bilingstate").val());
            $(".chosen-select-deselect").trigger("chosen:updated");
        }
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

    $("#btnSaveInvoice").click(function () {
        if ($("#insertInvoice").valid()) {
            var PurchaseItemList = [];
            var i = 1;
            $("#tblItemDetails tr").each(function () {
                var Obj = {
                    "InvoiceId": $("#hdnPurchaseId").val(),
                    "InvoiceNo": $("#billno").val(),
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
                    "Cess": $("#cess_" + i).val()

                }
                PurchaseItemList.push(Obj);
                i++;
            });
            var BillObject = new Object();
            BillObject = {
                "InvoiceId": $("#hdnPurchaseId").val(),
                "InvoiceType": $("#invoicetype").val(),
                "TransactionCode": $("#transactioncode").val(),
                "PortCode": $("#portCode").val(),
                "Type_E_OE": $("#transType").val(),
                "ShippingBillNo": $("#SBillNo").val(),
                "CustomerId": $("#invoiceto").val(),
                "InvoiceNo": $("#billno").val(),
                "InvoiceDate": $("#podate").val(),
                "DueDate": $("#duedate").val(),
                "SupplyDate": $("#supplydate").val(),
                "ShippingAddress1": $("#shipadd1").val(),
                "ShippingAddress2": $("#shipadd2").val(),
                "City": $("#city").val(),
                "State": $("#billingstate").val(),
                "PinCode": $("#pincode").val(),
                "Country": "India",
                "RefNo": $("#refno").val(),
                "AttachmentUrl": null,
                "Notes": $("#TA_notes").val(),
                "Discount": $("#disount").val(),
                "TotalAmount": $("#nettotal").text(),
                "IsTaxInclusive": $('#Inclusive').is(':checked') ? true : false,
                "IsReverseCharge": $('#reversecharge').is(':checked') ? true : false,
                "Advance": null,
                "TransportMode": $("#transmode").val(),
                "PlaceOfSupply": $("#supplyplace").val(),
                "VehicleNo": $("#vehicleno").val(),
                "Frieght": $("#freight").val(),
                "LabourCharge": $("#labourCharge").val(),
                "InsuranceAmount": $("#InsuranceAmt").val(),
                "OtherCharge": $("#otherCharges").val(),
                "TermCondition": $("#TandC").val(),
                "InvoicePaymentDetail": $("#INVPayDet").val(),
                "Cess": $("#cess").val(),
                "ReqInvoiceItemList": PurchaseItemList
            }
            var savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Invoicedetails.ashx?opertype=insert");
            if ($("#hdnPurchaseId").val() != "") {
                savePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Invoicedetails.ashx?opertype=update");
            }
            var params = $.extend({}, doAjax_params_default);
            params['url'] = savePOurl;
            params['data'] = JSON.stringify(BillObject);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = invoiceResponse.insertQuotationDetails;
            doAjax(params);
        }
    });

    $("#btnSaveHsnCode").click(function () {
        var hsnCode = $('input[name=rd_HSNHSC]:checked').attr("code");
        var rate = $('input[name=rd_HSNHSC]:checked').attr("rate");
        if (rate == "Nil" || rate == "Nill") {
            rate = "0";
        }
        $("#txt_hsnhsc").val(hsnCode);
        $("#taxdetails").val(rate);
        $("#taxdetails").trigger("chosen:updated");
        $('#codesmodal').modal('hide');
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
            //swal("Deleted!", "Your imaginary file has been deleted.", "success");           
            var getdeletePOurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Invoicedetails.ashx?opertype=delete");
            var params = $.extend({}, doAjax_params_default);
            params['url'] = getdeletePOurl;
            params['data'] = JSON.stringify(reqId);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = invoiceResponse.deleteQuotation;
            doAjax(params);
        });        
    });

    $(document).on("click", ".edit", function () {
        //$("#invoiceto").find('option').not(':first').remove();
        //getCustomerList();
        getUserProfileDetails();
        $("#btnSendQuote").show();
        $("#PrintPdf").show();
        var EditPOId = $(this).attr("id").split("_")[1];
        var reqId = { "Id": EditPOId }
        $("#hdnPurchaseId").val(EditPOId);
        var getPObyIdurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/Invoicedetails.ashx?opertype=getPODetails");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getPObyIdurl;
        params['data'] = JSON.stringify(reqId);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = invoiceResponse.getInvoiceDetailsbyId;
        setTimeout(function () { doAjax(params); }, 10);
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
            params['successCallbackFunction'] = invoiceResponse.insertItemDetils;
            doAjax(params);
        }
    });

    $("#btnSendQuote").click(function () {
        getUserProfileDetails();
        var CustRequest = new Object();
        $("#hdnCustomerId").val($("#invoiceto").val());
        CustRequest = {
            "Id": $("#invoiceto").val(),
        }
        var getCustDetailurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=getCustDetail");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getCustDetailurl;
        params['data'] = JSON.stringify(CustRequest);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = invoiceResponse.P_editCustDetails;
        doAjax(params);
    });

    $("#invoiceto").on("change", function () {
        $modal = $('#poorderto');
        if ($(this).val() === 'addnewpoto') {
            $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
            $modal.modal('show', { backdrop: 'static', keyboard: false });
            $(this).val("");
        }

        if ($("#invoiceto option:selected").val() !== "addnewpoto") {
            $('.edits').show();
        }
    });
    $(".edits").on("click", function () {
        var CustRequest = new Object();
        $("#hdnCustomerId").val($("#invoiceto").val());
        CustRequest = {
            "Id": $("#invoiceto").val(),
        }
        var getCustDetailurl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=getCustDetail");
        var params = $.extend({}, doAjax_params_default);
        params['url'] = getCustDetailurl;
        params['data'] = JSON.stringify(CustRequest);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = invoiceResponse.editCustDetails;
        doAjax(params);
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

    $('#invoicedetailstbl').DataTable({
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


    //---------
    $('#addinvoice').click(function () {
        getLastInvoiceId();
        $("#btnSendQuote").hide();
        $("#PrintPdf").hide();
        $("#invoicetable").hide(800);
        $("#addinvoicedetails").show(800);

    });

    $('#backtoinvoice').click(function () {
        $("#addinvoicedetails").hide(800);
        $("#invoicetable").show(800);
        $("#addinvoicedetails").find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
        $(".chosen-select-deselect").trigger("chosen:updated");
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
        //format: "dd-M-yyyy"
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

    $('#supplydate').datepicker({
        todayBtn: 1,
        autoclose: true,
        todayHighlight: true,
        //startDate: today
    //}).on('changeDate', function (selected) {
    //    var minDate = new Date(selected.date.valueOf());
    //    $('#duedate').datepicker('setStartDate', minDate);
    });

    

    $("#btn_SaveCustomer").click(function () {

        var customerProfile = new Object();
        customerProfile = {
            "CustomerId": $("#hdnCustomerId").val(),
            "CustomerName": $("#companyname").val(),
            "PrimaryContact": $("#ContactPerson").val(),
            "EmailId": $("#profileemail").val(),
            "PhoneNo": $("#contactno").val(),
            "BillingAddress1": $("#billingaddress1").val(),
            "BillingAddress2": $("#billingaddress2").val() + " " + $("#billingaddress3").val(),
            "BillingCity": $("#billingcity").val(),
            "BillingState": $("#bilingstate").val(),
            "BillingPinCode": $("#billingpin").val(),
            "BillingCountry": $("#billingCountry").val(),
            "ShippingAddress1": $("#shipaddress1").val(),
            "ShippingAddress2": $("#shipaddress2").val() + " " + $("#shipaddress3").val(),
            "ShippingCity": $("#shipcity").val(),
            "ShippingState": $("#shippingstate").val(),
            "ShippingPinCode": $("#shippin").val(),
            "ShippingCountry": "India",
            "Sez": $("#sez").is(":checked") ? "true" : "false",
            "PanNo": $("#panno").val(),
            "ServiceTaxNo": $("#servicetax").val(),
            "TinVatNo": $("#vattin").val(),
            "GstinNo": $("#gstnno").val(),
            "TdsSection": $("#tdsSection").val(),
            "TdsRate": $("#tdsrate").val(),
            "Note": $("#TA_notes").val()
        }

        var saveCustomerUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=insert");
        if ($("#hdnCustomerId").val() != "")
        {
            saveCustomerUrl = generateHandlerUrl.getUrl("../HandlerFiles/Manage/manageCustomers.ashx?opertype=update");
        }
        var params = $.extend({}, doAjax_params_default);
        params['url'] = saveCustomerUrl;
        params['data'] = JSON.stringify(customerProfile);
        params['requestType'] = "POST";
        params['successCallbackFunction'] = invoiceResponse.insertCustomerdetils;
        doAjax(params);
    });

    $(document).on('click', '.del', function () {
        var index = $(this).closest('tr').index();
        $(this).parent().parent().remove();
        for (var i = index; i < $('table tbody tr').children().length; i++) {
            $('table tbody tr:nth-child(' + i + ') td:first-child').text(i);
        }
    });

    $("#searchv").click(function () {
        var selCode = $("#crrole option:selected").val();
        if (selCode != "" && selCode != "-1") {
            var searchReq = new Object();
            searchReq.HsnOrHsc = selCode;
            searchReq.HsnDetail = $("#txtSearch").val();

            var searchurl = generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/HsnSacSearchResults.ashx');
            var params = $.extend({}, doAjax_params_default);
            params['url'] = searchurl;
            params['data'] = JSON.stringify(searchReq);
            params['requestType'] = "POST";
            params['successCallbackFunction'] = invoiceResponse.searchHsnHscdetails;
            doAjax(params);
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

    $(document).on('keyup change', '.calculate', function () {
        var Id = $(this).attr("id").split("_")[1];
        performCalculation(Id);
    });

    $(document).on('keyup change', '#disount, #invoiceto, #billingstate, #freight, #labourCharge, #InsuranceAmt, #otherCharges, #cess', function () {
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
                HtmlType : "Invoice",
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
