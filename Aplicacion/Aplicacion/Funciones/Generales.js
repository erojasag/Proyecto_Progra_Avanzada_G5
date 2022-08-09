function MostrarAlerta(mensaje, tipo) {

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 150000
    });

    Toast.fire({
        type: tipo,
        title: mensaje
    });

}