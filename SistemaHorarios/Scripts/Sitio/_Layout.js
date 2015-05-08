
var checkado = function () {
    $.notify({
        // options
        message: 'Entrada Registrada'
    }, {
        // settings
        type: 'success'
    });
}
var cambiosGuardados = function () {
    $("#modalCategorias").modal("hide");
    $.notify({
        // options
        message: 'Cambios Guardados (Es necesario <a href="/Configuracion/CategoriasEmpleados">actualizar la pagina</a>)'
    }, {
        // settings
        type: 'success'
    });
}
var permisoCerrado = function () {
    $("#btnCerrar").addClass("hidden");
    $("#mensaje").removeClass("text-danger");
    $("#mensaje").addClass("text-success");
    $("#mensaje").text("Permiso cerrado con exito");
}
var errorCerrar = function () {
    $("#mensaje").addClass("text-danger");
    $("#mensaje").text("El permiso no pudo cerrarse, contacte con el administrador");
}
var noEsDiaLaboral = function () {
    $.notify({
        // options
        message: 'Hoy no es un dia laboral'
    }, {
        // settings
        type: 'warning'
    });
}
var existe = function () {
    $.notify({
        // options
        message: 'Usted ya registro su entrada'
    }, {
        // settings
        type: 'danger'
    });
}
var noRegistroEntrada = function () {
    $.notify({
        // options
        message: 'No hay entrada registrada para este dia'
    }, {
        // settings
        type: 'danger'
    });
}

var checkadoSalida = function () {
    $.notify({
        // options
        message: 'Salida Registrada'
    }, {
        // settings
        type: 'success'
    });
}
var existeSalida = function () {
    $.notify({
        // options
        message: 'Usted ya registro su Salida'
    }, {
        // settings
        type: 'danger'
    });
}
var tarde = function () {
    $.notify({
        // options
        message: 'Su horario laboral para este dia ha terminado'
    }, {
        // settings
        type: 'danger'
    });
}
var temprano = function () {
    $.notify({
        // options
        message: 'Su horario laboral aun no inicia'
    }, {
        // settings
        type: 'danger'
    });
}
var btnLoad = function (element) {
    $(element).button("loading")

};
var btnUnload = function (element) {
    $(element).button("reset")
}
var festivo = function () {
    $.notify({
        // options
        message: 'Hoy es un dia no laboral, por favor revise su calendario para mas información'
    }, {
        // settings
        type: 'danger'
    });
}

