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