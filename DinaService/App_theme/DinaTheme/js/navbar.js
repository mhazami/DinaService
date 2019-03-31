$(document).ready(function () {
    menuScroll();
    navbar();
    function navbar() {
        $('.list-nav > li  ul').addClass('dropdown-container');
    }

    $(".r-collapse").click(function () {

        if ($('.icon-nav', this).hasClass("icon-nav-change")) {
            $('.icon-nav', this).addClass('').removeClass('icon-nav-change');
        }
        else {
            $('.icon-nav').addClass('').removeClass('icon-nav-change');
            $('.icon-nav', this).addClass('icon-nav-change');
        }
    });

    $(".list-nav > li > a").click(function () {

        if ($('.btn-menu', this).hasClass("icon-nav-change")) {
            $('.btn-menu', this).addClass('').removeClass('icon-nav-change');
        }
        else {
            $('.list-nav > li .btn-menu').addClass('').removeClass('icon-nav-change');
            $('.btn-menu', this).addClass('icon-nav-change');
        }
    });

    $('.mask').on('click', function () {
        $('.icon-nav').addClass('').removeClass('icon-nav-change');
        $('.sidenav').removeClass('open-nav').addClass('close-nav');

    }).children().on('click', function (event) {
        event.stopPropagation();
    });

    $("#accordian li")
        .click(function () {
            if ($(this).hasClass('active')) {
                $(this).removeClass('active');
            }
            $(this).addClass('active');
        });
    $("#accordian a")
        .click(function () {
            var link = $(this);
            var closestUl = link.closest("ul");
            var parallelActiveLinks = closestUl.find(".active");
            var closestLi = link.closest("li");
            var linkStatus = closestLi.hasClass("active");
            var count = 0;
            if ($(window).width() >= 750) {


                closestUl.find("ul")
                    .fadeOut(function () {
                        if (++count == closestUl.find("ul").length)
                            parallelActiveLinks.removeClass("active");
                    });

                if (!linkStatus) {
                    closestLi.children("ul").fadeIn();
                    closestLi.addClass("active");
                }
            } else {
                closestUl.find("ul")
                    .slideUp(function () {
                        if (++count == closestUl.find("ul").length)
                            parallelActiveLinks.removeClass("active");
                    });

                if (!linkStatus) {
                    closestLi.children("ul").slideDown();
                    closestLi.addClass("active");
                }
            }
        });





    $('body').click(function (event) {
        if (!$('.search-element').is(event.target) && $('.search-element').has(event.target).length === 0) {
            $('.search-element').removeClass('open');
            $('.search-box > a').removeClass('open');
        }
    });
    $('.search-box > a').click(function (event) {
        event.stopPropagation();
        $(this).toggleClass('open');
        $(".search-element").toggleClass('open');
    });






    $('body').click(function (event) {
        if (!$('.r-nav').is(event.target) && $('.r-nav').has(event.target).length === 0) {
            $('.r-nav').removeClass('open-nav');
            $('.r-nav').addClass('close-nav');
            $('.search-box > a').removeClass('open');
            $('.r-collapse .icon-nav').addClass('').removeClass('icon-nav-change');
        }
    });
    $('.r-collapse').click(function (event) {
        event.stopPropagation();
        $('.r-nav').toggleClass('open-nav close-nav');


    });





    $(document).scroll(function () {
        navbar();
        menuScroll();
    });


    function menuScroll() {
        if ($(window).width() >= 788) {

            $(window).bind('scroll', function () {

                var navHeight = 50;

                if ($(window).scrollTop() > navHeight) {

                    $('.container-nav').addClass('sticky');

                }

                else {

                    $('.container-nav').removeClass('sticky');

                }

            });

        }
    }

});
function aos() {

    AOS.init({
        easing: "ease-in-out-sine",
        once: true
    });
}
$('.owl-carousel').owlCarousel({
    rtl: true,
    loop: false,
    margin: 40,

    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 5
        }
    }
});