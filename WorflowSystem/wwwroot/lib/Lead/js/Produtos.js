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