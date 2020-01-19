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
    $(".pagination-box ul li a").click(function () {
        $(".pagination-box ul li a").removeClass("active");
        $(this).addClass("active");
    });

    $(".study-item span").removeAttr("style");
    $(".study-item p").removeAttr("style");
    $(".study-item").each(function () {
 
        if ($(".des-product", this).html().length > 350) {
            var text = $(".des-product", this).html().substring(0, 350);
            $(".des-product ", this).html(text + "...");
           }
    });
    $(".article-box").each(function () {
        if ($("p", this).html().length > 350) {
            var text = $("p", this).html().substring(0, 350);
            $("p", this).html(text + "...");
           }
    });

});


$(document).mouseup(function (e) {
    var container = $(".support-btn");
    if (!container.is(e.target) && container.has(e.target).length === 0) {
        $(".chat-box").removeClass("open");
        $(".support-btn").removeClass("opened");

    }
});