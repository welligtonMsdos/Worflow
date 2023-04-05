function buscarEndereco() {

    var cep = $("#cep").val();

    $.ajax
        ({
            dataType: "json",
            type: "POST",
            url: '/Endereco/BuscarEndereco',
            data: { cep: cep },
            success: function (data) {

                $("#logadouro").val(data.rua);
                $("#bairro").val(data.bairro);
                $("#cidade").val(data.cidade);
                $("#uf").val(data.uf);             

            },
            error: function (erro) {
            }
        });

}