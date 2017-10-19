String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

function toLocation(url) {
    var a = document.createElement('a');
    a.href = url;
    return a;
};

var cssStyle = "<style> body.A4.sheet { width: 210mm; height: 296mm; } .sheet.padding-6mm { padding: 6mm; } .pdftbl { border-collapse: collapse; border-spacing: 0; text-align: center; } .pdftbl th { border-style: solid; border-width: 1px; overflow: hidden; word-break: normal; height: 30px; background-color: #ddd; padding: 0 4px; } .pdftbl td { border-style: solid; border-width: 1px; overflow: hidden; word-break: normal; height: 30px; } .pdftbl.footer { font-weight: bold; } </style>";

//------------------file Upload-----------------
function sendFileUpload(file) {
    var fileDetails = new FormData();
    fileDetails.append(file.name, file);
    $.ajax({
        type: 'post',
        url: generateHandlerUrl.getUrl('../HandlerFiles/FileUploader.ashx?type=Logo&FileName=' + file.name),
        data: fileDetails,
        success: function (result) {
            fileDetails = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + result.replace('~', '');

            $.ajax({
                type: 'post',
                url: generateHandlerUrl.getUrl('../HandlerFiles/UploadLogo.ashx?fName=' + fileDetails),
                data: "",
                success: function (data) {
                    $(".upload").hide();
                    $("#cmp_LogoImg").attr("src", fileDetails).css("height", "110px;");
                    AlertSuc.alertsuccess("success", "File uploaded successfully !!");
                }
            });

            
        },
        processData: false,
        //contentType: file.type
        contentType: false
    });
}

