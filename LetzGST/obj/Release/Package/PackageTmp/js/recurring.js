$(document).ready(function () {
    $('#pobills').DataTable({
        responsive: true
    });
});

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

});

$('#backtopo').click(function () {
    $("#addexpense").hide(800);
    $("#expensetable").show(800);

});
//---
$('#podate').datepicker({
    autoclose: true,
    todayHighlight: true
});
$('#duedate').datepicker({
    autoclose: true,
    todayHighlight: true
}); /**/



$(document).ready(function () {

    $(document).on('click', '.del', function () {
        var index = $(this).closest('tr').index();
        $(this).parent().parent().remove();
        for (var i = index; i < $('table tbody tr').children().length; i++) {
            $('table tbody tr:nth-child(' + i + ') td:first-child').text(i);
        }
    });

    $(document).on('click', '.add', function () {
        $(this).val('Delete');
        $(this).attr('class', 'btn btn-primary del');
        var appendTxt = "<tr> <td>" + (parseInt($(this).closest('tr').find('td:first-child').text()) + 1) + "</td> <td> <select name='additems' class='form-control additems' required='required'> <option selected>-- Select --</option> <option value='addnewitem' class='addnewtxt'>Add new item</option> <option value='1'> Abc </option> <option value='2'> IT services </option> <option value='3'> JS Enterprises</option> </select> </td> <td><input type='text' class='form-control'></td> <td><input type='text' class='form-control'></td> <td><input type='text' class='form-control'></td> <td><input type='text' class='form-control'></td> <td><input type='text' class='form-control' disabled></td> <td> <select id='tax' name='tax' class='form-control' required='required'> <option selected>-- Select --</option> <option>NA</option> <option value='0'> 0 </option> <option value='3'> 3% </option> <option value='5'>5%</option> <option value='12'>12%</option> <option value='18'>18%</option> <option value='28'>28%</option> </select> </td><td> <select id='tax' name='tax' class='form-control' required='required'> <option selected>-- Select --</option> <option value='inputgood'>Input Good</option> <option value='inputservice'>Input Service</option> <option value='capitalgood'>Capital Good</option> </select> </td> <td> <select id='tax' name='tax' class='form-control' required='required'> <option selected>-- Select --</option> <option value='T4'> Business Purpose (T4) </option> <option value='T1'> Non-Business Purpose (T1) </option> <option value='T2'>Sale of Exempted supply (T2)</option> <option value='T3'>Restricted Products (T3)</option> <option value='C2'>Common/Other (C2)</option> </select> </td> <td width='2%'><input type='button' class='btn btn-primary add' value='Add More' />  </td> </tr>";
        $("tr:last").after(appendTxt);
    });
});


/*$(document).on('change', 'select[name="additems"]', function () {
    if ($(this).find('option:selected').text() !== "Add new") {
        if (!$(this).attr('rowAdded')) {
            $('#potable tbody').append($('#potable tbody tr:first-child').clone());
            $('#potable tbody tr:last-child td:first-child').text($('#potable tbody tr').length);
            for (var i = 3; i < $('#potable tbody tr:first-child').children().length - 1; i++) {
                $('#potable tbody tr:last-child td:nth-child(' + i + ')').find('input').val('');
            }
            $('#potable tbody tr:last-child td:nth-child(2)').find('select').removeAttr('disabled');
            $(this).attr('rowAdded', true);
        }
    } else {
        $(this).attr('');
    }
});

$(document).on('click', '.delete-row', function () {
    if ($(this).closest('tr').index()) {
        $(this).closest('tr').remove();
    } else {
        for (var i = 3; i < $('#potable tbody tr:first-child').children().length - 1; i++) {
            $('#potable tbody tr:first-child td:nth-child(' + i + ')').find('input').val('');
            //$('select option:selected').removeAttr('selected');
            //$('select').val('');
        }
    }

});*/
//-------open modal for poorder to
