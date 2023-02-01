function changeSegmento(value) {
    var id = $('#comboSegmento').val();

    $.ajax
        ({
            url: '/Lead/_CarregaProdutos',
            type: 'GET',
            data: {id: id},
            success: function (data) {
                $("#listaProdutos").html(data);
            },
            error: function (erro) {
                alert(erro);
            }
        });

}

function verificarProdutos() {
    var retorno = false;

    $('input[name=produtos]').each(function () {
        if ($(this).prop("checked")) {
            retorno = true;
        }
    });

    return retorno;
}