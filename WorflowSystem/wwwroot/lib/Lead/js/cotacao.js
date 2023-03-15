$(document).ready(function () {
    var leadId = $('#LeadId').val();

    buscarCotacao(leadId);   
})

function abrirDetalheCotacao(cotacaoId) {    

    $.ajax({
        type: "GET",
        url: '/Lead/BuscarDetalheCotacao',
        data: {
            cotacaoId: cotacaoId
        },
        cache: false,
        async: false,
        success: function (data) {          

            $('#partialDetalhesCotacoes').html(data);

            $('#DetalhesCotacoes').modal('show');
        }
    })
}

function abrirEditarCotacao(cotacaoId) {
  
    $.ajax({
        type: "GET",
        url: '/Lead/BuscarEditarCotacao',
        data: {
            cotacaoId: cotacaoId
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialEditarCotacao').html(data);

            var opcao = $('#StatusFinalizada').val();         

            if (opcao == "True") {
                document.getElementById('Opcoes').value = 1;               
            } else {
                document.getElementById('Opcoes').value = 2;              
            }

            $('#EditarCotacao').modal('show');         
        }
    })
}

function abrirExcluirCotacao(cotacaoId) {
    $.ajax({
        type: "GET",
        url: '/Lead/BuscarExcluirCotacao',
        data: {
            cotacaoId: cotacaoId
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialExcluirCotacao').html(data);

            $('#ExcluirCotacao').modal('show');
        }
    })
}

function buscarCotacao(leadId) {
    $.ajax({
        type: "GET",
        url: '/Lead/BuscarCotacao',
        data: {
            leadId: leadId
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialCotacoes').html(data);

        }
    })
}

function inserirCotacao(leadId) {

    var DataEmissao = $('#DataEmissao').val();
    var DataVencimento = $('#DataVencimento').val();
    var Valor = $('#Valor').val();
    var SeguradoraId = $('#SeguradoraId').val();

    $.ajax({
        type: "GET",
        url: '/Lead/InserirCotacao',
        data: {
            dataEmissao: DataEmissao,
            dataVencimento: DataVencimento,
            valor: Valor,
            leadId: leadId,
            seguradoraId: SeguradoraId
        },
        cache: false,
        async: false,
        success: function (data) {

            toastr.success('Cotação salva com sucesso!');

            $('#partialCotacoes').html(data);
        }
    })
}

function atualizarCotacao(leadId) {  
   
    var DataEmissao = $('#DataEmissao').val();
    var DataVencimento = $('#DataVencimento').val();
    var Valor = $('#Valor').val().replace('.','').replace(',','.');
    var SeguradoraId = $('#SeguradoraId').val();
    var CotacaoId = $('#CotacaoId').val();    
    var StatusCotacao = $('#Opcoes').val();

    $.ajax({
        type: "GET",
        url: '/Lead/AtualizarCotacao',
        data: {
            dataEmissao: DataEmissao,
            dataVencimento: DataVencimento,
            valor: Valor,
            leadId: leadId,
            seguradoraId: SeguradoraId,
            cotacaoId: CotacaoId,
            statusCotacao: StatusCotacao
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialCotacoes').html(data);

            toastr.success('Cotação salva com sucesso!');
        },
        error: function (data) {
            toastr.error('Erro.', 'Cotação');       
        }
    })
}

function excluirCotacao(cotacaoId) {

    var leadId = $('#LeadId').val();

    $.ajax({
        type: "GET",
        url: '/Lead/ExcluirCotacao',
        data: {            
            cotacaoId: cotacaoId,
            leadId: leadId
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialCotacoes').html(data);
            toastr.success('Cotação excluída com sucesso!');
        },
        error: function (data) {
            toastr.error('Erro.', 'Cotação');   
        }
    })
}

