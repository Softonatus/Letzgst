$(document).ready(function () {

    $('#rtnmonth').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: "mm-yyyy",
        viewMode: "momnths",
        minViewMode: "months"
    });
    //------------------datatabels------------
    $('#gstr1-b2b').DataTable({});
    $('#gstr1-b2cl').DataTable({});
    $('#gstr1-b2cs').DataTable({});
    $('#gstr1-cdnr').DataTable({});
    $('#gstr1-cdnur').DataTable({});
    $('#gstr1-exp').DataTable({});
     $('#gstr1-at').DataTable({});
     $('#gstr1-atadj').DataTable({});

});
