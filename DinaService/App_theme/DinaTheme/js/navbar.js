$(document).ready(function () {

    navbar();
    function navbar() {
        $('.list-nav > li  ul').addClass('dropdown-container');
    }


    $(".icon-nav").click(function () {

        if ($(this).hasClass("icon-nav-change")) {
            $('.icon-nav').addClass('').removeClass('icon-nav-change');
            $('.sidenav').removeClass('open-nav').addClass('close-nav');
        }
        else {
            $('.icon-nav').addClass('icon-nav-change');
            $('.sidenav').removeClass('close-nav').addClass('open-nav');
        }
    });

    $(".list-nav > li ").click(function () {

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
    $('.search-box > a ').click(function() {
        $('.search-element').addClass('open');
    });

    $(document).scroll(function () {
        navbar();
    });
});
