function MostrarAlerta(mensaje, tipo) {

    const Toast = Swal.fire({
        title: 'Oops...',
        text: mensaje,
        footer: '<a href="">Why do I have this issue?</a>'
    });
        /*Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 150000
    });*/

    Swal.fire({
        type: tipo,
        title: mensaje
    });

}