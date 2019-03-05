$(document).ready(function () {

    navbar();
    function navbar() {

        $('.list-nav > li  ul').addClass('dropdown-container');



      
    }

    $(".list-nav > li ").click(function () {

        if ($('.icon-nav', this).hasClass("icon-nav-change")) {
            $('.icon-nav', this).addClass('').removeClass('icon-nav-change');
        }
        else {
            $('.icon-nav', this).addClass('icon-nav-change');
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

            closestUl.find("ul")
                .slideUp(function () {
                    if (++count == closestUl.find("ul").length)
                        parallelActiveLinks.removeClass("active");
                });

            if (!linkStatus) {
                closestLi.children("ul").slideDown();
                closestLi.addClass("active");
            }
        });


    $(document).scroll(function () {
        navbar();
    });
});
