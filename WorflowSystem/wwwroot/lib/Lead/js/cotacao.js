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
            $('#partialCotacoes').html(data);
        }
    })
}

function atualizarCotacao(leadId) {
    var DataEmissao = $('#DataEmissao').val();
    var DataVencimento = $('#DataVencimento').val();
    var Valor = $('#Valor').val();
    var SeguradoraId = $('#SeguradoraId').val();
    var CotacaoId = $('#CotacaoId').val();

    $.ajax({
        type: "GET",
        url: '/Lead/AtualizarCotacao',
        data: {
            dataEmissao: DataEmissao,
            dataVencimento: DataVencimento,
            valor: Valor,
            leadId: leadId,
            seguradoraId: SeguradoraId,
            cotacaoId: CotacaoId
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialCotacoes').html(data);
        },
        error: function (data) {
            alert('erro');           
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
        },
        error: function (data) {
            alert('erro');
        }
    })
}

