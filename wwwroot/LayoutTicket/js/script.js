$(function () {
    // Mobile navbar button
    $('.mobile-menu_btn').click(showMobileNav);

    $('.mobile-menu-close_btn').click(hideMobileNav);
});

function showMobileNav(e) {
    $(e.currentTarget).hide();
    $('.mobile-menu-close_btn').show();
    $('.navbar').addClass('active');
}
function hideMobileNav(e) {
    $(e.currentTarget).hide();
    $('.mobile-menu_btn').show();
    $('.navbar').removeClass('active');
}

// close alert

$('.close-close').click(function () {
    $(this).parent().hide();
});

// button cinema seat
var countSeat = 0;
$('.cinema-seat').click(function () {
    if ($(this).hasClass('cinema-seat__active')) {
        $(this).removeClass('cinema-seat__active');
        countSeat--;
    } else {
        $(this).addClass('cinema-seat__active');
        countSeat++;
    }
});

// sell validate
$('.btn-sell').click(function () {
    if (countSeat == 0) {
        $('.zero-seat').show(150).css({ display: 'flex', top: '50px', left: '25%' });
    } else if (countSeat > 1) {
        $('.one-seat').show(150).css({ display: 'flex', top: '50px', left: '25%' });
    } else {
        console.log('ngu1');
        // $('.modal-success').on('shown.bs.modal', function (e) {
        //     console.log('nguu2');
        //     console.log(e);
        //     $('.modal-lgg').attr('aria-hidden', true);
        // });
        var modalShow = new bootstrap.Modal(document.querySelector('.modal-lgg'), {});

        modalShow._element.classList.remove('show', 'modal-backdrop');

        var modalSuccess = new bootstrap.Modal(document.querySelector('.modal-success'), {
            // backdrop: true,
        });
        modalSuccess.show();
    }
    setTimeout(function () {
        jQuery('.one-seat').hide();
        jQuery('.zero-seat').hide();
    }, 4000);
});

$('.list-film__container').slick({
    ifinity: true,
    arrows: true,
    autoplaySpeed: 1000,
    autoplay: true,
    slidesToShow: $(window).width() < 776 ? 3 : 5,
    slidesToScroll: 1,
    prevArrow: $('.arrow-left'),
    nextArrow: $('.arrow-right'),
});

$(window).on('resize', function () {
    var win = $(this);
    if (win.width() < 767) {
        /* ... */
    }
    if (win.width() >= 1280) {
        /* ... */
    }
});

// blog js thuần :)))
x = document.querySelectorAll('.btn--blog');
x[0].onclick = function () {
    x[0].classList.add('blog-active');
    x[1].classList.remove('blog-active');
};
x[1].onclick = function () {
    x[1].classList.add('blog-active');
    x[0].classList.remove('blog-active');
};
