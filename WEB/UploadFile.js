﻿function uploadFileDocuments(codigoMontura) {
    var formData = new FormData();
    var varLstAnexo = ObtenerAnexos();
    debugger;
    $.each(varLstAnexo, function (key, value) {
        var file = value;
        formData.append(file.name, file);
    });
    console.log("Codigo ingresado al JS es :" + codigoMontura);
    if (varLstAnexo != null) {
        var urlConsultaRest = "ghUploadFile.ashx?Id=" + codigoMontura;
        $.ajax({
            url: urlConsultaRest,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: formData,
            success: function (result) {
                //$('#preloader').fadeOut('slow');
                console.log("Documento cargado");

            },
            error: function (err) {
                console.log("error upload file");
            }
        });
    }
    
}


function ObtenerAnexos() {
    var varAnexos = new Array();
    
    var $targetval = $("#FileUpload1");
        var varDocumentoAnexo = $targetval.prop("files");
        if (!varDocumentoAnexo == false) {
            varAnexos.push(varDocumentoAnexo[0]);
        }
    return varAnexos;
}