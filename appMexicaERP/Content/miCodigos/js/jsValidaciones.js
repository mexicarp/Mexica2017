function valTextoNumeroConEspacios(valor, label, mensajeError, automatico) {
    var patron = /^[a-zA-Z0-9ñÑàèìòùÀÈÌÒÙáéíóúÁÉÍÓÚ\s*]*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe contener sólo texo y números<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}


function valEntero(valor, label, mensajeError, automatico) {
    var patron = /^\d*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe ser un número entero<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valDecimal(valor, label, mensajeError, automatico) {
    var patron = /^(\d+([\.]{1}\d+)?)*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe ser un número<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valDosDecimales(valor, label, mensajeError, automatico) {
    var patron = /^(\d+([\.]{1}\d{1,2})?)*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe ser un número con 2 decimales<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valEmail(valor, label, mensajeError, automatico) {
    var patron = /^([a-zA-Z0-9\.\-_]+\@[a-zA-Z0-9\-_]+\.[a-zA-Z]+(\.[a-zA-Z]+)?)*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe cumplir el patron: ejemplo@dominio.com<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valUrl(valor, label, mensajeError, automatico) {
    var patron = /^((ht|f)tps?:\/\/\w+([\.\-\w]+)?\.([a-z]{2,4}|travel)(:\d{2,5})?(\/.*)?)?$/i;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" no cumple el formato adecuado<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valCampoObligatorio(valor, label, mensajeError, automatico) {
    var validacion = ($.trim(valor) !== "");

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" es requerido<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valFecha(valor, label, mensajeError, automatico) {
    var patron = /^((((1|2){1}\d{3}\/(0|1){1}\d{1}\/[0-3]{1}\d{1})|((1|2){1}\d{3}\-(0|1){1}\d{1}\-[0-3]{1}\d{1})){1})*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" es incorrecto<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valFechaHora(valor, label, mensajeError, automatico) {
    var patron = /^((((1|2){1}\d{3}\/(0|1){1}\d{1}\/[0-3]{1}\d{1}\s[0-2]{1}\d{1}:[0-5]{1}\d{1}:[0-5]\d{1})|((1|2){1}\d{3}\-(0|1){1}\d{1}\-[0-3]{1}\d{1}\s[0-2]{1}\d{1}:[0-5]{1}\d{1}:[0-5]\d{1})){1})*$/;
    var validacion = patron.test(valor);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" es incorrecto<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valLongitudRango(valor, label, longitudMinima, longitudMaxima, mensajeError, automatico) {
    var validacion = (valor.length >= longitudMinima && valor.length <= longitudMaxima);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe tener entre ' + longitudMinima + '-' + longitudMaxima + ' caracteres<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}

function valLongitudExacto(valor, label, longitud, mensajeError, automatico) {
    var validacion = (valor.length == longitud);

    if (automatico && !validacion) {
        return 'El campo \"' + label + '\" debe tener exactamente ' + longitud + ' caracteres<br>';
    }

    if (!automatico && !validacion) {
        return mensajeError + '<br>';
    }

    return '';
}