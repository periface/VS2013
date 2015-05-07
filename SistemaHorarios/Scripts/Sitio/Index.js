/// <reference path="../FullCalendar/fullcalendar.min.js" />
$(function () {
    var $body = $("body");
    //Declaración de var 
    var $miHistorial = $("#miHistLink");
    var $contenedorDetalle = $("#contenedorDetalle");
    var $modalDetalle = $("#modalDetalle");
    var $contenedor = $("#contenedor");
    var $linkHistorial = $("#histLink");
    var $linkUsuarios = $("#ursLink");
    var $linkReportes = $("#repLink");
    var $linkPermisos = $(".permisos");
    var $linkDatos = $("#capDatos");
    var $calendario = $("#calendarioAct");
    var url = {
        cargaFechas: "/Configuracion/Fechas",
        cargaDetalleFecha: "/PanelControl/DetalleFecha/",
    }
    var calendarioConfig = function () {
        return {
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            loading: function (cargando) {

            },
            
            lang: "es",
            
            timeFormat: "H(:mm)",
            displayEventEnd: true,
            events: url.cargaFechas,
            eventClick: function (calEvent, jsEvent, view) {
                cargaModalDetalle(calEvent.id);
            }
        }
    }
    //Declaración de fun
    var cargaModalDetalle = function (idEvento) {
        $contenedorDetalle.load(url.cargaDetalleFecha + idEvento, function () {
            $modalDetalle.modal("show");
        });
    }
    var cargaMiHistorial = function () {
        $contenedor.load("/PanelControl/MiHistorial");
    }
    var cargaCalendarioAct = function () {
        $calendario.fullCalendar(calendarioConfig());
    }
    var cargaFormDatos = function () {
        $contenedor.load("/PanelControl/CapturarDatos");
    }
    var cargaFormHistorial = function () {
        $contenedor.load("/PanelControl/Historial");
    }
    var cargaUsuarios = function () {
        $contenedor.load("/PanelControl/Usuarios");
    }
    var cargaFormReportes = function () {
        $contenedor.load("/PanelControl/Reportes");
    }
    var cargaPermisos = function (idUsuario, fecha, _self) {
        var $contenedor = $("#modalContenedor");
        var $modal = $("#modalPermisos");
        $contenedor.load("/PanelControl/Permisos", { id: idUsuario, fecha: fecha }, function () {
            unLoadingModal(_self);
            $modal.modal("show");
        });
    }
    var loading = function () {
        $contenedor.html("<p>Cargando...</p>");
    }
    var loadingModal = function (element) {
        $(element).button("loading")
    }
    var unLoadingModal = function (element) {

        $(element).button("reset")
    }
    //Implementación
    $linkHistorial.click(function () {
        loading();
        cargaFormHistorial();
    });
    $linkReportes.click(function () {
        loading();
        cargaFormReportes();
    });
    $linkUsuarios.click(function () {
        loading();
        cargaUsuarios();
    });
    $linkDatos.click(function () {
        loading();
        cargaFormDatos();
    });
    $miHistorial.click(function () {
        loading();
        cargaMiHistorial();
    });
    $body.on("click", ".permisos", function () {
        var _self = $(this);
        var id = $(this).data("id");
        var fecha = $(this).data("fecha");
        loadingModal(_self);
        cargaPermisos(id, fecha, _self);
    });
    cargaCalendarioAct();
})