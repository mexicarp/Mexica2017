var timeOutCerrarMensajeGlobal = '';

function mostrarMensajeGlobal(texto, color) {
    $('#mensajeGlobal').css(
    {
        'display': 'inline-block',
        'opacity': '1'
    });

    $('#mensajeGlobal').css({'background-color' : color});

    $('#mensajeGlobal > #mensajeGlobalContenido').html(texto);
}

function cerrarMensajeGlobal() {
    $('#mensajeGlobal').css(
    {
        'opacity': '0',
        'transition': 'opacity 0.7s'
    });

    window.setTimeout(function ()
    {
        $('#mensajeGlobal').css(
    {
        'display': 'none'
    });
    }, 700);
}