var oTableTours;
var handleDataTableDefaultTours;
var Tbl_Tours;

var oTableAgencias;
var handleDataTableDefaultAgencias;
var Tbl_Agencias;

var oTablePrecios;
var handleDataTableDefaultPrecios;
var Tbl_Precios;



function dialogoAjax(idDialogo, anchoDialogo, modal, title, position, data, url, method, preFunction, postFunction, cache, async) {
    $('#' + idDialogo).html('');

    if ((typeof preFunction) == 'function') {
        preFunction();
    }

    $('#divModalCargaAjax').show();

    $.ajax(
    {
        url: url,
        type: method,
        data: data,
        cache: cache,
        async: async
    }).done(function (pagina) {
        $('#divModalCargaAjax').hide();
        $('#' + idDialogo).html(pagina);

        if ((typeof postFunction) == 'function') {
            postFunction();
        }
    }).fail(function () {
        mostrarMensajeGlobal('Ocurrió un error inesperado. Por favor reporte esto a la plataforma o al correo "ovallesoft@gmail.com". Pedimos disculpas y damos gracias por su comprensión.', '#B20A0A');
    });

    $('#' + idDialogo).dialog(
    {
        resizable: false,
        width: anchoDialogo,
        modal: modal,
        title: title,
        position: { at: position }
    });
}

function paginaAjax(idSeccion, data, url, method, preFunction, postFunction, cache, async) {
    if ((typeof preFunction) == 'function') {
        preFunction();
    }

    //$('#divModalCargaAjax').show();

    $.ajax(
    {
        url: url,
        type: method,
        data: data,
        cache: cache,
        async: async
    }).done(function (pagina) {
        //$('#divModalCargaAjax').hide();
        $('#' + idSeccion).html(pagina);

        if ((typeof postFunction) == 'function') {
            postFunction();
        }
    }).fail(function () {
        //$('#divModalCargaAjax').hide();
        $('#' + idSeccion).html('<div class="divAlertaRojo">Ocurrió un error inesperado. Por favor reporte esto a la plataforma o al correo "ovallesoft@gmail.com". Pedimos disculpas y damos gracias por su comprensión.</div>');
    });
}

function paginaAjaxScrollAbajo(idSeccion, data, url, method, preFunction, postFunction, cache, async, tagLoadingAdd) {
    if ((typeof preFunction) == 'function') {
        preFunction();
    }

    $('#' + idSeccion).append('<' + tagLoadingAdd + ' id="tagLoadingAdd" style="background-color: #f5f5f5;color: #999999;padding: 7px;text-align: center;">Cargando...</' + tagLoadingAdd + '>');

    $.ajax(
    {
        url: url,
        type: method,
        data: data,
        cache: cache,
        async: async
    }).done(function (pagina) {
        $('#tagLoadingAdd').remove();
        $('#' + idSeccion).append(pagina);

        if ((typeof postFunction) == 'function') {
            postFunction();
        }
    }).fail(function () {
        $('#tagLoadingAdd').remove();
        $('#' + idSeccion).html('<div class="divAlertaRojo">Ocurrió un error inesperado. Por favor reporte esto a la plataforma o al correo "ovallesoft@gmail.com". Pedimos disculpas y damos gracias por su comprensión.</div>');
    });
}

function SelectAgencia(idSeccion, data, url, method, preFunction, postFunction, cache, async) {
    //if ((typeof preFunction) == 'function') {
    //    preFunction();
    //}
    if (data != -1) {
        $.ajax(
        {
            url: url,
            type: method,
            data: data,
            cache: cache,
            async: async
        }).done(function (pagina) {
            //CalcFechaPaq();
            $('#' + idSeccion).html(pagina);
            //if ((typeof postFunction) == 'function') {
            //    postFunction();
            //}
        }).fail(function () {
            $('#' + idSeccion).html('<div class="divAlertaRojo">Ocurrió un error inesperado. Por favor reporte esto a la plataforma o al correo "ovallesoft@gmail.com". Pedimos disculpas y damos gracias por su comprensión.</div>');
        });
    }
    else {
        $('#' + idSeccion).html('<div class="divAlertaRojo">Seleccione un paquete...!!!.</div>');
    }
}

handleDataTableDefaultTours = function () {
    "use strict";
    oTableTours = $('#data-table_tour').dataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "aoColumns": [
         null,
         null,
         null,
        ],
        iDisplayLength: 5,
        deferRender: true,
        // scrollY: 325,
        //scrollCollapse: true,
        //  scroller: true,
        select: true,
        responsive: true,
        bDestroy: true
    });

    $('#data-table tbody').on("click", 'tr', function (e) {

    });
}
Tbl_Tours = function () {
    "use strict";
    return {
        init: function () {
            handleDataTableDefaultTours();
        }
    };
}();

handleDataTableDefaultAgencias = function () {
    "use strict";
    oTableAgencias = $('#data-table_agencia').dataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "aoColumns": [
         null,
         null,
         null,
        ],
        iDisplayLength: 5,
        deferRender: true,
        // scrollY: 325,
        //scrollCollapse: true,
        //  scroller: true,
        select: true,
        responsive: true,
        bDestroy: true
    });

    $('#data-table tbody').on("click", 'tr', function (e) {

    });
}
Tbl_Agencias = function () {
    "use strict";
    return {
        init: function () {
            handleDataTableDefaultAgencias();
        }
    };
}();

handleDataTableDefaultPrecios = function () {
    "use strict";
    oTablePrecios = $('#data-table_agenciatour').dataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "aoColumns": [
         null,
         null,
         null,
         null,
         null,
        ],
        iDisplayLength: 5,
        deferRender: true,
        // scrollY: 325,
        //scrollCollapse: true,
        //  scroller: true,
        select: true,
        responsive: true,
        bDestroy: true
    });

    $('#data-table tbody').on("click", 'tr', function (e) {

    });
}
Tbl_Precios = function () {
    "use strict";
    return {
        init: function () {
            handleDataTableDefaultPrecios();
        }
    };
}();