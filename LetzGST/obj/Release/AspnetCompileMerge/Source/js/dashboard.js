$(document).ready(function () {
    //highliht the menu
    var $target = $('#sidebar-wrapper');
    $target.find("ul li ul").each(function () {
        $(this).removeClass("show");
    });
    $target.find("ul li a").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }

        $("#dashboard").addClass("active");
    });

    

//Shiv Jha

//$(document).ready(function () {
    //---------Expens Chart
    Highcharts.setOptions({
        colors: ['#ff1a1a', '#008000', '#ffa500', '#A52A2A']
    });

    Highcharts.chart('expensechart', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        credits: {
            enabled: false
        },
        title: {
            text: 'Expense'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },

                showInLegend: true
            }
        },
        series: [{
            name: 'Expense',
            colorByPoint: true,
            data: [{
                name: 'Pending',
                y: 56.33
            }, {
                name: 'Paid',
                y: 24.03,
                sliced: true,
                selected: true
            }, {
                name: 'Overdue',
                y: 10.38
            },
                {
                    name: 'Partial Paid',
                    y: 5.38
                }]
        }]
    });
    //-----------------Invoice Chart
    Highcharts.setOptions({
        colors: ['#ff1a1a', '#008000', '#ffa500', '#A52A2A']
    });
    Highcharts.chart('invoicechart', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        credits: {
            enabled: false
        },
        title: {
            text: 'Invoice'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },

                showInLegend: true
            }
        },
        series: [{
            name: 'Invoice',
            colorByPoint: true,
            data: [{
                name: 'Pending',
                y: 56.33
            }, {
                name: 'Paid',
                y: 24.03,
                sliced: true,
                selected: true
            }, {
                name: 'Overdue',
                y: 10.38
            },
                {
                    name: 'Partial Paid',
                    y: 5.38
                }]
        }]
    });




    defaultSelection();


    //start Expense
    $('#dpSelectTypeExpense').on('change', function () {
        if (this.value == '1') {
            //emptyExpense();
            fillMonthlyExpense();
        } else {
            //emptyExpense();
            fillQuarterlyExpense();
        }
    });
    $('#drpMonthQurterExpense').on('change', function () {
        fillExpensedetails($('#dpSelectTypeExpense option:selected').val(), this.value);
        
    });
    function fillQuarterlyExpense() {
        $('#drpMonthQurterExpense').empty();
        $('#drpMonthQurterExpense').append('<option value="4">1 April – 30 June</option><option value="7">1 July – 30 September</option><option value="10">1 October – 31 December</option><option value="1">1 January – 31 March</option>');
      
    };
    function emptyExpense() {
        $("#exUTGST").empty();
        $("#exIGST").empty();
        $("#exSGST").empty();
        $("#exCGST").empty();
        $("#exTotalTax").empty();
    };

    function fillMonthlyExpense() {
        $('#drpMonthQurterExpense').empty();
        $('#drpMonthQurterExpense').append('<option value="1"> January </option><option value="2"> February </option><option value="3"> March </option><option value="4"> April </option><option value="5"> May </option><option value="6"> June </option><option value="7"> July </option><option value="8"> August </option><option value="9"> September  </option><option value="10"> October  </option><option value="11"> November   </option><option value="12"> December   </option>');
    };
    function fillExpensedetails(type, value) {
        $.ajax({
            type: "GET",
            url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/ExpenseDashboard.ashx'),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { Type: type, Value: value },
            success: function (data) {
               
                    $("#exUTGST").text(data.billUtgst);
                    $("#exIGST").text(data.billIgst);
                    $("#exSGST").text(data.billSgst);
                    $("#exCGST").text(data.billCgst);
                    $("#exTotalTax").text(data.billTotalTax);

               
                ///*Hight Chart Start */
                //    Highcharts.setOptions({
                //        colors: ['#ff1a1a', '#008000', '#ffa500', '#A52A2A']
                //    });

                //    Highcharts.chart('expensechart', {
                //        chart: {
                //            plotBackgroundColor: null,
                //            plotBorderWidth: null,
                //            plotShadow: false,
                //            type: 'pie'
                //        },
                //        credits: {
                //            enabled: false
                //        },
                //        title: {
                //            text: 'Expense'
                //        },
                //        tooltip: {
                //            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                //        },
                //        plotOptions: {
                //            pie: {
                //                allowPointSelect: true,
                //                cursor: 'pointer',
                //                dataLabels: {
                //                    enabled: false
                //                },

                //                showInLegend: true
                //            }
                //        },
                //        series: [{
                //            name: 'Expense',
                //            colorByPoint: true,
                //            data: [{
                //                name: 'Pending',
                //                y: 1
                //            }, {
                //                name: 'Paid',
                //                y: 3,
                //                sliced: true,
                //                selected: true
                //            }, {
                //                name: 'Overdue',
                //                y: 3
                //            },
                //                {
                //                    name: 'Partial Paid',
                //                    y: 3
                //                }]
                //        }]
                //    });

                ///*High Chart Expense End*/


            },
            error: function (data, success, error) {
                AlertSuc.alertsuccess("error", error);
            }
        });
    }

    function fillExpensedata() {
        $.ajax({
            type: "GET",
            url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/ExpenseDashboard.ashx'),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data:{},
            success: function (data) {
                
               
                $("#exUTGST").text(data.billUtgst);
                $("#exIGST").text(data.billIgst);
                $("#exSGST").text(data.billSgst);
                $("#exCGST").text(data.billCgst);
                $("#exTotalTax").text(data.billTotalTax);


                /*Hight Chart Start */
                Highcharts.setOptions({
                    colors: ['#ff1a1a', '#008000', '#ffa500', '#A52A2A']
                });

                Highcharts.chart('expensechart', {
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie'
                    },
                    credits: {
                        enabled: false
                    },
                    title: {
                        text: 'Expense'
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: false
                            },

                            showInLegend: true
                        }
                    },
                    series: [{
                        name: 'Expense',
                        colorByPoint: true,
                        data: [{
                            name: 'Pending',
                            y: 1
                        }, {
                            name: 'Paid',
                            y: 3,
                            sliced: true,
                            selected: true
                        }, {
                            name: 'Overdue',
                            y: 3
                        },
                            {
                                name: 'Partial Paid',
                                y: 3
                            }]
                    }]
                });

                /*High Chart Expense End*/


            },
            error: function (data, success, error) {
                AlertSuc.alertsuccess("error", error);
            }
        });
    }
    //end Expense


    function defaultSelection() {
      
        fillMonthlyExpense();
        fillMonthlyInvoice();

        $('#drpMonthQurterExpense').val(new Date().getMonth() + 1);
        $('#drpMonthQurterInvoice').val(new Date().getMonth() + 1);
        //fillExpensedata();
        fillExpensedetails($('#dpSelectTypeExpense option:selected').text(), $('#drpMonthQurterExpense option:selected').val());
        fillInvoicedetails($('#dpSelectTypeInvoice option:selected').text(), $('#drpMonthQurterInvoice option:selected').val());
    };

    //start Invoice
    $('#dpSelectTypeInvoice').on('change', function () {
      
        if (this.value == '1') { fillMonthlyInvoice(); } else { fillQuarterlyInvoice(); }
    });
    $('#drpMonthQurterInvoice').on('change', function () {
        fillInvoicedetails($('#dpSelectTypeInvoice option:selected').val(), this.value);
    });
    function fillQuarterlyInvoice() {
        $('#drpMonthQurterInvoice').empty();
      
        $('#drpMonthQurterInvoice').append('<option value="4">1 April – 30 June</option><option value="7">1 July – 30 September</option><option value="10">1 October – 31 December</option><option value="1">1 January – 31 March</option>');
    };
    function fillMonthlyInvoice() {
        $('#drpMonthQurterInvoice').empty();
        $('#drpMonthQurterInvoice').append('<option value="1"> January </option><option value="2"> February </option><option value="3"> March </option><option value="4"> April </option><option value="5"> May </option><option value="6"> June </option><option value="7"> July </option><option value="8"> August </option><option value="9"> September  </option><option value="10"> October  </option><option value="11"> November   </option><option value="12"> December   </option>');
    };
    function fillInvoicedetails(type, value) {
        $.ajax({
           
            type: "GET",
            url: generateHandlerUrl.getUrl('../HandlerFiles/Dashboard/InvoiceDashboard.ashx'),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { Type: type, Value: value },
            success: function (data) {
                
                
                    $("#InUTGST").text(data.invoiceUtgst);
                    $("#InIGST").text(data.invoiceIgst);
                    $("#InSGST").text(data.invoiceSgst);
                    $("#InCGST").text(data.invoiceCgst);
                    $("#InToalTax").text(data.invoiceTotalTax);
                   
            },
            error: function (data, success, error) {
                AlertSuc.alertsuccess("error", error);
            }
        });
    }
    //end Invoice
});


