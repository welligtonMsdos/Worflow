function buscarCliente() {

    var cnpj = $("#cnpj").val();

    $.ajax
        ({
            dataType: "json",
            type: "POST",
            url: '/Lead/BuscarCliente',           
            data: { cnpj: cnpj },
            success: function (data) {               

                $("#agencia").val(data[0].agencia);
                $("#conta").val(data[0].conta);
                $("#razaoSocial").val(data[0].razaoSocial);
                $("#fantasia").val(data[0].fantasia);
                $("#email").val(data[0].email);
                $("#telefone").val(data[0].telefone);              
                $("#LeadClienteId").val(data[0].id);
                $("#clienteId").val(data[0].id);
                $("#leadEnderecoId").val(data[0].enderecoId);
                $("#cep").val(data[0].endereco.cep);
                $("#logadouro").val(data[0].endereco.logadouro);
                $("#numero").val(data[0].endereco.numero);
                $("#bairro").val(data[0].endereco.bairro);
                $("#cidade").val(data[0].endereco.cidade);
                $("#uf").val(data[0].endereco.uf);

            },
            error: function (erro) {            
            }
        });

}