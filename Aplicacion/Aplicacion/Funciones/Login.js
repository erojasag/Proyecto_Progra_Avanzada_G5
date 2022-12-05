function ValidarUsuario() {
    $(document).ready(function () {
        let msj = $("#IdMsj").val();

        if (msj != "") {
            MostrarAlerta(msj, "success");

            if (msj == isEmpty) {
                MostrarAlerta(msj, "error");

            }

        });
}

