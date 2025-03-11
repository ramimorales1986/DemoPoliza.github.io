function DetalleCliente(param) {
   
    const formData = new FormData();
    formData.append("poliza", param);
    $.ajax({
        url: "/Cuentas/RenovarPoliza",
        type: "POST",
        data: formData,
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            window.location.href = url;
        },
        error: function (data) {
            window.location.href = '/Principal/ConsolidadoCuentas';
        }
    });
}