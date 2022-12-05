const togglePassword = document.querySelector('#togglePassword');
const togglePassword2 = document.querySelector('#togglePassword2');
const password = document.querySelector('#inputPassword');

const password2 = document.querySelector('#inputPassword2');

togglePassword.addEventListener('click', function (e) {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    
    password.setAttribute('type', type);
    
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});

togglePassword2.addEventListener('click', function (e) {
    // toggle the type attribute
    
    const type2 = password2.getAttribute('type2') === 'password2' ? 'text' : 'password2';

    password2.setAttribute('type2', type2);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});


if (password != password2) {
    $(document).ready(function () {
        let msj = $("#IdMsj").val();
        if (msj != "") {
            MostrarAlerta(msj, "error");
        }

    });
}