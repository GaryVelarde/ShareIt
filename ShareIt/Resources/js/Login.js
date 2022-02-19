function validarLogin() {
    cargando();
    var usuario = document.getElementById('ipUsuario').value;
    var password = document.getElementById('ipPassword').value;
    var validacionCorreo = 0;

    if (usuario.length == 0) {
        $("#validacionIpEmail").addClass('alert-validate');
    } else {
        $("#validacionIpEmail").removeClass('alert-validate');
    }

    if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(usuario)) {
        validacionCorreo = 1;
    } else {
        validacionCorreo = 0;
    }

    if (password.length == 0) {
        $("#validacionIpPassword").addClass('alert-validate');
    } else {
        $("#validacionIpPassword").removeClass('alert-validate');
    }
    if (usuario.length > 0 && password.length > 0 && validacionCorreo == 1) {
        alert('si');
    }
    finCarga();
};
function validarEmail(valor) {
    if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(valor)) {
        $("#validacionIpEmail").removeClass('alert-validate');
    } else {
        $("#validacionIpEmail").addClass('alert-validate');
    }
};

function cargando() {
    $("#myModal").fadeIn();
    document.getElementsByTagName('body')[0].style.overflow = 'hidden';
};
function finCarga() {
    $("#myModal").fadeOut();
    document.getElementsByTagName('body')[0].style.overflow = 'visible';
};

