$(document).ready(listarPrivacidad);
function textAreaAdjust(element) {
    element.style.height = "1px";
    element.style.height = (25 + element.scrollHeight) + "px";
}
function registrarPublicacion() {
    var descripcion = document.getElementById('ipPublicacionTexto').value;
    var privacidad = $("#cboPrivacidad").val();
    if (descripcion == '' || descripcion == null || descripcion.length == 0) {
        alert('Por favor ingrese la descripción de la publicación');
        return false;
    }
    $.ajax({
        type: 'GET',
        url: '/ShareIt/RegistrarPublicacion',
        data: {
            usuarioId: 9,
            descripcion: descripcion,
            privacidad: privacidad
        },
        success: function (data) {
            $.each(data, function (i, val) {
                if (val.Codigo == "1") {

                } else {
                    alert("Hubo un error al registrar la punlicación: " + val.Mensaje);
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

function listarPrivacidad() {
    $.ajax({
        type: 'GET',
        url: '/ShareIt/ListarPrivacidad',
        data: {
        },
        success: function (data) {
            var opciones = '';
            $.each(data, function (i, val) {
                $("#cboPrivacidad").append('<option value="' + val.privacidadId + '" '+ val.selected +' >' + val.descripcion + '</option>');
            });
        },
        error: function () {
        },
        complete: function () {
        }
    })
};

function ListarTopPublicaciones() {
    $.ajax({
        type: 'GET',
        url: '/ShareIt/ListarTopPublicaciones',
        data: {
        },
        success: function (data) {
            var public = '';
            $.each(data, function (i, val) {
                public += '<div class="item">'
                public +=   '<div class="card img-thumbnail" style="width: 18rem;">';
                public +=       '<div class="card-body">';
                public +=           '<div style="display: flex;">';
                public +=               '<img class="img-circle img-bordered-sm" style="height: 40px; width: 40px;" src="~/Resources/img/Avatars/'+ val.avatar +'" alt="User Image">';
                public +=                   '<p style="font-weight: bold; font-size:15px; padding-top: 7px; padding-left: 10px;">'+ val.nombres +'</p>';
                public +=                   '</div>';
                public +=                   '<p>'+ val.descripcion +'</p>';
                public +=               '<button type="button" class="btn btn-link">Ver más...</button>';
                public +=           '</div>';
                public +=       '</div>';
                public +=   '</div>';
               
            });
            $("#divCarruselTopPublicaciones").append(public);
        },
        error: function () {
        },
        complete: function () {
        }
    })
};
function mostrarAgregarArchivos() {
    document.getElementById('divContentMensajeSubirArchivo').style.display = 'none';
    $("#divContentAgregarArchivos").fadeIn();
};
function ocultarAgregarArchivos() {
    document.getElementById('divContentAgregarArchivos').style.display = 'none';
    $("#divContentMensajeSubirArchivo").fadeIn();
};
function actualizarLike(tipoLike, publicacionId, usuarioId, etiquetaA) {
    var cantLikesPublicacion = $("#aCantLikes" + publicacionId).text();
    $.ajax({
        type: 'GET',
        url: '/ShareIt/ActualizarLike',
        data: {
            tipoLike: tipoLike,
            publicacionId: publicacionId,
            usuarioId: usuarioId
        },
        success: function (data) {
            var public = '';
            $.each(data, function (i, val) {
                if (val.Codigo == '1') {

                    etiquetaA.style.color = 'blue';
                    $("#aCantLikes" + publicacionId).text((parseInt(cantLikesPublicacion) + 1));
                    etiquetaA.setAttribute('onclick', "actualizarLike('0'," + publicacionId + "," + usuarioId + ", this)");

                }
                else if (val.Codigo == '2') {

                    etiquetaA.style.color = '';
                    $("#aCantLikes" + publicacionId).text((cantLikesPublicacion - 1));
                    etiquetaA.setAttribute('onclick', "actualizarLike('1'," + publicacionId + "," + usuarioId + ", this)");

                }
                else if (val.Codigo == '0') {

                }
                mostrarResultado('actualizar like', val.Codigo, val.Mensaje);
            });
            $("#divCarruselTopPublicaciones").append(public);
        },
        error: function () {
        },
        complete: function () {
        }
    })
};
function mostrarResultado(nombreOperacion, codigo, mensaje) {
    console.log('------------------------Resultado de ' + nombreOperacion + '------------------------\nCodigo: ' + codigo + '\nMensaje: ' + mensaje);
};