$(document).ready(function () {
    $('.slide-show .slide-items-box:first-child').addClass('current');
    $('.content-slide p').wrap('<div></div>');
    var current_item = $('.current').index();

    $.setSettingSlider('.slide-show',
        {
            height: '550px',
            width: '100%',
            isShow: true,
            slider_control: 'icon',
            change_button: true,
            type_change: 'fade',
            time_change: 10000,
            //            auto_change: true,

        });

    text_effect();

});


(function ($) {
    $.setSettingSlider = function (selector, setting) {
        var defaults = {
            color: '#ffffff',
            background: '#146DA8',
            height: '450px',
            width: '600px;',
            isShow: true,
            auto_change: true,
            time_change: 3000,
            slider_control: 'icon',
            type_change: 'fade',
            change_button: false,
        }
        var obj = $(selector);
        var config = $.extend({

            defaults
        },
            setting);


        $('.slide-show').each(function () {
            var ID = this.id;
            var idElement = $("#" + ID + "");


            $(document).ready(function () {

                $(idElement).children('.prev-slide').click(function () {
                    clearInterval(interval);
                    prev_slide();
                });

                $(idElement).children('.next-slide').click(function () {
                    clearInterval(interval);

                    next_slide();


                });
            });



            if (setting.auto_change == true) {
                var interval = setInterval(doStuff, setting.time_change);
                function doStuff() {
                    next_slide();
                }


            }



            function next_slide() {

                var countIndex = $(idElement).children('.slide-show .slide-items-box').length;
                var current_item = $(idElement).children('.current').index();
                var current_item_dots = $(idElement).children('.current-dot').index();
                if (countIndex => current_item) {

                    current_item++;
                    current_item_dots++;
                    $(idElement).children('.current').removeClass('current');
                    $(idElement).children('.slide-show .slide-items-box').removeClass('lasts');
                    $(idElement).children('.current-dot').removeClass('current-dot');
                    if (countIndex == current_item) {
                        current_item = 0;
                        current_item_dots = 0;
                    }

                    $(idElement).children(".slide-show .slide-items-box").eq(current_item - 1).addClass('lasts');
                    $(idElement).children(".slide-show .slide-items-box").eq(current_item).addClass('current');
                    $(idElement).children(".dot-slider .doted-item").eq(current_item_dots).addClass('current-dot');
                }
                text_effect();


            }


            function prev_slide() {
                var countIndex = $(idElement).children('.slide-show .slide-items-box').length;
                var current_item = $(idElement).children('.current').index();
                var current_item_dots = $(idElement).children('.current-dot').index();
                if (countIndex => current_item) {

                    current_item--;
                    current_item_dots--;
                    $(idElement).children('.current').removeClass('current');
                    $(idElement).children('.slide-show .slide-items-box').removeClass('lasts');
                    $(idElement).children('.current-dot').removeClass('current-dot');
                    if (countIndex == current_item) {
                        current_item = 0;
                        current_item_dots = 0;
                    }
                    $(idElement).children('.slide-show .slide-items-box').removeClass('lasts');
                    $(idElement).children(".slide-show .slide-items-box").eq(current_item).addClass('current');
                    $(idElement).children(".slide-show .slide-items-box").eq(current_item + 1).addClass('lasts');
                    $(idElement).children(".dot-slider .doted-item").eq(current_item_dots).addClass('current-dot');
                }
                text_effect();
            }


            if (setting.isShow == true) {
                obj.each(function () {
                    $(idElement).css({
                        'color': config.color,
                        'background': config.background,
                        'width': config.width,
                        'height': config.height
                    });
                    $('.slide-items-box', idElement).css({
                        'width': config.width

                    });

                    $('img', idElement).css({
                        'width': config.width,
                        'height': config.height
                    });
                    //content-slide


                    switch (setting.slider_control) {
                        case 'button':
                            $(idElement).append(' <button onclick="prev_slide()" class="prev-slide"> prev</button>' +
                                ' <button  class="next-slide"> Next</button >');
                            break;
                        case 'icon':
                            $(idElement).append(' <button class="prev-slide has-icon-slider"> &#10094;</button>' +
                                ' <button  class="next-slide has-icon-slider" > &#10095;</button >');
                            break;
                        default:
                    }
                    switch (setting.type_change) {
                        case 'top-to-bottom':
                            $('.slide-items-box', idElement).addClass('top-to-bottom');
                            break;

                        case 'bottom-to-top':
                            $('.slide-items-box', idElement).addClass('bottom-to-top');
                            break;
                        case 'left-to-right':
                            $('.slide-items-box', idElement).addClass('left-to-right');
                            break;
                        case 'right-to-left':
                            $('.slide-items-box', idElement).addClass('right-to-left');
                            break;
                        default:
                    }
                });
            } else {
                obj.each(function () {

                    $(this).css({ 'display': none });
                });
            }

            if (setting.change_button == true) {
                $(document).ready(function () {
                    $("body").keydown(function (e) {
                        if (e.keyCode == 37) { // left

                            var interval = setInterval(doStuff, setting.time_change);
                            function doStuff() {
                                clearInterval(interval);
                            }

                            if ($('.slide-show .slide-items-box', idElement).hasClass('left-to-right') || $('.slide-show .slide-items-box', idElement).hasClass('right-to-left')) {

                                $('.slide-items-box', idElement).addClass('left-to-right');
                                $('.slide-items-box', idElement).removeClass('right-to-left');
                            }
                            else if ($('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom') || $('.slide-show .slide-items-box', idElement).hasClass('bottom-to-top') || $('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom-effect')) {

                                $('.slide-items-box', idElement).addClass('top-to-bottom');
                                $('.slide-items-box', idElement).removeClass('bottom-to-top');
                            }
                            next_slide();


                        } else if (e.keyCode == 39) { // right
                            var interval1 = setInterval(doStuff, setting.time_change);
                            function doStuff() {
                                clearInterval(interval1);
                            }


                            if ($('.slide-show .slide-items-box', idElement).hasClass('left-to-right') || $('.slide-show .slide-items-box', idElement).hasClass('right-to-left')) {

                                $('.slide-items-box', idElement).removeClass('left-to-right');
                                $('.slide-items-box', idElement).addClass('right-to-left');
                            }
                            else if ($('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom') || $('.slide-show .slide-items-box', idElement).hasClass('bottom-to-top') || $('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom-effect')) {

                                $('.slide-items-box', idElement).removeClass('top-to-bottom');
                                $('.slide-items-box', idElement).addClass('bottom-to-top');
                            }
                            prev_slide();
                        }
                    });
                });
            } else {
                return;
            }

            $(document).ready(function () {
                $('.dot-slider', idElement).addClass('auto_hidden');
                $(".content-slide", idElement).each(function () {
                    $('.slide-show .doted-item:first-child', idElement).addClass('current-dot');
                    var countIndex = $('.slide-show .slide-items-box', idElement).length;
                    for (var i = 0; i <= $('.slide-show .slide-items-box', idElement).length; i++) {
                        $('.dot-slider', idElement).append('<a class="doted-item"></a>');
                        return;
                    }
                });

                $('.doted-item', idElement).click(function () {
                    var interval = setInterval(doStuff, setting.time_change);
                    function doStuff() {
                        clearInterval(interval);
                    }

                    var a = $(idElement).index();
                    var current_item = $('.current', idElement).index();
                    var lasts = $('.lasts', idElement).index();
                    if (lasts < 0) {
                        var lasts = 0;
                    }
                    $('.slide-show .slide-items-box', idElement).removeClass('lasts');

                    $(".slide-show .slide-items-box", idElement).eq(current_item).addClass('lasts');
                    var name_item = $(idElement);
                    if ($(name_item).hasClass("current-dot")) {
                        return;
                    } else {
                        if ($('.slide-show .slide-items-box', idElement).hasClass('left-to-right') || $('.slide-show .slide-items-box', idElement).hasClass('right-to-left')) {
                            if (a > current_item) {

                                $('.slide-items-box', idElement).removeClass('left-to-right');
                                $('.slide-items-box', idElement).addClass('right-to-left');

                            }
                            else if (a < current_item) {
                                $('.slide-items-box', idElement).addClass('left-to-right');
                                $('.slide-items-box', idElement).removeClass('right-to-left');
                            }
                        }
                        else if ($('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom') || $('.slide-show .slide-items-box', idElement).hasClass('bottom-to-top') || $('.slide-show .slide-items-box', idElement).hasClass('top-to-bottom-effect')) {
                            if (a > current_item) {
                                $('.slide-items-box', idElement).removeClass('top-to-bottom');
                                $('.slide-items-box', idElement).addClass('bottom-to-top');

                            }
                            else if (a < current_item) {
                                $('.slide-items-box', idElement).addClass('top-to-bottom');
                                $('.slide-items-box', idElement).removeClass('bottom-to-top');
                            }
                        }
                        $('.current', idElement).removeClass('current');

                        $('.current-dot', idElement).removeClass('current-dot');
                        $(name_item).addClass('current-dot');
                        $(".slide-show .slide-items-box", idElement).eq(a).addClass('current');

                    }
                    text_effect();
                });
            });

        });


    };
})(jQuery);
function text_effect() {
    $(".current .content-slide > span").slideUp(300).delay(500).fadeIn(400);
    $(".current .content-slide > div").slideUp(300).delay(2500).fadeIn(400);
    $(".current .content-slide .r-slider-btn").slideUp(300).delay(3000).fadeIn(400);


}



//رفع مشکل تمام صفحه شدن اسلاید ها