//------------------Print Page -----------------
function printdiv(printpage) {
    var divToPrint = document.getElementById(printpage);

    var newWin = window.open('', 'Print-Window');

    newWin.document.open();

    newWin.document.write('<html>' + cssStyle + '<body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

    newWin.document.close();

    setTimeout(function () { newWin.close(); }, 10);
}

//--Check image exists--
function fileExists(url) {
    if (url) {
        var req = new XMLHttpRequest();
        req.open('GET', url, false);
        req.send();
        return req.status == 200;
    } else {
        return false;
    }
}
//---------Side menu
$sidebarMenu = function (menu) {
    var animationSpeed = 300,
        subMenuSelector = '.sidebar-submenu';

    $(menu).on('click', 'li a', function (e) {
        var $this = $(this);
        var checkElement = $this.next();

        if (checkElement.is(subMenuSelector) && checkElement.is(':visible')) {
            checkElement.slideUp(animationSpeed, function () {
                checkElement.removeClass('menu-open');
            });
            checkElement.parent("li").removeClass("active");
        }

            //If the menu is not visible
        else if ((checkElement.is(subMenuSelector)) && (!checkElement.is(':visible'))) {
            //Get the parent menu
            var parent = $this.parents('ul').first();
            //Close all open menus within the parent
            //var ul = parent.find('ul:visible').slideUp(animationSpeed);
            //Remove the menu-open class from the parent
            //ul.removeClass('menu-open');
            //Get the parent li
            var parent_li = $this.parent("li");

            //Open the target menu and add the menu-open class
            checkElement.slideDown(animationSpeed, function () {
                //Add the class active to the parent li
                checkElement.addClass('menu-open');
                //parent.find('li.active').removeClass('active');
                parent_li.addClass('active');
            });
        }
        //if this isn't a link, prevent the page from being redirected
        if (checkElement.is(subMenuSelector)) {
            e.preventDefault();
        }
    });
}

var doAjax_params_default = {
    'url': null,
    'requestType': "GET",
    //'contentType': 'application/x-www-form-urlencoded; charset=UTF-8',
    'contentType': "application/json; charset=utf-8",
    'dataType': 'json',
    'data': {},
    'beforeSendCallbackFunction': null,
    'successCallbackFunction': null,
    'completeCallbackFunction': null,
    'errorCallBackFunction': null,
};


function doAjax(doAjax_params) {
    var url = doAjax_params['url'];
    var requestType = doAjax_params['requestType'];
    var contentType = doAjax_params['contentType'];
    var dataType = doAjax_params['dataType'];
    var data = doAjax_params['data'];
    var beforeSendCallbackFunction = doAjax_params['beforeSendCallbackFunction'];
    var successCallbackFunction = doAjax_params['successCallbackFunction'];
    var completeCallbackFunction = doAjax_params['completeCallbackFunction'];
    var errorCallBackFunction = doAjax_params['errorCallBackFunction'];

    //make sure that url ends with '/'
    /*if(!url.endsWith("/")){
     url = url + "/";
    }*/

    $.ajax({
        url: url,
        crossDomain: true,
        type: requestType,
        contentType: contentType,
        dataType: dataType,
        data: data,
        beforeSend: function (jqXHR, settings) {
            if (typeof beforeSendCallbackFunction === "function") {
                beforeSendCallbackFunction();
            }
        },
        success: function (data, textStatus, jqXHR) {
            if (typeof successCallbackFunction === "function") {
                successCallbackFunction(data);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (typeof errorCallBackFunction === "function") {
                errorCallBackFunction(errorThrown);
            }

        },
        complete: function (jqXHR, textStatus) {
            if (typeof completeCallbackFunction === "function") {
                completeCallbackFunction();
            }
        }
    });
}

$(document).ajaxStart(function () {
    $("#preloader").show();
});

$(document).ajaxStop(function () {
    $('#preloader').fadeOut(1000);
});

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function formatCurrentDate() {
    var d = new Date(),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
}

function parseDate(str) {
    var mdy = str.split('-');
    return new Date(mdy[0], mdy[1] - 1, mdy[2]);
}

function daydiff(first, second) {
    return Math.round((second - first) / (1000 * 60 * 60 * 24));
}

$(document).ready(function () {
    var date = $("#hdn_Expiry").val();
    if (date != "" && date != undefined) {
        var current_date = formatCurrentDate();
        var remaining_days = daydiff(parseDate(current_date), parseDate(date));

        if (parseInt(remaining_days) <= 30) {
            swal({
                title: "Alert",
                text: "Your liscence will expire in " + remaining_days + " days. Please click on continue to proceed.",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-warning",
                confirmButtonText: "Continue",
                closeOnConfirm: false
            },
            function (isConfirm) {
                if (!isConfirm) {
                    var url = window.location.href;
                    var arr = url.split("/");
                    var hrefval = arr[0] + "//" + arr[2] + "/" + "Index.aspx";
                    window.location.href = hrefval;
                }
                else {
                    swal.close();
                }
            });
        }
    }
    


    $('#companyUpLogo').change(function () {
        sendFileUpload(this.files[0]);
    });

    if ($("#hdn_LogoUrl").val() != "") {        
        var fileNameUrl = $("#hdn_LogoUrl").val();
        if (fileNameUrl.indexOf("http://") == -1)
        {
            fileNameUrl = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + fileNameUrl.replace('~', '');
        }
        else
        {
            var newFileName = fileNameUrl.replace(/https?:\/\/[^\/]+/i, "");
            fileNameUrl = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + newFileName.replace('~', '');
        }
        if (fileExists(fileNameUrl)) {
            $(".upload").hide();
            $("#cmp_LogoImg").attr("src", fileNameUrl).css("height", "110px;");
        }
    }

    var CurentFiscalY = getFiscalY();
    //alert(CurentFiscalY);

    $("#LoginInfo").text(AlertSuc.getProperty($("#hdn_uType").val()) + " " + $("#hdn_LoginName").val());
    $("#fiscalYear").text(CurentFiscalY);

    $(document).on('keydown', function (e) {
        var kc = e.which || e.keyCode;

        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "I") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/Invoice.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "Q") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/quotation.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "A") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/Advance.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "E") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/PurchaseOrder.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "B") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/Bills.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "C") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/CreditNote.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "D") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Manage/DebitNote.aspx';
        }
        if (e.ctrlKey && String.fromCharCode(kc).toUpperCase() == "D") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Dashboard/Dashboard.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "P") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Dashboard/Profile.aspx';
        }
        if (e.altKey && String.fromCharCode(kc).toUpperCase() == "H") {
            e.preventDefault();
            //console.log(String.fromCharCode(kc).toUpperCase());
            window.location.href = '../Dashboard/Hsnsac.aspx';
        }
    });

    $sidebarMenu($('.sidebar-menu'));
    var type = getUrlVars()["usertype"];
    var Id = getUrlVars()["cmp_id"];
    if (type != null && type !== "" && type != undefined)
    {
        var querystring = 'usertype=company&cmp_id=' + Id;
        $("#hdn_uType").val("0");
        $("#rightMenu").hide();
        var $menu = $('#sidebar-wrapper');
        $menu.find("ul li a").each(function () {
            var href = $(this).attr('href');
            if (href) {
                if ((href.indexOf('#') == -1) && (href != "javascript:void(0)")) {
                    href += (href.match(/\?/) ? '&' : '?') + querystring;
                    $(this).attr('href', href);
                }
            }
        });
    }


    if (($("#hdn_FirstTime").val()) == "0") {
        $('#sidebar-wrapper').addClass("firstlogin");
        swal("Welcome to Letz gst!");
       // $('#sidebar-wrapper a').click(function(){ return false });
    }

    if ($("#hdn_uType").val() == "1" || $("#hdn_uType").val() == "3")
    {
        $("#mn_Client").show();
    }
    else
    {
        $("#mn_Client").hide();
    }

    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });

    $('ul.nav li.dropdown').hover(function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
    }, function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
    });
});



