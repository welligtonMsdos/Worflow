$("#btnEnviarAnexo").click(function (e) {
  
    var $el = $('#FormUpload');    

    var $el1 = $el.wrap('<form>').closest('form').get(0);

    console.log($el.wrap('<form>'));

    $.ajax
        ({           
            type: "POST",
            url: '/Lead/EnviarArquivo',
            data: new FormData($el1),
            async: true,
            success: function (retorno) {

            },
            processData: false,
            contentType: false,
            error: function (erro) {
            }
        });

})

$("#novoAnexo").click(function () {
    var $el = $('#FormUpload');

    $el.wrap('<form>').closest('form').get(0).reset();

    $el.unwrap();
});

