// $(document).ready(function () {
//     // $("#btn_Checkdate").click(async function () {
//     //     $.ajax({
//     //         url: '/Reservation/AJAXPost',
//     //         type: 'POST',
//     //         contentType: 'application/json; charset=utf-8',
//     //         headers: {
//     //             RequestVerificationToken:
//     //                 $('input:hidden[name="__RequestVerificationToken"]').val()
//     //         },
//     //         data: JSON.stringify({rezervt: $("#Date_input").val()})
//     //     })
//     //         .done(function (result) {
//     //         })
//… rest of code left out
// $.ajax({
//      type: "POST",
//      url: "/Reservation/AJAXPost",
//      data: {"Datereserv": $("#Date_input").val()},
//      success: function (response) {
//          // alert("Student Name: " + response.Name + "<br/>Email: " + response.Email);
//      },
//      failure: function (response) {
//          alert(response.responseText);
//      },
//      error: function (response) {
//          alert(response.responseText);
//      }
//  });
//     });
// });
// $(document).ready(function () {
//     let option = $("#Table_option");
//
//     $(document).on("click", "#btn_Checkdate",
//         function () {
//             // var data = $("#studenteForm").serialize();
//             // console.log(data);
//             // alert(data);
//             let ccc = ($("#Date_input")[0].value.toString())
//            
//
//             $.ajax({
//                 type: "POST",
//                 url: '/Reservation/CheckDate',
//                 data: ccc,
//                 dataType: "text",
//                 success: function (msg) {
//                     console.log(msg);
//                 },
//                 error: function (req, status, error) {
//                     console.log(msg);
//                 }
//             })
// $.ajax({
//     type: 'POST',
//     url: '/Reservation/CheckDate',
//     contentType: 'application/json', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
//     data: date_input,
//     success: function (result) {
//         alert('Successfully received Data ');
//         console.log(result);
//     },
//     error: function () {
//         alert('Failed to receive the Data');
//         console.log('Failed ');
//     }
// })
// alert("okeey")
// $.ajax({
//     url: "/Reservation/CheckDate",
//     method: "GET",
//     success: function (result) {
//         console.log(result)
//         console.log($("#Table_option"))
//         for (let i = 0; i < result.length; i++) {
//             // .innerHTML +='<option> Name</option>';
//             option[0].innerHTML += `<option value="${result[i].id}">${result[i].tableNumber}</option>`;
//         }
//     }
// })
// console.log(date_input[0].value)
// $.ajax({
//     // url: "/Reservation/CheckDate",
//     // method: "POST",
//     // data: date_input[0].value.toString(),
//     // dataType: "text",
//     // success: function (resultData) {
//     //     alert("Save Complete");
//     // }
//     url: "/Reservation/CheckDate\"",
//     type: "post",
//     data: date_input
// })


$('.owl-carousel').owlCarousel({
    loop: true,
    margin: 0,
    nav: true,
    autoplay: true,
    autoplayTimeout: 4000, //slide deyishim sureti
    autoplayHoverPause: false,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})
//         })
// })

// dish owl carousel slider js
// var owl = $('.dish_carousel').owlCarousel({
//     loop: true,
//     margin: 15,
//     dots: false,
//     autoplay: true,
//     navText: [
//         '<i class="fa fa-arrow-left" aria-hidden="true"></i>',
//         '<i class="fa fa-arrow-right" aria-hidden="true"></i>'
//     ],
//     autoplayHoverPause: true,
//     responsive: {
//         0: {
//             items: 1,
//             margin: 0
//         },
//         800: {
//             items: 3
//         },
//         576: {
//             items: 2
//         },
//         991: {
//             items: 4
//         }
//     }
// })
//
/*
var $owl = $('.owl-carousel');

$owl.children().each( function( index ) {
    $(this).attr( 'data-position', index ); // NB: .attr() instead of .data()
});

$owl.owlCarousel({
    center: true,
    loop: true,
    items: 5,
    autoplay:true,
    autoplayTimeout:1000,
    autoplayHoverPause:true

});
*/
//
// $(document).on('click', '.owl-item>div', function() {
//     // see https://owlcarousel2.github.io/OwlCarousel2/docs/api-events.html#to-owl-carousel
//     var $speed = 300;  // in ms
//     $owl.trigger('to.owl.carousel', [$(this).data( 'position' ), $speed] );
// });
//

$(function () {
    $('.mhn-slide').owlCarousel({
        nav: true,
        //loop:true,
        slideBy: 'page',
        loop: true,
        items: 5,
        autoplay: true,
        autoplayTimeout: 1000,
        autoplayHoverPause: true,
        rewind: false,
        responsive: {
            0: {items: 1},
            480: {items: 2},
            600: {items: 3},
            1000: {items: 4}
        },
        smartSpeed: 70,
        onInitialized: function (e) {
            $(e.target).find('img').each(function () {
                if (this.complete) {
                    $(this).closest('.mhn-inner').find('.loader-circle').hide();
                    $(this).closest('.mhn-inner').find('.mhn-img').css('background-image', 'url(' + $(e.target).attr('src') + ')');
                } else {
                    $(this).bind('load', function (e) {
                        $(e.target).closest('.mhn-inner').find('.loader-circle').hide();
                        $(e.target).closest('.mhn-inner').find('.mhn-img').css('background-image', 'url(' + $(e.target).attr('src') + ')');
                    });
                }
            });
        },
        navText: ['<svg viewBox="0 0 24 24"><path d="M15.41 7.41L14 6l-6 6 6 6 1.41-1.41L10.83 12z"></path></svg>', '<svg viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"></path></svg>']
    });
});


lightGallery(document.querySelector(".galery"))


$(document).ready(function () {
    var $regexnumber = /^(\+|\d)[0-9]{8,16}$/;
    $('#PhoneNumber').on('keypress keydown keyup', function () {
        if (!$(this).val().match($regexnumber)) {

            $('.PhoneNumberlabel').addClass('text-danger');
            $('.PhoneNumberlabel').show();
        } else {

            $('.PhoneNumberlabel').removeClass('text-danger');
        }
    });


    var $regexEmail = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    $('#Email').on('keypress keydown keyup', function () {
        if (!$(this).val().match($regexEmail)) {
            $('.Emaillabel').addClass('text-danger');
            $('.Emaillabel').show();
        } else {
            // else, do not display message
            $('.Emaillabel').removeClass('text-danger');
        }
    });
});


$(document).ready(function () {


    const picker = document.getElementById('datepicker');
    picker.addEventListener('input', function (e) {
        var day = new Date(this.value).getUTCDay();
        if ([5, 0].includes(day)) {
            e.preventDefault();
            this.value = '';
            alert('Weekends not allowed');
        }
    });

 });
