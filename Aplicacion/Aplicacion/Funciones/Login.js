function ValidarUsuario() {
    $.ajax({
        type: 'POST',
        url: "/users/ValidateUser",
        data: {
            "User":"User"
        },
        dataType: 'json',
        success: function (data) {
            alert('Successful');
        },
        error: function (data) {
            alert('successfull');
        }
    });
}