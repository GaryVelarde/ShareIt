function validarLogin() {
    var usuario = document.getElementById('ipUsuario').value;
    var password = document.getElementById('ipPassword').value;
    if (usuario.length == 0) {
        $("#validacionIpEmail").addClass('alert-validate');
    } else {
        $("#validacionIpEmail").removeClass('alert-validate');
    }

    if (password.length == 0) {
        $("#validacionIpPassword").addClass('alert-validate');
    } else {
        $("#validacionIpPassword").removeClass('alert-validate');
    }
    if (usuario.length > 0 && password.length > 0) {
        alert('si');
        r   eturn false;
    }
};
function validarEmail(valor) {
    if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(valor)) {
        $("#validacionIpEmail").removeClass('alert-validate');
    } else {
        $("#validacionIpEmail").addClass('alert-validate');
    }
}