const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('#inputPassword');
const form = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');

formulario.addEventListener('submit', function(e) {
    e.preventDefault();
});

togglePassword.addEventListener('click', function (e) {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});

/*function TogglePass() {
    var x = document.getElementById("myInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}*/

function matchPassword() {
    var pw1 = document.getElementById('inputPassword');
    var pw2 = document.getElementById('inputPassword1');
    if (pw1 !== pw2) {
        alert("Passwords did not match");
    } if (pw1 === pw2) {
        alert("Passwords match");
    }
}  
