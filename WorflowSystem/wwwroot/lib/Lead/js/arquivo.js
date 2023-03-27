﻿$(document).ready(function () {
    var leadId = $('#LeadId').val();

    buscarAnexo(leadId);
})

$("#btnEnviarAnexo").click(function (e) {
  
    var $el = $('#FormUpload');    

    var $el1 = $el.wrap('<form>').closest('form').get(0);   

    $.ajax
        ({           
            type: "POST",
            url: '/Lead/EnviarArquivo',
            data: new FormData($el1), 
            async: true,
            success: function (data) {

                toastr.success('Arquivos anexados com sucesso!');

                $('#partialAnexo').html(data);
            },
            processData: false,
            contentType: false,
            error: function (erro) {
            }
        });

})

function buscarAnexo(leadId) {
    $.ajax({
        type: "GET",
        url: '/Lead/BuscarAnexo',
        data: {
            leadId: leadId
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialAnexo').html(data);

        }
    })
}

$("#novoAnexo").click(function () {
    var $el = $('#FormUpload');

    $el.wrap('<form>').closest('form').get(0).reset();

    $el.unwrap();
});

