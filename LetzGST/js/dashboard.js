$(document).ready(function () {
    $('.fp').click(function () {
        $('.login-translate-container').css("transform", "translateX(-240px)");
    });

    $('.bl').click(function () {
        $('.login-translate-container').css("transform", "translateX(0px)");
    });
    $('.sign').click(function () {
        $('.login-translate-container').css("transform", "translateX(-480px)");
    });
    

});


$('input').each(function () {
    if ($(this).val() != '') {
        console.log('all inputs filled');
    } else {
        console.log('theres an empty input');
        return false
    }
});
//------------------dashboard-----------------


$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

$('ul.nav li.dropdown').hover(function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
}, function () {
    $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
});


$('#selectprofile').change(function () {
    $('.hideme').hide();
    $('.hidemember').hide();
    if ($(this).val() == 'ca') {
        $('.hidemember').show();
    } else if ($(this).val() == 'consultant') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == 'individual') {
        $('.hideme, .hidemember').hide();
    } else if ($(this).val() == 'comp') {
        $('.hideme, .hidemember').hide();
    } else {
        $('.hideme').show();
    }
});
