var menuStatus = localStorage.getItem("isMenuOpened");

if (menuStatus != null) {
    if (menuStatus != "menu_opened") {
        $(".sidebar").addClass("minion");
        $("#btn").html("menu");
        localStorage.setItem("isMenuOpened", "menu_closed");
    }
    else {
        $(".sidebar").removeClass("minion");
        $("#btn").html("menu_open");
        localStorage.setItem("isMenuOpened", "menu_opened");
    }
} else {
    $(".sidebar").removeClass("minion");
    $("#btn").html("menu_open");
    localStorage.setItem("isMenuOpened", "menu_opened");
}


// on page loaded
$(document).ready(function () {

    // Logo Click to Home
    $(".sidebar .logo-details").click(function (e) {
        window.location.href = "/";
    });

    $('body').bind('cut copy paste', function (e) {
        e.preventDefault();
    });
    

    // Side Navigation minion action stating function
    $("#btn").click(() => {
        if ($("#btn").html() === "menu") {
            $(".sidebar").removeClass("minion");
            $("#btn").html("menu_open");
            localStorage.setItem("isMenuOpened", "menu_opened");
        } else {
            $(".sidebar").addClass("minion");
            $("#btn").html("menu");
            localStorage.setItem("isMenuOpened", "menu_closed");
        }
    });




});


