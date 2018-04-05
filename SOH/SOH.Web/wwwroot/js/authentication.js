function postLogOutRequest() {
    var targetURL = window.location.origin + "/account/logout";
    return $.ajax({
        url: targetURL,
        type: "post",
        headers: {
            'Content-Type': 'application/json',
            "RequestVerificationToken": $('#RequestVerificationToken').val()
        },
        success: function (response) {
            window.location.href = window.location.href;
        },
        error: function (xhr) {
            alert("We are really sorry :( Something wrong happened.");
        }
    });
}

$("#logoutButton").click(function () {
    window.postLogOutRequest();
});