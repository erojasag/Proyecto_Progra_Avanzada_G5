var x = $('#myHiddenVar').val();
$('#displayname').val(x.toString());

$(document).ready(function () {
    let msj = $("#IdMsj").val();
    if (msj != "") {
        MostrarAlerta(msj, "error");
    }

});