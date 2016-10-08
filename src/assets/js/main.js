$(".tabs").hide();

$(".workers-list__button").on("click", function() {
    console.log("works");
    $(".workers-list__button").css("margin", "5px");
    $(".workers-list__button").css("box-shadow", "2px 2px 5px rgb(200,200,200)");
    $(this).css("margin", "7px 3px 3px 7px");
    $(this).css("box-shadow", "0 0 0");

    var j = $(this).data("id");
    $(".tabs").fadeOut();
    $('#workers__container').empty();

    setTimeout(tabDisplay, 1000);
        function tabDisplay() {
            var tab = "#tab_" + j;
            $(tab).fadeIn();
        };
    $(".workers-list__button").addClass("hidden");

    $.ajax({
        type: 'GET',
        url: 'http://jakubswierczek.azurewebsites.net/api/users',
        data: { get_param: 'value' },
        dataType: 'json',
        success: function (data) {
            $.each(data, function(index, element) {
                var container = "<div class=profile data-id=" + element.Id + "><img src=assets/images/face_" + element.Id + ".png alt class=face><div>" + element.Name + " " + element.Surname + "<br><span class=role>" + element.Role + "</span></div></div>";
                $('#workers__container').append(container);
            });
            $(".profile").on('click', function () {
                console.log($(this));
                var personalId = $(this).attr("data-id");
                var link = 'http://jakubswierczek.azurewebsites.net/api/users/' + personalId;
                $('#workers__container').empty();
                console.log(link);

                $.ajax({
                    type: 'GET',
                    url: link,
                    data: { get_param: 'value' },
                    dataType: 'json',
                    success: function (data) {
                        var container = "<div class=profile-full data-id=" + data.Id + "><img src=assets/images/photo_" + data.Id + ".png alt class=photo><table><tr><td>IMIĘ</td><td>" + data.Name + "</td></tr><tr><td>NAZWISKO</td><td>" + data.Surname + "</td></tr><tr><td>STANOWISKO</td><td data-id=" + data.RoleId + ">" + data.Role +  "</td></tr><tr><td>TECHNOLOGIE</td><td>" + data.Technologies +  "</td></tr><tr><td>ZAINTERESOWANIA</td><td>" + data.Hobbies + "</td></tr></table></div>";
                        $('#workers__container').append(container);
                    },
                    error: function() {
                        console.log("error");
                    }
                });
            });
        }
    });

})





$("#trigger").on("click", function() {
    $(".workers-list__button").toggleClass("hidden");
})

$(".submit").on("click", function(ev) {
    ev.preventDefault();
})


$(".addUser").on("click", function() {
    alert("Dodano użytkownika");
})