var generateHandlerUrl = {
    getUrl: function(url)
    {
        var href = url;
        var C_type = getUrlVars()["usertype"];
        var C_Id = getUrlVars()["cmp_id"];
        if (C_type != null && C_type !== "" && C_type != undefined) {
            var hnd_querystring = 'usertype=company&cmp_id=' + C_Id;
            href += (href.match(/\?/) ? '&' : '?') + hnd_querystring;
        }
        return href;
    }
}

var CodeList = {
"1" : "CA",
"2" : "COMPANY",
"3" : "CAUSER",
"4" : "CA COMPANY",
"5" : "COMPANY USER",
"6": "CA COMPANUY USER",
}

function getFiscalY() {
    //get current date
    var today = new Date();
     
    //get current month
    var curMonth = today.getMonth();
     
    var fiscalYr = "";
    if (curMonth > 3) { //
        var nextYr1 = (today.getFullYear() + 1).toString();
        fiscalYr = today.getFullYear().toString() + "-" + nextYr1.charAt(0) + nextYr1.charAt(1)+ nextYr1.charAt(2) + nextYr1.charAt(3);
    } else {
        var nextYr2 = today.getFullYear().toString();
        fiscalYr = (today.getFullYear() - 1).toString() + "-" + nextYr2.charAt(2) + nextYr2.charAt(3);
    }
    return (fiscalYr);
}

var AlertSuc = {
    alertsuccess: function (type, message) {
       // var iconType = "error";
        if (type == "success") {
            $("#msg_Container").removeClass("alert-warning");
            $("#msg_Container").addClass("alert-success");
           // iconType = "sucess";
        }
        else {
            //iconType = "error";
            $("#msg_Container").removeClass("alert-success");
            $("#msg_Container").addClass("alert-warning");
        }
        $("#spn_msg").text(message);
        $("#msg_Container").show();
        $('#msg_Container').fadeOut(6000);
       
    },

    getProperty : function (propertyName) {
        return CodeList[propertyName];
    },

    sessionTimeOut : function()
    {
        alertsuccess("error", "Session Timed Out. Please login again")
        
    },  
    
    clear_form_elements: function(frm_ID) {
        jQuery("#" + frm_ID).find(':input').each(function () {
            switch (this.type) {
                case 'password':
                case 'text':
                case 'textarea':
                case 'file':
                case 'select-one':
                case 'select-multiple':
                case 'date':
                case 'number':
                case 'tel':
                case 'email':
                    jQuery(this).val('');
                    break;
                case 'checkbox':
                case 'radio':
                    this.checked = false;
                    break;
            }
        });
    },

    number2text: function (value) {
        var fraction = Math.round(frac(value) * 100);
        var f_text = "";

        if (fraction > 0) {
            f_text = "AND " + convert_number(fraction) + " PAISE";
        }

        return convert_number(value) + " RUPEE " + f_text + " ONLY";
    }
}


//function number2text(value) {
//    var fraction = Math.round(frac(value) * 100);
//    var f_text = "";

//    if (fraction > 0) {
//        f_text = "AND " + convert_number(fraction) + " PAISE";
//    }

//    return convert_number(value) + " RUPEE " + f_text + " ONLY";
//}

function frac(f) {
    return f % 1;
}

function convert_number(number) {
    if ((number < 0) || (number > 999999999)) {
        return "NUMBER OUT OF RANGE!";
    }
    var Gn = Math.floor(number / 10000000);  /* Crore */
    number -= Gn * 10000000;
    var kn = Math.floor(number / 100000);     /* lakhs */
    number -= kn * 100000;
    var Hn = Math.floor(number / 1000);      /* thousand */
    number -= Hn * 1000;
    var Dn = Math.floor(number / 100);       /* Tens (deca) */
    number = number % 100;               /* Ones */
    var tn = Math.floor(number / 10);
    var one = Math.floor(number % 10);
    var res = "";

    if (Gn > 0) {
        res += (convert_number(Gn) + " CRORE");
    }
    if (kn > 0) {
        res += (((res == "") ? "" : " ") +
        convert_number(kn) + " LAKH");
    }
    if (Hn > 0) {
        res += (((res == "") ? "" : " ") +
            convert_number(Hn) + " THOUSAND");
    }

    if (Dn) {
        res += (((res == "") ? "" : " ") +
            convert_number(Dn) + " HUNDRED");
    }


    var ones = Array("", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN");
    var tens = Array("", "", "TWENTY", "THIRTY", "FOURTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY");

    if (tn > 0 || one > 0) {
        if (!(res == "")) {
            res += " AND ";
        }
        if (tn < 2) {
            res += ones[tn * 10 + one];
        }
        else {

            res += tens[tn];
            if (one > 0) {
                res += ("-" + ones[one]);
            }
        }
    }

    if (res == "") {
        res = "zero";
    }
    return res;
}