function validacionDatos() {
    var nombres = $("#ipNombres").val();
    var apellidos = $("#ipApellidos").val();
    var correo = $("#ipCorreo").val();
    var clave = $("#ipPassword").val();
    var segundaClave = $("#ipPassword2").val();
    var fechaNacimiento = $("#ipFechaNacimiento").val();
    var celular = $("#ipCelular").val();
    var fechaActual = $("#ipFechaActual").val();

    var valNombres = 0;
    var valApellidos = 0;
    var valCorreo = 0;
    var valClave = 0;
    var valFechaNacimiento = 0;
    var valCelular = 0;

    if (nombres.length == 0) {
        $("#validacionipNombres").addClass('alert-validate');
        valNombres = 0;
    } else {
        $("#validacionipNombres").removeClass('alert-validate');
        valNombres = 1;
    }

    if (apellidos.length == 0) {
        $("#validacionipApellidos").addClass('alert-validate');
        valApellidos = 0;
    } else {
        $("#validacionipApellidos").removeClass('alert-validate');
        valApellidos = 1;
    }

    if (celular.length < 9) {
        $("#validacionipCelular").addClass('alert-validate');
        valCelular = 0;
    } else {
        $("#validacionipCelular").removeClass('alert-validate');
        valCelular = 1;
    }

    if (correo.length == 0) {
        var aviso = document.getElementById("validacionIpEmail");
        aviso.setAttribute("data-validate", "Por favor ingrese su correo.");
        $("#validacionIpEmail").addClass('alert-validate');
        valCorreo = 0;
    } else {
        var aviso = document.getElementById("validacionIpEmail");
        aviso.setAttribute("data-validate", "El correo no es válido.");
       
        if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(correo)) {
            valCorreo = 1;
            $("#validacionIpEmail").removeClass('alert-validate');
        } else {
            valCorreo = 0;
            $("#validacionIpEmail").addClass('alert-validate');
        }
    }
    

    if (clave.length == 0) {
        var aviso = document.getElementById("validacionIpPassword");
        aviso.setAttribute("data-validate", "Se necesita una contraseña segura.");
        $("#validacionIpPassword").addClass('alert-validate');
        valClave = 0;
    } else {
        validarClave();
        if (segundaClave.length == 0) {
            $("#validacionIpPassword2").addClass('alert-validate');
            valClave = 0;
        } else {
            if (segundaClave == clave) {
                $("#validacionIpPassword2").removeClass('alert-validate');
                valClave = 1;
            } else {
                var aviso = document.getElementById("validacionIpPassword2");
                aviso.setAttribute("data-validate", "La contraseña no coincide.");
                $("#validacionIpPassword2").addClass('alert-validate');
                valClave = 0;
            }
        }
    }

    if (fechaNacimiento == fechaActual) {
        $("#validacionipFechaNacimiento").addClass('alert-validate');
        valFechaNacimiento = 0;
    } else {
        $("#validacionipFechaNacimiento").removeClass('alert-validate');

        valFechaNacimiento = 1;
    }

    if (valNombres == 1 && valApellidos == 1 && valCorreo == 1 && valClave == 1 && valFechaNacimiento == 1 && valCelular == 1) {
        registrarUsuario();
    };

};
function registrarUsuario() {
    var nombres = $("#ipNombres").val();
    var apellidos = $("#ipApellidos").val();
    var correo = $("#ipCorreo").val();
    var clave = $("#ipPassword").val();
    var fechaNacimiento = $("#ipFechaNacimiento").val();
    var celular = $("#ipCelular").val();
    $.ajax({
        type: 'GET',
        url: '/Login/RegistrarUsuario',
        data: {
            nombres: nombres,
            apellidos: apellidos,
            correo: correo,
            clave: clave,
            fechaNacimiento: fechaNacimiento,
            celular: celular
        },
        success: function (data) {
            $.each(data, function (i, val) {
                if (val.Codigo == "1") {
                    //window.location.href = 'DatosPersonales/{new idUsuario=' + val.Datos + '}';

                    $.ajax({
                        url: 'Login/DatosPersonales',
                        method: "post",
                        data: {idUsuario : '1'},
                        success: function (response) {

                        },
                        async: true
                    });

                    alert(val.Mensaje);
                } else {
                    alert("Hubo un error al registrar el usuario: " + val.Mensaje);
                }
                console.log('Resultado: \n' + val.Codigo + ' / ' + val.Mensaje + ' / ' + val.Datos);
            });
        },
        error: function () {
        },
        complete: function () {
        }
    })
};
function validarClave() {
    var aviso = document.getElementById("validacionIpPassword");
    var contrasenna = document.getElementById('ipPassword').value;
    if (validar_clave(contrasenna) == true) {
        aviso.setAttribute("data-validate", "Se necesita una contraseña segura.");
        $("#validacionIpPassword").removeClass('alert-validate');
    } else if (contrasenna == "") {
        aviso.setAttribute("data-validate", "Se necesita una contraseña segura.");
        $("#validacionIpPassword").removeClass('alert-validate');
    }
    else {
        aviso.setAttribute("data-validate", "Debe contener al menos 8 dígitos entre letras minúsculas, mayúsculas, números y símbolos.");
        $("#validacionIpPassword").addClass('alert-validate');
    }
};
function validar_clave(contrasenna) {
    if (contrasenna.length >= 8) {
        var mayuscula = false;
        var minuscula = false;
        var numero = false;
        var caracter_raro = false;

        for (var i = 0; i < contrasenna.length; i++) {
            if (contrasenna.charCodeAt(i) >= 65 && contrasenna.charCodeAt(i) <= 90) {
                mayuscula = true;
            }
            else if (contrasenna.charCodeAt(i) >= 97 && contrasenna.charCodeAt(i) <= 122) {
                minuscula = true;
            }
            else if (contrasenna.charCodeAt(i) >= 48 && contrasenna.charCodeAt(i) <= 57) {
                numero = true;
            }
            else {
                caracter_raro = true;
            }
        }
        if (mayuscula == true && minuscula == true && caracter_raro == true && numero == true) {
            return true;
        }
    }
    return false;
};
function visualizarClave(pInput, btn) {
    document.getElementById(pInput).setAttribute("type", "text");
    btn.setAttribute("class", "fas fa-eye-slash");
    btn.setAttribute("onclick", "ocultarClave('" + pInput + "',this)");
};
function ocultarClave(pInput, btn) {
    document.getElementById(pInput).setAttribute("type", "password");
    btn.setAttribute("class", "fas fa-eye");
    btn.setAttribute("onclick", "visualizarClave('" + pInput + "',this)");
};