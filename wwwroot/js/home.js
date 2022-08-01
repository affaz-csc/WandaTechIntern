// this is our js script file

$(function () { // onload

    // wait and then call
    $('#noti-message').html("<strong>Please wait...</strong>");
    $('#noti-alert').addClass('show');

    setTimeout(fetchNotificaitons, 2500);
});

function fetchNotificaitons() {
    // send request to server: checkNotificaitons
    // receive notification
    // update user with alert
    var response = { "count": 33, "message": "You have 33 notifications" }; //RESP

    // update the msesage inside alert
    var retMessg = "You have <strong>" + response.count + " new notifications.</strong>";
    $('#noti-message').html(retMessg);

    //// show notification alert
    //$('#noti-alert').addClass('show');

    console.log('==>> notificaiton updated');
}
